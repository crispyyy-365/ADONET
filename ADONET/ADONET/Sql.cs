using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    internal class Sql
    {
        private const string connection = @"server=LAPTOP-E5JPOQ6L\SQLEXPRESS;database=DATABASEADONET;trusted_connection=true;integrated security=true;";

        private static SqlConnection sqlConnection = new SqlConnection(connection);

        public int ExecuteCommand(string command)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(command);
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
    }
}