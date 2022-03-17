
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using XWinService.Global;
using XWinService.SQLConnection;


namespace XWinService
{
    static class Program
    {

        private static System.Timers.Timer Sheduletimer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ISConnection = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CheckServerConnection())
            {
                ISConnection = true;
               
            }
            GetGlobals();
            Application.Run(new frmHome(ISConnection));
        }

          public  static bool CheckServerConnection()
        {
            bool bValid = false;
            bool NeverShow = false;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\XSConnection");
            if (key.ValueCount > 0)
            {
                string constring = Crypto.Decript((string)key.GetValue("Connection"));

                if (!string.IsNullOrEmpty(constring))
                {
                    ConnectionGlobal.PrimaryConnectionString = constring;
                    string NeverShowAgain = (string)key.GetValue("ShowAgain");
                    if (!string.IsNullOrEmpty(NeverShowAgain)) NeverShow = Convert.ToBoolean(NeverShowAgain);
                    NeverShow = true;
                    bValid = true; 
                }
                else
                {
                    bValid = false;
                }
                if (!NeverShow)
                {
                    //frmConnection frmDBConnect = new frmConnection();
                    //if (frmDBConnect.ShowDialog() == DialogResult.OK)
                    //{
                    //    bValid = true;
                    //}
                }
                
            }
            else
            {//frmConnection frmDBConnect = new frmConnection();
            //    if (frmDBConnect.ShowDialog() == DialogResult.OK)
            //    {
            //        bValid = true;
            //    }
            }
            return bValid;
           
        }

        
        private static void GetGlobals()
        {
            GetSettings();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\XSConnection\ApiSettings");
            if (key.ValueCount > 0)
            {
                key.GetValue("ApiSettings");
              
                if (!string.IsNullOrEmpty(Crypto.Decript((string)key.GetValue("Unitnumber"))))
                    SystemGlobals.UnitNumber = Crypto.Decript((string)key.GetValue("Unitnumber"));
                if (!string.IsNullOrEmpty(Crypto.Decript((string)key.GetValue("LeaseCode"))))
                    SystemGlobals.LeaseCode = Crypto.Decript((string)key.GetValue("LeaseCode"));
                               
            }
        }

        private static void SheduleSyncTime()
        {
       
                Console.WriteLine("### Timer Started ###");

                DateTime nowTime = DateTime.Now;
                DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 12, 01, 0, 0); //Specify your scheduled time HH,MM,SS [8am and 42 minutes]
                if (nowTime > scheduledTime)
                {
                    scheduledTime = scheduledTime.AddDays(1);
                }

                int tickTime = (int)(scheduledTime - DateTime.Now).TotalMilliseconds;
         
            Sheduletimer = new System.Timers.Timer(tickTime);
            //Sheduletimer.Interval = tickTime;
            Sheduletimer.Elapsed += new ElapsedEventHandler(Sheduletimer_Elapsed);
            Sheduletimer.Start();
            
        }
        private static void Sheduletimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("### Timer Stopped ### \n");
            Sheduletimer.Stop();
            Console.WriteLine("### Scheduled Task Started ### \n\n");
            Console.WriteLine("Hello World!!! - Performing scheduled task\n");
            Console.WriteLine("### Task Finished ### \n\n");
            SheduleSyncTime();
        }

        private static void GetSettings()
        {
            try
            {

                DataSet dsSetting = new DataSet();
                DataTable dtSettings = null;
                string strXMLFile = "XmlSettings.xml";
                if (!System.IO.File.Exists(strXMLFile))
                    return;

                dsSetting.ReadXml(strXMLFile);
                dtSettings = dsSetting.Tables[0];
                if (dtSettings.Rows.Count > 0)
                {
                    SystemGlobals.UnitNumber = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["Unitnumber"]));
                    SystemGlobals.LeaseCode = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["LeaseCode"]));
                    if (dtSettings.Columns.Contains("ApiSyncStartDate"))
                        if (SystemGlobals.IsDate(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["ApiSyncStartDate"]))))
                        {
                            SystemGlobals.ApiSyncStartDate = Convert.ToDateTime(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["ApiSyncStartDate"])));
                        }
                    if (dtSettings.Columns.Contains("API_D")) SystemGlobals.API_D = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_D"]));
                    if (dtSettings.Columns.Contains("API_KEY_D")) SystemGlobals.API_KEY_D = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_KEY_D"]));
                    if (dtSettings.Columns.Contains("SecretKey_D")) SystemGlobals.SecretKey_D = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SecretKey_D"]));
                    if (dtSettings.Columns.Contains("API_M")) SystemGlobals.API_M = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_M"]));
                    if (dtSettings.Columns.Contains("API_KEY_M")) SystemGlobals.API_KEY_M = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_KEY_M"]));
                    if (dtSettings.Columns.Contains("SecretKey_M")) SystemGlobals.SecretKey_M = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SecretKey_M"]));

                    
                    if (dtSettings.Columns.Contains("SheduledTime"))
                        if (SystemGlobals.IsDate(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SheduledTime"]))))
                        {
                            SystemGlobals.SheduledTime = Convert.ToDateTime(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SheduledTime"])));
                        }

                    if (dtSettings.Columns.Contains("StartSync"))
                    {
                        SystemGlobals.StartSync = Convert.ToBoolean(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["StartSync"])));
                    }
                    else
                        SystemGlobals.StartSync = false;
                }
                dsSetting.Dispose();
                dtSettings.Dispose();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
