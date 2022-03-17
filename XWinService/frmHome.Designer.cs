namespace XWinService
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHomeDate = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSysDate = new System.Windows.Forms.Label();
            this.btnApi = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSyncWith = new System.Windows.Forms.Label();
            this.lblSheduledTime = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SyncTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHomeDate);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnApi);
            this.panel1.Controls.Add(this.btnConnection);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.pnlLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 514);
            this.panel1.TabIndex = 2;
            // 
            // lblHomeDate
            // 
            this.lblHomeDate.AutoSize = true;
            this.lblHomeDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHomeDate.Location = new System.Drawing.Point(3, 460);
            this.lblHomeDate.Name = "lblHomeDate";
            this.lblHomeDate.Size = new System.Drawing.Size(28, 17);
            this.lblHomeDate.TabIndex = 11;
            this.lblHomeDate.Text = "     ";
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(0, 224);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(172, 55);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = " Report";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSysDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 486);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(172, 26);
            this.panel4.TabIndex = 0;
            // 
            // lblSysDate
            // 
            this.lblSysDate.AutoSize = true;
            this.lblSysDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSysDate.Location = new System.Drawing.Point(3, 6);
            this.lblSysDate.Name = "lblSysDate";
            this.lblSysDate.Size = new System.Drawing.Size(60, 17);
            this.lblSysDate.TabIndex = 10;
            this.lblSysDate.Text = "             ";
            // 
            // btnApi
            // 
            this.btnApi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApi.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnApi.FlatAppearance.BorderSize = 0;
            this.btnApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnApi.Image = ((System.Drawing.Image)(resources.GetObject("btnApi.Image")));
            this.btnApi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApi.Location = new System.Drawing.Point(0, 169);
            this.btnApi.Name = "btnApi";
            this.btnApi.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnApi.Size = new System.Drawing.Size(172, 55);
            this.btnApi.TabIndex = 9;
            this.btnApi.Text = " API Service";
            this.btnApi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApi.UseVisualStyleBackColor = true;
            this.btnApi.Click += new System.EventHandler(this.btnApi_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConnection.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnConnection.FlatAppearance.BorderSize = 0;
            this.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnConnection.Image")));
            this.btnConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnection.Location = new System.Drawing.Point(0, 114);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConnection.Size = new System.Drawing.Size(172, 55);
            this.btnConnection.TabIndex = 8;
            this.btnConnection.Text = " Connection";
            this.btnConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 59);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(172, 55);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "  Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlLogo.Controls.Add(this.label1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(172, 59);
            this.pnlLogo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xenia ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(174, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 60);
            this.panel2.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(234, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Connection";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Xenia";
            this.notifyIcon.BalloonTipTitle = "Xenia";
            this.notifyIcon.ContextMenuStrip = this.ContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Xenia";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuShow,
            this.cmnuExit});
            this.ContextMenu.Name = "contextMenuStrip1";
            this.ContextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // cmnuShow
            // 
            this.cmnuShow.Name = "cmnuShow";
            this.cmnuShow.Size = new System.Drawing.Size(103, 22);
            this.cmnuShow.Text = "Open";
            this.cmnuShow.Click += new System.EventHandler(this.cmnuShow_Click);
            // 
            // cmnuExit
            // 
            this.cmnuExit.Name = "cmnuExit";
            this.cmnuExit.Size = new System.Drawing.Size(103, 22);
            this.cmnuExit.Text = "Exit";
            this.cmnuExit.Click += new System.EventHandler(this.cmnuExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblSyncWith);
            this.panel3.Controls.Add(this.lblSheduledTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(174, 487);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(577, 27);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Next Sync with in :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sheduled Time : ";
            // 
            // lblSyncWith
            // 
            this.lblSyncWith.AutoSize = true;
            this.lblSyncWith.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncWith.Location = new System.Drawing.Point(351, 6);
            this.lblSyncWith.Name = "lblSyncWith";
            this.lblSyncWith.Size = new System.Drawing.Size(45, 17);
            this.lblSyncWith.TabIndex = 1;
            this.lblSyncWith.Text = "00:00";
            // 
            // lblSheduledTime
            // 
            this.lblSheduledTime.AutoSize = true;
            this.lblSheduledTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheduledTime.Location = new System.Drawing.Point(112, 5);
            this.lblSheduledTime.Name = "lblSheduledTime";
            this.lblSheduledTime.Size = new System.Drawing.Size(45, 17);
            this.lblSheduledTime.TabIndex = 0;
            this.lblSheduledTime.Text = "00:00";
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(174, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(577, 427);
            this.pnlMain.TabIndex = 6;
            // 
            // SyncTimer
            // 
            this.SyncTimer.Interval = 1000;
            this.SyncTimer.Tick += new System.EventHandler(this.SyncTimer_Tick);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 514);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xenia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHome_FormClosed);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.Resize += new System.EventHandler(this.frmHome_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnApi;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSyncWith;
        private System.Windows.Forms.Label lblSheduledTime;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSysDate;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblHomeDate;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuShow;
        private System.Windows.Forms.ToolStripMenuItem cmnuExit;
        public System.Windows.Forms.Timer SyncTimer;
    }
}