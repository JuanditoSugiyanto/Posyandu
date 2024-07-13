<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderKader.Master" AutoEventWireup="true" CodeBehind="WebForm1Kader.aspx.cs" Inherits="Posyandu.AfterLoginKader.WebForm1Kader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
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
        <asp:TextBox runat="server" ID="TxtSearch" class="DaftarAnakTB" BorderStyle="Inset" Width="548px"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
        <br />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
     <Columns>
         <asp:BoundField DataField="NIK" HeaderText="NIK" />
         <asp:TemplateField HeaderText="Nama Anak">
             <ItemTemplate>
                 <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("NIK", "ControlAnak.aspx?NIK={0}") %>' Text='<%# Eval("namaAnak") %>'></asp:HyperLink>
             </ItemTemplate>
         </asp:TemplateField>
         <asp:BoundField DataField="tanggalLahir" HeaderText="Tanggal Lahir" />
         <asp:BoundField DataField="umur" HeaderText="Umur" />
         <asp:BoundField DataField="jenisKelamin" HeaderText="Jenis Kelamin" />
         <asp:BoundField DataField="alamat" HeaderText="Alamat" />
         <asp:BoundField DataField="namaPosyandu" HeaderText="Nama Posyandu" />
         <asp:BoundField DataField="beratBadan" HeaderText="Berat Badan" />
         <asp:BoundField DataField="tinggiBadan" HeaderText="Tinggi Badan" />
         <asp:BoundField DataField="statusGizi" HeaderText="Status Gizi" />
         <asp:BoundField DataField="NamaOrangTua" HeaderText="Nama Orang Tua" />
     </Columns>
 </asp:GridView>
        

       
</div>

   
</asp:Content>
