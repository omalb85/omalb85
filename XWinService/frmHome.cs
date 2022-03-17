using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using XWinService;
using XWinService.Global;
using XWinService.UI;

namespace XWinService
{
    public partial class frmHome : Form
    {

        private static System.Timers.Timer Sheduletimer;
        #region Member Variables
        private Form activeForm;
        private DateTime CurrDt =  DateTime.Now;
        private DateTime ShedDt;
        private bool m_ISConnection = false;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public frmHome(bool IsConnection=false)
        {
            InitializeComponent();
            m_ISConnection = IsConnection;
           // if (!IsConnection) ChildForms(new frmConnection());

        }
        #endregion

        #region Methods
        private void ChildForms(Form ChildForm)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
                
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            ChildForm.WindowState = FormWindowState.Maximized;
            this.pnlMain.Controls.Add(ChildForm);
            this.pnlMain.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            this.lblTitle.Text = ChildForm.Text;
        }

        private void SheduleSyncTime()
        {

            Console.WriteLine("### Timer Started ###");



            DateTime scheduledTime = new DateTime(CurrDt.Year, CurrDt.Month, CurrDt.Day, 12, 01, 0, 0); //Specify your scheduled time HH,MM,SS [8am and 42 minutes]
            scheduledTime = SystemGlobals.SheduledTime;

            TimeSpan CurrentTime = CurrDt.TimeOfDay;
            TimeSpan ShedTime = scheduledTime.TimeOfDay;
            if (CurrDt > scheduledTime)
            {
                scheduledTime = scheduledTime.AddDays(1);
            }
            if (CurrentTime > ShedTime)
            {
                
                scheduledTime = scheduledTime.AddDays(1);
            }
            int tickTime = (int)(ShedTime - CurrentTime).TotalMilliseconds;
            int tickMin = (int)(ShedTime - CurrentTime).TotalMinutes;

            //label7.Text = Convert.ToString(scheduledTime);
           // lblSysDate.Text = CurrDt.ToString();
           // lbltick.Text = tickMin.ToString()+ " m";
            if (tickTime > 0)
            { 
            Sheduletimer = new System.Timers.Timer(tickTime);
            //Sheduletimer.Interval = tickTime;
            Sheduletimer.Elapsed += new ElapsedEventHandler(Sheduletimer_Elapsed);
            Sheduletimer.Start();
        }


        }
        private  void Sheduletimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("### Timer Stopped ### \n");
            Sheduletimer.Stop();
            //lbltick.Text = "ticked" + ShedDt.ToString();
            Console.WriteLine("### Scheduled Task Started ### \n\n");
            Console.WriteLine("Hello World!!! - Performing scheduled task\n");
            Console.WriteLine("### Task Finished ### \n\n");
           // CurrDt= CurrDt.AddDays(1);
            SheduleSyncTime();
        }

        private bool SetSheduler()
        {
            if (m_ISConnection && (!string.IsNullOrEmpty(SystemGlobals.API_D) && !string.IsNullOrEmpty(SystemGlobals.API_KEY_D)) && SystemGlobals.StartSync)
            {
                SyncTimer.Start();
                return true;
            }
            else return false;
        }
        
        private void ShowInNotification()
        {
            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;
            this.Hide();
        }
       
         

        #endregion

        #region Control Events
        private void btnApi_Click(object sender, EventArgs e)
        {
            //frmXWinService frm = new frmXWinService();
            //frm.ShowDialog();
            ChildForms(new frmXWinService(this));
        }
        #endregion

        #region Form Events
        private void frmHome_Load(object sender, EventArgs e)
        {
           if(! m_ISConnection) ChildForms(new frmConnection());
            else ChildForms(new frmTransactionReportSynch());
            //SheduleSyncTime();
           if( SetSheduler())  lblSheduledTime.Text = SystemGlobals.SheduledTime.ToShortTimeString();
            ShowInNotification();
        }
        #endregion

        private void btnConnection_Click(object sender, EventArgs e)
        {
            ChildForms(new frmConnection());
        }

        private void btnApi_Click_1(object sender, EventArgs e)
        {
            ChildForms(new frmXWinService(this));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
          
            //frmTransactionReportSynch frm = new frmTransactionReportSynch();
            //    frm.ShowDialog();

        }

        private void frmHome_Resize(object sender, EventArgs e)
        {
            //base.OnResize(e);
            bool cursorNotificationBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

                if(this.WindowState==FormWindowState.Minimized&& cursorNotificationBar)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                this.Hide();
            }

        }


    
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.Visible = true;
        }

        

        private void btnReport_Click(object sender, EventArgs e)
        {
            ChildForms(new frmTransactionReportSynch());
        }

        private void SyncTimer_Tick(object sender, EventArgs e)
        {
           
            DateTime CurrentTime = DateTime.Now;
            TimeSpan CSpan = CurrentTime.TimeOfDay;
            var t = (SystemGlobals.SheduledTime.TimeOfDay - CSpan).TotalMilliseconds;
            var ts = t < 0 ? t+TimeSpan.FromHours(24).TotalMilliseconds : t;
            var hms = TimeSpan.FromMilliseconds(ts);
           
            lblSyncWith.Text =string.Format("{0}", hms);
            lblHomeDate.Text = CurrentTime.ToShortTimeString();
            lblSheduledTime.Text = SystemGlobals.SheduledTime.ToShortTimeString();
            //int cH = CurrentTime.Hour;
            //int cM = CurrentTime.Minute;


            //DateTime SheduledMaxTime = SystemGlobals.SheduledTime.AddMilliseconds(SyncTimer.Interval);
            //int sH = SystemGlobals.SheduledTime.Hour;
            //int sM = SystemGlobals.SheduledTime.Minute;
            //if ((cH == sH && cM >= sM) && (cH == sH && cM < sM + 3))
            //{

            //    SyncTimer.Stop();
            //    if (TransactionReport.ReportChecking())
            //    { 
            //    SyncTimer.Enabled = true;
            //    SyncTimer.Start();
            //    }
            //}
            if (CurrentTime.TimeOfDay >= SystemGlobals.SheduledTime.TimeOfDay && CurrentTime.TimeOfDay< SystemGlobals.SheduledTime.AddMilliseconds(SyncTimer.Interval).TimeOfDay)
            {
               
                SyncTimer.Stop();
                if (TransactionReport.ReportChecking())
                {
                    SyncTimer.Enabled = true;
                    SyncTimer.Start();
                }
                else
                {
                    //lblHomeDate.Text = "Sync Stopped!";
                    notifyIcon.Text= "Sync Error";
                    notifyIcon.BalloonTipText = "Sync Error!";
                    notifyIcon.BalloonTipTitle = "XENIA";
                    notifyIcon.ShowBalloonTip(1000);
                    SyncTimer.Enabled = true;
                    SyncTimer.Start();

                }
            }
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SyncTimer.Stop();
            this.SyncTimer.Dispose();
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void cmnuShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void cmnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
