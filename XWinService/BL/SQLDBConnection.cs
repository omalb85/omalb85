using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XWinService.Global;

namespace XWinService.BL
{
  public  class SQLDBConnection
    {

        
            public string ServerName { get; set; }
            public string DataBase { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool NeverShow { get; set; }



            public static void CheckDbConnection(RegistryKey Rkey)
            {
                string ConPass = "";
                RegistryKey key = Rkey;
                SqlConnectionStringBuilder m_ConString = new SqlConnectionStringBuilder();
                if (key.ValueCount > 0)
                    m_ConString.DataSource = (string)key.GetValue("ServerName");
                m_ConString.InitialCatalog = (string)key.GetValue("DataBaseName");
                m_ConString.UserID = (string)key.GetValue("UserID");
                ConPass = (string)key.GetValue("Password");
                m_ConString.Password = Crypto.Decript(ConPass);
                SqlConnection con = new SqlConnection(m_ConString.ConnectionString);
                con.Open();

            }
        
    }
}
