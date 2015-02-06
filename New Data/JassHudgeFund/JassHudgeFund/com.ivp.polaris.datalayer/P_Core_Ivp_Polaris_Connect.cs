using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.datalayer
{
    public partial class P_Core_Ivp_Polaris_Connect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt = new DataTable();

        SqlConnection getConnection()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString());
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet returnDataset(string query)
        {
            try
            {
                ds = new DataSet();
                da = new SqlDataAdapter(query, getConnection());
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int executeQuery(String Query, SqlConnection connection = null)
        {
            SqlConnection connectionnew = connection == null ? getConnection() : connection;
            try
            {
                connectionnew.Open();
                cmd = new SqlCommand(Query, connectionnew);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectionnew.Close();
            }
        }

        public object executeScaler(String Query)
        {
            SqlConnection con = getConnection();
            try
            {
                con.Open();
                cmd = new SqlCommand(Query, con);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool executeStoreprocedure(SqlCommand cmd)
        {
            SqlConnection con = getConnection();
            try
            {
                con.Open();
                cmd.Connection = con;
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
    }
}
