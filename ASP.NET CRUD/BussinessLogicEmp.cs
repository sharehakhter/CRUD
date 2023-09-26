using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.DataAccess;
using System.Configuration;


namespace WebApp
{
    public class BussinessLogicEmp
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
        private SqlDataAdapter sqlDataAdapter;
        DataSet dtSet;
        DataTable dt;

        public int Add(ClsEmp objEmp)
        {
            try
            {
                DataAccess objData = new DataAccess(strConnectionString);

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = objData.GetConnection();

                sqlCommand.CommandText = "sp_CRUD";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Event", "Add");
                sqlCommand.Parameters.AddWithValue("@FirstName", objEmp.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", objEmp.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", objEmp.Address);
                sqlCommand.Parameters.AddWithValue("@CNICNo", objEmp.CNICNo);
                sqlCommand.Parameters.AddWithValue("@PhoneNo", objEmp.PhoneNo);
                sqlCommand.Parameters.AddWithValue("@JobTitle", objEmp.JobTitle);
                sqlCommand.Parameters.AddWithValue("@DOB", objEmp.DOB);
                sqlCommand.Parameters.AddWithValue("@CurrentSalary", objEmp.CurrentSalary);

                int m = sqlCommand.ExecuteNonQuery();

                objData.CloseConnection(sqlCommand.Connection);
                objData.DisposeConnection(sqlCommand.Connection);

                return m;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet Bind()
        {
            DataAccess objData = new DataAccess(strConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = objData.GetConnection();
            sqlCommand.CommandText = "sp_CRUD";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Event", "Select");
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dtSet = new DataSet();
            sqlDataAdapter.Fill(dtSet);

            objData.CloseConnection(sqlCommand.Connection);
            objData.DisposeConnection(sqlCommand.Connection);

            return dtSet;
        }


        public DataSet Search(ClsEmp objEmp)
        {
            DataAccess objData = new DataAccess(strConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = objData.GetConnection();
            sqlCommand.CommandText = "sp_CRUD";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Event", "Search");
            sqlCommand.Parameters.AddWithValue("@SearchWord", objEmp.SearchWord);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dtSet = new DataSet();
            sqlDataAdapter.Fill(dtSet);

            objData.CloseConnection(sqlCommand.Connection);
            objData.DisposeConnection(sqlCommand.Connection);

            return dtSet;
        }

        public int Update(ClsEmp objEmp)
        {
            try
            {
                DataAccess objData = new DataAccess(strConnectionString);

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = objData.GetConnection();


                sqlCommand.CommandText = "sp_CRUD";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Event", "Update");
                sqlCommand.Parameters.AddWithValue("@EmpId", objEmp.EmpId);
                sqlCommand.Parameters.AddWithValue("@FirstName", objEmp.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", objEmp.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", objEmp.Address);
                sqlCommand.Parameters.AddWithValue("@CNICNo", objEmp.CNICNo);
                sqlCommand.Parameters.AddWithValue("@PhoneNo", objEmp.PhoneNo);
                sqlCommand.Parameters.AddWithValue("@JobTitle", objEmp.JobTitle);
                sqlCommand.Parameters.AddWithValue("@DOB", objEmp.DOB);
                sqlCommand.Parameters.AddWithValue("@CurrentSalary", objEmp.CurrentSalary);

                int m = sqlCommand.ExecuteNonQuery();

                objData.CloseConnection(sqlCommand.Connection);
                objData.DisposeConnection(sqlCommand.Connection);

                return m;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete(ClsEmp objEmp)
        {
            DataAccess objData = new DataAccess(strConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = objData.GetConnection();

            sqlCommand.CommandText = "sp_CRUD";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Event", "Delete");
            sqlCommand.Parameters.AddWithValue("@EmpId", objEmp.EmpId);

            int m = sqlCommand.ExecuteNonQuery();

            objData.CloseConnection(sqlCommand.Connection);
            objData.DisposeConnection(sqlCommand.Connection);

            return m;
        }

        public DataTable GetLogin(ClsEmp objEmp)
        {
            DataAccess objData = new DataAccess(strConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = objData.GetConnection();

            sqlCommand.CommandText = "sp_GetLogin";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserName", objEmp.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", objEmp.Password);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            objData.CloseConnection(sqlCommand.Connection);
            objData.DisposeConnection(sqlCommand.Connection);

            return dt;
        }
    }
}