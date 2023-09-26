using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DataAccess
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
      
        #region SQL FUNCTIONS
        public DataAccess(string strConnectionString)
        {
            this.strConnectionString = strConnectionString;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(strConnectionString);
            connection.Open(); // Open the connection
            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close(); // Close the connection if it's open
            }
        }

        public void DisposeConnection(SqlConnection connection)
        {
            if (connection != null)
            {
                connection.Dispose(); // Dispose of the connection object
            }
        }
        #endregion
    }
}