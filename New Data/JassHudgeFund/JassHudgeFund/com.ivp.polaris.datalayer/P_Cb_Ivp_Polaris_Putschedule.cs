using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Cb_Ivp_Polaris_Putschedule
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public DateTime _put_Date { get; set; }
        public decimal _put_Price { get; set; }

        /// <summary>
        /// Insert Data in cb.ivp_polaris_putschedule
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertPutschedule(P_Cb_Ivp_Polaris_Putschedule objClass)
        {
            try
            {
                string Query = "insert into cb.ivp_polaris_putschedule(fk_security_id,put_date,put_price)  "
                    + "values({0},'{1}',{2})";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._put_Date, objClass._put_Price);
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
        /// Update Data in cb.ivp_polaris_putschedule
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdatePutschedule(P_Cb_Ivp_Polaris_Putschedule objClass)
        {
            try
            {
                string Query = "update cb.ivp_polaris_putschedule set fk_security_id={0},put_date='{1}',put_price={2})  "
                    + "where code = {3}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._put_Date, objClass._put_Price,objClass._code);
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
        /// Delete Data in cb.ivp_polaris_putschedule
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeletePutschedule(P_Cb_Ivp_Polaris_Putschedule objClass)
        {
            try
            {
                string Query = "delete from cb.ivp_polaris_putschedule where code = {0}";
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
