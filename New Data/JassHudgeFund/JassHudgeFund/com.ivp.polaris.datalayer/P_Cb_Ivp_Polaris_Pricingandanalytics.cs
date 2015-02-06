using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Cb_Ivp_Polaris_Pricingandanalytics
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public decimal _ask_Price { get; set; }
        public decimal _high_Price { get; set; }
        public decimal _low_Price { get; set; }
        public decimal _open_Price { get; set; }
        public long _volume { get; set; }
        public decimal _bid_Price { get; set; }
        public decimal _last_Price { get; set; }

        /// <summary>
        /// Insert Data in cb.ivp_polaris_pricingandanalytics
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertPricingandanalytics(P_Cb_Ivp_Polaris_Pricingandanalytics objClass)
        {
            try
            {
                string Query = "insert into cb.ivp_polaris_pricingandanalytics(fk_security_id,ask_price,high_price,low_price,open_price,volume,bid_price,last_price)  "
                    + "values({0},{1},{2},{3},{4},{5},{6},{7})";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._ask_Price, objClass._high_Price,objClass._low_Price,objClass._open_Price,objClass._volume,objClass._bid_Price,objClass._last_Price);
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
        /// Update Data in cb.ivp_polaris_pricingandanalytics
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdatePricingandanalytics(P_Cb_Ivp_Polaris_Pricingandanalytics objClass)
        {
            try
            {
                string Query = "update cb.ivp_polaris_pricingandanalytics set fk_security_id={0},ask_price={1},high_price={2},low_price={3},open_price={4},volume={5},bid_price={6},last_price={7})  "
                    + "where code={8}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._ask_Price, objClass._high_Price, objClass._low_Price, objClass._open_Price, objClass._volume, objClass._bid_Price, objClass._last_Price,objClass._code);
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
        /// Delete Data in cb.ivp_polaris_pricingandanalytics
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeletePricingandanalytics(P_Cb_Ivp_Polaris_Pricingandanalytics objClass)
        {
            try
            {
                string Query = "delete from cb.ivp_polaris_pricingandanalytics where code={0}";
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
