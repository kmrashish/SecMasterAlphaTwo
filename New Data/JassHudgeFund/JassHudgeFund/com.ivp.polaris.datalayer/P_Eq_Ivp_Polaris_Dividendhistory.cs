using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Eq_Ivp_Polaris_Dividendhistory
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public DateTime _declared_Date { get; set; }
        public DateTime _ex_Date { get; set; }
        public DateTime _record_Date { get; set; }
        public DateTime _pay_Date { get; set; }
        public decimal _amount { get; set; }
        public string _frequency { get; set; }
        public string _dividend_Type { get; set; }

        /// <summary>
        /// Insert Data in eq.ivp_polaris_dividendhistory
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertDividendHistory(P_Eq_Ivp_Polaris_Dividendhistory objClass)
        {
            try
            {
                string Query = "insert into eq.ivp_polaris_dividendhistory(fk_security_id,declared_date,ex_date,record_date,pay_date,amount,frequency,dividend_type) "
                    + "values({0},'{1}','{2}','{3}','{4}',{5},'{6}','{7}')";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._declared_Date, objClass._ex_Date, objClass._record_Date, objClass._pay_Date, objClass._amount, objClass._frequency, objClass._dividend_Type);
                if (connect.executeQuery(Query) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Update Data in eq.ivp_polaris_dividendhistory
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateDividendHistory(P_Eq_Ivp_Polaris_Dividendhistory objClass)
        {
            try
            {
                string Query = "update eq.ivp_polaris_dividendhistory set fk_security_id={0},declared_date='{1}',ex_date='{2}',record_date='{3}',pay_date='{4}',amount={5},frequency='{6}',dividend_type='{7}') "
                    + "where code={8}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._declared_Date, objClass._ex_Date, objClass._record_Date, objClass._pay_Date, objClass._amount, objClass._frequency, objClass._dividend_Type,objClass._code);
                if (connect.executeQuery(Query) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Delete Data in eq.ivp_polaris_dividendhistory
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteDividendHistory(P_Eq_Ivp_Polaris_Dividendhistory objClass)
        {
            try
            {
                string Query = "delete from eq.ivp_polaris_dividendhistory where code={0}";
                Query = string.Format(Query, objClass._code);
                if (connect.executeQuery(Query) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
