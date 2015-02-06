using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Eq_Ivp_Polaris_Pricingdetails
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public decimal _open_Price { get; set; }
        public decimal _close_Price { get; set; }
        public long _volume { get; set; }
        public decimal _last_Price { get; set; }
        public decimal _ask_Price { get; set; }
        public decimal _bid_Price { get; set; }
        public float _pe_Ratio { get; set; }

        /// <summary>
        /// Insert Data in eq.ivp_polaris_pricingdetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertPricingDetails(P_Eq_Ivp_Polaris_Pricingdetails objClass)
        {
            try
            {
                string Query = "insert into eq.ivp_polaris_pricingdetails(fk_security_id,open_price,close_price,volume,last_price,ask_price,bid_price,pe_ratio) "
                    + "values({0},{1},{2},{3},{4},{5},{6},'{7}')";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._open_Price, objClass._close_Price, objClass._volume, objClass._last_Price, objClass._ask_Price, objClass._bid_Price, objClass._pe_Ratio);
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
        /// Update Data in eq.ivp_polaris_pricingdetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdatePricingDetails(P_Eq_Ivp_Polaris_Pricingdetails objClass)
        {
            try
            {
                string Query = "update eq.ivp_polaris_pricingdetails set fk_security_id = {0},open_price = {1},close_price = {2},volume = {3},last_price = {4},ask_price = {5},bid_price = {6},pe_ratio = '{7}') "
                    + "where code={8}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._open_Price, objClass._close_Price, objClass._volume, objClass._last_Price, objClass._ask_Price, objClass._bid_Price, objClass._pe_Ratio,objClass._code);
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
        /// Delete Data in eq.ivp_polaris_pricingdetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeletePricingDetails(P_Eq_Ivp_Polaris_Pricingdetails objClass)
        {
            try
            {
                string Query = "delete from eq.ivp_polaris_pricingdetails where code={0}";
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
