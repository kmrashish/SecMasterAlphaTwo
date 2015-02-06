using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.ivp.polaris.datalayer;
using System.Data;

namespace com.ivp.polaris.loadsecurity
{
    public partial class P_Wizard_Panel
    {
        P_Core_Ivp_Polaris_Connect connect = new P_Core_Ivp_Polaris_Connect();
        public DataTable SelectFile(string fileType, string filePath, string sheetNameOrSeperator)
        {
            try
            {
                DataTable MyDt = new DataTable();
                if (fileType == "CSV")
                {
                    IP_File_Csv objinter = new P_Raw_Csv();
                    MyDt = objinter.Read(filePath, Convert.ToChar(sheetNameOrSeperator));
                }
                else if (fileType == "XLS")
                {
                    IP_File_Excel objinter = new P_Raw_Excel();
                    MyDt = objinter.Read(filePath, sheetNameOrSeperator);
                }
                else
                {
                    throw new Exception("File Format Not Supported");
                }
                return MyDt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListClass> GetTablesOrStoreProcedure(SqlConnection conn)
        {
            List<ListClass> lstClass = new List<ListClass>();
            DataTable MyDt = new DataTable();
            try
            {
                string Query = "select 'pro' id,CONCAT(specific_schema,'.',specific_name) as Name from INFORMATION_SCHEMA.ROUTINES where ROUTINE_TYPE='procedure'";
                foreach (DataRow val in connect.returnDataset(Query).Tables[0].Rows)
                    lstClass.Add(new ListClass(val[0].ToString(), val[1].ToString()));
                Query = "select 'tab' id,CONCAT(table_schema,'.',table_name) as Name from INFORMATION_SCHEMA.TABLES";
                foreach (DataRow val in connect.returnDataset(Query).Tables[0].Rows)
                    lstClass.Add(new ListClass(val[0].ToString(), val[1].ToString()));

                return lstClass;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> GetSourceFields()
        {
            try
            {
                List<string> lstStr = new List<string>();
                DataTable MyDt = new DataTable();
                MyDt = SelectFile("", "", "");
                foreach (var columns in MyDt.Columns)
                    lstStr.Add(columns.ToString());
                return lstStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetDestinationFields(ListClass lstCLass)
        {
            try 
            {
                List<string> lstStr = new List<string>();
                string query="";
                DataTable MyDt = new DataTable();
                if(lstCLass._type=="tab")
                {
                    query = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA='{0}' and TABLE_NAME='{1}'";
                    query=string.Format(query,lstCLass._name.Substring(0,lstCLass._name.LastIndexOf(".")),lstCLass._name.Substring(lstCLass._name.LastIndexOf(".")));
                    MyDt = connect.returnDataset(query).Tables[0];
                    foreach (var columns in MyDt.Columns)
                        lstStr.Add(columns.ToString());
                }
                else if (lstCLass._type == "pro")
                {
                    query = "select PARAMETER_NAME from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_SCHEMA='{0}' and SPECIFIC_NAME='{1}'";
                    query = string.Format(query, lstCLass._name.Substring(0, lstCLass._name.LastIndexOf(".")), lstCLass._name.Substring(lstCLass._name.LastIndexOf(".")));
                    MyDt = connect.returnDataset(query).Tables[0];
                    foreach (var columns in MyDt.Columns)
                        lstStr.Add(columns.ToString());
                }
                return lstStr;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }

    public class ListClass
    {
        public string _type { get; set; }
        public string _name { get; set; }

        public ListClass(string type, string name)
        {
            _type = type;
            _name = name;
        }
    }
}
