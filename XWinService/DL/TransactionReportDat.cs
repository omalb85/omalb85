using BL;
using System;
using System.Data;
using XWinService.SQLConnection;

namespace XWinService.DL
{
    public class TransactionReportDat :SQLDataServerConnection
    {
        public DataTable GetTransactionReport(TransactionReport obj)
        {
            DataTable dt=null;
            string SQLText = "";
            string WHERE = "";
            string GROUPBY = "";
            string Columns = "";
            if (obj.ISDailyReport)
            {
                Columns = " CONVERT(DATE,invdate)  AS TransDate";
                 WHERE = "WHERE CONVERT(DATE,invdate)=CONVERT(DATE,@InvDate) ";
                GROUPBY = "GROUP BY CONVERT(DATE,invdate)";
            }
            else
            {
                Columns = "YEAR(invdate)[Year], MONTH(invdate)[month],DATENAME(MONTH, invdate)[MonthName],CONVERT(DATE,@InvDate) AS TransDate,CONVERT(DATE,@InvDateTo) AS TransDateTo,'Sales Report' AS Remarks";
                WHERE = "WHERE (CONVERT(DATE,invdate) BETWEEN CONVERT(DATE,CAST(@InvDate AS VARCHAR(20))) AND CONVERT(DATE,CAST(@InvDateTo AS VARCHAR(20)))) ";
                GROUPBY = "GROUP BY YEAR(invdate), MONTH(invdate),DATENAME(MONTH, invdate)";
            }
                try
            {

                OpenConnection();
                SQLText = "SELECT "+ Columns+",Count(Invid) as TransCount,SUM(billAmount) As TransNetAmount FROM dbo.trsSale " + WHERE + GROUPBY;
                CreateCommand(SQLText, SqlCommandType.Text);
                AddParameter("@InvDate", obj.TransactionDate, SqlDataType.DateTime, 0);
                AddParameter("@InvDateTo", obj.TransactionDateTo, SqlDataType.DateTime, 0);
                dt = FillDataTable();
                CloseConnection();
                DisposeCommand();
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
    }
}
