using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace com.ivp.polaris.loadsecurity
{
    public partial class P_Raw_Excel:IP_File_Excel
    {
        Microsoft.Office.Interop.Excel.Application Oexl;
        Workbook Owb;
        Worksheet Ows;

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                GC.Collect();
            }
        }

        public bool Write(string fileName, DataSet ds)
        {
            Oexl = new Microsoft.Office.Interop.Excel.Application();
            string _TempPath = Path.GetFullPath(fileName);
            if (!File.Exists(_TempPath)) //Check for Existing file, if not create a new one.
            {
                Owb = Oexl.Workbooks.Add(1);
                Owb.SaveCopyAs(_TempPath);
            }

            Owb = Oexl.Workbooks.Open(_TempPath, 0, false, 5, "MYPersonal@123", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false); //Define Path of Excel Sheet

            int rowcount = 10;
            int tab = 0;
            try
            {
                if (ds != null)
                {
                    foreach (System.Data.DataTable dt in ds.Tables)
                    {
                        Ows = (Worksheet)Owb.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value); // Add new Worksheet Of Excel
                        //Ows.Name = ds.Tables[tab].TableName;

                        foreach (DataRow dr in dt.Rows)
                        {
                            rowcount++;
                            for (int i = 1; i <= dt.Columns.Count; i++)
                            {
                                //MessageBox.Show(dt.Columns[i-1].DataType.ToString());
                                Ows.Cells[rowcount, i] = dr[i - 1].ToString();
                            }
                            Ows.Columns.AutoFit();
                        }
                        rowcount = 10;
                        ++tab;
                    }
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                Owb.Password = "MYPersonal@123";
                Owb.Save();
                Owb.Close(false, Missing.Value, Missing.Value);
                Oexl.Quit();
                releaseObject(Owb);
                releaseObject(Ows);
                releaseObject(Oexl);
            }
        }

        public System.Data.DataTable Read(string excelFile, string sheetName)
        {
            try
            {
                System.Data.DataTable dv = new System.Data.DataTable();
                string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + ";Extended Properties='Excel 8.0;HDR=Yes;'";
                using (OleDbConnection connection = new OleDbConnection(con))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("select * from [" + sheetName + "$]", connection);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(command))
                    {
                        da.Fill(dv);
                        //dv = dv.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
                    }
                }
                return dv;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
