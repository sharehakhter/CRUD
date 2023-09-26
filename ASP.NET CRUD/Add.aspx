<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebApp.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" charset="utf-8" src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script type="text/javascript" charset="utf-8" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="https://cdn.datatables.net/1.11.3/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $('#example').DataTable();

        });

    </script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }

        .error-message {
            color: red;
        }

        #top-right-button {
            position: absolute;
            top: 10px;
            right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="top-right-button">
                <asp:Button Text="Log Out" ID="btnLogout" OnClick="btnLogout_Click" runat="server" />
            </div>

            <table id="example" class="table table-striped">
                <tr>
                    <td class="auto-style7">First Name</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="233px" />
                        <asp:RequiredFieldValidator ID="reqFirstName" ControlToValidate="txtFirstName" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter First Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Last Name</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtLastName" runat="server" Width="233px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqLastName" ControlToValidate="txtLastName" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter Last Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Address</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtAddress" runat="server" Width="233px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqAddress" ControlToValidate="txtAddress" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter Address"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">CNIC #</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtCNIC" runat="server" Width="233px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqCNIC" ControlToValidate="txtCNIC" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter CNIC #"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Phone #</td>
                    <td class="auto-style1" style="text-align: center">:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtPhone" runat="server" Width="233px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqPhone" ControlToValidate="txtPhone" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter Phone #"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Job Title</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtJobTitle" runat="server" Width="233px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqJobTitle" ControlToValidate="txtJobTitle" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter Job Title"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Date of Birth</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtDOB" runat="server" Width="233px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Current Salary</td>
                    <td class="auto-style9" style="text-align: center">:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtSalary" runat="server" Width="233px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqSalary" ControlToValidate="txtSalary" CssClass="error-message" runat="server" ValidationGroup="AddForm" ErrorMessage="*Enter Current Salary"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9" style="text-align: center">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Button ID="btnSubmit" runat="server" ValidationGroup="AddForm" OnClick="btnSubmit_Click" Text="Submit" Width="237px" />
                        <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" ValidationGroup="AddForm" Visible="false" runat="server" Text="Update" Width="122px" />
                        <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" runat="server" Visible="false" Width="111px" />
                    </td>
                </tr>
            </table>
            <br />
            <center>
        <asp:TextBox ID="txtSearch" placeholder="Enter First or Last Name" runat="server" style="margin-left: 0px" Width="542px" />
        <asp:Button Text="Search" ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="115px" />

        <br />
        <br />
        
        <asp:GridView ID="grvEmployee" class="table table-bordered table-condensed table-responsive table-hover" AutoGenerateColumns="false" EmptyDataText="No Records in Database" OnPageIndexChanging="grvEmployee_PageIndexChanging" OnRowCancelingEdit="grvEmployee_RowCancelingEdit" OnRowDeleting="grvEmployee_RowDeleting" OnRowEditing="grvEmployee_RowEditing" runat="server" Width="982px">
            
           <Columns>

               <asp:TemplateField HeaderText="Employee ID">
                   <ItemTemplate>
                       
                       <div  style ="text-align:center;">
                       <asp:Label ID="lblEmpId" Text ='<%#Eval("EmpId") %>' runat="server" />
                           </div>
                   </ItemTemplate>
               </asp:TemplateField>
               
               <asp:TemplateField HeaderText="First Name">
                   <ItemTemplate>
                       <asp:Label ID="lblFirstName" Text ='<%#Eval("FirstName") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Last Name">
                   <ItemTemplate>
                       <asp:Label ID="lblLastName" Text ='<%#Eval("LastName") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Address">
                   <ItemTemplate>
                       <asp:Label ID="lblAddress" Text ='<%#Eval("Address") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="CNIC #">
                   <ItemTemplate>
                       <asp:Label ID="lblCNICNo" Text ='<%#Eval("CNICNo") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Phone #">
                   <ItemTemplate>
                       <asp:Label ID="lblPhoneNo" Text ='<%#Eval("PhoneNo") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Job Title">
                   <ItemTemplate>
                       <asp:Label ID="lblJobTitle" Text ='<%#Eval("JobTitle") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="D.O.B">
                   <ItemTemplate>
                       <asp:Label ID="lblDOB" Text ='<%#Eval("DOB") %>' runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Current Salary">
                   <ItemTemplate>
                       <asp:Label ID="lblCurrentSalary" Text ='<%#Eval("CurrentSalary") %>'  runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Update">
                   <ItemTemplate>
                       <asp:Button ID="btnEdit" Text="Edit" CommandName="Edit" runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Delete">
                   <ItemTemplate>
                       <asp:LinkButton ID="btnDelete" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this?');" runat="server" />
                       </ItemTemplate>
               </asp:TemplateField>
           </Columns>               
        </asp:GridView>

        </center>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
