using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.filewatcher
{
    public partial class P_Util
    {
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
