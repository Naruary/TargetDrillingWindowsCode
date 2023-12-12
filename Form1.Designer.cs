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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileSelected = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUploadStart = new System.Windows.Forms.Button();
            this.btnAbortUpload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbUpDownSelect = new System.Windows.Forms.GroupBox();
            this.rbDownload = new System.Windows.Forms.RadioButton();
            this.rbUpload = new System.Windows.Forms.RadioButton();
            this.gbUpload = new System.Windows.Forms.GroupBox();
            this.gbDownload = new System.Windows.Forms.GroupBox();
            this.btnDownloadAbort = new System.Windows.Forms.Button();
            this.btnDownloadStart = new System.Windows.Forms.Button();
            this.btnDownloadSave = new System.Windows.Forms.Button();
            this.tBoxTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSerialLog = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbUploadOptions = new System.Windows.Forms.GroupBox();
            this.gbUpDownSelect.SuspendLayout();
            this.gbUpload.SuspendLayout();
            this.gbDownload.SuspendLayout();
            this.gbUploadOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Selected:";
            // 
            // lblFileSelected
            // 
            this.lblFileSelected.Location = new System.Drawing.Point(201, 122);
            this.lblFileSelected.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(837, 88);
            this.lblFileSelected.TabIndex = 1;
            this.lblFileSelected.Text = "No File";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(25, 38);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(174, 77);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Select Upload File";
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
            // btnUploadStart
            // 
            this.btnUploadStart.Location = new System.Drawing.Point(42, 53);
            this.btnUploadStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnUploadStart.Name = "btnUploadStart";
            this.btnUploadStart.Size = new System.Drawing.Size(176, 51);
            this.btnUploadStart.TabIndex = 5;
            this.btnUploadStart.Text = "Start";
            this.btnUploadStart.UseVisualStyleBackColor = true;
            this.btnUploadStart.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnAbortUpload
            // 
            this.btnAbortUpload.Enabled = false;
            this.btnAbortUpload.Location = new System.Drawing.Point(48, 118);
            this.btnAbortUpload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAbortUpload.Name = "btnAbortUpload";
            this.btnAbortUpload.Size = new System.Drawing.Size(176, 51);
            this.btnAbortUpload.TabIndex = 6;
            this.btnAbortUpload.Text = "Abort";
            this.btnAbortUpload.UseVisualStyleBackColor = true;
            this.btnAbortUpload.Click += new System.EventHandler(this.btnKillUpload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 732);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(123, 730);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 29);
            this.lblStatus.TabIndex = 8;
            // 
            // gbUpDownSelect
            // 
            this.gbUpDownSelect.Controls.Add(this.rbDownload);
            this.gbUpDownSelect.Controls.Add(this.rbUpload);
            this.gbUpDownSelect.Location = new System.Drawing.Point(404, 27);
            this.gbUpDownSelect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbUpDownSelect.Name = "gbUpDownSelect";
            this.gbUpDownSelect.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbUpDownSelect.Size = new System.Drawing.Size(256, 205);
            this.gbUpDownSelect.TabIndex = 9;
            this.gbUpDownSelect.TabStop = false;
            this.gbUpDownSelect.Text = "Function";
            // 
            // rbDownload
            // 
            this.rbDownload.AutoSize = true;
            this.rbDownload.Location = new System.Drawing.Point(48, 128);
            this.rbDownload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbDownload.Name = "rbDownload";
            this.rbDownload.Size = new System.Drawing.Size(140, 33);
            this.rbDownload.TabIndex = 1;
            this.rbDownload.TabStop = true;
            this.rbDownload.Text = "Download";
            this.rbDownload.UseVisualStyleBackColor = true;
            this.rbDownload.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbUpload
            // 
            this.rbUpload.AutoSize = true;
            this.rbUpload.Checked = true;
            this.rbUpload.Location = new System.Drawing.Point(48, 63);
            this.rbUpload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbUpload.Name = "rbUpload";
            this.rbUpload.Size = new System.Drawing.Size(109, 33);
            this.rbUpload.TabIndex = 0;
            this.rbUpload.TabStop = true;
            this.rbUpload.Text = "Upload";
            this.rbUpload.UseVisualStyleBackColor = true;
            this.rbUpload.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // gbUpload
            // 
            this.gbUpload.Controls.Add(this.btnUploadStart);
            this.gbUpload.Controls.Add(this.btnAbortUpload);
            this.gbUpload.Enabled = false;
            this.gbUpload.Location = new System.Drawing.Point(741, 37);
            this.gbUpload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbUpload.Name = "gbUpload";
            this.gbUpload.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbUpload.Size = new System.Drawing.Size(256, 195);
            this.gbUpload.TabIndex = 10;
            this.gbUpload.TabStop = false;
            this.gbUpload.Text = "Upload";
            // 
            // gbDownload
            // 
            this.gbDownload.Controls.Add(this.btnDownloadAbort);
            this.gbDownload.Controls.Add(this.btnDownloadStart);
            this.gbDownload.Controls.Add(this.btnDownloadSave);
            this.gbDownload.Location = new System.Drawing.Point(741, 252);
            this.gbDownload.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbDownload.Name = "gbDownload";
            this.gbDownload.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbDownload.Size = new System.Drawing.Size(256, 250);
            this.gbDownload.TabIndex = 11;
            this.gbDownload.TabStop = false;
            this.gbDownload.Text = "Download";
            // 
            // btnDownloadAbort
            // 
            this.btnDownloadAbort.Enabled = false;
            this.btnDownloadAbort.Location = new System.Drawing.Point(42, 175);
            this.btnDownloadAbort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDownloadAbort.Name = "btnDownloadAbort";
            this.btnDownloadAbort.Size = new System.Drawing.Size(176, 51);
            this.btnDownloadAbort.TabIndex = 7;
            this.btnDownloadAbort.Text = "Abort";
            this.btnDownloadAbort.UseVisualStyleBackColor = true;
            this.btnDownloadAbort.Click += new System.EventHandler(this.btnDownloadAbort_Click);
            // 
            // btnDownloadStart
            // 
            this.btnDownloadStart.Location = new System.Drawing.Point(42, 53);
            this.btnDownloadStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDownloadStart.Name = "btnDownloadStart";
            this.btnDownloadStart.Size = new System.Drawing.Size(176, 51);
            this.btnDownloadStart.TabIndex = 5;
            this.btnDownloadStart.Text = "Start";
            this.btnDownloadStart.UseVisualStyleBackColor = true;
            this.btnDownloadStart.Click += new System.EventHandler(this.btnDownloadStart_Click);
            // 
            // btnDownloadSave
            // 
            this.btnDownloadSave.Enabled = false;
            this.btnDownloadSave.Location = new System.Drawing.Point(42, 113);
            this.btnDownloadSave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDownloadSave.Name = "btnDownloadSave";
            this.btnDownloadSave.Size = new System.Drawing.Size(176, 51);
            this.btnDownloadSave.TabIndex = 6;
            this.btnDownloadSave.Text = "Save";
            this.btnDownloadSave.UseVisualStyleBackColor = true;
            this.btnDownloadSave.Click += new System.EventHandler(this.btnDownloadSave_Click);
            // 
            // tBoxTimeout
            // 
            this.tBoxTimeout.Location = new System.Drawing.Point(435, 52);
            this.tBoxTimeout.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tBoxTimeout.Name = "tBoxTimeout";
            this.tBoxTimeout.Size = new System.Drawing.Size(140, 35);
            this.tBoxTimeout.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "ACK Timeout";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "msecs";
            // 
            // tbSerialLog
            // 
            this.tbSerialLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerialLog.Location = new System.Drawing.Point(28, 615);
            this.tbSerialLog.Multiline = true;
            this.tbSerialLog.Name = "tbSerialLog";
            this.tbSerialLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSerialLog.Size = new System.Drawing.Size(846, 94);
            this.tbSerialLog.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 583);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "Serial Log";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(894, 632);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(131, 77);
            this.btnClearLog.TabIndex = 17;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // gbUploadOptions
            // 
            this.gbUploadOptions.Controls.Add(this.btnSelectFile);
            this.gbUploadOptions.Controls.Add(this.label1);
            this.gbUploadOptions.Controls.Add(this.lblFileSelected);
            this.gbUploadOptions.Controls.Add(this.label4);
            this.gbUploadOptions.Controls.Add(this.tBoxTimeout);
            this.gbUploadOptions.Controls.Add(this.label5);
            this.gbUploadOptions.Location = new System.Drawing.Point(12, 351);
            this.gbUploadOptions.Name = "gbUploadOptions";
            this.gbUploadOptions.Size = new System.Drawing.Size(1047, 218);
            this.gbUploadOptions.TabIndex = 18;
            this.gbUploadOptions.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 782);
            this.Controls.Add(this.gbUploadOptions);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.gbDownload);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSerialLog);
            this.Controls.Add(this.gbUpload);
            this.Controls.Add(this.gbUpDownSelect);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSerialPort);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Target Drilliling Upload/Download CSV (v1.0)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbUpDownSelect.ResumeLayout(false);
            this.gbUpDownSelect.PerformLayout();
            this.gbUpload.ResumeLayout(false);
            this.gbDownload.ResumeLayout(false);
            this.gbUploadOptions.ResumeLayout(false);
            this.gbUploadOptions.PerformLayout();
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
        private System.Windows.Forms.Button btnUploadStart;
        private System.Windows.Forms.Button btnAbortUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gbUpDownSelect;
        private System.Windows.Forms.RadioButton rbDownload;
        private System.Windows.Forms.RadioButton rbUpload;
        private System.Windows.Forms.GroupBox gbUpload;
        private System.Windows.Forms.TextBox tBoxTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbDownload;
        private System.Windows.Forms.Button btnDownloadStart;
        private System.Windows.Forms.Button btnDownloadSave;
        private System.Windows.Forms.TextBox tbSerialLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnDownloadAbort;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox gbUploadOptions;
    }
}

