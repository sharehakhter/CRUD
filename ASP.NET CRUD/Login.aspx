<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.0.1/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.3/css/dataTables.bootstrap5.min.css" />

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script type="text/javascript" charset="utf-8" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="https://cdn.datatables.net/1.11.3/js/dataTables.bootstrap5.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
        <asp:Label ID="lblUser" Text="Enter Username: " runat="server" />
        <asp:TextBox ID="txtUser" PlaceHolder="Enter Username" cssclass="form-control" style="width: 200px;" runat="server" />
        <br />
        <asp:Label ID="lblPass" Text="Enter Password:" runat="server" />
        <asp:TextBox ID="txtPass" PlaceHolder="Enter Password" cssclass="form-control" TextMode="Password" style="width: 200px;" runat="server" />
        <br />

        <asp:Button ID="btnLogin" Text="Login" CssClass="btn-default" OnClick="btnLogin_Click" runat="server" />
        <br />
        <asp:Label Text="" ID="lblMsg"  runat="server" />
        </center>
        </div>
    </form>
</body>
</html>
