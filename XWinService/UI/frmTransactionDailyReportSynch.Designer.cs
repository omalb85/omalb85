namespace XWinService.UI
{
    partial class frmTransactionReportSynch
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdCurrentMonth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMonthlyRepo = new System.Windows.Forms.RadioButton();
            this.rbDailyRepo = new System.Windows.Forms.RadioButton();
            this.pnlTransMain = new System.Windows.Forms.Panel();
            this.pnlDaily = new System.Windows.Forms.Panel();
            this.dtTranDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtTransDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblUnitNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtUnitNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTransNetAmount = new System.Windows.Forms.TextBox();
            this.txtTransCount = new System.Windows.Forms.TextBox();
            this.lblLeaseCode = new System.Windows.Forms.Label();
            this.txtLeaseCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.SErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTransMain.SuspendLayout();
            this.pnlDaily.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdCurrentMonth);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 40);
            this.panel1.TabIndex = 0;
            // 
            // rdCurrentMonth
            // 
            this.rdCurrentMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdCurrentMonth.AutoSize = true;
            this.rdCurrentMonth.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCurrentMonth.Location = new System.Drawing.Point(389, 11);
            this.rdCurrentMonth.Name = "rdCurrentMonth";
            this.rdCurrentMonth.Size = new System.Drawing.Size(77, 21);
            this.rdCurrentMonth.TabIndex = 4;
            this.rdCurrentMonth.Text = " Current";
            this.rdCurrentMonth.UseVisualStyleBackColor = true;
            this.rdCurrentMonth.CheckedChanged += new System.EventHandler(this.rdCurrentMonth_CheckedChanged);
            this.rdCurrentMonth.Click += new System.EventHandler(this.rdCurrentMonth_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rbMonthlyRepo);
            this.groupBox1.Controls.Add(this.rbDailyRepo);
            this.groupBox1.Location = new System.Drawing.Point(87, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 36);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rbMonthlyRepo
            // 
            this.rbMonthlyRepo.AutoSize = true;
            this.rbMonthlyRepo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMonthlyRepo.Location = new System.Drawing.Point(124, 9);
            this.rbMonthlyRepo.Name = "rbMonthlyRepo";
            this.rbMonthlyRepo.Size = new System.Drawing.Size(154, 21);
            this.rbMonthlyRepo.TabIndex = 3;
            this.rbMonthlyRepo.Text = "Monthly Daily Report";
            this.rbMonthlyRepo.UseVisualStyleBackColor = true;
            this.rbMonthlyRepo.CheckedChanged += new System.EventHandler(this.rbMonthlyRepo_CheckedChanged);
            // 
            // rbDailyRepo
            // 
            this.rbDailyRepo.AutoSize = true;
            this.rbDailyRepo.Checked = true;
            this.rbDailyRepo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDailyRepo.Location = new System.Drawing.Point(8, 9);
            this.rbDailyRepo.Name = "rbDailyRepo";
            this.rbDailyRepo.Size = new System.Drawing.Size(101, 21);
            this.rbDailyRepo.TabIndex = 2;
            this.rbDailyRepo.TabStop = true;
            this.rbDailyRepo.Text = "Daily Report";
            this.rbDailyRepo.UseVisualStyleBackColor = true;
            this.rbDailyRepo.CheckedChanged += new System.EventHandler(this.rbDailyRepo_CheckedChanged);
            // 
            // pnlTransMain
            // 
            this.pnlTransMain.Controls.Add(this.pnlDaily);
            this.pnlTransMain.Controls.Add(this.panel3);
            this.pnlTransMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTransMain.Location = new System.Drawing.Point(0, 40);
            this.pnlTransMain.Name = "pnlTransMain";
            this.pnlTransMain.Size = new System.Drawing.Size(544, 281);
            this.pnlTransMain.TabIndex = 1;
            // 
            // pnlDaily
            // 
            this.pnlDaily.Controls.Add(this.dtTranDate);
            this.pnlDaily.Controls.Add(this.label8);
            this.pnlDaily.Controls.Add(this.label10);
            this.pnlDaily.Controls.Add(this.dtTransDateTo);
            this.pnlDaily.Controls.Add(this.lblUnitNumber);
            this.pnlDaily.Controls.Add(this.label2);
            this.pnlDaily.Controls.Add(this.txtRemarks);
            this.pnlDaily.Controls.Add(this.txtUnitNumber);
            this.pnlDaily.Controls.Add(this.label4);
            this.pnlDaily.Controls.Add(this.label3);
            this.pnlDaily.Controls.Add(this.txtTransNetAmount);
            this.pnlDaily.Controls.Add(this.txtTransCount);
            this.pnlDaily.Controls.Add(this.lblLeaseCode);
            this.pnlDaily.Controls.Add(this.txtLeaseCode);
            this.pnlDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDaily.Location = new System.Drawing.Point(0, 0);
            this.pnlDaily.Name = "pnlDaily";
            this.pnlDaily.Size = new System.Drawing.Size(544, 211);
            this.pnlDaily.TabIndex = 20;
            this.pnlDaily.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDaily_Paint);
            // 
            // dtTranDate
            // 
            this.dtTranDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTranDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTranDate.Location = new System.Drawing.Point(146, 19);
            this.dtTranDate.Name = "dtTranDate";
            this.dtTranDate.Size = new System.Drawing.Size(147, 24);
            this.dtTranDate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(298, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 26);
            this.label8.TabIndex = 5;
            this.label8.Text = "To:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 26);
            this.label10.TabIndex = 15;
            this.label10.Text = "Remarks :";
            // 
            // dtTransDateTo
            // 
            this.dtTransDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtTransDateTo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTransDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransDateTo.Location = new System.Drawing.Point(390, 19);
            this.dtTransDateTo.Name = "dtTransDateTo";
            this.dtTransDateTo.Size = new System.Drawing.Size(147, 24);
            this.dtTransDateTo.TabIndex = 6;
            // 
            // lblUnitNumber
            // 
            this.lblUnitNumber.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitNumber.Location = new System.Drawing.Point(13, 60);
            this.lblUnitNumber.Name = "lblUnitNumber";
            this.lblUnitNumber.Size = new System.Drawing.Size(123, 26);
            this.lblUnitNumber.TabIndex = 7;
            this.lblUnitNumber.Text = "Unit Number:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sales Date :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(146, 137);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(392, 68);
            this.txtRemarks.TabIndex = 16;
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitNumber.Location = new System.Drawing.Point(146, 52);
            this.txtUnitNumber.Multiline = true;
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.ReadOnly = true;
            this.txtUnitNumber.Size = new System.Drawing.Size(147, 35);
            this.txtUnitNumber.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Transaction Count :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(298, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Net Amount :";
            // 
            // txtTransNetAmount
            // 
            this.txtTransNetAmount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransNetAmount.Location = new System.Drawing.Point(390, 94);
            this.txtTransNetAmount.Multiline = true;
            this.txtTransNetAmount.Name = "txtTransNetAmount";
            this.txtTransNetAmount.ReadOnly = true;
            this.txtTransNetAmount.Size = new System.Drawing.Size(147, 35);
            this.txtTransNetAmount.TabIndex = 14;
            // 
            // txtTransCount
            // 
            this.txtTransCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransCount.Location = new System.Drawing.Point(146, 95);
            this.txtTransCount.Multiline = true;
            this.txtTransCount.Name = "txtTransCount";
            this.txtTransCount.ReadOnly = true;
            this.txtTransCount.Size = new System.Drawing.Size(147, 35);
            this.txtTransCount.TabIndex = 12;
            // 
            // lblLeaseCode
            // 
            this.lblLeaseCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaseCode.Location = new System.Drawing.Point(298, 57);
            this.lblLeaseCode.Name = "lblLeaseCode";
            this.lblLeaseCode.Size = new System.Drawing.Size(90, 26);
            this.lblLeaseCode.TabIndex = 9;
            this.lblLeaseCode.Text = "Lease Code :";
            // 
            // txtLeaseCode
            // 
            this.txtLeaseCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaseCode.Location = new System.Drawing.Point(391, 50);
            this.txtLeaseCode.Multiline = true;
            this.txtLeaseCode.Name = "txtLeaseCode";
            this.txtLeaseCode.ReadOnly = true;
            this.txtLeaseCode.Size = new System.Drawing.Size(147, 35);
            this.txtLeaseCode.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnShow);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnPush);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 211);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 70);
            this.panel3.TabIndex = 19;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(323, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(106, 62);
            this.btnShow.TabIndex = 19;
            this.btnShow.Text = "Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(221, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 62);
            this.button1.TabIndex = 18;
            this.button1.Text = "Test API";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPush
            // 
            this.btnPush.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPush.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPush.Location = new System.Drawing.Point(430, 4);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(106, 62);
            this.btnPush.TabIndex = 20;
            this.btnPush.Text = "Report Synch";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // SErrorProvider
            // 
            this.SErrorProvider.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // frmTransactionReportSynch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 321);
            this.Controls.Add(this.pnlTransMain);
            this.Controls.Add(this.panel1);
            this.Name = "frmTransactionReportSynch";
            this.Text = "Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTransactionReportSynch_FormClosing);
            this.Load += new System.EventHandler(this.frmTransactionReportSynch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTransMain.ResumeLayout(false);
            this.pnlDaily.ResumeLayout(false);
            this.pnlDaily.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTransMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMonthlyRepo;
        private System.Windows.Forms.RadioButton rbDailyRepo;
        private System.Windows.Forms.ErrorProvider SErrorProvider;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RadioButton rdCurrentMonth;
        private System.Windows.Forms.Panel pnlDaily;
        private System.Windows.Forms.DateTimePicker dtTranDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtTransDateTo;
        private System.Windows.Forms.Label lblUnitNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtUnitNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTransNetAmount;
        private System.Windows.Forms.TextBox txtTransCount;
        private System.Windows.Forms.Label lblLeaseCode;
        private System.Windows.Forms.TextBox txtLeaseCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPush;
    }
}