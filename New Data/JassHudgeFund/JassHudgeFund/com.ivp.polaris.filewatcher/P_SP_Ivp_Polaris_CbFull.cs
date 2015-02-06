using com.ivp.polaris.filewatcher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_SP_Ivp_Polaris_CbFull
    {
        P_Util connect = new P_Util();
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
        public string _firstcouponcode { get; set; }
        public string _duration { get; set; }
        public string _volatility_ThirtyD { get; set; }
        public string _volatility_NintyD { get; set; }
        public string _convexity { get; set; }
        public string _average_Volume_ThirtyD { get; set; }
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
        public string _cusip { get; set; }
        public string _isin { get; set; }
        public string _sedol { get; set; }
        public string _bloomberg_Ticker { get; set; }
        public long _bloomberg_Unique_Id { get; set; }
        public long _bloomberg_Global_Id { get; set; }
        public DateTime _call_Date { get; set; }
        public decimal _call_Price { get; set; }
        public DateTime _put_Date { get; set; }
        public decimal _put_Price { get; set; }
        public decimal _ask_Price { get; set; }
        public decimal _high_Price { get; set; }
        public decimal _low_Price { get; set; }
        public decimal _open_Price { get; set; }
        public long _volume { get; set; }
        public decimal _bid_Price { get; set; }
        public decimal _last_Price { get; set; }

        public bool Insert_Update_Delete_CB(P_SP_Ivp_Polaris_CbFull objCls, string type)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.NVarChar).Value = type;
                cmd.Parameters.Add("@securiry_name", SqlDbType.NVarChar).Value = objCls._securiry_Name;
                cmd.Parameters.Add("@securiry_description", SqlDbType.NVarChar).Value = objCls._securiry_Description;
                cmd.Parameters.Add("@asset_type", SqlDbType.NVarChar).Value = objCls._asset_Type;
                cmd.Parameters.Add("@investment_type", SqlDbType.NVarChar).Value = objCls._investment_Type;
                cmd.Parameters.Add("@trading_factor", SqlDbType.NVarChar).Value = objCls._trading_Factor;
                cmd.Parameters.Add("@pricing_factor", SqlDbType.NVarChar).Value = objCls._pricing_Factor;
                cmd.Parameters.Add("@created_by", SqlDbType.NVarChar).Value = objCls._created_By;
                cmd.Parameters.Add("@created_on", SqlDbType.Date).Value = objCls._created_On;
                cmd.Parameters.Add("@last_modified_by", SqlDbType.NVarChar).Value = objCls._last_Modified_By;
                cmd.Parameters.Add("@last_modified_on", SqlDbType.Date).Value = objCls._last_Modified_On;
                cmd.Parameters.Add("@is_active", SqlDbType.Bit).Value = objCls._is_Active;
                cmd.Parameters.Add("@first_coupon_date", SqlDbType.Date).Value = objCls._first_Coupon_Date;
                cmd.Parameters.Add("@coupon_cap", SqlDbType.NVarChar).Value = objCls._coupon_Cap;
                cmd.Parameters.Add("@coupon_floor", SqlDbType.NVarChar).Value = objCls._coupon_Floor;
                cmd.Parameters.Add("@coupon_frequency", SqlDbType.NVarChar).Value = objCls._coupon_Frequency;
                cmd.Parameters.Add("@coupon_rate", SqlDbType.NVarChar).Value = objCls._coupon_Rate;
                cmd.Parameters.Add("@coupon_type", SqlDbType.NVarChar).Value = objCls._coupon_Type;
                cmd.Parameters.Add("@float_spread", SqlDbType.NVarChar).Value = objCls._float_Spread;
                cmd.Parameters.Add("@is_callable", SqlDbType.Bit).Value = objCls._is_Callable;
                cmd.Parameters.Add("@is_fix_to_float", SqlDbType.Bit).Value = objCls._is_Fix_To_Float;
                cmd.Parameters.Add("@is_putable", SqlDbType.Bit).Value = objCls._is_Putable;
                cmd.Parameters.Add("@issue_date", SqlDbType.Date).Value = objCls._issue_Date;
                cmd.Parameters.Add("@last_reset_date", SqlDbType.Date).Value = objCls._last_Reset_Date;
                cmd.Parameters.Add("@maturity_date", SqlDbType.Date).Value = objCls._maturity_Date;
                cmd.Parameters.Add("@maximum_call_notice_days", SqlDbType.BigInt).Value = objCls._maximum_Call_Notice_Days;
                cmd.Parameters.Add("@maximum_put_notice_days", SqlDbType.BigInt).Value = objCls._maximum_Put_Notice_Days;
                cmd.Parameters.Add("@penultimate_coupon_date", SqlDbType.Date).Value = objCls._penultimate_Coupon_Date;
                cmd.Parameters.Add("@reset_frequency", SqlDbType.NVarChar).Value = objCls._reset_Frequency;
                cmd.Parameters.Add("@has_position", SqlDbType.Bit).Value = objCls._has_Position;
                cmd.Parameters.Add("@form_pf_asset_class", SqlDbType.NVarChar).Value = objCls._form_Pf_Asset_Class;
                cmd.Parameters.Add("@form_pf_country", SqlDbType.NVarChar).Value = objCls._form_Pf_Country;
                cmd.Parameters.Add("@form_pf_credit_rating", SqlDbType.NVarChar).Value = objCls._form_Pf_Credit_Rating;
                cmd.Parameters.Add("form_pf_currency", SqlDbType.NVarChar).Value = objCls._form_Pf_Currency;
                cmd.Parameters.Add("@form_pf_instrument", SqlDbType.NVarChar).Value = objCls._form_Pf_Instrument;
                cmd.Parameters.Add("@form_pf_liquid_profile", SqlDbType.NVarChar).Value = objCls._form_Pf_Liquid_Profile;
                cmd.Parameters.Add("@form_pf_maturity", SqlDbType.NVarChar).Value = objCls._form_Pf_Maturity;
                cmd.Parameters.Add("@form_pf_naics_code", SqlDbType.NVarChar).Value = objCls._form_Pf_Naics_Code;
                cmd.Parameters.Add("@form_pf_region", SqlDbType.NVarChar).Value = objCls._form_Pf_Region;
                cmd.Parameters.Add("@form_pf_sector", SqlDbType.NVarChar).Value = objCls._form_Pf_Sector;
                cmd.Parameters.Add("@form_pf_sub_asset_class", SqlDbType.NVarChar).Value = objCls._form_Pf_Sub_Asset_Class;
                cmd.Parameters.Add("@firstcouponcode", SqlDbType.NVarChar).Value = objCls._firstcouponcode;
                cmd.Parameters.Add("@duration", SqlDbType.NVarChar).Value = objCls._duration;
                cmd.Parameters.Add("@volatility_thirtyD", SqlDbType.NVarChar).Value = objCls._volatility_ThirtyD;
                cmd.Parameters.Add("@volatility_nintyD", SqlDbType.NVarChar).Value = objCls._volatility_NintyD;
                cmd.Parameters.Add("@convexity", SqlDbType.NVarChar).Value = objCls._convexity;
                cmd.Parameters.Add("@average_volume_thirtyD", SqlDbType.NVarChar).Value = objCls._average_Volume_ThirtyD;
                cmd.Parameters.Add("@issue_country", SqlDbType.NVarChar).Value = objCls._issue_Country;
                cmd.Parameters.Add("@exchange", SqlDbType.NVarChar).Value = objCls._exchange;
                cmd.Parameters.Add("@issuer", SqlDbType.NVarChar).Value = objCls._issuer;
                cmd.Parameters.Add("@issue_currency", SqlDbType.NVarChar).Value = objCls._issue_Currency;
                cmd.Parameters.Add("@trading_currency", SqlDbType.NVarChar).Value = objCls._trading_Currency;
                cmd.Parameters.Add("@bloomberg_industry_sub_group", SqlDbType.NVarChar).Value = objCls._bloomberg_Industry_Sub_Group;
                cmd.Parameters.Add("@bloomberg_industry_group", SqlDbType.NVarChar).Value = objCls._bloomberg_Industry_Group;
                cmd.Parameters.Add("@bloomberg_industry_sector", SqlDbType.NVarChar).Value = objCls._bloomberg_Industry_Sector;
                cmd.Parameters.Add("@country_of_incorporation", SqlDbType.NVarChar).Value = objCls._country_Of_Incorporation;
                cmd.Parameters.Add("@risk_currency", SqlDbType.NVarChar).Value = objCls._risk_Currency;
                cmd.Parameters.Add("@cusip", SqlDbType.NVarChar).Value = objCls._cusip;
                cmd.Parameters.Add("@isin", SqlDbType.NVarChar).Value = objCls._isin;
                cmd.Parameters.Add("@sedol", SqlDbType.NVarChar).Value = objCls._sedol;
                cmd.Parameters.Add("@bloomberg_ticker", SqlDbType.NVarChar).Value = objCls._bloomberg_Ticker;
                cmd.Parameters.Add("@bloomberg_unique_id", SqlDbType.BigInt).Value = objCls._bloomberg_Unique_Id;
                cmd.Parameters.Add("@bloomberg_global_id", SqlDbType.BigInt).Value = objCls._bloomberg_Global_Id;
                cmd.Parameters.Add("@call_date", SqlDbType.Date).Value = objCls._call_Date;
                cmd.Parameters.Add("@call_price", SqlDbType.Money).Value = objCls._call_Price;
                cmd.Parameters.Add("@put_date", SqlDbType.Date).Value = objCls._put_Date;
                cmd.Parameters.Add("@put_price", SqlDbType.Money).Value = objCls._put_Price;
                cmd.Parameters.Add("@ask_price", SqlDbType.Money).Value = objCls._ask_Price;
                cmd.Parameters.Add("@high_price", SqlDbType.Money).Value = objCls._high_Price;
                cmd.Parameters.Add("@low_price", SqlDbType.Money).Value = objCls._low_Price;
                cmd.Parameters.Add("@open_price", SqlDbType.Money).Value = objCls._open_Price;
                cmd.Parameters.Add("@volume", SqlDbType.BigInt).Value = objCls._volume;
                cmd.Parameters.Add("@bid_price", SqlDbType.Money).Value = objCls._bid_Price;
                cmd.Parameters.Add("@last_price", SqlDbType.Money).Value = objCls._last_Price;
                cmd.Parameters.Add("@security_id", SqlDbType.BigInt).Value = objCls._security_Id;
                cmd.Parameters["@security_id"].Direction = ParameterDirection.Output;
                cmd.CommandText = "cb.sp_ivp_polaris_iudfull_security";
                return connect.executeStoreprocedure(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
