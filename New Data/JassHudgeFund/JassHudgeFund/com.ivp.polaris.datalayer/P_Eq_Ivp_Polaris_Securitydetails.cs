using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Eq_Ivp_Polaris_Securitydetails
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public bool _is_Adr { get; set; }
        public string _adr_Underlying_Ticker { get; set; }
        public string _adr_Underlying_Currency { get; set; }
        public string _shares_Per_Adr { get; set; }
        public DateTime _ipo_Date { get; set; }
        public DateTime _price_Currency { get; set; }
        public long _settle_Days { get; set; }
        public string _shares_Outstanding { get; set; }
        public string _voting_Rights_Per_Share { get; set; }
        public string _form_Pf_Asset_Class { get; set; }
        public string _form_Pf_Country { get; set; }
        public string _form_Pf_Credit_Rating { get; set; }
        public string _form_Pf_Currency { get; set; }
        public string _form_Pf_Instrument { get; set; }
        public string _form_Pf_Liquid_Profile { get; set; }
        public string _form_Pf_Maturity { get; set; }
        public string _form_Pf_Naics_Code { get; set; }
        public string _form_Pf_Region { get; set; }
        public string _form_Pf_Sector { get; set; }
        public string _form_Pf_Sub_Asset_Class { get; set; }

        /// <summary>
        /// Insert Data in eq.ivp_polaris_securitydetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertSecurityDetails(P_Eq_Ivp_Polaris_Securitydetails objClass)
        {
            try
            {
                string Query = "insert into eq.ivp_polaris_securitydetails(fk_security_id,is_adr,adr_underlying_ticker,adr_underlying_currency,shares_per_adr,ipo_date,price_currency,settle_days,shares_outstanding,voting_rights_per_share,form_pf_asset_class,form_pf_country,form_pf_credit_rating,form_pf_currency,form_pf_instrument,form_pf_liquid_profile,form_pf_maturity,form_pf_naics_code,form_pf_region,form_pf_sector,form_pf_sub_asset_class) "
                    + "values({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._is_Adr, objClass._adr_Underlying_Ticker, objClass._adr_Underlying_Currency, objClass._shares_Per_Adr, objClass._ipo_Date, objClass._price_Currency, objClass._settle_Days, objClass._shares_Outstanding, objClass._voting_Rights_Per_Share,objClass._form_Pf_Asset_Class,objClass._form_Pf_Country,objClass._form_Pf_Credit_Rating,objClass._form_Pf_Currency,objClass._form_Pf_Instrument,objClass._form_Pf_Liquid_Profile,objClass._form_Pf_Maturity,objClass._form_Pf_Naics_Code,objClass._form_Pf_Region,objClass._form_Pf_Sector,objClass._form_Pf_Sub_Asset_Class);
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
        /// Update Data in eq.ivp_polaris_securitydetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateSecurityDetails(P_Eq_Ivp_Polaris_Securitydetails objClass)
        {
            try
            {
                string Query = "update eq.ivp_polaris_securitydetails set fk_security_id = {0},is_adr = '{1}',adr_underlying_ticker = '{2}',adr_underlying_currency = '{3}',shares_per_adr = '{4}',ipo_date = '{5}',price_currency = '{6}',settle_days = {7},shares_outstanding = '{8}',voting_rights_per_share = '{9}',form_pf_asset_class = '{10}',form_pf_country = '{11}',form_pf_credit_rating = '{12}',form_pf_currency = '{13}',form_pf_instrument = '{14}',form_pf_liquid_profile = '{15}',form_pf_maturity = '{16}',form_pf_naics_code = '{17}',form_pf_region = '{18}',form_pf_sector = '{19}',form_pf_sub_asset_class = '{20}') "
                    + "where code={21}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._is_Adr, objClass._adr_Underlying_Ticker, objClass._adr_Underlying_Currency, objClass._shares_Per_Adr, objClass._ipo_Date, objClass._price_Currency, objClass._settle_Days, objClass._shares_Outstanding, objClass._voting_Rights_Per_Share, objClass._form_Pf_Asset_Class, objClass._form_Pf_Country, objClass._form_Pf_Credit_Rating, objClass._form_Pf_Currency, objClass._form_Pf_Instrument, objClass._form_Pf_Liquid_Profile, objClass._form_Pf_Maturity, objClass._form_Pf_Naics_Code, objClass._form_Pf_Region, objClass._form_Pf_Sector, objClass._form_Pf_Sub_Asset_Class,objClass._code);
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
        /// Delete Data in eq.ivp_polaris_securitydetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteSecurityDetails(P_Eq_Ivp_Polaris_Securitydetails objClass)
        {
            try
            {
                string Query = "delete from eq.ivp_polaris_securitydetails where code={0}";
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
