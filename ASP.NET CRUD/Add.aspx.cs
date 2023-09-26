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
    public partial class Add : System.Web.UI.Page
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;     
        DataSet dtSet;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserIsLoggedIn())
                {
                    BindEmployee();
                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        
        #region Submit / Add

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Submit();
                BindEmployee();
            }
            catch (Exception ex)
            {

            }
        }

        public void Submit()
        {
            if (Validation())
            {
                ClsEmp objEmp = new ClsEmp();
                BussinessLogicEmp objBL = new BussinessLogicEmp();

                objEmp.FirstName = Convert.ToString(txtFirstName.Text.Trim());
                objEmp.LastName = Convert.ToString(txtLastName.Text.Trim());
                objEmp.Address = Convert.ToString(txtAddress.Text.Trim());
                objEmp.CNICNo = Convert.ToString(txtCNIC.Text.Trim());
                objEmp.PhoneNo = Convert.ToString(txtPhone.Text.Trim());
                objEmp.JobTitle = Convert.ToString(txtJobTitle.Text.Trim());
                objEmp.DOB = Convert.ToString(txtDOB.Text.Trim());
                objEmp.CurrentSalary = Convert.ToString(txtSalary.Text);

                int m = objBL.Add(objEmp);

                if (m != 0)
                {
                    Response.Write("<<script>alert('Data Inserted')</script>");
                    Clear();
                }
                else
                {
                    Response.Write("<<script>alert('Data Not Inserted')</script>");
                }
            }

            else
            {
                Response.Write("<<script>alert('Phone # / CNIC # is Invalid or Empty')</script>");
            }

        } 
        #endregion

        public void BindEmployee()
        {
            ClsEmp objEmp = new ClsEmp();
            BussinessLogicEmp objBL = new BussinessLogicEmp();

            dtSet = objBL.Bind();

            grvEmployee.DataSource = dtSet;
            grvEmployee.DataBind();

        }

        protected void grvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grvEmployee.PageIndex = e.NewPageIndex;
            //BindEmployee();  
        }

        protected void grvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //rvEmployee.EditIndex = -1;
            // BindEmployee();  
        }

        protected void grvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClsEmp objEmp = new ClsEmp();
            BussinessLogicEmp objBL = new BussinessLogicEmp();

            objEmp.EmpId = Convert.ToInt32(((Label)grvEmployee.Rows[e.RowIndex].FindControl("lblEmpId")).Text);

            int m = objBL.Delete(objEmp);

            if (m != 0)
            {
                Response.Write("<<script>alert('Data Deleted Successfully ')</script>");
            }
            else
            {
                Response.Write("<<script>alert('Data Not Deleted')</script>");
            }

            BindEmployee();

        }

        protected void grvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int RowIndex = e.NewEditIndex;
            Label empid = (Label)grvEmployee.Rows[RowIndex].FindControl("lblEmpId");
            Session["EmpId"] = empid.Text;

            txtFirstName.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblFirstName")).Text.ToString();
            txtLastName.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblLastName")).Text.ToString();
            txtAddress.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblAddress")).Text.ToString();
            txtCNIC.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblCNICNo")).Text.ToString();
            txtPhone.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblPhoneNo")).Text.ToString();
            txtJobTitle.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblJobTitle")).Text.ToString();
            txtDOB.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblDOB")).Text.ToString();
            txtSalary.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblCurrentSalary")).Text.ToString();

            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                ClsEmp objEmp = new ClsEmp();
                BussinessLogicEmp objBL = new BussinessLogicEmp();

                objEmp.EmpId = Convert.ToInt32((Session["EmpId"]));
                objEmp.FirstName = Convert.ToString(txtFirstName.Text.Trim());
                objEmp.LastName = Convert.ToString(txtLastName.Text.Trim());
                objEmp.Address = Convert.ToString(txtAddress.Text.Trim());
                objEmp.CNICNo = Convert.ToString(txtCNIC.Text.Trim());
                objEmp.PhoneNo = Convert.ToString(txtPhone.Text.Trim());
                objEmp.JobTitle = Convert.ToString(txtJobTitle.Text.Trim());
                objEmp.DOB = Convert.ToString(txtDOB.Text.Trim());
                objEmp.CurrentSalary = Convert.ToString(txtSalary.Text);

                int m = objBL.Update(objEmp);
                if (m != 0)
                {
                    Response.Write("<<script>alert('Data Updated')</script>");
                }
                else
                {
                    Response.Write("<<script>alert('Data Not Updated')</script>");
                }

                btnSubmit.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                Clear();

                BindEmployee();
            }

            else
            {
                Response.Write("<<script>alert('Phone # / CNIC # is Invalid or Empty')</script>");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        #region Validations & Clear

        public bool Validation()
        {
            if (ValidateCNIC() && ValidatePhone())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCNIC()
        {
            string CNICNo = txtCNIC.Text;
            Regex regex = new Regex(@"(^\d{13}$)");
            Match match = regex.Match(CNICNo);
            if (match.Success)
                return true;
            else
                return false;
        }

        private bool ValidatePhone()
        {
            string phone = txtPhone.Text;
            Regex regex = new Regex(@"(^\d{11}$)");
            Match match = regex.Match(phone);
            if (match.Success)
                return true;
            else
                return false;
        }

        public void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtAddress.Text = txtCNIC.Text = txtPhone.Text = txtJobTitle.Text = txtDOB.Text = txtSalary.Text = "";
        }


        #endregion

        public void Search()
        {
            ClsEmp objEmp = new ClsEmp();
            BussinessLogicEmp objBL = new BussinessLogicEmp();

            objEmp.SearchWord = Convert.ToString(txtSearch.Text.Trim());

            dtSet = objBL.Search(objEmp);

            grvEmployee.DataSource = dtSet;
            grvEmployee.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("dtAdmin");
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        private bool UserIsLoggedIn()
        {
            if (Session["dtAdmin"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

