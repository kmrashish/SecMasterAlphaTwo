using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Cb_Ivp_Polaris_Securitydetails
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public long _code { get; set; }
        public long _fk_Security_Id { get; set; }
        public DateTime _first_Coupon_Date { get; set; }
        public string _coupon_Cap { get; set; }
        public string _coupon_Floor { get; set; }
        public string _coupon_Frequency { get; set; }
        public string _coupon_Rate { get; set; }
        public string _coupon_Type { get; set; }
        public string _float_Spread { get; set; }
        public bool _is_Callable { get; set; }
        public bool _is_Fix_To_Float { get; set; }
        public bool _is_Putable { get; set; }
        public DateTime _issue_Date { get; set; }
        public DateTime _last_Reset_Date { get; set; }
        public DateTime _maturity_Date { get; set; }
        public long _maximum_Call_Notice_Days { get; set; }
        public long _maximum_Put_Notice_Days { get; set; }
        public DateTime _penultimate_Coupon_Date { get; set; }
        public string _reset_Frequency { get; set; }
        public bool _has_Position { get; set; }
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
        /// Insert Data in cb.ivp_polaris_securitydetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool InsertSecurityDetails(P_Cb_Ivp_Polaris_Securitydetails objClass)
        {
            try
            {
                string Query = "insert into cb.ivp_polaris_securitydetails( fk_security_id,first_coupon_date,coupon_cap,coupon_floor,coupon_frequency,coupon_rate,coupon_type,float_spread,is_callable,is_fix_to_float,is_putable,issue_date,last_reset_date,maturity_date,maximum_call_notice_days,maximum_put_notice_days,penultimate_coupon_date,reset_frequency,has_position,form_pf_asset_class,form_pf_country,form_pf_credit_rating,form_pf_currency,form_pf_instrument,form_pf_liquidity_profile,form_pf_maturity,form_pf_naics_code,form_pf_region,form_pf_sector,form_pf_sub_asset_class) "
                    + "values({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._first_Coupon_Date, objClass._coupon_Cap, objClass._coupon_Floor, objClass._coupon_Frequency, objClass._coupon_Rate, objClass._coupon_Type, objClass._float_Spread, objClass._is_Callable, objClass._is_Fix_To_Float, objClass._is_Putable, objClass._issue_Date, objClass._last_Reset_Date, objClass._maturity_Date, objClass._maximum_Call_Notice_Days, objClass._maximum_Put_Notice_Days, objClass._penultimate_Coupon_Date, objClass._reset_Frequency, objClass._has_Position, objClass._form_Pf_Asset_Class, objClass._form_Pf_Country, objClass._form_Pf_Credit_Rating, objClass._form_Pf_Currency, objClass._form_Pf_Instrument, objClass._form_Pf_Liquid_Profile, objClass._form_Pf_Maturity, objClass._form_Pf_Naics_Code, objClass._form_Pf_Region, objClass._form_Pf_Sector, objClass._form_Pf_Sub_Asset_Class);
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
        /// Update Data in cb.ivp_polaris_securitydetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool UpdateSecurityDetails(P_Cb_Ivp_Polaris_Securitydetails objClass)
        {
            try
            {
                string Query = "update cb.ivp_polaris_securitydetails set fk_security_id ={0},first_coupon_date='{1}',coupon_cap='{2}',coupon_floor='{3}',coupon_frequency='{4}',coupon_rate='{5}',coupon_type='{6}',float_spread='{7}',is_callable='{8}',is_fix_to_float='{9}',is_putable='{10}',issue_date='{11}',last_reset_date='{12}',maturity_date='{13}',maximum_call_notice_days='{14}',maximum_put_notice_days='{15}',penultimate_coupon_date='{16}',reset_frequency='{17}',has_position='{18}',form_pf_asset_class='{19}',form_pf_country='{20}',form_pf_credit_rating='{21}',form_pf_currency='{22}',form_pf_instrument='{23}',form_pf_liquidity_profile='{24}',form_pf_maturity='{25}',form_pf_naics_code='{26}',form_pf_region='{27}',form_pf_sector='{28}',form_pf_sub_asset_class='{29}') "
                    + " where code={30}";
                Query = string.Format(Query, objClass._fk_Security_Id, objClass._first_Coupon_Date, objClass._coupon_Cap, objClass._coupon_Floor, objClass._coupon_Frequency, objClass._coupon_Rate, objClass._coupon_Type, objClass._float_Spread, objClass._is_Callable, objClass._is_Fix_To_Float, objClass._is_Putable, objClass._issue_Date, objClass._last_Reset_Date, objClass._maturity_Date, objClass._maximum_Call_Notice_Days, objClass._maximum_Put_Notice_Days, objClass._penultimate_Coupon_Date, objClass._reset_Frequency, objClass._has_Position, objClass._form_Pf_Asset_Class, objClass._form_Pf_Country, objClass._form_Pf_Credit_Rating, objClass._form_Pf_Currency, objClass._form_Pf_Instrument, objClass._form_Pf_Liquid_Profile, objClass._form_Pf_Maturity, objClass._form_Pf_Naics_Code, objClass._form_Pf_Region, objClass._form_Pf_Sector, objClass._form_Pf_Sub_Asset_Class,objClass._code);
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
        /// Update Data in cb.ivp_polaris_securitydetails
        /// </summary>
        /// <param name="objClass">Object Of Class</param>
        /// <returns>Bool Value True- Success, False- Failure</returns>
        public bool DeleteSecurityDetails(P_Cb_Ivp_Polaris_Securitydetails objClass)
        {
            try
            {
                string Query = "delete from cb.ivp_polaris_securitydetails where code={0}";
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
