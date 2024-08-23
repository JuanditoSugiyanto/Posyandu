<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginOrtu/HeaderChildOrtu.Master" AutoEventWireup="true" CodeBehind="RiwayatPenimbangan.aspx.cs" Inherits="Posyandu.AfterLoginOrtu.RiwayatPenimbangan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
    <Columns>    
        <asp:BoundField DataField="Tanggal_Timbang" HeaderText="Tanggal Timbang" />
        <asp:BoundField DataField="Berat_Badan" HeaderText="Berat Badan (Kg)" />
        <asp:BoundField DataField="Tinggi_Badan" HeaderText="Tinggi Badan (Cm)" />
        <asp:BoundField DataField="Status_Gizi" HeaderText="Status Gizi" />
        <asp:BoundField DataField="Umur" HeaderText="Umur" />
    </Columns>
</asp:GridView>
</asp:Content>
