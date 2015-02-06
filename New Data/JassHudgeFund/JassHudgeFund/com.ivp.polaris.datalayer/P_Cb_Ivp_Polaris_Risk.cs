using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Cb_Ivp_Polaris_Risk
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public string _firstcouponcode { get; set; }
        public string _duration { get; set; }
        public string _volatility_ThirtyD { get; set; }
        public string _volatility_NintyD { get; set; }
        public string _convexity { get; set; }
        public string _average_Volume_ThirtyD { get; set; }

        /// <summary>
        /// Insert Data in cb.ivp_polaris_risk
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertRisk(P_Cb_Ivp_Polaris_Risk objClass)
        {
            try
            {
                string Query = "insert into cb.ivp_polaris_risk(fk_security_id,firstcouponcode,duration,volatility_thirtyD,volatility_nintyD,convexity,average_volume_thirtyD) "
                    + "values({0},'{1}','{2}','{3}','{4}','{5}','{6}')";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._firstcouponcode, objClass._duration, objClass._volatility_ThirtyD, objClass._volatility_NintyD, objClass._convexity,objClass._average_Volume_ThirtyD);
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
        /// Update Data in cb.ivp_polaris_risk
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateRisk(P_Cb_Ivp_Polaris_Risk objClass)
        {
            try
            {
                string Query = "update cb.ivp_polaris_risk set fk_security_id = {0},firstcouponcode = '{1}',duration = '{2}',volatility_thirtyD = '{3}',volatility_nintyD = '{4}',convexity = '{5}',average_volume_thirtyD = '{6}') "
                    + "where code={7}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._firstcouponcode, objClass._duration, objClass._volatility_ThirtyD, objClass._volatility_NintyD, objClass._convexity, objClass._average_Volume_ThirtyD,objClass._code);
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
        /// Delete Data in cb.ivp_polaris_risk
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteRisk(P_Cb_Ivp_Polaris_Risk objClass)
        {
            try
            {
                string Query = "delete from cb.ivp_polaris_risk where code={0}";
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
