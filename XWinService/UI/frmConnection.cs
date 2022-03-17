using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XWinService.BL;
using XWinService.Global;
using XWinService.UI;

namespace XWinService
{
    enum WorkOption
    {
        Save = 1,
        Get = 2,
        Search = 3,
    }
    public partial class frmConnection : Form
    {

        #region Member Variables
        //Data Source=DESKTOP-9J3B7U7\SQLEXPRESS;Initial Catalog=GMS;User ID=sa;Password=***********
        private SqlConnectionStringBuilder m_ConString;
        private SQLDBConnection m_DBConnection;
        private BindingSource m_BindingSource;
        private ErrorProvider m_ErrorProvider;
        private List<WindowsFocusControls> m_FocusControlsList;
        private int ActionOption = 0;
        frmDialouge Dialogue;
        private Thread CThread;

        #endregion

        #region Constructor
        public frmConnection()
        {
            InitializeComponent();
          
        }
        #endregion

        #region Method
        private void Init()
        {
            m_BindingSource = new BindingSource();
            errorProvider.DataSource = m_BindingSource;
            NewConnection();
            SetProperties();
            AddProperties();
        }
       private void NewConnection()
        {
            m_DBConnection = new SQLDBConnection();
            m_BindingSource.DataSource = m_DBConnection;
            m_BindingSource.ResetCurrentItem();


        }

        private void SetProperties()
        {
            txtServerName.DataBindings.Add("Text", m_BindingSource, "ServerName");
            txtDB.DataBindings.Add("Text", m_BindingSource, "DataBase");
            txtUserName.DataBindings.Add("Text", m_BindingSource, "UserName");
            txtPassword.DataBindings.Add("Text", m_BindingSource, "Password");
           
        }
        private void AddProperties()
        {
            m_FocusControlsList = new List<WindowsFocusControls>();
            m_FocusControlsList.Add(new WindowsFocusControls(txtServerName, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtDB, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtUserName, 0));
            m_FocusControlsList.Add(new WindowsFocusControls(txtPassword, 0));
        
        }

        private void ConnectionSave()
        {
            try
            {

                m_ConString = new SqlConnectionStringBuilder();
                m_ConString.DataSource = m_DBConnection.ServerName;
                m_ConString.InitialCatalog = m_DBConnection.DataBase;
                m_ConString.UserID = m_DBConnection.UserName;
                m_ConString.Password = m_DBConnection.Password;

                SqlConnection con = new SqlConnection(m_ConString.ConnectionString);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    //m_DBConnection.Password = Crypto.Encript(m_DBConnection.Password);
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\XSConnection");
                    key.SetValue("Connection", Crypto.Encript(m_ConString.ConnectionString));
                    key.SetValue("ServerName", Crypto.Encript(m_DBConnection.ServerName));
                    key.SetValue("DataBaseName", Crypto.Encript(m_DBConnection.DataBase));
                    key.SetValue("UserName", Crypto.Encript(m_DBConnection.UserName));
                    key.SetValue("Password", Crypto.Encript(m_DBConnection.Password));
                    //key.SetValue("ShowAgain", m_DBConnection.NeverShow);
                    //this.DialogResult = DialogResult.OK;
                }
                else
                {

                    //this.DialogResult = DialogResult.Cancel;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Server Error","Invalid Server!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void ReadConnection()
        {
            m_ConString = new SqlConnectionStringBuilder();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\XSConnection");
            if (key.ValueCount > 0)
            {
                key.GetValue("Connection");
                m_ConString.DataSource = m_DBConnection.ServerName = Crypto.Decript((string)key.GetValue("ServerName"));
                m_ConString.InitialCatalog = m_DBConnection.DataBase = Crypto.Decript((string)key.GetValue("DataBaseName"));
                m_ConString.UserID = m_DBConnection.UserName = Crypto.Decript((string)key.GetValue("UserName"));
                m_DBConnection.Password = Crypto.Decript((string)key.GetValue("Password"));
                m_ConString.Password = m_DBConnection.Password;
                //m_DBConnection.NeverShow = Convert.ToBoolean(key.GetValue("ShowAgain"));


                SqlConnection con = new SqlConnection(m_ConString.ConnectionString);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                }
                m_BindingSource.DataSource = m_DBConnection;
            }
        }
        #endregion
        private void frmConnection_Load(object sender, EventArgs e)
        {
            Init();
            // backgroundWorkerCon.Dispose();
            //  backgroundWorkerCon = new BackgroundWorker();
            // if (backgroundWorkerCon.IsBusy && backgroundWorkerCon.WorkerSupportsCancellation) { CThread = Thread.CurrentThread; CThread.Abort(); }
            if (backgroundWorkerCon.IsBusy) {  MessageBox.Show("Work in progress"); Task.Delay(15000); }
            Thread.Sleep(100);
            //ReadConnection();
            ActionOption = (int)WorkOption.Get;
            backgroundWorkerCon.RunWorkerAsync();

            Dialogue = new frmDialouge(" Loading......");
            Dialogue.ShowDialog();



        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            backgroundWorkerCon.RunWorkerAsync();
            ActionOption = (int)WorkOption.Save;
            Dialogue = new frmDialouge(" Saving......");
            Dialogue.ShowDialog();

          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(ActionOption ==(int)WorkOption.Get)
            ReadConnection();
            else if(ActionOption==(int)WorkOption.Save)
                ConnectionSave();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_BindingSource.ResetCurrentItem();
            Dialogue.Close();
        }

        private void frmConnection_Shown(object sender, EventArgs e)
        {
           
        }
    }
}
