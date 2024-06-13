<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterKader.aspx.cs" Inherits="Posyandu.Register_and_Login.RegisterKader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
  <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
    <link href="../Content/stylesRegKader.css" rel="stylesheet" />
  <script>
      $(function () {
          $("#datepicker").datepicker({
              changeMonth: true,
              changeYear: true
          });
      });
  </script>
</head>
<body>
    <form id="form1" runat="server">
        <img src="../Content/Posyandu%202021%20Logo%20(PNG720p)%20-%20Vector69Com%201.png" />
        <div>
            <h1>Register</h1>
            <h3>Selamat Datang di halaman pendaftaran Kader</h3>

            <asp:Label ID="LblNamaReg" runat="server" Text="Nama"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server" CssClass="input"></asp:TextBox>

         

            <asp:Label ID="LblTanggalLahirReg" runat="server" Text="Tanggal Lahir"></asp:Label>
            <input type="text" id="datepicker" class="input" />

            <asp:Label ID="LblPasswordReg" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPasswordReg" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>

            <asp:Label ID="LblNikReg" runat="server" Text="Masukkan NIK Anda"></asp:Label>
            <asp:TextBox ID="TxtNikReg" runat="server" CssClass="input"></asp:TextBox>

            <asp:Button ID="BtnRegister" runat="server" Text="Register" CssClass="button" />
            
        </div>
    </form>
</body>
</html>
