namespace XWinService
{
    partial class frmXWinService
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAPIM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAPIKEYM = new System.Windows.Forms.TextBox();
            this.txtSecurityM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkEnableSync = new System.Windows.Forms.CheckBox();
            this.txtLeaseCode = new System.Windows.Forms.TextBox();
            this.dtTimeStamp = new System.Windows.Forms.DateTimePicker();
            this.txtUnitNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtSyncStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAPID = new System.Windows.Forms.TextBox();
            this.lblApi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAPIKeyD = new System.Windows.Forms.TextBox();
            this.txtSecretD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 65);
            this.panel1.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(392, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 55);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.groupBox4);
            this.pnlTop.Controls.Add(this.groupBox3);
            this.pnlTop.Controls.Add(this.groupBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(499, 360);
            this.pnlTop.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAPIM);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtAPIKEYM);
            this.groupBox4.Controls.Add(this.txtSecurityM);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(499, 109);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MONTHLY SALES API SETTINGS";
            // 
            // txtAPIM
            // 
            this.txtAPIM.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIM.Location = new System.Drawing.Point(93, 20);
            this.txtAPIM.Name = "txtAPIM";
            this.txtAPIM.Size = new System.Drawing.Size(390, 24);
            this.txtAPIM.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "API";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Secret Key";
            // 
            // txtAPIKEYM
            // 
            this.txtAPIKEYM.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIKEYM.Location = new System.Drawing.Point(93, 49);
            this.txtAPIKEYM.Name = "txtAPIKEYM";
            this.txtAPIKEYM.Size = new System.Drawing.Size(238, 24);
            this.txtAPIKEYM.TabIndex = 2;
            // 
            // txtSecurityM
            // 
            this.txtSecurityM.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurityM.Location = new System.Drawing.Point(93, 78);
            this.txtSecurityM.Name = "txtSecurityM";
            this.txtSecurityM.Size = new System.Drawing.Size(238, 24);
            this.txtSecurityM.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "API KEY";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkEnableSync);
            this.groupBox3.Controls.Add(this.txtLeaseCode);
            this.groupBox3.Controls.Add(this.dtTimeStamp);
            this.groupBox3.Controls.Add(this.txtUnitNumber);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtSyncStartDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 136);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SYNC- SETTINGS";
            // 
            // chkEnableSync
            // 
            this.chkEnableSync.AutoSize = true;
            this.chkEnableSync.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableSync.Location = new System.Drawing.Point(345, 105);
            this.chkEnableSync.Name = "chkEnableSync";
            this.chkEnableSync.Size = new System.Drawing.Size(118, 21);
            this.chkEnableSync.TabIndex = 10;
            this.chkEnableSync.Text = "Start Synching";
            this.chkEnableSync.UseVisualStyleBackColor = true;
            // 
            // txtLeaseCode
            // 
            this.txtLeaseCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaseCode.Location = new System.Drawing.Point(107, 44);
            this.txtLeaseCode.Name = "txtLeaseCode";
            this.txtLeaseCode.Size = new System.Drawing.Size(239, 24);
            this.txtLeaseCode.TabIndex = 6;
            // 
            // dtTimeStamp
            // 
            this.dtTimeStamp.CustomFormat = "hh:mm tt";
            this.dtTimeStamp.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeStamp.Location = new System.Drawing.Point(153, 102);
            this.dtTimeStamp.Name = "dtTimeStamp";
            this.dtTimeStamp.ShowUpDown = true;
            this.dtTimeStamp.Size = new System.Drawing.Size(95, 24);
            this.dtTimeStamp.TabIndex = 9;
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitNumber.Location = new System.Drawing.Point(107, 17);
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.Size = new System.Drawing.Size(239, 24);
            this.txtUnitNumber.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "API Sync Time :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lease Code";
            // 
            // dtSyncStartDate
            // 
            this.dtSyncStartDate.CustomFormat = "";
            this.dtSyncStartDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSyncStartDate.Location = new System.Drawing.Point(152, 74);
            this.dtSyncStartDate.Name = "dtSyncStartDate";
            this.dtSyncStartDate.Size = new System.Drawing.Size(169, 24);
            this.dtSyncStartDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "API Sync Start Date :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Unit Number";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAPID);
            this.groupBox1.Controls.Add(this.lblApi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAPIKeyD);
            this.groupBox1.Controls.Add(this.txtSecretD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DAILY SALES API SETTINGS";
            // 
            // txtAPID
            // 
            this.txtAPID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPID.Location = new System.Drawing.Point(92, 19);
            this.txtAPID.Name = "txtAPID";
            this.txtAPID.Size = new System.Drawing.Size(391, 24);
            this.txtAPID.TabIndex = 1;
            // 
            // lblApi
            // 
            this.lblApi.AutoSize = true;
            this.lblApi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApi.Location = new System.Drawing.Point(11, 27);
            this.lblApi.Name = "lblApi";
            this.lblApi.Size = new System.Drawing.Size(28, 17);
            this.lblApi.TabIndex = 0;
            this.lblApi.Text = "API";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Secret Key";
            // 
            // txtAPIKeyD
            // 
            this.txtAPIKeyD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIKeyD.Location = new System.Drawing.Point(92, 48);
            this.txtAPIKeyD.Name = "txtAPIKeyD";
            this.txtAPIKeyD.Size = new System.Drawing.Size(238, 24);
            this.txtAPIKeyD.TabIndex = 2;
            // 
            // txtSecretD
            // 
            this.txtSecretD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecretD.Location = new System.Drawing.Point(92, 77);
            this.txtSecretD.Name = "txtSecretD";
            this.txtSecretD.Size = new System.Drawing.Size(238, 24);
            this.txtSecretD.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "API KEY";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // frmXWinService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 425);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panel1);
            this.Name = "frmXWinService";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmXWinService_Load);
            this.panel1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSecretD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAPIKeyD;
        private System.Windows.Forms.TextBox txtAPID;
        private System.Windows.Forms.Label lblApi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtSyncStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTimeStamp;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox chkEnableSync;
        private System.Windows.Forms.TextBox txtLeaseCode;
        private System.Windows.Forms.TextBox txtUnitNumber;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtAPIM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAPIKEYM;
        private System.Windows.Forms.TextBox txtSecurityM;
        private System.Windows.Forms.Label label9;
    }
}