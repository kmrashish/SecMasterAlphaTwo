using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    class P_Core_Ivp_Polaris_Core_Referencedata
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public string _issue_Country { get; set; }
        public string _exchange { get; set; }
        public string _issuer { get; set; }
        public string _issue_Currency { get; set; }
        public string _trading_Currency { get; set; }
        public string _bloomberg_Industry_Sub_Group { get; set; }
        public string _bloomberg_Industry_Group { get; set; }
        public string _bloomberg_Industry_Sector { get; set; }
        public string _country_Of_Incorporation { get; set; }
        public string _risk_Currency { get; set; }

        /// <summary>
        /// Insert Data in core.ivp_polaris_core_referencedata
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertReferenceData(P_Core_Ivp_Polaris_Core_Referencedata objClass)
        {
            try
            {
                string Query = "insert into core.ivp_polaris_core_referencedata(issue_country,exchange,issuer,issue_currency,trading_currency,bloomberg_industry_sub_group,bloomberg_industry_group,bloomberg_industry_sector,country_of_incorporation,risk_currency) "
                    + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                Query = string.Format(Query, objClass._issue_Country, objClass._exchange, objClass._issuer, objClass._issue_Currency, objClass._trading_Currency, objClass._bloomberg_Industry_Sub_Group,objClass._bloomberg_Industry_Group,objClass._bloomberg_Industry_Sector,objClass._country_Of_Incorporation,objClass._risk_Currency);
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
        /// Update Data in core.ivp_polaris_core_referencedata
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateReferenceData(P_Core_Ivp_Polaris_Core_Referencedata objClass)
        {
            try
            {
                string Query = "update core.ivp_polaris_core_referencedata set issue_country = '{0}',exchange = '{1}',issuer = '{2}',issue_currency = '{3}',trading_currency = '{4}',bloomberg_industry_sub_group = '{5}',bloomberg_industry_group = '{6}',bloomberg_industry_sector = '{7}',country_of_incorporation = '{8}',risk_currency = '{9}') "
                    + "where code = {10}";
                Query = string.Format(Query, objClass._issue_Country, objClass._exchange, objClass._issuer, objClass._issue_Currency, objClass._trading_Currency, objClass._bloomberg_Industry_Sub_Group, objClass._bloomberg_Industry_Group, objClass._bloomberg_Industry_Sector, objClass._country_Of_Incorporation, objClass._risk_Currency,objClass._code);
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
        /// Delete Data in core.ivp_polaris_core_referencedata
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteReferenceData(P_Core_Ivp_Polaris_Core_Referencedata objClass)
        {
            try
            {
                string Query = "Delete from core.ivp_polaris_core_referencedata where code = {0}";
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

        /// <summary>
        /// Select Data of core.ivp_polaris_core_referencedata
        /// </summary>
        /// <param name="code">Code For Selecting Particular Table_Name.</param>
        /// <returns>List Of Objects</returns>
        public List<P_Core_Ivp_Polaris_Core_Referencedata> SelectReferenceData(long code = 0)
        {
            try
            {
                List<P_Core_Ivp_Polaris_Core_Referencedata> lstObj = new List<P_Core_Ivp_Polaris_Core_Referencedata>();
                string Query = "select * from core.ivp_polaris_core_referencedata";
                if (code > 0)
                {
                    Query += "where code = {0}";
                    Query = string.Format(Query, code);
                }
                DataTable dt = connect.returnDataset(Query).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    P_Core_Ivp_Polaris_Core_Referencedata tempObj = new P_Core_Ivp_Polaris_Core_Referencedata();
                    tempObj._code = Convert.ToInt64(row["code"]);
                    tempObj._issue_Country = row["issue_Country"].ToString();
                    tempObj._exchange = row["exchange"].ToString();
                    tempObj._issuer = row["issuer"].ToString();
                    tempObj._issue_Currency = row["issue_Currency"].ToString();
                    tempObj._trading_Currency = row["trading_Currency"].ToString();
                    tempObj._bloomberg_Industry_Sub_Group = row["bloomberg_Industry_Sub_Group"].ToString();
                    tempObj._bloomberg_Industry_Group = row["bloomberg_Industry_Group"].ToString();
                    tempObj._bloomberg_Industry_Sector = row["bloomberg_Industry_Sector"].ToString();
                    tempObj._country_Of_Incorporation = row["country_Of_Incorporation"].ToString();
                    tempObj._risk_Currency = row["risk_Currency"].ToString();
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
