<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginOrtu/HeaderOrtu.Master" AutoEventWireup="true" CodeBehind="WebForm1Ortu.aspx.cs" Inherits="Posyandu.AfterLoginOrtu.WebForm1Ortu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="BtnTambahAnak" runat="server" Text="Tambah Anak" OnClick="BtnTambahAnak_Click"/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NIK" HeaderText="NIK" />
            <asp:TemplateField HeaderText="Nama Anak">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("NIK", "DetaiAnak.aspx?NIK={0}") %>' Text='<%# Eval("namaAnak") %>'></asp:HyperLink>
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
        </Columns>
    </asp:GridView>
</asp:Content>
