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

            thread = new Thread(new ThreadStart(Worker));
            thread.Start();
        }

        const int sleepTime = 100;


        private void Worker()
        {

            sp.Write("BEGIN_CSV");
            Console.WriteLine("PC: BEGIN_CSV");
            Thread.Sleep(sleepTime);
            string ack = sp.ReadExisting();
            Console.WriteLine("EMB: " + ack);
            if (ack != "BEGIN") 
            {
                sp.Close();
                Console.WriteLine("Invalid target Response to BEGIN_CSV");
                thread.Abort(); 
            }

            foreach (string s in csvLines)
            {
                sp.Write(s);
                Console.WriteLine("PC: " + s);
                Thread.Sleep(sleepTime);
                ack = sp.ReadExisting();
                Console.WriteLine("EMB: " + ack);
                if (ack != "ACK")
                {
                    sp.Close();
                    Console.WriteLine("No ACK or INVALID ACK to line " + s);
                    thread.Abort();
                }
            }

            sp.Write("END_CSV");
            Console.WriteLine("PC: END_CSV");
            Thread.Sleep(sleepTime);
            ack = sp.ReadExisting();
            Console.WriteLine("EMB: " + ack);
            if (ack != "END")
            {
                sp.Close();
                Console.WriteLine("Invalid target Response to END_CSV");
                thread.Abort();
            }

            sp.Close();
            thread.Abort();
        }

        private void btnKillUpload_Click(object sender, EventArgs e)
        {
            sp.Close();
            thread.Abort();
        }
    }
}
