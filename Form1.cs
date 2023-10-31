using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Upload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitSerialPorts();
        }

        string []csvLines;
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK) 
            {
                lblFileSelected.Text = openFileDialog1.FileName;

                // read the csv file into strings
                csvLines = File.ReadAllLines(lblFileSelected.Text);

                btnUpload.Enabled = true;
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

        SerialPort sp;
        Thread thread;
        private void btnUpload_Click(object sender, EventArgs e)
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
            btnUpload.Enabled = false;
            btnKillUpload.Enabled = true;
            lblStatus.Text = "Upload in progress...";

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

        }


        private void Worker()
        {
            SendString("BEGIN_CSV\r", "BEGIN\r", "Error with BEGIN_CSV");

            UInt16 lineNumber = 0;
            foreach (string s in csvLines)
            {
                if (!s.Contains(","))
                { 
                    continue; 
                }
                lineNumber++;
                SendString(s + "\r", "ACK\r", "Error with line number:" + lineNumber.ToString());
            }

            SendString("END_CSV\r", "END\r", "Error with END_CSV");

            sp.Close();
            UploadThreadOver("Success Upload");
            thread.Abort();
        }

        private void btnKillUpload_Click(object sender, EventArgs e)
        {
            thread.Abort();
            sp.Close();
            UploadThreadOver("Upload Killed");
        }

        private bool SendString (string s, string expected, String error)
        {
            int timer = 0;
            StringBuilder sb = new StringBuilder();
            sp.Write (s);
            Console.WriteLine("PC: " + s);
            const int sleepTime = 10;

            while (timer < 1000)
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
            UploadThreadOver(error);
            thread.Abort();

            return false;
        }
    }
}
