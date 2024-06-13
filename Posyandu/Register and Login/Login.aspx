<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Posyandu.Register_and_Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Content/stylesLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <img src="../Content/Posyandu%202021%20Logo%20(PNG720p)%20-%20Vector69Com%201.png" class="logo" />
            <h1>Login</h1>
            <h3>Selamat Datang di halaman Login</h3>

            <asp:Label ID="LblNikLogin" runat="server" Text="NIK" CssClass="label"></asp:Label>
            <asp:TextBox ID="TxtNikLogin" runat="server" CssClass="input"></asp:TextBox>

            <asp:Label ID="LblPasswordReg" runat="server" Text="Password" CssClass="label"></asp:Label>
            <asp:TextBox ID="TxtPasswordReg" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>

            <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="button" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Belum punya akun?"></asp:Label>
               <asp:HyperLink id="hyperlink1" NavigateUrl="RoleSelector.aspx" Text="Daftar di sini." runat="server"/> 

        </div>
    </form>
</body>
</html>
