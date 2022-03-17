using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class TransDailyReportJson
    {

       public string UnitNo
        {
            get;
            set;
        }
        public string LeaseCode
        {
            get;
            set;
        }
        public string SalesDate
        {

            get;
            set;

        }
       
        public string TransactionCount
        {
            get;
            set;
        }
        public string NetSales
        {
            get;
            set;
        }


    }

    public class TransMonthlyReportJson
    {

        public string UnitNo
        {
            get;
            set;
        }
        public string LeaseCode
        {
            get;
            set;
        }
        public string SalesDateFrom
        {

            get;
            set;

        }
        public string SalesDateTo
        {

            get;
            set;

        }
        public string TransactionCount
        {
            get;
            set;
        }
        public string TotalSales
        {
            get;
            set;
        }
        public string Remarks { get; set; }


    }

    public class TransJsonResult
    {
        public string Code { get; set; }
        public string Result { get; set; }
        public string ErrorMsg { get; set; }
    }
}
