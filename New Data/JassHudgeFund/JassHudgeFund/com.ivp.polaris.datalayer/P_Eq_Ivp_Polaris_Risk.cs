using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Eq_Ivp_Polaris_Risk
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public string _twenty_Day_Average_Volume { get; set; }
        public string _beta { get; set; }
        public string _short_Interest { get; set; }
        public string _ytd_Return { get; set; }
        public string _ninty_Day_Price_Volatility { get; set; }

        /// <summary>
        /// Insert Data in eq.ivp_polaris_risk
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertRisk(P_Eq_Ivp_Polaris_Risk objClass)
        {
            try
            {
                string Query = "insert into eq.ivp_polaris_risk(fk_security_id,twenty_day_average_volume,beta,short_interest,ytd_return,ninty_day_price_volatility) "
                    + "values({0},'{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._twenty_Day_Average_Volume, objClass._beta, objClass._short_Interest, objClass._ytd_Return, objClass._ninty_Day_Price_Volatility);
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
        /// Update Data in eq.ivp_polaris_risk
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateRisk(P_Eq_Ivp_Polaris_Risk objClass)
        {
            try
            {
                string Query = "update eq.ivp_polaris_risk set fk_security_id = {0},twenty_day_average_volume = '{1}',beta = '{2}',short_interest = '{3}',ytd_return = '{4}',ninty_day_price_volatility = '{5}') "
                    + "where code={6}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._twenty_Day_Average_Volume, objClass._beta, objClass._short_Interest, objClass._ytd_Return, objClass._ninty_Day_Price_Volatility,objClass._code);
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
        /// Delete Data in eq.ivp_polaris_risk
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteRisk(P_Eq_Ivp_Polaris_Risk objClass)
        {
            try
            {
                string Query = "delete from eq.ivp_polaris_risk where code={0}";
                Query = string.Format(Query,objClass._code);
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
