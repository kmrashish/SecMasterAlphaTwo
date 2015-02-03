using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SecMasterVersionTwo
{
    public class ivp_secm_DAL:IFactoryBase
    {
        public void ExecuteProcedure(string procedureName, string procedureParameters, SqlConnection connection)
        {
            try
            {
                connection.Open();
                //call the procedure with the procedure name and supplying the parameters
            }
            catch (Exception ex)
            {
                //handle the exception, and rollback the transaction if needed
            }
            finally
            {
                connection.Close();
            }
        }
        public void ExecuteProcedure(string procedureName, string procedureParameters)
        {
            string ConnectionString="";
            SqlConnection connection=new SqlConnection(ConnectionString);
            ExecuteProcedure(procedureName, procedureParameters, connection);
        }

        public void ExecuteTextQuery(char TypeOfQuery, string columns, string table_name, SqlConnection connection)
        {
            try
            {
                connection.Open();
                // execute the query, complete the operation
            }
            catch (Exception ex)
            {
                //handle the exception, if transaction was hindered, rollback the transaction
            }
            finally
            {
                connection.Close();
            }            
        }
        public void ExecuteTextQuery(char TypeOfQuery, string columns, string table_name)
        {
            string ConnectionString = "";
            SqlConnection connection = new SqlConnection(ConnectionString);
            ExecuteTextQuery(TypeOfQuery, columns, table_name, connection);
        }

        public void ExecuteSelectQuery(string columns, string table_name, SqlConnection connection)
        {
            try
            {
                connection.Open();
                //execute the select query and display the result
            }
            catch (Exception ex)
            {
                //check for exception and handle likewise
            }
            finally
            {
                connection.Close();
            }
        }
        public void ExecuteSelectQuery(string columns, string table_name)
        {
            string ConnectionString = "";
            SqlConnection connection = new SqlConnection(ConnectionString);
            ExecuteSelectQuery(columns, table_name, connection);
        }

        public void ExecuteBulkCopy(string table_name, DataSet myDataSet, SqlConnection connection)
        {
            try
            {
                connection.Open();
                //perform the bulk copy operation from source tables to destination tables
            }
            catch (Exception ex)
            {
                //handle the exception and rollback the transaction if needed
            }
            finally
            {
                connection.Close();
            }
        }
        public void ExecuteBulkCopy(string table_name, DataSet myDataSet)
        {
            string ConnectionString = "";
            SqlConnection connection = new SqlConnection(ConnectionString);
            ExecuteBulkCopy(table_name, myDataSet, connection);
        }
    }
}
