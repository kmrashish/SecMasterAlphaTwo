using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Cb_Ivp_Polaris_Callschedule
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public DateTime _call_Date { get; set; }
        public decimal _call_Price { get; set; }

        /// <summary>
        /// Insert Data in cb.ivp_polaris_callschedule
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertCallschedule(P_Cb_Ivp_Polaris_Callschedule objClass)
        {
            try
            {
                string Query = "insert into cb.ivp_polaris_callschedule(fk_security_id,call_date,call_price)  "
                    + "values({0},'{1}',{2})";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._call_Date, objClass._call_Price);
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
        /// Delete Data in cb.ivp_polaris_callschedule
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateCallschedule(P_Cb_Ivp_Polaris_Callschedule objClass)
        {
            try
            {
                string Query = "update cb.ivp_polaris_callschedule set fk_security_id={0},call_date='{1}',call_price={2})  "
                    + "where code={3}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._call_Date, objClass._call_Price,objClass._code);
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
        /// Delete Data in cb.ivp_polaris_callschedule
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteCallschedule(P_Cb_Ivp_Polaris_Callschedule objClass)
        {
            try
            {
                string Query = "delete from cb.ivp_polaris_callschedule where code={0}";
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
