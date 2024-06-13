<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleSelector.aspx.cs" Inherits="Posyandu.Register_and_Login.RoleSelector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/styles2.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="../Content/Posyandu%202021%20Logo%20(PNG720p)%20-%20Vector69Com%201.png" />
            <h1>Register</h1>
            <h2>Pilih Peran Anda</h2>
            <asp:Button ID="BtnOrangTuaReg" runat="server" CssClass="buttonOrtu" Text="Orang Tua" OnClick="BtnOrangTuaReg_Click"/>
            <asp:Button ID="BtnKaderReg" runat="server" CssClass="buttonKader" Text="Kader Posyandu" OnClick="BtnKaderReg_Click" Width="227px"/>
        </div>
    </form>
</body>
</html>
