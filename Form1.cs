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
            sp.Open();
            sp.ReadTimeout = 100;
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            btnKillUpload.Enabled = true;

            thread = new Thread(new ThreadStart(Worker));
            thread.Start();
        }




        private void Worker()
        {
            SendString("BEGIN_CSV\r", "BEGIN\r");

            foreach (string s in csvLines)
            {
                if (!s.Contains(","))
                { 
                    continue; 
                }
                SendString(s + "\r", "ACK\r");
            }

            SendString("END_CSV\r", "END\r");

            sp.Close();
            thread.Abort();
        }

        private void btnKillUpload_Click(object sender, EventArgs e)
        {
            sp.Close();
            thread.Abort();
            btnKillUpload.Enabled = false;
        }

        private bool SendString (string s, string expected)
        {
            int timer = 0;
            StringBuilder sb = new StringBuilder();
            sp.Write (s);
            Console.WriteLine("PC: " + s);
            const int sleepTime = 10;

            while (timer < 100)
            {
                Thread.Sleep(sleepTime);
                timer += sleepTime;
                string resp = sp.ReadExisting();
                sb.Append (resp);
                if (sb.ToString() == expected)
                {
                    Console.WriteLine("EMB: " +  resp);
                    return true;
                }
            }

            sp.Close();
            Console.WriteLine("Invalid target Response");
            thread.Abort();

            return false;
        }
    }
}
