using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XWinService.SQLConnection
{ 
    public enum SqlCommandType
    {
        StoredProcedure = 4,
        TableDirect = 512,
        Text = 1
    }

    public enum SqlConnectionType
    {
        PrimaryConnection = 1,
        SecondaryConnection,
        AnotherConnection
    }

    public enum SqlDataType
    {
        BigInt = 0,
        Binary = 1,
        Bit = 2,
        Char = 3,
        DateTime = 4,
        Decimal = 5,
        Float = 6,
        Image = 7,
        Int = 8,
        Money = 9,
        NChar = 10,
        NText = 11,
        NVarChar = 12,
        Real = 13,
        UniqueIdentifier = 14,
        SmallDateTime = 15,
        SmallInt = 16,
        SmallMoney = 17,
        Text = 18,
        Timestamp = 19,
        TinyInt = 20,
        VarBinary = 21,
        VarChar = 22,
        Variant = 23,
        Xml = 25,
        Udt = 29,
        Structured = 30,
        Date = 31,
        Time = 32,
        DateTime2 = 33,
        DateTimeOffset = 34,
        DBNULL,
        DB
    }

    public enum SqlParameterDirection
    {
        Input = 1,
        Output = 2,
        InputOutput = 3,
        ReturnValue = 6
    }
    public class SQLDataServerConnection
    {
        private SqlConnection objConn;
        private SqlConnectionStringBuilder strConBuilder;
        private static SqlConnection m_SqlPrimaryCon;
        private static SqlConnection m_sqlOtherCon;
        private static SqlTransaction m_sqlTransactionCon;


        private SqlCommand m_sqlCmdPrimary;
        private SqlCommand m_sqlCmdOther;
        private string m_PrimaryConnectionString;
        private string m_strError;
        private bool m_IsError;
        private string m_SQLQuery = "";
        public SQLDataServerConnection()
        {
            try
            {
                string strConString = "";
                if (!string.IsNullOrEmpty(ConnectionGlobal.PrimaryConnectionString))
                {
                    //m_SqlPrimaryCon = new SqlConnection(ConnectionGlobal.PrimaryConnectionString);
                    m_PrimaryConnectionString = ConnectionGlobal.PrimaryConnectionString;
                }
            }
            catch (Exception ex)
            {

            }

        }

       


        public bool OpenConnection(SqlConnectionType CnType = SqlConnectionType.PrimaryConnection, string strAnotherConnectionString = "")
        {

            bool blnIsOpen = false;
            SqlConnection con = null;
            bool bValid = false;
            try
            {
                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        if (!(m_SqlPrimaryCon != null && m_SqlPrimaryCon.State != ConnectionState.Closed))
                        {
                            bValid = true;
                            m_SqlPrimaryCon = new SqlConnection();
                            m_SqlPrimaryCon.ConnectionString = m_PrimaryConnectionString;
                            con = m_SqlPrimaryCon;
                            //DataAccess.g_SqlCon.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(g_SqlCon_InfoMessage);
                        }
                        break;
                    case SqlConnectionType.AnotherConnection:
                        bValid = true;
                        m_sqlOtherCon = new SqlConnection();
                        m_sqlOtherCon.ConnectionString = strAnotherConnectionString;
                        con = m_sqlOtherCon;
                        break;
                }
                if (bValid) con.Open();
                m_IsError = false;
                blnIsOpen = true;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("OpenConnection", ex,ProductName,CompanyName,ProductVersion);
                m_strError = "OpenConnection:: " + ex.Message;
            }
            return blnIsOpen;
        }

        
        public void CloseConnection(SqlConnectionType CnType = SqlConnectionType.PrimaryConnection)
        {
            SqlConnection con = null;
            try
            {
                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        
                            if (m_SqlPrimaryCon != null)
                            {
                                if (m_SqlPrimaryCon.State == System.Data.ConnectionState.Open) m_SqlPrimaryCon.Close();
                                m_SqlPrimaryCon.Dispose();
                                m_SqlPrimaryCon = null;
                            }
                       
                        break;

                    case SqlConnectionType.AnotherConnection:
                        if (m_sqlOtherCon != null)
                        {
                            if (m_sqlOtherCon.State == System.Data.ConnectionState.Open) m_sqlOtherCon.Close();
                            m_sqlOtherCon.Dispose();
                            m_sqlOtherCon = null;
                        }
                        break;
                }
                m_IsError = false;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("CloseConnection", ex, ProductName, CompanyName, ProductVersion);
                m_strError = "CloseConnection:: " + ex.Message;
            }
        }

        
        protected void CreateCommand(string strCmdText, SqlCommandType cmdType, SqlConnectionType CnType = SqlConnectionType.PrimaryConnection)
        {
            try
            {
                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        if (m_SqlPrimaryCon.State == System.Data.ConnectionState.Closed) m_SqlPrimaryCon.Open();
                        m_sqlCmdPrimary = new SqlCommand(strCmdText);
                        m_sqlCmdPrimary.CommandTimeout = 0;
                        m_sqlCmdPrimary.Connection = m_SqlPrimaryCon;
                        m_sqlCmdPrimary.CommandText = strCmdText;
                        m_sqlCmdPrimary.CommandType = (System.Data.CommandType)cmdType;
                        m_sqlCmdPrimary.Transaction = m_sqlTransactionCon;

                        break;
                    case SqlConnectionType.AnotherConnection:
                        m_sqlCmdOther = new SqlCommand(strCmdText);
                        m_sqlCmdOther.CommandTimeout = 0;
                        m_sqlCmdOther.Connection = m_sqlOtherCon;
                        m_sqlCmdOther.CommandText = strCmdText;
                        m_sqlCmdOther.CommandType = (System.Data.CommandType)cmdType;
                        break;
                }
                m_IsError = false;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("CreateCommand", ex, ProductName, CompanyName, ProductVersion);
                m_strError = "CreateCommand:: " + ex.Message;
            }
        }

        
        protected void DisposeCommand(SqlConnectionType CnType = SqlConnectionType.PrimaryConnection)
        {
            try
            {
                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        if (m_sqlCmdPrimary != null) m_sqlCmdPrimary.Dispose();
                        m_sqlCmdPrimary = null;
                        break;
                    case SqlConnectionType.AnotherConnection:
                        if (m_sqlCmdOther != null) m_sqlCmdOther.Dispose();
                        m_sqlCmdOther = null;
                        break;
                }
                m_IsError = false;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("DisposeCommand", ex, ProductName, CompanyName, ProductVersion);
                m_strError = "DisposeCommand " + ex.Message;
            }
        }

        
        protected SqlParameter AddParameter(string strParameterName, object ParameterValue, SqlDataType dbType, int Size,
                   SqlParameterDirection ParameterDirection = SqlParameterDirection.Input, SqlConnectionType CnType = SqlConnectionType.PrimaryConnection)
        {
            SqlParameter sqlparam = null;
            try
            {
                sqlparam = new SqlParameter();
                sqlparam.Direction = (System.Data.ParameterDirection)ParameterDirection;
                sqlparam.SqlDbType = (System.Data.SqlDbType)dbType;
                sqlparam.ParameterName = strParameterName;
                sqlparam.Size = Size;
                sqlparam.Value = ParameterValue;

                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        m_sqlCmdPrimary.Parameters.Add(sqlparam);
                        break;
                    case SqlConnectionType.AnotherConnection:
                        m_sqlCmdOther.Parameters.Add(sqlparam);
                        break;
                }
                m_IsError = false;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("AddParameter", ex, ProductName, CompanyName, ProductVersion);
                m_strError = "AddParameter:: " + ex.Message;
            }
            return sqlparam;
        }

        
        protected void ClearParameters(SqlConnectionType CnType = SqlConnectionType.PrimaryConnection)
        {
            try
            {
                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        m_sqlCmdPrimary.Parameters.Clear();
                        break;
                    case SqlConnectionType.AnotherConnection:
                        m_sqlCmdOther.Parameters.Clear();
                        break;
                }
                m_IsError = false;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("ClearParameters", ex, ProductName, CompanyName, ProductVersion);
                m_strError = "ClearParameters:: " + ex.Message;
            }
        }

        protected object GetParameterValue(string ParameterName)
        {
            return m_sqlCmdPrimary.Parameters[ParameterName].Value; ;
        }

        public DataTable FillDataTable(SqlConnectionType CnType = SqlConnectionType.PrimaryConnection)
        {
            DataTable dttbl = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            try
            {
                switch (CnType)
                {
                    case SqlConnectionType.PrimaryConnection:
                        sqlDataAdapter.SelectCommand = m_sqlCmdPrimary;
                        break;
                    case SqlConnectionType.AnotherConnection:
                        sqlDataAdapter.SelectCommand = m_sqlCmdOther;
                        break;
                }
                sqlDataAdapter.Fill(dttbl);
                m_IsError = false;
            }
            catch (Exception ex)
            {
                m_IsError = true;
                //ExceptionLog.WriteErrorLog("FillDataTable", ex, ProductName, CompanyName, ProductVersion);
                m_strError = "FillDataTable:: " + ex.Message;
            }
            return dttbl;
        }
    }
}