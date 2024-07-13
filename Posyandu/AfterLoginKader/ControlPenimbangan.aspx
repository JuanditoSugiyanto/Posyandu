<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderChild.Master" AutoEventWireup="true" CodeBehind="ControlPenimbangan.aspx.cs" Inherits="Posyandu.AfterLoginKader.ControlPenimbangan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
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

    
     <asp:Label ID="LblTanggalLahirReg" runat="server" Text="Tanggal Pemeriksaan"></asp:Label>
    <input type="text" id="datepicker" class="input" />
    <asp:HiddenField ID="HiddenFieldDatePicker" runat="server" />
    <br />
    <asp:Label ID="LblTinggiBadan" runat="server" Text="Tinggi Badan (Cm)"></asp:Label>
    <asp:TextBox ID="TxtTinggiBadan" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LblBeratBadan" runat="server" Text="Berat Badan (Kg)"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="BtnAddData" runat="server" Text="Masukan Data" OnClick="BtnAddData_Click"/>

</asp:Content>
