using BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XWinService.Global;
using XWinService.SQLConnection;


namespace XWinService.UI
{
    public partial class frmTransactionReportSynch : Form
    {
        #region Member Variables

        TransactionReport m_TranRepo;
        private BindingSource m_BindingSource;
        private ErrorProvider m_ErrorProvider;
        private List<WindowsFocusControls> m_FocusControlsList;
        List<TransactionReport> l1 = new List<TransactionReport>();
        TransDailyReportJson objReportJson;
        private frmDialouge Dialogue;
        private int workOption;
        private bool CurrentMonth = false;

        #endregion

        #region Constructor

        public frmTransactionReportSynch()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region Methods

        private void Init()
        {
            m_BindingSource = new BindingSource();
            NewTransReport();
            SetProperties();
            AddProperties();
        }

        private void NewTransReport()
        {
            m_TranRepo = new TransactionReport();
            m_TranRepo.TransactionDate = DateTime.Now;
            m_TranRepo.TransactionDateTo = DateTime.Now;
            m_TranRepo.UniNumber = SystemGlobals.UnitNumber;
            m_TranRepo.LeaseCode = SystemGlobals.LeaseCode;
            m_TranRepo.ISDailyReport = true;
            rbDailyRepo.Checked = true;
            SetReportType();
            m_BindingSource.DataSource = m_TranRepo;
            SErrorProvider.DataSource = m_BindingSource;
            m_BindingSource.ResetCurrentItem();
          
        }
        private void SetProperties()
        {

            //******************Daily ******************************************
            txtUnitNumber.DataBindings.Add("Text", m_BindingSource, "UniNumber");
            txtLeaseCode.DataBindings.Add("Text", m_BindingSource, "LeaseCode");
            txtTransCount.DataBindings.Add("Text", m_BindingSource, "TransactionCount");
            txtTransNetAmount.DataBindings.Add("Text", m_BindingSource, "TotalTransNetAmount");
            dtTranDate.DataBindings.Add("Text", m_BindingSource, "TransactionDate");
            rbDailyRepo.DataBindings.Add("Checked", m_BindingSource, "ISDailyReport");
            rbMonthlyRepo.DataBindings.Add("Checked", m_BindingSource, "ISMonthlyReport");
            dtTransDateTo.DataBindings.Add("Text", m_BindingSource, "TransactionDateTo");
            txtRemarks.DataBindings.Add("Text", m_BindingSource, "Remarks");


        }
        private void AddProperties()
        {
            m_FocusControlsList = new List<WindowsFocusControls>();
            m_FocusControlsList.Add(new WindowsFocusControls(lblUnitNumber, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtLeaseCode, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtTransCount, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtTransNetAmount, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(dtTranDate, 0));


        }

        private void Log(string logMessage, StreamWriter stWriter)
        {
            try
            {
               // stWriter.Write("\r\n Report  ");
               if( m_TranRepo.ISDailyReport) stWriter.WriteLine("Daily Transaction Report");
                if (m_TranRepo.ISMonthlyReport) stWriter.WriteLine("Monthly Transaction Report");

                stWriter.WriteLine("Last Sync Time :{0},Last Sync Date: {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                stWriter.WriteLine("UnitNumber  :{0}",m_TranRepo.UniNumber);
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

        private void SigleLineLog(string logMessage, StreamWriter stWriter)
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

        public  void WriteLog(string strLog)
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
                //Log(strLog, log);
                SigleLineLog(strLog, log);
                log.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Events

        private void frmTransactionReportSynch_Load(object sender, EventArgs e)
        {
            //DateTimePicker dtPicker = new DateTimePicker();
            //dtPicker.Location = new Point(190, 53);
            //dtPicker.Size = new Size(252, 40);
            //dtPicker.MaxDate = new DateTime(2500, 12, 20);
            //dtPicker.MinDate = new DateTime(1753, 1, 1);
            //dtPicker.Format = DateTimePickerFormat.Long;
            //dtPicker.Name = "MyPicker";
            //dtPicker.Font = new Font("Tahoma", 12);
            //dtPicker.Visible = true;
            //dtPicker.Value = DateTime.Today;

            //pnlformCtrl.Controls.Add(dtPicker);
        }


        #endregion
        private void ShowReport()
        {
           
            SErrorProvider.Clear();
            SErrorProvider.UpdateBinding();
            if (m_TranRepo.ValidateReport())
            {
                DataTable dt = m_TranRepo.GetTransactionReport();
                if (dt.Rows.Count > 0)
                {
                    m_TranRepo.TransactionCount = Convert.ToInt32(dt.Rows[0]["TransCount"]);
                    m_TranRepo.TotalTransNetAmount = Convert.ToDouble(dt.Rows[0]["TransNetAmount"]);
                    m_TranRepo.TransactionDate = Convert.ToDateTime(dt.Rows[0]["TransDate"]);
                    if (m_TranRepo.ISMonthlyReport)
                    {
                        m_TranRepo.TransactionDateTo = Convert.ToDateTime(dt.Rows[0]["TransDateTo"]);
                        m_TranRepo.Remarks = Convert.ToString(dt.Rows[0]["Remarks"])+ Convert.ToString(m_TranRepo.TransactionDate.ToShortDateString())+" TO "+ Convert.ToString(m_TranRepo.TransactionDateTo.ToShortDateString());
                    }
                    m_TranRepo.UniNumber = SystemGlobals.UnitNumber;
                    m_TranRepo.LeaseCode = SystemGlobals.LeaseCode;

                }
                else
                {
                    m_TranRepo.TransactionCount = 0;
                    m_TranRepo.TotalTransNetAmount = 0;
                    //m_TranRepo.TransactionDate = Convert.ToDateTime(dt.Rows[0]["TransDate"]);
                    if (m_TranRepo.ISMonthlyReport)
                    {
                        // m_TranRepo.TransactionDateTo = Convert.ToDateTime(dt.Rows[0]["TransDateTo"]);
                        m_TranRepo.Remarks = "";
                    }
                    m_TranRepo.UniNumber = SystemGlobals.UnitNumber;
                    m_TranRepo.LeaseCode = SystemGlobals.LeaseCode;

                }
            }
            else
            {
                if(!string.IsNullOrEmpty(m_TranRepo.ErrorMessage))
                MessageBox.Show(m_TranRepo.ErrorMessage);
               
                var ctrlName = m_TranRepo.SetError(pnlDaily, m_TranRepo.ErrorPopertyName);
                if(ctrlName!=null)SErrorProvider.SetError(m_TranRepo.SetError(pnlDaily, m_TranRepo.ErrorPopertyName), m_TranRepo.ErrorMessage);
                //else MessageBox.Show(m_TranRepo.ErrorMessage);

            }
          
            //gvReport.DataSource = dt;

        }

        private void SyncReport()
        {
            DataTable dt = m_TranRepo.GetTransactionReport();
            if (dt.Rows.Count > 0)
            {
                m_TranRepo.TransactionCount = Convert.ToInt32(dt.Rows[0]["TransCount"]);
                m_TranRepo.TotalTransNetAmount = Convert.ToDouble(dt.Rows[0]["TransNetAmount"]);
                m_TranRepo.TransactionDate = Convert.ToDateTime(dt.Rows[0]["TransDate"]);
                if (m_TranRepo.ISMonthlyReport)
                {
                    m_TranRepo.TransactionDateTo = Convert.ToDateTime(dt.Rows[0]["TransDateTo"]);
                    m_TranRepo.Remarks = Convert.ToString(dt.Rows[0]["Remarks"]);
                }
                m_TranRepo.UniNumber = SystemGlobals.UnitNumber;
                m_TranRepo.LeaseCode = SystemGlobals.LeaseCode;

            }
            var json = TransactionReportSync();
            WriteLog(json);
        }
        private void btnPush_Click(object sender, EventArgs e)
        {
            workOption = (int)WorkOption.Save;
            backgroundWorker.RunWorkerAsync();
            Dialogue = new frmDialouge("Sending Report......");
            Dialogue.ShowDialog();

        }


        public static string UploadAPI(string WebAPI, string API_KEY, string JSONString)
        {
            try
            {

                Uri ApiUrl = new Uri(WebAPI);
                ServicePointManager.MaxServicePointIdleTime = 1000;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return "";
        }
        private string SetSyncData()
        {
            string SyncDatajson = "";
            if(m_TranRepo.ISDailyReport)
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


        private string TransactionReportSync()
        {
            string Result = "";
            string response = "";
            string ApiKEY = "";
            try
            {
                string json = SetSyncData();
                string ApiUriString = "";
                
                if (m_TranRepo.ISDailyReport) { ApiUriString = SystemGlobals.API_D; ApiKEY = SystemGlobals.API_KEY_D; }
                else if (m_TranRepo.ISMonthlyReport) { ApiUriString = SystemGlobals.API_M; ApiKEY = SystemGlobals.API_KEY_M; }
                Result = UploadAPI(ApiUriString, ApiKEY, json);
               // Result = UploadAPI(ApiUriString, SystemGlobals.API_KEY_D, json);
                //HttpClientPushData("https://apidev.emaar.com/etenantsales/dailysales", json, "AlXBRGgn4diHVloG0oiSeq3MEA2AWhw0");
            }
            catch(Exception ex)
            {
               
            var obj = new
            {
               Code = "500", Result = "Internal Server Error", ErrorMsg = "Internal Server Error"

            };
                Result = JsonConvert.SerializeObject(obj);
                

            }
            TransJsonResult Traresults = JsonConvert.DeserializeObject<TransJsonResult>(Result);
            if (Traresults != null) response = string.Format("Code :{0},Result :{1},ErrorMsg :{2}", Traresults.Code, Traresults.Result, Traresults.ErrorMsg);
            return response; 
        }



        

        private void button1_Click(object sender, EventArgs e)
        {
            // var obj = new
            // {
            //     SalesDataCollection = new
            //     {
            //         SalesInfo = new dynamic[] {
            //                     new { UnitNo = "TDM-FF-184", LeaseCode = "t0014942",SalesDate="2021-09-21",TransactionCount="5",NetSales="5959"}

            //             }
            //     }
            // };
            // var json = JsonConvert.SerializeObject( obj, Formatting.Indented);
            //HttpContent c = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Uri u = new Uri("https://apidev.emaar.com/etenantsales/dailysales");

            // //HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
            // var t = Task.Run(() => WebPostURI(u, c));
            // t.Wait();

            // Console.WriteLine(t.Result);
            // Console.ReadLine();
           // httpClientApiSync();

        }

       private void MonthSettings()
        {
            DateTime dt = DateTime.Now;
            if (!rdCurrentMonth.Checked)dt= dt.AddMonths(-1);
            if (rdCurrentMonth.Checked) dt = DateTime.Now;
            //Get the number of days in the current month
            int daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);

            //First day of the month is always 1
            DateTime firstDay = new DateTime(dt.Year, dt.Month, 1);

            //Last day will be similar to the number of days calculated above
            DateTime lastDay = new DateTime(dt.Year,dt.Month, daysInMonth);

            m_TranRepo.TransactionDate = firstDay;
            m_TranRepo.TransactionDateTo = lastDay;
            m_BindingSource.ResetCurrentItem();

        }

        private void SetReportType()
        {
            m_BindingSource.EndEdit();
            if(rbDailyRepo.Checked)
            { 
                dtTransDateTo.Enabled = false;
                txtRemarks.ReadOnly = true;
                m_TranRepo.ISDailyReport = true;
                rdCurrentMonth.Visible = false;
                m_TranRepo.Remarks = "";
            }
            else
            {
                dtTransDateTo.Enabled = true;
                txtRemarks.ReadOnly = false;
                m_TranRepo.ISMonthlyReport = true;
                if (m_TranRepo.ISMonthlyReport) rdCurrentMonth.Visible = true;
                MonthSettings();

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            workOption = (int)WorkOption.Get;
            backgroundWorker.RunWorkerAsync();
            Dialogue = new frmDialouge(" Loading......");
            Dialogue.ShowDialog();
           
        }

        private void rbDailyRepo_CheckedChanged(object sender, EventArgs e)
        {
            SetReportType();
        }

        private void rbMonthlyRepo_CheckedChanged(object sender, EventArgs e)
        {
            SetReportType();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (workOption == (int)WorkOption.Get) ShowReport();
            if (workOption == (int)WorkOption.Save) SyncReport();
                
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_BindingSource.ResetCurrentItem();

            Dialogue.Close();
        }

        private void rdCurrentMonth_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMonth = true;
          

            //rdCurrentMonth.Checked = !rdCurrentMonth.Checked;
            SetReportType();
        }

        private void rdPrevious_CheckedChanged(object sender, EventArgs e)
        {
            SetReportType();
        }

        private void rdCurrentMonth_Click(object sender, EventArgs e)
        {
            if (CurrentMonth) CurrentMonth = !rdCurrentMonth.Checked;
            else rdCurrentMonth.Checked = CurrentMonth;
        }

        private void pnlDaily_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTransactionReportSynch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)

                backgroundWorker.CancelAsync();
        }
    }
}
