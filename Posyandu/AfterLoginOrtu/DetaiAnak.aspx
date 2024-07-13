<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginOrtu/HeaderOrtu.Master" AutoEventWireup="true" CodeBehind="DetaiAnak.aspx.cs" Inherits="Posyandu.AfterLoginOrtu.DetaiAnak" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblNamaAnak" runat="server" Text="Nama Anak: "></asp:Label>
    <br />
    <asp:Label ID="LabelNama" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="LblNamaOrangTua" runat="server" Text="Nama Orang Tua: "></asp:Label>
    <br />
    <asp:Label ID="LblOrtu" runat="server" Text=""></asp:Label>
</asp:Content>
