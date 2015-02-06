using com.ivp.polaris.filewatcher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_SP_Ivp_Polaris_EqFull
    {
        P_Util connect = new P_Util();
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
        public bool _is_Adr { get; set; }
        public string _adr_Underlying_Ticker { get; set; }
        public string _adr_Underlying_Currency { get; set; }
        public string _shares_Per_Adr { get; set; }
        public DateTime _ipo_Date { get; set; }
        public string _price_Currency { get; set; }
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
        public string _twenty_Day_Average_Volume { get; set; }
        public string _beta { get; set; }
        public string _short_Interest { get; set; }
        public string _ytd_Return { get; set; }
        public string _ninty_Day_Price_Volatility { get; set; }
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
        public decimal _open_Price { get; set; }
        public decimal _close_Price { get; set; }
        public long _volume { get; set; }
        public decimal _last_Price { get; set; }
        public decimal _ask_Price { get; set; }
        public decimal _bid_Price { get; set; }
        public float _pe_Ratio { get; set; }
        public DateTime _declared_Date { get; set; }
        public DateTime _ex_Date { get; set; }
        public DateTime _record_Date { get; set; }
        public DateTime _pay_Date { get; set; }
        public decimal _amount { get; set; }
        public string _frequency { get; set; }
        public string _dividend_Type { get; set; }

        public bool Insert_Update_Delete_EQ(P_SP_Ivp_Polaris_EqFull objCls,string type)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.NVarChar).Value = type;
                cmd.Parameters.Add("@securiry_name", SqlDbType.NVarChar).Value = objCls._securiry_Name;
                cmd.Parameters.Add("@securiry_description", SqlDbType.NVarChar).Value = objCls._securiry_Description;
                cmd.Parameters.Add("@has_position", SqlDbType.Bit).Value = objCls._has_Position;
                cmd.Parameters.Add("@is_active", SqlDbType.Bit).Value = objCls._is_Active;
                cmd.Parameters.Add("@round_lot_size", SqlDbType.Int).Value = objCls._round_Lot_Size;
                cmd.Parameters.Add("@bloomberg_unique_name", SqlDbType.NVarChar).Value = objCls._bloomberg_Unique_Name;
                cmd.Parameters.Add("@created_by", SqlDbType.NVarChar).Value = objCls._created_By;
                cmd.Parameters.Add("@created_on", SqlDbType.Date).Value = objCls._created_On;
                cmd.Parameters.Add("@last_modified_by", SqlDbType.NVarChar).Value = objCls._last_Modified_By;
                cmd.Parameters.Add("@last_modified_on", SqlDbType.Date).Value = objCls._last_Modified_On;
                cmd.Parameters.Add("@is_adr", SqlDbType.Bit).Value = objCls._is_Adr;
                cmd.Parameters.Add("@adr_underlying_ticker", SqlDbType.NVarChar).Value = objCls._adr_Underlying_Ticker;
                cmd.Parameters.Add("@adr_underlying_currency", SqlDbType.NVarChar).Value = objCls._adr_Underlying_Currency;
                cmd.Parameters.Add("@shares_per_adr", SqlDbType.NVarChar).Value = objCls._shares_Per_Adr;
                cmd.Parameters.Add("@ipo_date", SqlDbType.Date).Value = objCls._ipo_Date;
                cmd.Parameters.Add("@price_currency", SqlDbType.NVarChar).Value = objCls._price_Currency;
                cmd.Parameters.Add("@settle_days", SqlDbType.BigInt).Value = objCls._settle_Days;
                cmd.Parameters.Add("@shares_outstanding", SqlDbType.NVarChar).Value = objCls._shares_Outstanding;
                cmd.Parameters.Add("@voting_rights_per_share", SqlDbType.NVarChar).Value = objCls._voting_Rights_Per_Share;
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
                cmd.Parameters.Add("@twenty_day_average_volume", SqlDbType.NVarChar).Value = objCls._twenty_Day_Average_Volume;
                cmd.Parameters.Add("@beta", SqlDbType.NVarChar).Value = objCls._beta;
                cmd.Parameters.Add("@short_interest", SqlDbType.NVarChar).Value = objCls._short_Interest;
                cmd.Parameters.Add("@ytd_return", SqlDbType.NVarChar).Value = objCls._ytd_Return;
                cmd.Parameters.Add("@ninty_day_price_volatility", SqlDbType.NVarChar).Value = objCls._ninty_Day_Price_Volatility;
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
                cmd.Parameters.Add("@open_price", SqlDbType.Money).Value = objCls._open_Price;
                cmd.Parameters.Add("@close_price", SqlDbType.Money).Value = objCls._close_Price;
                cmd.Parameters.Add("@volume", SqlDbType.BigInt).Value = objCls._volume;
                cmd.Parameters.Add("@last_price", SqlDbType.Money).Value = objCls._last_Price;
                cmd.Parameters.Add("@ask_price", SqlDbType.Money).Value = objCls._ask_Price;
                cmd.Parameters.Add("@bid_price", SqlDbType.Money).Value = objCls._bid_Price;
                cmd.Parameters.Add("@pe_ratio", SqlDbType.Float).Value = objCls._pe_Ratio;
                cmd.Parameters.Add("@declared_date", SqlDbType.Date).Value = objCls._declared_Date;
                cmd.Parameters.Add("@ex_date", SqlDbType.Date).Value = objCls._ex_Date;
                cmd.Parameters.Add("@record_date", SqlDbType.Date).Value = objCls._record_Date;
                cmd.Parameters.Add("@pay_date", SqlDbType.Date).Value = objCls._pay_Date;
                cmd.Parameters.Add("@amount", SqlDbType.Money).Value = objCls._amount;
                cmd.Parameters.Add("@frequency", SqlDbType.NVarChar).Value = objCls._frequency;
                cmd.Parameters.Add("@dividend_type", SqlDbType.NVarChar).Value = objCls._dividend_Type;
                cmd.Parameters.Add("@security_id", SqlDbType.BigInt).Value = objCls._security_Id;
                cmd.Parameters["@security_id"].Direction = ParameterDirection.Output;
                cmd.CommandText = "eq.sp_ivp_polaris_iudfull_security";
                return connect.executeStoreprocedure(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
