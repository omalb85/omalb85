using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XWinService.BL
{
   public class ApiConnection
    {
        #region Member variables
        private string m_API_D;

        private string m_API_Key_D;

        private string m_SecretKey_D;

        private string m_API_M;

        private string m_API_Key_M;

        private string m_SecretKey_M;

        private DateTime m_ApiSyncStartDate;

        private string m_UnitNumber;
        private string m_LeaseCode;
        private DateTime m_SheduledTime;

        private string m_SheduledTimeStr;

        private bool m_StartSync;


        #endregion

        #region Properties

        public string SecretKey_D
        {
            get { return m_SecretKey_D; }
            set { m_SecretKey_D = value; }
        }

        public string API_Key_D
        {
            get { return m_API_Key_D; }
            set { m_API_Key_D = value; }
        }


        public string API_D
        {
            get { return m_API_D; }
            set { m_API_D = value; }
        }

        public string LeaseCode
        {
            get { return m_LeaseCode; }
            set { m_LeaseCode = value; }
        }


        public string Unitnumber
        {
            get { return m_UnitNumber; }
            set { m_UnitNumber = value; }
        }


        public DateTime ApiSyncStartDate
        {
            get { return m_ApiSyncStartDate; }
            set { m_ApiSyncStartDate = value; }
        }

        public DateTime SheduledTime
        {
            get { return m_SheduledTime; }
            set
            {
                m_SheduledTime = value;
                m_SheduledTimeStr  = m_SheduledTime.ToString();

            }
        }

        public string SheduledTimeStr
        {
            get { return m_SheduledTimeStr; }
            set
            {

                m_SheduledTimeStr = value;
                if (IsDate(m_SheduledTimeStr))
                {
                    m_SheduledTime = Convert.ToDateTime(m_SheduledTimeStr);
                }
            }
        }


        public bool StartSync
        {
            get { return m_StartSync; }
            set { m_StartSync = value; }
        }

        

        public string API_M
        {
            get
            {
                return m_API_M;
            }

            set
            {
                m_API_M = value;
            }
        }

        public string API_Key_M
        {
            get
            {
                return m_API_Key_M;
            }

            set
            {
                m_API_Key_M = value;
            }
        }

        public string SecretKey_M
        {
            get
            {
                return m_SecretKey_M;
            }

            set
            {
                m_SecretKey_M = value;
            }
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
        #endregion


    }
}
