using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Eq_Ivp_Polaris_Securitysummary
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _security_Id { get; set; }
        public string _securiry_Name { get; set; }
        public string _securiry_Description { get; set; }
        public bool _has_Position { get; set; }
        public bool _is_Active { get; set; }
        public int _round_Lot_Size { get; set; }
        public string _bloomberg_Unique_Name { get; set; }
        public string _created_By { get; set; }
        public DateTime _created_On { get; set; }
        public string _last_Modified_By { get; set; }
        public DateTime _last_Modified_On { get; set; }

        /// <summary>
        /// Insert Data in eq.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertSecuritySummary(P_Eq_Ivp_Polaris_Securitysummary objClass)
        {
            try
            {
                string Query = "insert into eq.ivp_polaris_securitysummary(securiry_name,securiry_description,has_position,is_active,round_lot_size,bloomberg_unique_name,created_by,created_on,last_modified_by,last_modified_on) "
                    + "values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')";
                Query = string.Format(Query, objClass._securiry_Name, objClass._securiry_Description, objClass._has_Position, objClass._is_Active, objClass._round_Lot_Size, objClass._bloomberg_Unique_Name, objClass._created_By, objClass._created_On, objClass._last_Modified_By, objClass._last_Modified_On);
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
        /// Update Data in eq.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateSecuritySummary(P_Eq_Ivp_Polaris_Securitysummary objClass)
        {
            try
            {
                string Query = "update eq.ivp_polaris_securitysummary set securiry_name = '{0}',securiry_description = '{1}',has_position = '{2}',is_active = '{3}',round_lot_size = {4},bloomberg_unique_name = '{5}',created_by = '{6}',created_on = '{7}',last_modified_by = '{8}',last_modified_on = '{9}') "
                    + " where security_Id = {10}";
                Query = string.Format(Query, objClass._securiry_Name, objClass._securiry_Description, objClass._has_Position, objClass._is_Active, objClass._round_Lot_Size, objClass._bloomberg_Unique_Name, objClass._created_By, objClass._created_On, objClass._last_Modified_By, objClass._last_Modified_On,objClass._security_Id);
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
        /// Delete Data in eq.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteSecuritySummary(P_Eq_Ivp_Polaris_Securitysummary objClass)
        {
            try
            {
                string Query = "Update eq.ivp_polaris_securitysummary set is_active = '{0}' where security_Id = {1}";
                Query = string.Format(Query, objClass._is_Active,objClass._security_Id);
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
        /// Select Data of eq.ivp_polaris_securitysummary
        /// </summary>
        /// <param name="code">Code For Selecting Particular Table_Name.</param>
        /// <returns>List Of Objects</returns>
        public List<P_Eq_Ivp_Polaris_Securitysummary> SelectSectypeId(long code = 0)
        {
            try
            {
                List<P_Eq_Ivp_Polaris_Securitysummary> lstObj = new List<P_Eq_Ivp_Polaris_Securitysummary>();
                string Query = "select * from eq.ivp_polaris_securitysummary";
                if (code > 0)
                {
                    Query += "where code = {0}";
                    Query = string.Format(Query, code);
                }
                DataTable dt = connect.returnDataset(Query).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    P_Eq_Ivp_Polaris_Securitysummary tempObj = new P_Eq_Ivp_Polaris_Securitysummary();
                    tempObj._security_Id = Convert.ToInt64(row["security_Id"]);
                    tempObj._securiry_Name = row["securiry_Name"].ToString();
                    tempObj._securiry_Description = row["securiry_Description"].ToString();
                    tempObj._has_Position = Convert.ToBoolean(row["has_Position"]);
                    tempObj._is_Active = Convert.ToBoolean(row["is_Active"]);
                    tempObj._round_Lot_Size = Convert.ToInt32(row["round_Lot_Size"]);
                    tempObj._bloomberg_Unique_Name = row["bloomberg_Unique_Name"].ToString();
                    tempObj._created_By = row["created_By"].ToString();
                    tempObj._created_On = Convert.ToDateTime(row["created_On"]);
                    tempObj._last_Modified_By = row["last_Modified_By"].ToString();
                    tempObj._last_Modified_On = Convert.ToDateTime(row["last_Modified_On"]);
                    lstObj.Add(tempObj);
                }
                return lstObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
