using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;
using Upload.Properties;

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

        void OpenSerialPort()
        {
            string portName = comboBoxSerialPort.SelectedItem.ToString();
            sp = new SerialPort(portName, 57600, Parity.None, 8, StopBits.One);
            try
            {
                sp.Open();
            }
            catch
            {
                UploadThreadOver("Can't open serial port");
                return;
            }
            sp.ReadTimeout = 100;
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
        }

        SerialPort sp;
        Thread thread;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenSerialPort();
            btnUpload.Enabled = false;
            btnKillUpload.Enabled = true;
            lblStatus.Text = "Upload in progress...";

            gbUploadMethod.Enabled = false;
            m_Timeout = Convert.ToUInt64(tBoxTimeout.Text);

            thread = new Thread(new ThreadStart(Worker));
            thread.Start();
        }

        private void UploadThreadOver(string status)
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

        private void Worker()
        {
            SendBegin();

            UInt16 lineNumber = 0;
            foreach (string s in m_CSVLines)
            {
                if (!s.Contains(","))
                { 
                    continue; 
                }
                lineNumber++;
                SendLine(s, lineNumber);
            }

            SendEnd();

            UploadThreadOver("Success Upload");
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
            UploadThreadOver("Upload Killed");
            gbUploadMethod.Enabled = true;
        }

        private bool SendString (string s, string expected, String error)
        {
            UInt64 timer = 0;
            StringBuilder sb = new StringBuilder();
            sp.Write (s);
            Console.WriteLine("PC: " + s);
            const int sleepTime = 10;

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

            if (thread != null) 
            {
                UploadThreadOver(error);
                thread.Abort();
                thread = null;
            }

            return false;
        }

        /// <summary>
        /// This gets called no matter what check is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UploadAll = rbAll.Checked;
            Properties.Settings.Default.Save();
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
                    tBoxTimeout.Enabled = false;
                    lblStatus.Text = "Upload in progress...";
                    m_Timeout = Convert.ToUInt64(tBoxTimeout.Text);
                    OpenSerialPort();
                    if (!SendBegin())
                    {
                        lblStatus.Text = "Upload Failed";
                        SingleLineTerminated();
                    }
                    else
                    {
                        btnAbortSingleLine.Enabled = true;
                        m_SingleLineNumber = 0;
                        m_SingleLineState = eSingleLineState.SEND_FILE_LINES;
                    }
                    break;

                case eSingleLineState.SEND_FILE_LINES:
                    if (!SendLine(m_CSVLines[m_SingleLineNumber], m_SingleLineNumber))
                    {
                        lblStatus.Text = "Upload Failed";
                        SingleLineTerminated();
                    }
                    else
                    {
                        m_SingleLineNumber++;
                        if (m_SingleLineNumber >= m_CSVLines.Length)
                        {
                            m_SingleLineState = eSingleLineState.END;
                        }
                    }
                    break;

                case eSingleLineState.END:
                    if (SendEnd())
                    {
                        lblStatus.Text = "Upload Successful";
                    }
                    else
                    {
                        lblStatus.Text = "Upload Failed";
                    }

                    SingleLineTerminated();
                    break;
            }
        }

        void SingleLineTerminated()
        {
            gbUploadMethod.Enabled = true;
            btnAbortSingleLine.Enabled = false;
            tBoxTimeout.Enabled = true;
            m_SingleLineNumber = 0;
            m_SingleLineState = eSingleLineState.BEGIN;
            tBoxTimeout.Enabled = true;
            sp.Close();
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
            PushSingleLineFromClick();
        }

        private void btnAbortSingleLine_Click(object sender, EventArgs e)
        {
            SingleLineTerminated();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.AckTimeout = Convert.ToUInt64(tBoxTimeout.Text);
            Properties.Settings.Default.Save();
        }
    }
}
