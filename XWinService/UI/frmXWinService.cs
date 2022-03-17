using BL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XWinService.BL;
using XWinService.Global;
using XWinService.UI;

namespace XWinService
{
   
   
    public partial class frmXWinService : Form
    {
        #region Member Variables
        private ApiConnection m_ApiConnection ;
        private BindingSource m_BindingSource;
        private ErrorProvider m_ErrorProvider;
        private List<WindowsFocusControls> m_FocusControlsList;
        private frmDialouge Dialogue;
        private int workOption;
        Form ParentForm = null;

        #endregion

        #region Constructor
        public frmXWinService(Form frmParent=null)
        {
            InitializeComponent();
            ParentForm = frmParent;


        }
        #endregion

        #region Methods


        private void Init()
        {
            m_BindingSource = new BindingSource();
            NewApiConnection();
            SetProperties();
            AddProperties();
            SaveXmlData();
        }
        private void NewApiConnection()
        {
            m_ApiConnection = new ApiConnection();
            m_ApiConnection.ApiSyncStartDate = DateTime.Now;
            m_ApiConnection.SheduledTime = DateTime.Now;
            m_BindingSource.DataSource = m_ApiConnection;
            m_BindingSource.ResetCurrentItem();
        }
        private void SetProperties()
        {
            txtAPID.DataBindings.Add("Text", m_BindingSource, "API_D");
            txtAPIKeyD.DataBindings.Add("Text", m_BindingSource, "API_Key_D");
            txtSecretD.DataBindings.Add("Text", m_BindingSource, "SecretKey_D");
            txtAPIM.DataBindings.Add("Text", m_BindingSource, "API_M");
            txtAPIKEYM.DataBindings.Add("Text", m_BindingSource, "API_Key_M");
            txtSecurityM.DataBindings.Add("Text", m_BindingSource, "SecretKey_M");
            txtUnitNumber.DataBindings.Add("Text", m_BindingSource, "UnitNumber");
            txtLeaseCode.DataBindings.Add("Text", m_BindingSource, "LeaseCode");
            dtSyncStartDate.DataBindings.Add("Text", m_BindingSource, "ApiSyncStartDate");
            dtTimeStamp.DataBindings.Add("Text", m_BindingSource, "SheduledTimeStr");
            chkEnableSync.DataBindings.Add("Checked", m_BindingSource, "StartSync");
        }
        private void AddProperties()
        {
            m_FocusControlsList = new List<WindowsFocusControls>();
            m_FocusControlsList.Add(new WindowsFocusControls(txtAPID, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtAPIKeyD, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtSecretD, 0));
          

        }
        private void ApiSettingSave()
        {
            try
            {
                              
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\XSConnection\ApiSettings");
                    key.SetValue("API_D", Crypto.Encript(m_ApiConnection.API_D));
                    key.SetValue("API_Key_D", Crypto.Encript(m_ApiConnection.API_Key_D));
                    key.SetValue("SecretKey_D", Crypto.Encript(m_ApiConnection.SecretKey_D));

                key.SetValue("API_M", Crypto.Encript(m_ApiConnection.API_M));
                key.SetValue("API_Key_M", Crypto.Encript(m_ApiConnection.API_Key_M));
                key.SetValue("SecretKey_M", Crypto.Encript(m_ApiConnection.SecretKey_M));

                key.SetValue("Unitnumber", Crypto.Encript(m_ApiConnection.Unitnumber));
                key.SetValue("LeaseCode", Crypto.Encript(m_ApiConnection.LeaseCode));
                key.SetValue("ApiSyncStartDate", Crypto.Encript(m_ApiConnection.ApiSyncStartDate.ToString()));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void ReadConnection()
        {
            
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\XSConnection\ApiSettings");
            if (key.ValueCount > 0)
            {
                key.GetValue("ApiSettings");
                m_ApiConnection.API_D = Crypto.Decript((string)key.GetValue("API_D"));
                m_ApiConnection.API_Key_D =Crypto.Decript((string)key.GetValue("API_Key_D"));
                m_ApiConnection.SecretKey_D= Crypto.Decript((string)key.GetValue("SecretKey_D"));
                m_ApiConnection.API_M = Crypto.Decript((string)key.GetValue("API_M"));
                m_ApiConnection.API_Key_M = Crypto.Decript((string)key.GetValue("API_Key_M"));
                m_ApiConnection.SecretKey_M = Crypto.Decript((string)key.GetValue("SecretKey_M"));
                if (!string.IsNullOrEmpty(Crypto.Decript((string)key.GetValue("Unitnumber"))))
                m_ApiConnection.Unitnumber = Crypto.Decript((string)key.GetValue("Unitnumber"));
                if (!string.IsNullOrEmpty(Crypto.Decript((string)key.GetValue("LeaseCode"))))
                    m_ApiConnection.LeaseCode = Crypto.Decript((string)key.GetValue("LeaseCode"));
                //MessageBox.Show((string)key.GetValue("SecretKey"));
                if(!string.IsNullOrEmpty(Crypto.Decript((string)key.GetValue("ApiSyncStartDate"))))
                m_ApiConnection.ApiSyncStartDate = Convert.ToDateTime(Crypto.Decript((string)key.GetValue("ApiSyncStartDate")));

                m_BindingSource.DataSource = m_ApiConnection;
                m_BindingSource.ResetCurrentItem();
            }
        }


        private bool SaveConfigSettings()
        {
            bool bValid = true;
            System.Xml.XmlWriter xmlWr;
            string strXMLFile = "XmlSettings.xml";
            Type type = m_ApiConnection.GetType();
            PropertyInfo[] Setproperties = type.GetProperties();

            try
            {
                xmlWr = System.Xml.XmlWriter.Create(strXMLFile);

                xmlWr.WriteStartDocument();

                xmlWr.WriteStartElement("ServiceSettings");
                foreach (PropertyInfo property in Setproperties)
                {
                    xmlWr.WriteElementString(property.Name, Crypto.Encript((property.GetValue(m_ApiConnection, null)).ToString()));
                }
                xmlWr.WriteEndElement();
                xmlWr.WriteEndDocument();

                xmlWr.Flush();
                xmlWr.Close();

                SystemGlobals.SheduledTime = m_ApiConnection.SheduledTime;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("SaveConfigSettings : "+ex.Message.ToString());

                bValid = false;
            }
            return bValid;

        }

        private ApiConnection SaveXmlData()
        {
            
            //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //System.Xml.XmlTextReader treader = new System.Xml.XmlTextReader("XmlSettings.xml");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load("XmlSettings.xml");
            //System.Xml.XmlNode child = doc.SelectSingleNode("/ServiceSettings");
            //if (child != null)
            //{
            //    System.Xml.XmlNodeReader nr = new System.Xml.XmlNodeReader(child);
            //    //while (nr.Read())
            //    //    Console.WriteLine(nr.Name+"-----" +nr.Value);
            //}
            //XmlNodeReader NodeReader = new XmlNodeReader(doc);
            //XmlReaderSettings settings = new XmlReaderSettings();
            //settings.ValidationType = ValidationType.Schema;
            //XmlReader xmlreader = XmlReader.Create(NodeReader, settings);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/ServiceSettings");
            foreach (XmlNode node in nodes)
            {

                //costCode = node.Attributes["Id"].InnerText;
                //uprn = node.Attributes["Uprn"].InnerText;

                if (node["Unitnumber"]!=null) m_ApiConnection.Unitnumber = Crypto.Decript(Convert.ToString(node["Unitnumber"].InnerText));
                if (node["LeaseCode"]!=null) m_ApiConnection.LeaseCode = Crypto.Decript(Convert.ToString(node["LeaseCode"].InnerText));
                if (node["ApiSyncStartDate"]!=null)
                    if (IsDate(Crypto.Decript(Convert.ToString(node["ApiSyncStartDate"].InnerText))))
                    {
                        m_ApiConnection.ApiSyncStartDate = Convert.ToDateTime(Crypto.Decript(Convert.ToString(node["ApiSyncStartDate"].InnerText)));
                    }

                if (node["API_D"]!=null) m_ApiConnection.API_D = Crypto.Decript(Convert.ToString((node["API_D"].InnerText)));
                if (node["API_Key_D"]!=null) m_ApiConnection.API_Key_D = Crypto.Decript(Convert.ToString((node["API_Key_D"].InnerText)));
                if (node["SecretKey_D"]!=null) m_ApiConnection.SecretKey_D = Crypto.Decript(Convert.ToString(node["SecretKey_D"].InnerText));

                if (node["API_M"]!=null) m_ApiConnection.API_M = Crypto.Decript(Convert.ToString(node["API_M"].InnerText));
                if (node["API_Key_M"]!=null) m_ApiConnection.API_Key_M = Crypto.Decript(Convert.ToString(node["API_Key_M"].InnerText));
                if (node["SecretKey_M"]!=null) m_ApiConnection.SecretKey_M = Crypto.Decript(Convert.ToString(node["SecretKey_M"].InnerText));


                if (node["SheduledTime"]!=null)
                    if (IsDate(Crypto.Decript(Convert.ToString(node["SheduledTime"].InnerText))))
                    {
                        m_ApiConnection.SheduledTime = Convert.ToDateTime(Crypto.Decript(Convert.ToString(node["SheduledTime"].InnerText)));
                    }

                if (node["StartSync"]!=null)
                {

                    m_ApiConnection.StartSync = Convert.ToBoolean(Crypto.Decript(node["StartSync"].InnerText.ToString()));
                }
                else
                    m_ApiConnection.StartSync = false;
            }

            return m_ApiConnection;



        }
        private ApiConnection GetSettings()
        {
          
            try
            {
               
                DataSet dsSetting = new DataSet();
                DataTable dtSettings = null;
                string strXMLFile = "XmlSettings.xml";
                if (!System.IO.File.Exists(strXMLFile))
                    return m_ApiConnection;

                dsSetting.ReadXml(strXMLFile);
                dtSettings = dsSetting.Tables[0];
                if (dtSettings.Rows.Count > 0)
                {
                    m_ApiConnection.Unitnumber = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["Unitnumber"]));
                    m_ApiConnection.LeaseCode = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["LeaseCode"]));
                    if (dtSettings.Columns.Contains("ApiSyncStartDate"))
                        if (IsDate(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["ApiSyncStartDate"]))))
                        {
                            m_ApiConnection.ApiSyncStartDate = Convert.ToDateTime(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["ApiSyncStartDate"])));
                        }

                    if (dtSettings.Columns.Contains("API_D")) m_ApiConnection.API_D = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_D"]));
                    if (dtSettings.Columns.Contains("API_Key_D")) m_ApiConnection.API_Key_D = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_Key_D"]));
                    if (dtSettings.Columns.Contains("SecretKey_D")) m_ApiConnection.SecretKey_D = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SecretKey_D"]));

                    if (dtSettings.Columns.Contains("API_M")) m_ApiConnection.API_M = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_M"]));
                    if (dtSettings.Columns.Contains("API_Key_M")) m_ApiConnection.API_Key_M = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["API_Key_M"]));
                    if (dtSettings.Columns.Contains("SecretKey_M")) m_ApiConnection.SecretKey_M = Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SecretKey_M"]));


                    if (dtSettings.Columns.Contains("SheduledTime"))
                        if (IsDate(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SheduledTime"]))))
                        {
                            m_ApiConnection.SheduledTime = Convert.ToDateTime(Crypto.Decript(Convert.ToString(dtSettings.Rows[0]["SheduledTime"])));
                        }

                    if (dtSettings.Columns.Contains("StartSync"))
                    {
                        
                        m_ApiConnection.StartSync = Convert.ToBoolean(Crypto.Decript(dtSettings.Rows[0]["StartSync"].ToString()));
                    }
                    else
                        m_ApiConnection.StartSync = false;
                }
                dsSetting.Dispose();
                dtSettings.Dispose();
               // m_BindingSource.ResetCurrentItem();
            }
            catch(Exception ex)
            {
             
            }
            return m_ApiConnection;
        }

        public static bool IsDate(string strDate)
        {
            bool IsValid = false;
            DateTime dateValue;

            if (DateTime.TryParse(strDate, out dateValue)) IsValid = true;

            return IsValid;
        }
        #region Events
        private void frmXWinService_Load(object sender, EventArgs e)
        {
            Init();
            // ReadConnection();

            //workOption = (int)WorkOption.Get;
            //backgroundWorker.RunWorkerAsync();
            //Dialogue = new frmDialouge(" Loading......");
            //Dialogue.ShowDialog();
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            workOption = (int)WorkOption.Save;
            backgroundWorker.RunWorkerAsync();
            Dialogue = new frmDialouge(" Saving......");
            Dialogue.ShowDialog();
            if(SystemGlobals.StartSync=true)
            {
               
                TransactionReport.StartSync(ParentForm);
            }
            else TransactionReport.StopSync(ParentForm);
        }


        #endregion

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { if (workOption == (int)WorkOption.Get) //GetSettings();
                SaveXmlData();
                if (workOption == (int)WorkOption.Save) if (SaveConfigSettings())
                {
                    SystemGlobals.SetGlobalSettings();

                }


        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
            m_BindingSource.ResetCurrentItem();
            Dialogue.Close();
        }
    }
}
