<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderChild.Master" AutoEventWireup="true" CodeBehind="ControlVitamin.aspx.cs" Inherits="Posyandu.AfterLoginKader.ControlVitamin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
     table {
         border-collapse: collapse;
         width: 100%;
     }
     th, td {
         border: 1px solid black;
         padding: 8px;
         text-align: left;
     }
     .center-align {
         text-align: center;
     }
 </style>

 <script>
     function toggleCheckbox(checkbox) {
         var checkboxes = checkbox.parentNode.parentNode.querySelectorAll('input[type="checkbox"]');
         checkboxes.forEach(function (cb) {
             if (cb !== checkbox && cb.checked) {
                 cb.checked = false;
             }
         });
     }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr>
        <th></th>
        <th class="center-align">Merah</th>
        <th class="center-align">Biru</th>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelVitamin" runat="server" Text="Vitamin A"></asp:Label>
        </td>
        <td class="center-align">
            <asp:CheckBox ID="CheckBoxMerah" runat="server" onclick="toggleCheckbox(this)" />
        </td>
        <td class="center-align">
            <asp:CheckBox ID="CheckBoxBiru" runat="server" onclick="toggleCheckbox(this)" />
        </td>
    </tr>
   
  
</table>

    <asp:Button ID="BtnSave" runat="server" Text="Simpan Data" OnClick ="BtnSave_Click"/>
    <br />
    <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>

</asp:Content>
