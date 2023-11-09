namespace Upload
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileSelected = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnKillUpload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbUploadMethod = new System.Windows.Forms.GroupBox();
            this.rbSngleLine = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.gbAll = new System.Windows.Forms.GroupBox();
            this.gbSingleLine = new System.Windows.Forms.GroupBox();
            this.btnSendSingleLine = new System.Windows.Forms.Button();
            this.btnAbortSingleLine = new System.Windows.Forms.Button();
            this.tBoxTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbUploadMethod.SuspendLayout();
            this.gbAll.SuspendLayout();
            this.gbSingleLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Selected:";
            // 
            // lblFileSelected
            // 
            this.lblFileSelected.Location = new System.Drawing.Point(90, 217);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(451, 45);
            this.lblFileSelected.TabIndex = 1;
            this.lblFileSelected.Text = "No File";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(16, 173);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(12, 49);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Serial Port";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(18, 24);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnKillUpload
            // 
            this.btnKillUpload.Enabled = false;
            this.btnKillUpload.Location = new System.Drawing.Point(21, 53);
            this.btnKillUpload.Name = "btnKillUpload";
            this.btnKillUpload.Size = new System.Drawing.Size(75, 23);
            this.btnKillUpload.TabIndex = 6;
            this.btnKillUpload.Text = "Kill Upload";
            this.btnKillUpload.UseVisualStyleBackColor = true;
            this.btnKillUpload.Click += new System.EventHandler(this.btnKillUpload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(57, 290);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 8;
            // 
            // gbUploadMethod
            // 
            this.gbUploadMethod.Controls.Add(this.rbSngleLine);
            this.gbUploadMethod.Controls.Add(this.rbAll);
            this.gbUploadMethod.Location = new System.Drawing.Point(173, 12);
            this.gbUploadMethod.Name = "gbUploadMethod";
            this.gbUploadMethod.Size = new System.Drawing.Size(110, 83);
            this.gbUploadMethod.TabIndex = 9;
            this.gbUploadMethod.TabStop = false;
            this.gbUploadMethod.Text = "Upload Method";
            // 
            // rbSngleLine
            // 
            this.rbSngleLine.AutoSize = true;
            this.rbSngleLine.Location = new System.Drawing.Point(21, 51);
            this.rbSngleLine.Name = "rbSngleLine";
            this.rbSngleLine.Size = new System.Drawing.Size(48, 17);
            this.rbSngleLine.TabIndex = 1;
            this.rbSngleLine.TabStop = true;
            this.rbSngleLine.Text = "Line ";
            this.rbSngleLine.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(21, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // gbAll
            // 
            this.gbAll.Controls.Add(this.btnUpload);
            this.gbAll.Controls.Add(this.btnKillUpload);
            this.gbAll.Enabled = false;
            this.gbAll.Location = new System.Drawing.Point(318, 12);
            this.gbAll.Name = "gbAll";
            this.gbAll.Size = new System.Drawing.Size(110, 87);
            this.gbAll.TabIndex = 10;
            this.gbAll.TabStop = false;
            this.gbAll.Text = "All";
            // 
            // gbSingleLine
            // 
            this.gbSingleLine.Controls.Add(this.btnSendSingleLine);
            this.gbSingleLine.Controls.Add(this.btnAbortSingleLine);
            this.gbSingleLine.Enabled = false;
            this.gbSingleLine.Location = new System.Drawing.Point(452, 49);
            this.gbSingleLine.Name = "gbSingleLine";
            this.gbSingleLine.Size = new System.Drawing.Size(110, 121);
            this.gbSingleLine.TabIndex = 11;
            this.gbSingleLine.TabStop = false;
            this.gbSingleLine.Text = "Single";
            this.gbSingleLine.Visible = false;
            // 
            // btnSendSingleLine
            // 
            this.btnSendSingleLine.Location = new System.Drawing.Point(18, 24);
            this.btnSendSingleLine.Name = "btnSendSingleLine";
            this.btnSendSingleLine.Size = new System.Drawing.Size(75, 52);
            this.btnSendSingleLine.TabIndex = 5;
            this.btnSendSingleLine.Text = "Send Single Line";
            this.btnSendSingleLine.UseVisualStyleBackColor = true;
            this.btnSendSingleLine.Click += new System.EventHandler(this.btnSendSingleLine_Click);
            // 
            // btnAbortSingleLine
            // 
            this.btnAbortSingleLine.Enabled = false;
            this.btnAbortSingleLine.Location = new System.Drawing.Point(18, 82);
            this.btnAbortSingleLine.Name = "btnAbortSingleLine";
            this.btnAbortSingleLine.Size = new System.Drawing.Size(75, 23);
            this.btnAbortSingleLine.TabIndex = 6;
            this.btnAbortSingleLine.Text = "Abort";
            this.btnAbortSingleLine.UseVisualStyleBackColor = true;
            this.btnAbortSingleLine.Click += new System.EventHandler(this.btnAbortSingleLine_Click);
            // 
            // tBoxTimeout
            // 
            this.tBoxTimeout.Location = new System.Drawing.Point(194, 116);
            this.tBoxTimeout.Name = "tBoxTimeout";
            this.tBoxTimeout.Size = new System.Drawing.Size(62, 20);
            this.tBoxTimeout.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ACK Timeout";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "msecs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 328);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBoxTimeout);
            this.Controls.Add(this.gbSingleLine);
            this.Controls.Add(this.gbAll);
            this.Controls.Add(this.gbUploadMethod);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSerialPort);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblFileSelected);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Target Drilliling Upload CSV (v0.5)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbUploadMethod.ResumeLayout(false);
            this.gbUploadMethod.PerformLayout();
            this.gbAll.ResumeLayout(false);
            this.gbSingleLine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileSelected;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnKillUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gbUploadMethod;
        private System.Windows.Forms.RadioButton rbSngleLine;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox gbAll;
        private System.Windows.Forms.GroupBox gbSingleLine;
        private System.Windows.Forms.Button btnSendSingleLine;
        private System.Windows.Forms.Button btnAbortSingleLine;
        private System.Windows.Forms.TextBox tBoxTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

