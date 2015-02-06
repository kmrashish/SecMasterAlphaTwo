using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace ParserModuleAlpha
{
    class Program
    {
        static void Main(string[] args)
        {
            //this count will keep track of the number of securities stored in the data
            int noOfSecuritiesNow = CountSecurities();

            OleDbConnection con;
            DataSet ds;
            OleDbDataAdapter adapter;
            con = new OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\ashikumar\Downloads\Equity File.xls';Extended Properties='Excel 12.0;IMEX=1'");
            adapter = new OleDbDataAdapter("select * from [Equities$]", con);
            adapter.TableMappings.Add("Table", "TestTable");
            ds = new DataSet();
            adapter.Fill(ds);

            
            
            

            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            

            DataTable security_identifier_datatable = dt.DefaultView.ToTable(false, "CUSIP", "ISIN", "SEDOL", "Bloomberg Ticker", "Bloomberg Unique ID", "BBG Global ID", "Ticker and Exchange");
            security_identifier_datatable = security_identifier_datatable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

            DataColumn secid_column = new DataColumn("Security ID");
            secid_column.DataType = typeof(Int32);
            secid_column.AutoIncrement = true;
            secid_column.AutoIncrementSeed = 100;
            secid_column.AutoIncrementStep = 1;   
            
            security_identifier_datatable.Columns.Add(secid_column);
            secid_column.SetOrdinal(0);

            //DataGridView dgv = new DataGridView();
            //dgv.Size = new System.Drawing.Size(400, 400);
            //this.Controls.Add(dgv);
            //dgv.DataSource = security_identifier_datatable;

            
            con.Close();

            string ActualConnectionString = @"Data Source=192.168.0.63\DEV05H;Initial Catalog=MCA2015;User ID=mca2015;Password=ivp@123;";


            using (con)
            {
                con.Open();
                using (SqlBulkCopy sbc = new SqlBulkCopy(ActualConnectionString))
                {
                    sbc.DestinationTableName = "core.ivp_securityMaster_core_securityidentifier";

                    try
                    {
                        sbc.WriteToServer(security_identifier_datatable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            Console.Read();

            
        }

        private int CountSecurities()
        {
            string connectionString = @"Data Source=192.168.0.63\DEV05H;Initial Catalog=MCA2015;User ID=mca2015;Password=ivp@123;";
            SqlConnection conn = new SqlConnection(connectionString);
            int noOfSecuritiesNow = 0;
            try
            {
                conn.Open();
                string query = "select count(*) from core.ivp_securityMaster_core_securityidentifier";
                //SqlDataReader rdr;
                SqlCommand cmd = new SqlCommand(query, conn);
                noOfSecuritiesNow = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message);  }
            finally { conn.Close(); }
            return noOfSecuritiesNow;           
        }

    }
}

