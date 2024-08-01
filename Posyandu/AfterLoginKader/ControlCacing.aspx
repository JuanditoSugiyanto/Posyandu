<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderChild.Master" AutoEventWireup="true" CodeBehind="ControlCacing.aspx.cs" Inherits="Posyandu.AfterLoginKader.ControlCacing" %>
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
          <th class="center-align">Ya</th>
          <th class="center-align">Tidak</th>
      </tr>
      <tr>
          <td>
              <asp:Label ID="LabelCacing" runat="server" Text="Obat Cacing?"></asp:Label>
          </td>
          <td class="center-align">
              <asp:CheckBox ID="CheckBoxYaCacing" runat="server" onclick="toggleCheckbox(this)" />
          </td>
          <td class="center-align">
              <asp:CheckBox ID="CheckBox2" runat="server" onclick="toggleCheckbox(this)" />
          </td>
      </tr>
     
  </table>



    <asp:Button ID="BtnSave" runat="server" Text="Simpan" OnClick ="BtnSave_Click" />
</asp:Content>
