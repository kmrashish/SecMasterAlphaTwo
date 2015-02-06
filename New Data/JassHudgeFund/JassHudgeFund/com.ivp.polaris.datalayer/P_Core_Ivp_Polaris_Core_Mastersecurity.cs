using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Core_Ivp_Polaris_Core_Mastersecurity
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public string _table_Name { get; set; }
        public long _sectype_Id { get; set; }

        /// <summary>
        /// Insert Data in core.ivp_polaris_core_mastersecurity
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertMastersecurity(P_Core_Ivp_Polaris_Core_Mastersecurity objClass)
        {
            try
            {
                string Query = "Insert into core.ivp_polaris_core_mastersecurity(table_name,sectype_id) values({0},{1})";
                Query = string.Format(Query, objClass._table_Name, objClass._sectype_Id);
                if (connect.executeQuery(Query) > 0)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Update Data in core.ivp_polaris_core_mastersecurity
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateMastersecurity(P_Core_Ivp_Polaris_Core_Mastersecurity objClass)
        {
            try
            {
                string Query = "update core.ivp_polaris_core_mastersecurity set table_name= {0},sectype_id = {1} where code={2}";
                Query = string.Format(Query, objClass._table_Name, objClass._sectype_Id,objClass._code);
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
        /// Delete Data in core.ivp_polaris_core_mastersecurity
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteMastersecurity(P_Core_Ivp_Polaris_Core_Mastersecurity objClass)
        {
            try
            {
                string Query = "delete from core.ivp_polaris_core_mastersecurity where code={0}";
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
        /// Select Data of core.ivp_polaris_core_mastersecurity
        /// </summary>
        /// <param name="code">Code For Selecting Particular Table_Name.</param>
        /// <returns>List Of Objects</returns>
        public List<P_Core_Ivp_Polaris_Core_Mastersecurity> SelectMastersecurity(long code = 0)
        {
            try
            { 
                List<P_Core_Ivp_Polaris_Core_Mastersecurity> lstObj=new List<P_Core_Ivp_Polaris_Core_Mastersecurity>();
                string Query = "select * from core.ivp_polaris_core_mastersecurity";
                if(code>0)
                {
                    Query += "where code = {0}";
                    Query = string.Format(Query, code);
                }
                DataTable dt = connect.returnDataset(Query).Tables[0];
                foreach(DataRow row in dt.Rows)
                {
                    P_Core_Ivp_Polaris_Core_Mastersecurity tempObj = new P_Core_Ivp_Polaris_Core_Mastersecurity();
                    tempObj._code = Convert.ToInt64(row["code"]);
                    tempObj._table_Name = row["table_name"].ToString();
                    tempObj._sectype_Id = Convert.ToInt64(row["sectype_id"]);
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
