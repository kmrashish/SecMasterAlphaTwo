using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    class P_Core_Ivp_Polaris_Core_Securityitentifier
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public string _cusip { get; set; }
        public string _isin { get; set; }
        public string _sedol { get; set; }
        public string _bloomberg_Ticker { get; set; }

        public long _bloomberg_Unique_Id { get; set; }

        public long _bloomberg_Global_Id { get; set; }

        /// <summary>
        /// Insert Data in core.ivp_polaris_core_securityitentifier
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertSecurityItentifier(P_Core_Ivp_Polaris_Core_Securityitentifier objClass)
        {
            try
            {
                string Query = "insert into core.ivp_polaris_core_securityitentifier(cusip,isin,sedol,bloomberg_ticker,bloomberg_unique_id,bloomberg_global_id) "
                    + "values('{0}','{1}','{2}','{3}',{4},{5})";
                Query = string.Format(Query, objClass._cusip, objClass._isin, objClass._sedol, objClass._bloomberg_Ticker, objClass._bloomberg_Unique_Id, objClass._bloomberg_Global_Id);
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
        /// Update Data in core.ivp_polaris_core_securityitentifier
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateSecurityItentifier(P_Core_Ivp_Polaris_Core_Securityitentifier objClass)
        {
            try
            {
                string Query = "update core.ivp_polaris_core_securityitentifier set cusip='{0}',isin='{1}',sedol='{2}',bloomberg_ticker='{3}',bloomberg_unique_id={4},bloomberg_global_id={5} "
                    + "where code={6}";
                Query = string.Format(Query, objClass._cusip, objClass._isin, objClass._sedol, objClass._bloomberg_Ticker, objClass._bloomberg_Unique_Id, objClass._bloomberg_Global_Id,objClass._code);
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
        /// Delete Data in core.ivp_polaris_core_securityitentifier
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteSecurityItentifier(P_Core_Ivp_Polaris_Core_Securityitentifier objClass)
        {
            try
            {
                string Query = "delete from core.ivp_polaris_core_securityitentifier where code={0}";
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
        /// Select Data of core.ivp_polaris_core_securityitentifier
        /// </summary>
        /// <param name="code">Code For Selecting Particular Table_Name.</param>
        /// <returns>List Of Objects</returns>
        public List<P_Core_Ivp_Polaris_Core_Securityitentifier> SelectSectypeId(long code = 0)
        {
            try
            {
                List<P_Core_Ivp_Polaris_Core_Securityitentifier> lstObj = new List<P_Core_Ivp_Polaris_Core_Securityitentifier>();
                string Query = "select * from core.ivp_polaris_core_securityitentifier";
                if (code > 0)
                {
                    Query += "where code = {0}";
                    Query = string.Format(Query, code);
                }
                DataTable dt = connect.returnDataset(Query).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    P_Core_Ivp_Polaris_Core_Securityitentifier tempObj = new P_Core_Ivp_Polaris_Core_Securityitentifier();
                    tempObj._code = Convert.ToInt64(row["code"]);
                    tempObj._cusip = row["cusip"].ToString();
                    tempObj._isin = row["isin"].ToString();
                    tempObj._sedol = row["sedol"].ToString();
                    tempObj._bloomberg_Ticker = row["bloomberg_Ticker"].ToString();
                    tempObj._bloomberg_Unique_Id = Convert.ToInt64(row["bloomberg_Unique_Id"]);
                    tempObj._bloomberg_Global_Id = Convert.ToInt64(row["bloomberg_Global_Id"]);
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
