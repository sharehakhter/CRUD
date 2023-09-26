using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;      

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginMethod();
        }

        public void LoginMethod()
        {
            ClsEmp objEmp = new ClsEmp();
            BussinessLogicEmp objBL = new BussinessLogicEmp();

            objEmp.UserName = txtUser.Text.Trim();
            objEmp.Password = txtPass.Text.Trim();

            DataTable dt = new DataTable();

            dt = objBL.GetLogin(objEmp);

            if (dt.Rows.Count > 0)
            {
                Session["dtAdmin"] = dt;
                Response.Redirect("Add.aspx");
            }
            else
            {
                Clear();
                lblMsg.Text = "Your username and password is incorrect";
            }
        }

        public void Clear()
        {
            txtUser.Text = txtPass.Text = "";
            lblMsg.Text = "";
        }
    }
}