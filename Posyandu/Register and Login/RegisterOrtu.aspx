﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterOrtu.aspx.cs" Inherits="Posyandu.Register_and_Login.RegisterOrtu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - Orang Tua</title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
    <link href="../Content/stylesRegOrtu.css" rel="stylesheet" />
    <script>
        $(function () {
            var hiddenFieldId = '<%= HiddenFieldDatePicker.ClientID %>';
             $("#datepicker").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 dateFormat: "yy-mm-dd",
                 yearRange: "1900:2050",
                 onSelect: function (dateText) {
                     $('#' + hiddenFieldId).val(dateText);
                 }
             });
         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
<img src="../Content/Posyandu%202021%20Logo%20(PNG720p)%20-%20Vector69Com%201.png" />
        <div>
            <h1>Register</h1>
            <h3>Selamat Datang di halaman pendaftaran Orang Tua</h3>

            <asp:Label ID="LblNamaReg" runat="server" Text="Nama"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server" CssClass="input"></asp:TextBox>

            <asp:Label ID="LblRW" runat="server" Text="RW"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="RT"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="LblNomorTelReg" runat="server" Text="Nomor Telepon"></asp:Label>
            <asp:TextBox ID="TxtTelp" runat="server" CssClass="input"></asp:TextBox>

            <asp:Label ID="LblTanggalLahirReg" runat="server" Text="Tanggal Lahir"></asp:Label>
            <input type="text" id="datepicker" class="input" readonly="true"/>
            <asp:HiddenField ID="HiddenFieldDatePicker" runat="server" />


            <asp:Label ID="LblPasswordReg" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPasswordReg" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>

            <asp:Label ID="LblNikReg" runat="server" Text="Masukkan NIK Anda"></asp:Label>
            <asp:TextBox ID="TxtNikReg" runat="server" CssClass="input"></asp:TextBox>

            <asp:Button ID="BtnRegister" runat="server" Text="Register" CssClass="button" OnClick="BtnRegister_Click"/> 
             <br />
             <asp:Label ID="ErorMsg1" runat="server" Text="" ForeColor="#FF3300"></asp:Label>


    
        </div>
    </form>
</body>
</html>