using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text;

namespace Upload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitSerialPorts();
            rbUpload.Checked = Properties.Settings.Default.UploadAll;
            rbDownload.Checked = !Properties.Settings.Default.UploadAll;
            rb_CheckedChanged(this, null);
            gbDownload.Location = gbUpload.Location;
            m_Timeout = Properties.Settings.Default.AckTimeout;
            tBoxTimeout.Text = Properties.Settings.Default.AckTimeout.ToString();
            if (Properties.Settings.Default.MostRecentFile != "No File")
            {
                lblFileSelected.Text = Properties.Settings.Default.MostRecentFile;
                // read the csv file into strings
                m_CSVLines = File.ReadAllLines(lblFileSelected.Text);
                gbUpload.Enabled = true;
                gbDownload.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.UploadAll = rbUpload.Checked;
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
                gbUpload.Enabled = true;
                gbDownload.Enabled = true;
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

        bool OpenSerialPort()
        {
            string portName = comboBoxSerialPort.SelectedItem.ToString();
            sp = new SerialPort(portName, 57600, Parity.None, 8, StopBits.One);
            try
            {
                sp.Open();
            }
            catch
            {
                GUIUploadThreadOver("Can't open serial port");
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
            OpenSerialPort();
            tbSerialLog.Text = "";
            btnUploadStart.Enabled = false;
            btnClearLog.Enabled = false;
            btnAbortUpload.Enabled = true;
            lblStatus.Text = "Upload in progress...";

            gbUpDownSelect.Enabled = false;
            m_Timeout = Convert.ToUInt64(tBoxTimeout.Text);


            thread = new Thread(new ThreadStart(WorkerUploadAll));
            thread.IsBackground = true;
            thread.Start();
        }

        private void GUIUploadThreadOver(string status)
        {
            btnUploadStart.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnUploadStart.Enabled = true;
            });
            btnAbortUpload.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnAbortUpload.Enabled = false;
            });
            btnClearLog.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                btnClearLog.Enabled = true;
            });
            lblStatus.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                lblStatus.Text = status;
            });
            gbUpDownSelect.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                gbUpDownSelect.Enabled = true;
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
            gbUpDownSelect.Enabled = true;
        }

        private bool SendString (string s, string expected, String error)
        {
            UInt64 timer = 0;
            StringBuilder sb = new StringBuilder();
            sp.Write (s);
            Console.WriteLine("PC: " + s);
            tbSerialLog.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                tbSerialLog.AppendText("PC: " + s + System.Environment.NewLine);
            });
            const int sleepTime = 100;

            while (timer < m_Timeout)
            {
                Thread.Sleep(sleepTime);
                timer += sleepTime;
                string resp = sp.ReadExisting();
                sb.Append (resp);
                if (sb.ToString() == expected)
                {
                    Console.WriteLine("DEVICE: " +  sb.ToString());
                    tbSerialLog.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        tbSerialLog.AppendText("DEVICE: " + sb.ToString() + System.Environment.NewLine);
                    });
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
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            gbUpload.Visible = rbUpload.Checked;
            gbUploadOptions.Visible = rbUpload.Checked;
            gbDownload.Visible = !rbUpload.Checked;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            tbSerialLog.Text = "";
        }

        bool m_AbortDownload;
        private void btnDownloadStart_Click(object sender, EventArgs e)
        {
            OpenSerialPort();
            tbSerialLog.Text = "";
            gbUpDownSelect.Enabled = false;
            btnDownloadStart.Enabled = false;
            btnDownloadSave.Enabled = true;
            btnDownloadAbort.Enabled = true;

            lblStatus.Text = "Downloading started...";

            thread = new Thread(new ThreadStart(WorkerDownloadAll));
            // prevents exception if closing App w/o thread being killed
            thread.IsBackground = true;
            thread.Start();
        }

        private void btnDownloadSave_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            m_AbortDownload = true;
            if (res == DialogResult.OK) 
            {
                File.WriteAllText(saveFileDialog1.FileName, tbSerialLog.Text);

                btnDownloadStart.Enabled = true;
                btnDownloadSave.Enabled = false;
                btnDownloadAbort.Enabled = false;
                gbUpDownSelect.Enabled = true;

                lblStatus.Text = "Downloaded Data Saved";
            }

            sp.Close();
        }


        private void WorkerDownloadAll()
        {
           
            while (true)
            {
                // read the serial port
                string resp = sp.ReadExisting();
                resp = resp.Replace("\r", System.Environment.NewLine);
                tbSerialLog.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    tbSerialLog.AppendText(resp);
                });

                Thread.Sleep(10);
                if (m_AbortDownload)
                {
                    m_AbortDownload = false;
                    break;
                }

            }

            thread.Abort();
            thread = null;

        }

        private void btnDownloadAbort_Click(object sender, EventArgs e)
        {
            m_AbortDownload = true;
            btnDownloadStart.Enabled = true;
            btnDownloadSave.Enabled = false;
            btnDownloadAbort.Enabled = false;
            gbUpDownSelect.Enabled = true;
            lblStatus.Text = "Download Aborted!";
            sp.Close();
        }


    }
}
