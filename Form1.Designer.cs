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
            this.label1.Location = new System.Drawing.Point(30, 485);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Selected:";
            // 
            // lblFileSelected
            // 
            this.lblFileSelected.Location = new System.Drawing.Point(210, 485);
            this.lblFileSelected.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(1052, 100);
            this.lblFileSelected.TabIndex = 1;
            this.lblFileSelected.Text = "No File";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(38, 385);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(176, 51);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(28, 109);
            this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(276, 37);
            this.comboBoxSerialPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Serial Port";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(42, 53);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(176, 51);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnKillUpload
            // 
            this.btnKillUpload.Enabled = false;
            this.btnKillUpload.Location = new System.Drawing.Point(48, 118);
            this.btnKillUpload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnKillUpload.Name = "btnKillUpload";
            this.btnKillUpload.Size = new System.Drawing.Size(176, 51);
            this.btnKillUpload.TabIndex = 6;
            this.btnKillUpload.Text = "Kill Upload";
            this.btnKillUpload.UseVisualStyleBackColor = true;
            this.btnKillUpload.Click += new System.EventHandler(this.btnKillUpload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 648);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(132, 646);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 29);
            this.lblStatus.TabIndex = 8;
            // 
            // gbUploadMethod
            // 
            this.gbUploadMethod.Controls.Add(this.rbSngleLine);
            this.gbUploadMethod.Controls.Add(this.rbAll);
            this.gbUploadMethod.Location = new System.Drawing.Point(404, 27);
            this.gbUploadMethod.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbUploadMethod.Name = "gbUploadMethod";
            this.gbUploadMethod.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbUploadMethod.Size = new System.Drawing.Size(256, 184);
            this.gbUploadMethod.TabIndex = 9;
            this.gbUploadMethod.TabStop = false;
            this.gbUploadMethod.Text = "Upload Method";
            // 
            // rbSngleLine
            // 
            this.rbSngleLine.AutoSize = true;
            this.rbSngleLine.Location = new System.Drawing.Point(48, 114);
            this.rbSngleLine.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbSngleLine.Name = "rbSngleLine";
            this.rbSngleLine.Size = new System.Drawing.Size(83, 33);
            this.rbSngleLine.TabIndex = 1;
            this.rbSngleLine.TabStop = true;
            this.rbSngleLine.Text = "Line ";
            this.rbSngleLine.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(48, 42);
            this.rbAll.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(58, 33);
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
            this.gbAll.Location = new System.Drawing.Point(742, 27);
            this.gbAll.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbAll.Name = "gbAll";
            this.gbAll.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbAll.Size = new System.Drawing.Size(256, 195);
            this.gbAll.TabIndex = 10;
            this.gbAll.TabStop = false;
            this.gbAll.Text = "All";
            // 
            // gbSingleLine
            // 
            this.gbSingleLine.Controls.Add(this.btnSendSingleLine);
            this.gbSingleLine.Controls.Add(this.btnAbortSingleLine);
            this.gbSingleLine.Enabled = false;
            this.gbSingleLine.Location = new System.Drawing.Point(742, 245);
            this.gbSingleLine.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbSingleLine.Name = "gbSingleLine";
            this.gbSingleLine.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbSingleLine.Size = new System.Drawing.Size(256, 269);
            this.gbSingleLine.TabIndex = 11;
            this.gbSingleLine.TabStop = false;
            this.gbSingleLine.Text = "Single";
            this.gbSingleLine.Visible = false;
            // 
            // btnSendSingleLine
            // 
            this.btnSendSingleLine.Location = new System.Drawing.Point(42, 53);
            this.btnSendSingleLine.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSendSingleLine.Name = "btnSendSingleLine";
            this.btnSendSingleLine.Size = new System.Drawing.Size(176, 116);
            this.btnSendSingleLine.TabIndex = 5;
            this.btnSendSingleLine.Text = "Send Single Line";
            this.btnSendSingleLine.UseVisualStyleBackColor = true;
            this.btnSendSingleLine.Click += new System.EventHandler(this.btnSendSingleLine_Click);
            // 
            // btnAbortSingleLine
            // 
            this.btnAbortSingleLine.Enabled = false;
            this.btnAbortSingleLine.Location = new System.Drawing.Point(42, 182);
            this.btnAbortSingleLine.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAbortSingleLine.Name = "btnAbortSingleLine";
            this.btnAbortSingleLine.Size = new System.Drawing.Size(176, 51);
            this.btnAbortSingleLine.TabIndex = 6;
            this.btnAbortSingleLine.Text = "Abort";
            this.btnAbortSingleLine.UseVisualStyleBackColor = true;
            this.btnAbortSingleLine.Click += new System.EventHandler(this.btnAbortSingleLine_Click);
            // 
            // tBoxTimeout
            // 
            this.tBoxTimeout.Location = new System.Drawing.Point(452, 259);
            this.tBoxTimeout.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tBoxTimeout.Name = "tBoxTimeout";
            this.tBoxTimeout.Size = new System.Drawing.Size(140, 35);
            this.tBoxTimeout.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 269);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "ACK Timeout";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(612, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "msecs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 732);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Target Drilliling Upload CSV (v0.6)";
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

