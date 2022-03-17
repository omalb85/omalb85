using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XWinService;
using XWinService.DL;
using XWinService.Global;

namespace BL
{
    public class TransactionReport: ErrorLog
    {

        #region Member Variables
        private string m_UniNumber;
        private string m_LeaseCode;
        private DateTime m_TransactionDate;
        private String  m_TransactionDateString;
        private DateTime m_TransactionDateTo;
        private string m_TransactionDateToString;
        private int m_TransactionCount;
        private double m_TotalTransNetAmount;

        private string m_Remarks;
        private bool m_ISDailyReport;
        private bool m_ISMonthlyReport;



       

        #endregion

        #region Properties

        public string LeaseCode
        {
            get { return m_LeaseCode; }
            set { m_LeaseCode = value; }
        }
        public string UniNumber
        {
            get { return m_UniNumber; }
            set { m_UniNumber = value; }
        }
        public double TotalTransNetAmount
        {
            get { return m_TotalTransNetAmount; }
            set { m_TotalTransNetAmount = value; }
        }
        public int TransactionCount
        {
            get { return m_TransactionCount; }
            set { m_TransactionCount = value; }
        }
        public String TransactionDateString
        {
            get
            {
                return m_TransactionDateString;
            }
            set
            {
                m_TransactionDateString = value;
                if (IsDate(m_TransactionDateString))
                {
                    m_TransactionDate = Convert.ToDateTime(m_TransactionDateString);
                }
            }
        }
        public DateTime TransactionDate
        {

            get { return m_TransactionDate; }
            set
            {
                m_TransactionDate = value;
                m_TransactionDateString = m_TransactionDate.ToShortDateString();
            }
        }

        public DateTime TransactionDateTo
        {
            get
            {
                return m_TransactionDateTo;
            }

            set
            {
                m_TransactionDateTo = value;
                m_TransactionDateToString = m_TransactionDateTo.ToShortDateString();
            }
        }

        public string TransactionDateToString
        {
            get
            {
                return m_TransactionDateToString;
            }

            set
            {
                m_TransactionDateToString = value;
                if (IsDate(m_TransactionDateToString))
                {
                    m_TransactionDateTo = Convert.ToDateTime(m_TransactionDateToString);
                }
            }
        }


        public bool ISMonthlyReport
        {
            get { return m_ISMonthlyReport; }
            set
            {
                m_ISMonthlyReport = value;
                m_ISDailyReport = !m_ISMonthlyReport;
            }
        }

        public bool ISDailyReport
        {
            get { return m_ISDailyReport; }
            set
            {

                m_ISDailyReport = value;
                m_ISMonthlyReport = !m_ISDailyReport;

            }
        }


        public string Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }

        #endregion

        #region Methods
        public static bool IsDate(string strDate)
        {
            bool IsValid = false;
            DateTime dateValue;

            if (DateTime.TryParse(strDate, out dateValue)) IsValid = true;

            return IsValid;
        }

       public bool ValidateReport()
        {
            bool bValid = true;
            string errorMessage = "";
            ClearErrors();
            if (!SystemGlobals.IsDate(this.TransactionDateString))
            {
                this.ErrorMessage = "Sale From date is not valid";
                this.ErrorPopertyName = "TransactionDateString";
                bValid = false;
            }
            if (!SystemGlobals.IsDate(this.TransactionDateToString))
            {
               this.ErrorMessage= "Sale To date is not valid";
                this.ErrorPopertyName = "TransactionDateString";
                bValid = false;
            }
            if( this.ISMonthlyReport&&this.m_TransactionDate>this.TransactionDateTo)
            {
                this.ErrorMessage = "To date canot be less than from date";
                this.ErrorPopertyName = "TransactionDateTo";
                bValid = false;

            }
            return bValid;
        }

        public DataTable GetTransactionReport()
        {
            TransactionReportDat objDat = new TransactionReportDat();
           return objDat.GetTransactionReport(this);
        }


        private static void Log(string logMessage, StreamWriter stWriter, TransactionReport m_TranRepo)
        {
            try
            {
                // stWriter.Write("\r\n Report  ");
                if (m_TranRepo.ISDailyReport) stWriter.WriteLine("Daily Transaction Report");
                if (m_TranRepo.ISMonthlyReport) stWriter.WriteLine("Monthly Transaction Report");

                stWriter.WriteLine("Last Sync Time :{0},Last Sync Date: {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                stWriter.WriteLine("UnitNumber  :{0}", m_TranRepo.UniNumber);
                stWriter.WriteLine("LeaseCode  :{0}", m_TranRepo.LeaseCode);
                stWriter.WriteLine("SalesDate  :{0}", m_TranRepo.TransactionDateString);
                stWriter.WriteLine("TransactionCount  :{0}", m_TranRepo.TransactionCount);
                stWriter.WriteLine("NetAmount  :{0}", m_TranRepo.TotalTransNetAmount);
                stWriter.WriteLine("  :{0}", logMessage);
                stWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
        private static void SigleLineLog(string logMessage, StreamWriter stWriter, TransactionReport m_TranRepo)
        {
            try
            {
                string ReportType = "";
                // stWriter.Write("\r\n Report  ");
                if (m_TranRepo.ISDailyReport)
                {
                    ReportType = "Daily Transaction Report";
                    stWriter.WriteLine("{0},Last Sync Time :{1},Last Sync Date: {2},UnitNumber :{3},LeaseCode :{4},SalesDate :{5},TransactionCount :{6},NetAmount :{7},Status:{8}", ReportType, DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(),
                    m_TranRepo.UniNumber, m_TranRepo.LeaseCode,
                    m_TranRepo.TransactionDateString, m_TranRepo.TransactionCount,
                    m_TranRepo.TotalTransNetAmount, logMessage
                    );
                }

                if (m_TranRepo.ISMonthlyReport)
                {
                    ReportType = "Monthly Transaction Report";
                    stWriter.WriteLine("{0},Last Sync Time :{1},Last Sync Date: {2},UnitNumber :{3},LeaseCode :{4},SalesDateFrom :{5},SalesDateTo :{6},TransactionCount :{7},TotalSales :{8},Remarks :{9},Status :{10}", ReportType, DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(),
                    m_TranRepo.UniNumber, m_TranRepo.LeaseCode,
                    m_TranRepo.TransactionDateString, m_TranRepo.TransactionDateToString,
                    m_TranRepo.TransactionCount, m_TranRepo.TotalTransNetAmount, m_TranRepo.Remarks, logMessage
                    );
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void WriteLog(string strLog, TransactionReport m_TranRepo)
        {
            try
            {
                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                // string logFilePath = "C:\\Logs\\";
                string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                logFilePath = logFilePath + "\\Log" + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                //log.WriteLine(strLog);
                //Log("Synch Report", log, m_TranRepo);
                SigleLineLog(strLog, log, m_TranRepo);
                log.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #region SYNCH
        private static string SetSyncData(TransactionReport m_TranRepo)
        {
            string SyncDatajson = "";
            TransDailyReportJson objReportJson;
            if (m_TranRepo.ISDailyReport)
            {
                List<TransDailyReportJson> SalesInfo = new List<TransDailyReportJson>();
                objReportJson = new TransDailyReportJson();
                objReportJson.UnitNo = m_TranRepo.UniNumber;
                objReportJson.LeaseCode = m_TranRepo.LeaseCode;
                objReportJson.SalesDate = m_TranRepo.TransactionDate.ToString("yyyy-MM-dd");
                objReportJson.TransactionCount = Convert.ToString(m_TranRepo.TransactionCount);
                objReportJson.NetSales = Convert.ToString(m_TranRepo.TotalTransNetAmount);
                SalesInfo.Add(objReportJson);
                var TransJson = new
                {
                    SalesDataCollection = new
                    {
                        SalesInfo
                    }

                };
                SyncDatajson = JsonConvert.SerializeObject(TransJson, Formatting.Indented);

            }
            else
            {
                TransMonthlyReportJson TransMonthlyReportJson = new TransMonthlyReportJson();
                List<TransMonthlyReportJson> SalesInfo = new List<TransMonthlyReportJson>();
                TransMonthlyReportJson = new TransMonthlyReportJson();
                TransMonthlyReportJson.UnitNo = m_TranRepo.UniNumber;
                TransMonthlyReportJson.LeaseCode = m_TranRepo.LeaseCode;
                TransMonthlyReportJson.SalesDateFrom = m_TranRepo.TransactionDate.ToString("yyyy-MM-dd");
                TransMonthlyReportJson.SalesDateTo = m_TranRepo.TransactionDateTo.ToString("yyyy-MM-dd");
                TransMonthlyReportJson.TransactionCount = Convert.ToString(m_TranRepo.TransactionCount);
                TransMonthlyReportJson.TotalSales = Convert.ToString(m_TranRepo.TotalTransNetAmount);
                TransMonthlyReportJson.Remarks = m_TranRepo.Remarks;
                SalesInfo.Add(TransMonthlyReportJson);
                var TransJson = new
                {
                    SalesDataCollection = new
                    {
                        SalesInfo
                    }

                };
                SyncDatajson = JsonConvert.SerializeObject(TransJson, Formatting.Indented);
            }
            return SyncDatajson;

        }
        private static bool TransactionReportSync(TransactionReport m_TranRepo)
        {
            bool IsSuccess = false;
            string ApiRestunMessage = "";
            string Result = "";
            string ApiUriString = "";
            string ApiKEY = "";
            try
            {
                string json = SetSyncData(m_TranRepo);

                if (m_TranRepo.ISDailyReport) { ApiUriString = SystemGlobals.API_D; ApiKEY = SystemGlobals.API_KEY_D; }
                else if (m_TranRepo.ISMonthlyReport) { ApiUriString = SystemGlobals.API_M; ApiKEY = SystemGlobals.API_KEY_M; }

                 Result = UploadAPI(ApiUriString, ApiKEY, json);
                //HttpClientPushData("https://apidev.emaar.com/etenantsales/dailysales", json, "AlXBRGgn4diHVloG0oiSeq3MEA2AWhw0");
              
            }
            catch(Exception ex)
            {
                IsSuccess = false;
                var obj = new
                {
                    Code = "500",
                    Result = "Internal Server Error",
                    ErrorMsg = "Internal Server Error"

                };
                Result = JsonConvert.SerializeObject(obj);
                MessageBox.Show(ex.Message.ToString());

            }
            TransJsonResult Traresults = JsonConvert.DeserializeObject<TransJsonResult>(Result);
            if (Traresults != null) if (Traresults.Code == "200")
                {

                    // MessageBox.Show("Data sync successfully.");
                    IsSuccess = true;
                }
                //else MessageBox.Show("ERROR", Traresults.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (Traresults != null) Result = string.Format("Code :{0},Result :{1},ErrorMsg :{2}", Traresults.Code, Traresults.Result, Traresults.ErrorMsg);

            WriteLog(Result, m_TranRepo);
            return IsSuccess;
        }
        public static bool StartSynchReportToApi(TransactionReport m_TransactionRepo)
        {
            bool bValid = false;
            try
            {
                DataTable dtReport = null;
                TransactionReport m_TranRepo = new TransactionReport();
                m_TranRepo = m_TransactionRepo;
                TransactionReportDat objDat = new TransactionReportDat();

                dtReport = objDat.GetTransactionReport(m_TranRepo);
                if (dtReport.Rows.Count > 0)
                {
                    m_TranRepo.TransactionCount = Convert.ToInt32(dtReport.Rows[0]["TransCount"]);
                    m_TranRepo.TotalTransNetAmount = Convert.ToDouble(dtReport.Rows[0]["TransNetAmount"]);
                    m_TranRepo.TransactionDate = Convert.ToDateTime(dtReport.Rows[0]["TransDate"]);
                    if (m_TranRepo.ISMonthlyReport)
                    {
                        m_TranRepo.TransactionDateTo = Convert.ToDateTime(dtReport.Rows[0]["TransDateTo"]);
                       // m_TranRepo.Remarks = Convert.ToString(dtReport.Rows[0]["Remarks"]);
                        m_TranRepo.Remarks = Convert.ToString(dtReport.Rows[0]["Remarks"]) + Convert.ToString(m_TranRepo.TransactionDate.ToShortDateString()) + " TO " + Convert.ToString(m_TranRepo.TransactionDateTo.ToShortDateString());

                    }
                    m_TranRepo.UniNumber = SystemGlobals.UnitNumber;
                    m_TranRepo.LeaseCode = SystemGlobals.LeaseCode;
                   
                }
                else
                {
                    m_TranRepo.TransactionCount = 0;
                    m_TranRepo.TotalTransNetAmount = 0;
                    m_TranRepo.TransactionDate = m_TransactionRepo.TransactionDate;
                    m_TranRepo.TransactionDateTo = m_TransactionRepo.TransactionDateTo;
                    m_TranRepo.UniNumber = SystemGlobals.UnitNumber;
                    m_TranRepo.LeaseCode = SystemGlobals.LeaseCode;
                    m_TranRepo.Remarks = "";
                }
                bValid = TransactionReportSync(m_TranRepo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return bValid;



        }
        public static string UploadAPI(string WebAPI, string API_KEY, string JSONString)
        {
            try
            {

                Uri ApiUrl = new Uri(WebAPI);
                ServicePointManager.MaxServicePointIdleTime = 1000;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ///ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient client;
                client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers["Accept"] = "application/json";
                client.Headers["Content-type"] = "application/json";
                // if (!string.IsNullOrEmpty(API_KEY)) client.Headers["Authorization"] = "x-apikey" + API_KEY;
                if (!string.IsNullOrEmpty(API_KEY)) client.Headers["x-apikey"] = API_KEY;

                client.Encoding = Encoding.UTF8;

               // string json = client.UploadString(new Uri("https://apidev.emaar.com/etenantsales/dailysales"), "POST", JSONString);
                 string json = client.UploadString(ApiUrl, "POST", JSONString);


                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return "";
        }

        public static void StartSync(Form parent)
        {
            frmHome home = (frmHome)parent;
            home.SyncTimer.Start();
           
        }
        public static void StopSync(Form parent)
        {
            frmHome home = (frmHome)parent;
            home.SyncTimer.Stop();

        }
        public static bool ReportChecking()
        {
            bool bValid = false;
            TransactionReport m_TransactionRepo = new TransactionReport();
            DateTime DtCurrentDate = DateTime.Now;
            bool IsPreviousReportDate = false;

            TimeSpan Start = TimeSpan.Parse("20:0:0");
            TimeSpan end = TimeSpan.Parse("23:59:59");
            DateTime reportingDate=DateTime.Now;
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((DtCurrentDate.TimeOfDay >= Start) && (DtCurrentDate.TimeOfDay <= end))
            {
                reportingDate = DateTime.Now;
            }
            else if ((DtCurrentDate.TimeOfDay >= TimeSpan.Parse("0:0:1")) && (DtCurrentDate.TimeOfDay <= TimeSpan.Parse("19:59:59")))
            {
                reportingDate = DateTime.Now.AddDays(-1);
                IsPreviousReportDate = true;

            }
            m_TransactionRepo.TransactionDate = reportingDate;
            m_TransactionRepo.TransactionDateTo = reportingDate;
            m_TransactionRepo.ISDailyReport = true;

            // Synch Last day and Monthly sale
            /// Check and send last day report and Monthly at same time
            /// Monthly flag change off and send daily report
            /// m_TranRepo.ISMonthlyReport=false
            if (m_TransactionRepo.ISDailyReport)
            {
                bValid= StartSynchReportToApi(m_TransactionRepo);

            }

            //Get the number of days in the current month
            int daysInMonth = DateTime.DaysInMonth(reportingDate.Year, reportingDate.Month);

            //First day of the month is always 1
            DateTime firstDay = new DateTime(reportingDate.Year, reportingDate.Month, 1);

            //Last day will be similar to the number of days calculated above
            DateTime lastDay = new DateTime(reportingDate.Year, reportingDate.Month, daysInMonth);
            if (lastDay.ToShortDateString() == reportingDate.ToShortDateString())
            {
                m_TransactionRepo.ISDailyReport = false;
                m_TransactionRepo.ISMonthlyReport = true;
                m_TransactionRepo.TransactionDate = firstDay;
                m_TransactionRepo.TransactionDateTo = lastDay;
                bValid= StartSynchReportToApi(m_TransactionRepo);

            }
            else m_TransactionRepo.ISMonthlyReport = false;
            return bValid;
        }
        #endregion
        #endregion

    }
}
