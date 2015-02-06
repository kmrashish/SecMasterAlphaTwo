using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    class P_Core_Ivp_Polaris_Core_Sectype_Id
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public string _sectype_Name { get; set; }
        public string _sectype_Description { get; set; }
        public string _created_By { get; set; }
        public DateTime _created_On { get; set; }
        public string _last_Modified_By { get; set; }
        public DateTime _last_Modified_On { get; set; }

        /// <summary>
        /// Insert Data in core.ivp_polaris_core_sectype_id
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertSectypeId(P_Core_Ivp_Polaris_Core_Sectype_Id objClass)
        {
            try
            {
                string Query = "Insert into core.ivp_polaris_core_sectype_id(sectype_name,sectype_description,created_by,created_on,last_modified_by,last_modified_on) "
                    + "values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, objClass._sectype_Name, objClass._sectype_Description, objClass._created_By, objClass._created_On, objClass._last_Modified_By, objClass._last_Modified_On);
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
        /// Update Data in core.ivp_polaris_core_sectype_id
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateSectypeId(P_Core_Ivp_Polaris_Core_Sectype_Id objClass)
        {
            try
            {
                string Query = "update core.ivp_polaris_core_sectype_id set sectype_name='{0}',sectype_description='{1}',created_by='{2}',created_on='{3}',last_modified_by='{4}',last_modified_on='{5}' "
                    + "where code={6}";
                Query = string.Format(Query, objClass._sectype_Name, objClass._sectype_Description, objClass._created_By, objClass._created_On, objClass._last_Modified_By, objClass._last_Modified_On,objClass._code);
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
        /// Delete Data in core.ivp_polaris_core_sectype_id
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteSectypeId(P_Core_Ivp_Polaris_Core_Sectype_Id objClass)
        {
            try
            {
                string Query = "delete from core.ivp_polaris_core_sectype_id where code={0}";
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

        /// <summary>
        /// Select Data in core.ivp_polaris_core_sectype_id
        /// </summary>
        /// <param name="code">Code For Selecting Particular Table_Name.</param>
        /// <returns>List Of Objects</returns>
        public List<P_Core_Ivp_Polaris_Core_Sectype_Id> SelectSectypeId(long code = 0)
        {
            try
            {
                List<P_Core_Ivp_Polaris_Core_Sectype_Id> lstObj = new List<P_Core_Ivp_Polaris_Core_Sectype_Id>();
                string Query = "select * from core.ivp_polaris_core_sectype_id";
                if (code > 0)
                {
                    Query += "where code = {0}";
                    Query = string.Format(Query, code);
                }
                DataTable dt = connect.returnDataset(Query).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    P_Core_Ivp_Polaris_Core_Sectype_Id tempObj = new P_Core_Ivp_Polaris_Core_Sectype_Id();
                    tempObj._code = Convert.ToInt64(row["code"]);
                    tempObj._sectype_Name = row["sectype_name"].ToString();
                    tempObj._sectype_Description = row["sectype_description"].ToString();
                    tempObj._created_By = row["created_by"].ToString();
                    tempObj._created_On = Convert.ToDateTime(row["created_on"]);
                    tempObj._last_Modified_By = row["last_modified_by"].ToString();
                    tempObj._last_Modified_On = Convert.ToDateTime(row["last_modified_on"]);
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