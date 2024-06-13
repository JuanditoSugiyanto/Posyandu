<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/Header.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Posyandu.AfterLogin.WebForm1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Label runat="server" Text="Selamat Datang, Siti Mursidah" Font-Bold="True" Font-Size="25pt" class ="NameWelcome"></asp:Label>
        <br />
        <br /> 
        <br />
        <asp:Label runat="server" Text="Daftar Anak" Font-Bold="True" Font-Size="15pt" class="DaftarAnakText"></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" Text="Nama/ ID Anak" Font-Bold="True" class="DaftarAnakText1"></asp:Label>
        <br />
        <asp:TextBox runat="server" class="DaftarAnakTB" BorderStyle="Inset" Width="548px"></asp:TextBox>

        <br />
        <br />
        <br />
        <br />

        <img src="../Content/Group%2027.png" class="cardTemplate"/>

        <asp:Chart runat="server" Width="547px">
            <series>
                <asp:Series Name="Series1"></asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </chartareas>
        </asp:Chart>
</div>

    </form>

</asp:Content>
