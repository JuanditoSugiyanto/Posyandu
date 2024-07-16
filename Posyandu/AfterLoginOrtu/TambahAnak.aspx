<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginOrtu/HeaderOrtu.Master" AutoEventWireup="true" CodeBehind="TambahAnak.aspx.cs" Inherits="Posyandu.AfterLoginOrtu.TambahAnak" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
  <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
   
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

    <asp:Label ID="LblNikAnak" runat="server" Text="NIK"></asp:Label>
    <br />
    <asp:TextBox ID="TxtNIK" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LblNamaAnak" runat="server" Text="Nama Lengkap Anak"></asp:Label>
    <br />
    <asp:TextBox ID="TxtNamaAnak" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LblKelamin" runat="server" Text="Jenis Kelamin"></asp:Label>
    <br />
    <asp:TextBox ID="TxtKelamin" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LblTanggalLahirReg" runat="server" Text="Tanggal Lahir"></asp:Label>
    <br />
    <input type="text" id="datepicker" class="input" readonly="readonly"/>
    <asp:HiddenField ID="HiddenFieldDatePicker" runat="server" />
    <br />
    <asp:Label ID="LblAlamatAnak" runat="server" Text="Alamat"></asp:Label>
    <br />
    <asp:TextBox ID="TxtAlamatAnak" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="BtnTambah" runat="server" Text="Daftarakan" OnClick ="BtnTambah_Click" />
    <br />
     <asp:Label ID="ErorMsg1" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
</asp:Content>
