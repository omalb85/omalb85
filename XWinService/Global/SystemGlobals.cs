using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XWinService.Global
{
   public  class SystemGlobals
   {
        public static string UnitNumber { get; set; }
        public static string LeaseCode { get; set; }

        public static string API_D { get; set; }
        public static string API_KEY_D { get; set; }
        public static string SecretKey_D { get; set; }

        public static string API_M { get; set; }
        public static string API_KEY_M { get; set; }
        public static string SecretKey_M { get; set; }

        public static DateTime SheduledTime { get; set; }

        public static DateTime ApiSyncStartDate { get; set; }

        public static DateTime ApiLastSyncDate { get; set; }
        public static string Unitnumber { get; internal set; }

        public static bool IsDate(string strDate)
        {
            bool IsValid = false;
            DateTime dateValue;

            if (DateTime.TryParse(strDate, out dateValue)) IsValid = true;

            return IsValid;
        }

        public static bool StartSync { get; set; }
        private static frmDialouge Dialouge;
        public   static void NofificationDialouge(string Message)
        {
            Dialouge = new frmDialouge(Message);
            Dialouge.Show();
            DialogDelay();


        }
        private async static void DialogDelay()
        {
            await Task.Delay(3000);
            Dialouge.Close();
            
        }
        public static void WaitDialouge(string Message)
        {
            Dialouge = new frmDialouge(Message);
            Dialouge.Show();
        }
        public static void DialougeStop()
        {
            if(Dialouge!=null)
          Dialouge.Close();
        }

        public static void SetGlobalSettings()
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
    }
}
