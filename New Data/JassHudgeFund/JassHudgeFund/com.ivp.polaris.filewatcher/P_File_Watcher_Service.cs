using com.ivp.polaris.datalayer;
using com.ivp.polaris.loadsecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace com.ivp.polaris.filewatcher
{
    partial class P_File_Watcher_Service : ServiceBase
    {
        public P_File_Watcher_Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            JassWatcher.Path = ConfigurationManager.AppSettings["FileWatch"];
            P_ErrorLib.WriteErrorLog("Service Started");
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        private void JassWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                P_ErrorLib.WriteErrorLog("File Dropped New");
                GetProcess(e.FullPath, e.Name);
            }
            catch (Exception ex)
            {
                P_ErrorLib.WriteErrorLog(ex);
            }



        }

        private void JassWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        public void GetProcess(string filePath, string fileName)
        {
            try
            {
                P_ErrorLib.WriteErrorLog("Start Process");
                P_ErrorLib.WriteErrorLog(filePath);
                string extension = fileName.Substring(fileName.LastIndexOf('.') + 1);
                P_ErrorLib.WriteErrorLog(extension);

                if (extension == "xls" || extension == "XLS")
                {
                    DataTable dt = P_ErrorLib.Read(filePath, "Security");
                    if (fileName.Contains("eq"))
                    {
                        if (fileName.Contains("INSERT"))
                        {
                            SetEquity(dt, "INSERT");
                            P_ErrorLib.WriteErrorLog("INSERTED");
                        }
                        else if (fileName.Contains("DELETE"))
                        {
                            SetEquity(dt, "DELETE");
                            P_ErrorLib.WriteErrorLog("DELETED");
                        }
                        else if (fileName.Contains("UPDATE"))
                        {
                            SetEquity(dt, "UPDATE");
                            P_ErrorLib.WriteErrorLog("UPDATED");
                        }
                        else
                        {
                            P_ErrorLib.WriteErrorLog("IN XLS ERROR FORMAT");
                        }
                    }
                    else if (fileName.Contains("cb"))
                    {
                        if (fileName.Contains("INSERT"))
                        {
                            SetBond(dt, "INSERT");
                            P_ErrorLib.WriteErrorLog("INSERTED");
                        }
                        else if (fileName.Contains("DELETE"))
                        {
                            SetBond(dt, "DELETE");
                            P_ErrorLib.WriteErrorLog("DELETED");
                        }
                        else if (fileName.Contains("UPDATE"))
                        {
                            SetBond(dt, "UPDATE");
                            P_ErrorLib.WriteErrorLog("UPDATED");
                        }
                        else
                        {
                            P_ErrorLib.WriteErrorLog("IN XLS ERROR FORMAT");
                        }
                    }
                }
                else
                {
                    P_ErrorLib.WriteErrorLog("File Format Not Supported.");
                }
            }
            catch (Exception ex)
            {
                P_ErrorLib.WriteErrorLog("ex");
                P_ErrorLib.WriteErrorLog(ex);
            }
        }

        public bool SetEquity(DataTable dt, string type)
        {
            try
            {
                P_ErrorLib.WriteErrorLog("SET EQUITY");
                P_SP_Ivp_Polaris_EqFull objCls = new P_SP_Ivp_Polaris_EqFull();
                foreach (DataRow dr in dt.Rows)
                {
                    objCls._security_Id = dr["security_id"] == DBNull.Value ? 0 : Convert.ToInt64(dr["security_id"]);
                    objCls._securiry_Name = dr["securiry_name"].ToString();
                    objCls._securiry_Description = dr["securiry_description"].ToString();
                    objCls._has_Position = Convert.ToBoolean(dr["has_position"]);
                    objCls._is_Active = Convert.ToBoolean(dr["is_active"]);
                    objCls._round_Lot_Size = Convert.ToInt32(dr["round_lot_size"]);
                    objCls._bloomberg_Unique_Name = dr["bloomberg_unique_name"].ToString();
                    objCls._created_By = dr["created_by"].ToString();
                    objCls._created_On = Convert.ToDateTime(dr["created_on"]);
                    objCls._last_Modified_By = dr["last_modified_by"].ToString();
                    objCls._last_Modified_On = Convert.ToDateTime(dr["last_modified_on"]);
                    objCls._is_Adr = Convert.ToBoolean(dr["is_adr"]);
                    objCls._adr_Underlying_Ticker = dr["adr_underlying_ticker"].ToString();
                    objCls._adr_Underlying_Currency = dr["adr_underlying_currency"].ToString();
                    objCls._shares_Per_Adr = dr["shares_per_adr"].ToString();
                    objCls._ipo_Date = Convert.ToDateTime(dr["ipo_date"]);
                    objCls._price_Currency = dr["price_currency"].ToString();
                    objCls._settle_Days = Convert.ToInt32(dr["settle_days"]);
                    objCls._shares_Outstanding = dr["shares_outstanding"].ToString();
                    objCls._voting_Rights_Per_Share = dr["voting_rights_per_share"].ToString();
                    objCls._form_Pf_Asset_Class = dr["form_pf_asset_class"].ToString();
                    objCls._form_Pf_Country = dr["form_pf_country"].ToString();
                    objCls._form_Pf_Credit_Rating = dr["form_pf_credit_rating"].ToString();
                    objCls._form_Pf_Currency = dr["form_pf_currency"].ToString();
                    objCls._form_Pf_Instrument = dr["form_pf_instrument"].ToString();
                    objCls._form_Pf_Liquid_Profile = dr["form_pf_liquid_profile"].ToString();
                    objCls._form_Pf_Maturity = dr["form_pf_maturity"].ToString();
                    objCls._form_Pf_Naics_Code = dr["form_pf_naics_code"].ToString();
                    objCls._form_Pf_Region = dr["form_pf_region"].ToString();
                    objCls._form_Pf_Sector = dr["form_pf_sector"].ToString();
                    objCls._form_Pf_Sub_Asset_Class = dr["form_pf_sub_asset_class"].ToString();
                    objCls._twenty_Day_Average_Volume = dr["twenty_day_average_volume"].ToString();
                    objCls._beta = dr["beta"].ToString();
                    objCls._short_Interest = dr["short_interest"].ToString();
                    objCls._ytd_Return = dr["ytd_return"].ToString();
                    objCls._ninty_Day_Price_Volatility = dr["ninty_day_price_volatility"].ToString();
                    objCls._issue_Country = dr["issue_country"].ToString();
                    objCls._exchange = dr["exchange"].ToString();
                    objCls._issuer = dr["issuer"].ToString();
                    objCls._issue_Currency = dr["issue_currency"].ToString();
                    objCls._trading_Currency = dr["trading_currency"].ToString();
                    objCls._bloomberg_Industry_Sub_Group = dr["bloomberg_industry_sub_group"].ToString();
                    objCls._bloomberg_Industry_Group = dr["bloomberg_industry_group"].ToString();
                    objCls._bloomberg_Industry_Sector = dr["bloomberg_industry_sector"].ToString();
                    objCls._country_Of_Incorporation = dr["country_of_incorporation"].ToString();
                    objCls._risk_Currency = dr["risk_currency"].ToString();
                    objCls._cusip = dr["cusip"].ToString();
                    objCls._isin = dr["isin"].ToString();
                    objCls._sedol = dr["sedol"].ToString();
                    objCls._bloomberg_Ticker = dr["bloomberg_ticker"].ToString();
                    objCls._bloomberg_Unique_Id = Convert.ToInt32(dr["bloomberg_unique_id"]);
                    objCls._bloomberg_Global_Id = Convert.ToInt32(dr["bloomberg_global_id"]);
                    objCls._open_Price = Convert.ToDecimal(dr["open_price"]);
                    objCls._close_Price = Convert.ToDecimal(dr["close_price"]);
                    objCls._volume = Convert.ToInt64(dr["volume"]);
                    objCls._last_Price = Convert.ToDecimal(dr["last_price"]);
                    objCls._ask_Price = Convert.ToDecimal(dr["ask_price"]);
                    objCls._bid_Price = Convert.ToDecimal(dr["bid_price"]);
                    objCls._pe_Ratio = float.Parse(dr["pe_ratio"].ToString());
                    objCls._declared_Date = Convert.ToDateTime(dr["declared_date"]);
                    objCls._ex_Date = Convert.ToDateTime(dr["ex_date"]);
                    objCls._record_Date = Convert.ToDateTime(dr["record_date"]);
                    objCls._pay_Date = Convert.ToDateTime(dr["pay_date"]);
                    objCls._amount = Convert.ToDecimal(dr["amount"]);
                    objCls._frequency = dr["frequency"].ToString();
                    objCls._dividend_Type = dr["dividend_type"].ToString();
                    objCls.Insert_Update_Delete_EQ(objCls, type);
                }
                return true;
            }
            catch (Exception ex)
            {
                P_ErrorLib.WriteErrorLog("SP ERROR");
                P_ErrorLib.WriteErrorLog(ex);
                throw ex;
            }
        }

        public bool SetBond(DataTable dt,string type)
        {
            try
            {
                P_ErrorLib.WriteErrorLog("SET BOND");
                P_SP_Ivp_Polaris_CbFull objCls = new P_SP_Ivp_Polaris_CbFull();
                foreach (DataRow dr in dt.Rows)
                {
                    objCls._security_Id = dr["security_id"] == DBNull.Value ? 0 : Convert.ToInt64(dr["security_id"]);
                    objCls._securiry_Name = dr["securiry_name"].ToString();
                    objCls._securiry_Description = dr["securiry_description"].ToString();
                    objCls._asset_Type = Convert.ToString(dr["asset_Type"]);
                    objCls._investment_Type = Convert.ToString(dr["investment_Type"]);
                    objCls._trading_Factor = Convert.ToString(dr["trading_factor"]);
                    objCls._pricing_Factor = dr["pricing_factor"].ToString();
                    objCls._created_By = dr["created_by"].ToString();
                    objCls._created_On = Convert.ToDateTime(dr["created_on"]);
                    objCls._last_Modified_By = dr["last_modified_by"].ToString();
                    objCls._last_Modified_On = Convert.ToDateTime(dr["last_modified_on"]);
                    objCls._is_Active = Convert.ToBoolean(dr["is_active"]);
                    objCls._first_Coupon_Date = Convert.ToDateTime(dr["first_coupon_date"]);
                    objCls._coupon_Cap = dr["coupon_cap"].ToString();
                    objCls._coupon_Floor = dr["coupon_floor"].ToString();
                    objCls._coupon_Frequency = Convert.ToString(dr["coupon_frequency"]);
                    objCls._coupon_Rate = dr["coupon_rate"].ToString();
                    objCls._coupon_Type = Convert.ToString(dr["coupon_type"]);
                    objCls._float_Spread = dr["float_spread"].ToString();
                    objCls._is_Callable = Convert.ToBoolean(dr["is_callable"]);
                    objCls._is_Fix_To_Float = Convert.ToBoolean(dr["is_fix_to_float"]);
                    objCls._is_Putable = Convert.ToBoolean(dr["is_putable"]);
                    objCls._issue_Date = Convert.ToDateTime(dr["issue_date"]);
                    objCls._last_Reset_Date = Convert.ToDateTime(dr["last_reset_date"]);
                    objCls._maturity_Date = Convert.ToDateTime(dr["maturity_date"]);
                    objCls._maximum_Call_Notice_Days = Convert.ToInt64(dr["maximum_call_notice_days"]);
                    objCls._maximum_Put_Notice_Days = Convert.ToInt64(dr["maximum_put_notice_days"]);
                    objCls._penultimate_Coupon_Date = Convert.ToDateTime(dr["penultimate_coupon_date"]);
                    objCls._reset_Frequency = dr["reset_frequency"].ToString();
                    objCls._has_Position = Convert.ToBoolean(dr["has_position"]);
                    objCls._form_Pf_Asset_Class = dr["form_pf_asset_class"].ToString();
                    objCls._form_Pf_Country = dr["form_pf_country"].ToString();
                    objCls._form_Pf_Credit_Rating = dr["form_pf_credit_rating"].ToString();
                    objCls._form_Pf_Currency = dr["form_pf_currency"].ToString();
                    objCls._form_Pf_Instrument = dr["form_pf_instrument"].ToString();
                    objCls._form_Pf_Liquid_Profile = dr["form_pf_liquidity_profile"].ToString();
                    objCls._form_Pf_Maturity = dr["form_pf_maturity"].ToString();
                    objCls._form_Pf_Naics_Code = dr["form_pf_naics_code"].ToString();
                    objCls._form_Pf_Region = dr["form_pf_region"].ToString();
                    objCls._form_Pf_Sector = dr["form_pf_sector"].ToString();
                    objCls._form_Pf_Sub_Asset_Class = dr["form_pf_sub_asset_class"].ToString();
                    objCls._firstcouponcode = dr["firstcouponcode"].ToString();
                    objCls._duration = dr["duration"].ToString();
                    objCls._volatility_ThirtyD = dr["volatility_thirtyD"].ToString();
                    objCls._volatility_NintyD = dr["volatility_nintyD"].ToString();
                    objCls._convexity = dr["convexity"].ToString();
                    objCls._average_Volume_ThirtyD = dr["average_volume_thirtyD"].ToString();
                    objCls._issue_Country = dr["issue_country"].ToString();
                    objCls._exchange = dr["exchange"].ToString();
                    objCls._issuer = dr["issuer"].ToString();
                    objCls._issue_Currency = dr["issue_currency"].ToString();
                    objCls._trading_Currency = dr["trading_currency"].ToString();
                    objCls._bloomberg_Industry_Sub_Group = dr["bloomberg_industry_sub_group"].ToString();
                    objCls._bloomberg_Industry_Group = dr["bloomberg_industry_group"].ToString();
                    objCls._bloomberg_Industry_Sector = dr["bloomberg_industry_sector"].ToString();
                    objCls._country_Of_Incorporation = dr["country_of_incorporation"].ToString();
                    objCls._risk_Currency = dr["risk_currency"].ToString();
                    objCls._cusip = dr["cusip"].ToString();
                    objCls._isin = dr["isin"].ToString();
                    objCls._sedol = dr["sedol"].ToString();
                    objCls._bloomberg_Ticker = dr["bloomberg_ticker"].ToString();
                    objCls._bloomberg_Unique_Id = Convert.ToInt32(dr["bloomberg_unique_id"]);
                    objCls._bloomberg_Global_Id = Convert.ToInt32(dr["bloomberg_global_id"]);
                    objCls._call_Date = Convert.ToDateTime(dr["call_date"]);
                    objCls._call_Price = Convert.ToDecimal(dr["call_price"]);
                    objCls._put_Date = Convert.ToDateTime(dr["put_date"]);
                    objCls._put_Price = Convert.ToDecimal(dr["put_price"]);
                    objCls._ask_Price = Convert.ToDecimal(dr["ask_price"]);
                    objCls._high_Price = Convert.ToDecimal(dr["high_price"]);
                    objCls._low_Price = Convert.ToDecimal(dr["low_price"]);
                    objCls._open_Price = Convert.ToDecimal(dr["open_price"]);
                    objCls._volume = Convert.ToInt64(dr["volume"]);
                    objCls._bid_Price = Convert.ToDecimal(dr["bid_price"]);
                    objCls._last_Price = Convert.ToDecimal(dr["last_price"]);
                    objCls.Insert_Update_Delete_CB(objCls, type);
                }
                return true;
            }
            catch (Exception ex)
            {
                P_ErrorLib.WriteErrorLog("SP ERROR");
                P_ErrorLib.WriteErrorLog(ex);
                throw ex;
            }
        }

    }
}
