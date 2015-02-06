using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    class P_Cb_Ivp_Polaris_Securitysummary
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _security_Id { get; set; }
        public string _securiry_Name { get; set; }
        public string _securiry_Description { get; set; }
        public string _asset_Type { get; set; }
        public string _investment_Type { get; set; }
        public string _trading_Factor { get; set; }
        public string _pricing_Factor { get; set; }
        public string _created_By { get; set; }
        public DateTime _created_On { get; set; }
        public string _last_Modified_By { get; set; }
        public DateTime _last_Modified_On { get; set; }
        public bool _is_Active { get; set; }

        /// <summary>
        /// Insert Data in cb.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertSecuritySummary(P_Cb_Ivp_Polaris_Securitysummary objClass)
        {
            try
            {
                string Query = "insert into cb.ivp_polaris_securitysummary(security_name,security_description,asset_type,investment_type,trading_factor,pricing_factor,created_by,created_on,last_modified_by,last_modified_on,is_active) "
                    + "values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}')";
                Query = string.Format(Query, objClass._securiry_Name, objClass._securiry_Description, objClass._asset_Type, objClass._investment_Type, objClass._trading_Factor, objClass._pricing_Factor, objClass._created_By, objClass._created_On, objClass._last_Modified_By, objClass._last_Modified_On,objClass._is_Active);
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
        /// Update Data in cb.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateSecuritySummary(P_Cb_Ivp_Polaris_Securitysummary objClass)
        {
            try
            {
                string Query = "update cb.ivp_polaris_securitysummary set security_name='{0}',security_description='{1}',asset_type='{2}',investment_type='{3}',trading_factor='{4}',pricing_factor='{5}',created_by='{6}',created_on='{7}',last_modified_by='{8}',last_modified_on='{9}',is_active='{10}') "
                    + "where _security_Id={11}";
                Query = string.Format(Query, objClass._securiry_Name, objClass._securiry_Description, objClass._asset_Type, objClass._investment_Type, objClass._trading_Factor, objClass._pricing_Factor, objClass._created_By, objClass._created_On, objClass._last_Modified_By, objClass._last_Modified_On, objClass._is_Active,objClass._security_Id);
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
        /// Delete Data in cb.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteSecuritySummary(P_Cb_Ivp_Polaris_Securitysummary objClass)
        {
            try
            {
                string Query = "Update cb.ivp_polaris_securitysummary set is_active = '{0}' where security_Id = {1}";
                Query = string.Format(Query, objClass._is_Active, objClass._security_Id);
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
