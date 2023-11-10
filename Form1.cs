using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;
using Upload.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Upload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitSerialPorts();
            rbAll.Checked = Properties.Settings.Default.UploadAll;
            rbSngleLine.Checked = !Properties.Settings.Default.UploadAll;
            gbSingleLine.Location = gbAll.Location;
            m_Timeout = Properties.Settings.Default.AckTimeout;
            tBoxTimeout.Text = Properties.Settings.Default.AckTimeout.ToString();
            if (Properties.Settings.Default.MostRecentFile != "")
            {
                lblFileSelected.Text = Properties.Settings.Default.MostRecentFile;
                // read the csv file into strings
                m_CSVLines = File.ReadAllLines(lblFileSelected.Text);
                gbAll.Enabled = true;
                gbSingleLine.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.UploadAll = rbAll.Checked;
            Properties.Settings.Default.AckTimeout = Convert.ToUInt64(tBoxTimeout.Text);
            Properties.Settings.Default.MostRecentFile = lblFileSelected.Text;
            Properties.Settings.Default.Save();
        }

        string []m_CSVLines;
        UInt64 m_Timeout;
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK) 
            {
                lblFileSelected.Text = openFileDialog1.FileName;

                // read the csv file into strings
                m_CSVLines = File.ReadAllLines(lblFileSelected.Text);
                gbAll.Enabled = true;
                gbSingleLine.Enabled = true;
            }
        }

        private void InitSerialPorts()
        {
            string []portNames = SerialPort.GetPortNames();
            foreach (string s in portNames)
            {
                comboBoxSerialPort.Items.Add(s);
            }

            if (comboBoxSerialPort.Items.Count > 0) 
            {
                comboBoxSerialPort.SelectedIndex = 0;
            }
        }

        enum eUploadMethod
        {
            ALL,
            SINGLE_LINE,
        };

        bool OpenSerialPort(eUploadMethod method)
        {
            string portName = comboBoxSerialPort.SelectedItem.ToString();
            sp = new SerialPort(portName, 57600, Parity.None, 8, StopBits.One);
            try
            {
                sp.Open();
            }
            catch
            {
                if (method == eUploadMethod.ALL)
                {
                    GUIUploadThreadOver("Can't open serial port");
                }
                else
                {
                    SingleLineThreadTerminated("Can't open serial port");
                }
                return false;
            }
            sp.ReadTimeout = 100;
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            return true;
        }

        SerialPort sp;
        Thread thread;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenSerialPort(eUploadMethod.ALL);
            btnUpload.Enabled = false;
            btnKillUpload.Enabled = true;
            lblStatus.Text = "Upload in progress...";

            gbUploadMethod.Enabled = false;
            m_Timeout = Convert.ToUInt64(tBoxTimeout.Text);

            thread = new Thread(new ThreadStart(WorkerUploadAll));
            thread.Start();
        }

        private void GUIUploadThreadOver(string status)
        {
            btnUpload.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnUpload.Enabled = true;
            });
            btnKillUpload.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnKillUpload.Enabled = false;
            });
            lblStatus.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                lblStatus.Text = status;
            });
            gbUploadMethod.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                gbUploadMethod.Enabled = true;
            });
        }


        private bool SendLine(string line, UInt16 fileLineNumber)
        {
            string crLine = line + "\r";
            return SendString(crLine, "ACK\r", "Error with line number:" + fileLineNumber.ToString());
        }

        private bool SendBegin()
        {
            return SendString("BEGIN_CSV\r", "BEGIN\r", "Error with BEGIN_CSV");
        }

        private bool SendEnd() 
        {
            return SendString("END_CSV\r", "END\r", "Error with END_CSV");
        }

        private void WorkerUploadAll()
        {
            if (!SendBegin())
            {
                GUIUploadThreadOver("Upload Failed");
                thread.Abort();
                thread = null;
            }

            UInt16 lineNumber = 0;
            foreach (string s in m_CSVLines)
            {
                if (!s.Contains(","))
                { 
                    continue; 
                }
                lineNumber++;
                if (!SendLine(s, lineNumber))
                {
                    GUIUploadThreadOver("Upload Failed");
                    thread.Abort();
                    thread = null;
                }
            }

            if (!SendEnd()) 
            {
                GUIUploadThreadOver("Upload Failed");
                thread.Abort();
                thread = null;
            }

            GUIUploadThreadOver("Success Upload");
            thread.Abort();
            thread = null;
        }

        private void btnKillUpload_Click(object sender, EventArgs e)
        {
            thread.Abort();
            if (sp != null)
            {
                sp.Close();
            }
            GUIUploadThreadOver("Upload Killed");
            gbUploadMethod.Enabled = true;
        }

        private bool SendString (string s, string expected, String error)
        {
            UInt64 timer = 0;
            StringBuilder sb = new StringBuilder();
            sp.Write (s);
            Console.WriteLine("PC: " + s);
            const int sleepTime = 100;

            while (timer < m_Timeout)
            {
                Thread.Sleep(sleepTime);
                timer += sleepTime;
                string resp = sp.ReadExisting();
                sb.Append (resp);
                if (sb.ToString() == expected)
                {
                    Console.WriteLine("EMB: " +  sb.ToString());
                    return true;
                }
            }

            sp.Close();
            Console.WriteLine("Invalid target Response");

            return false;
        }

        /// <summary>
        /// This gets called no matter what check is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            gbAll.Visible = rbAll.Checked;
            gbSingleLine.Visible = !rbAll.Checked;
        }


        /////////////////////////////////////////
        /// Send Single Line at a time 
        ////////////////////////////////////////////

        UInt16 m_SingleLineNumber;

        enum eSingleLineState
        {
            BEGIN,
            SEND_FILE_LINES,
            END,
        };

        eSingleLineState m_SingleLineState;
        private void PushSingleLineFromClick()
        {
            switch (m_SingleLineState) 
            { 
                case eSingleLineState.BEGIN:
                    OpenSerialPort(eUploadMethod.SINGLE_LINE);
                    tBoxTimeout.Enabled = false;
                    lblStatus.Text = "Upload in progress...";
                    m_Timeout = Convert.ToUInt64(tBoxTimeout.Text);
                    thread = new Thread(new ThreadStart(WorkerSendSingle));
                    thread.Start();
                    break;

                case eSingleLineState.SEND_FILE_LINES:
                case eSingleLineState.END:
                    thread = new Thread(new ThreadStart(WorkerSendSingle));
                    thread.Start();
                    break;
            }
        }

        /// <summary>
        /// Called at the end of every single line send, whether or not successful
        /// </summary>
        /// <param name="status"></param>
        void SingleLineThreadTerminated(string status)
        {
            btnSendSingleLine.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnSendSingleLine.Enabled = true;
            });
            btnAbortSingleLine.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnAbortSingleLine.Enabled = false;
            });
            lblStatus.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                lblStatus.Text = status;
            });
            gbUploadMethod.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                gbUploadMethod.Enabled = true;
            });
            tBoxTimeout.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                tBoxTimeout.Enabled = true;
            });


            thread.Abort();
            thread = null;

        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendSingleLine_Click(object sender, EventArgs e)
        {
            gbUploadMethod.Enabled = false;
            btnAbortSingleLine.Enabled = true;
            btnSendSingleLine.Enabled = false;
            PushSingleLineFromClick();
        }

        private void btnAbortSingleLine_Click(object sender, EventArgs e)
        {
            SingleLineThreadTerminated("Upload aborted");
            m_SingleLineState = eSingleLineState.BEGIN;
            sp.Close();
        }


        /// <summary>
        /// Single line at a time thread
        /// </summary>
        private void WorkerSendSingle()
        {
            bool success = false; 
            switch (m_SingleLineState)
            {
                case eSingleLineState.BEGIN:
                    success = SendBegin();
                    if (success)
                    {
                        m_SingleLineNumber = 0;
                        m_SingleLineState = eSingleLineState.SEND_FILE_LINES;
                        SingleLineThreadTerminated("Begin Successful");
                    }
                    break;

                case eSingleLineState.SEND_FILE_LINES:
                    // Advance past blank lines
                    while (!m_CSVLines[m_SingleLineNumber].Contains(","))
                    {
                        m_SingleLineNumber++;
                    }
                    success = SendLine(m_CSVLines[m_SingleLineNumber], m_SingleLineNumber);
                    if (success)
                    {
                        m_SingleLineNumber++;
                        if (m_SingleLineNumber >= m_CSVLines.Length)
                        {
                            m_SingleLineState = eSingleLineState.END;
                        }
                        SingleLineThreadTerminated("Single Line Successful");
                    }
                    break;

                case eSingleLineState.END:
                    success = SendEnd();
                    if (success)
                    {
                        sp.Close();
                        SingleLineThreadTerminated("Upload Successful");
                    }
                    break;

            }

            if (!success)
            {
                m_SingleLineNumber = 0;
                m_SingleLineState = eSingleLineState.BEGIN;
                sp.Close();
                SingleLineThreadTerminated("Upload Failed");
            }

        }
    }
}
