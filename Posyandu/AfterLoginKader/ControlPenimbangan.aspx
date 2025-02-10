<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderChild.Master" AutoEventWireup="true" CodeBehind="ControlPenimbangan.aspx.cs" Inherits="Posyandu.AfterLoginKader.ControlPenimbangan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function confirmDelete() {
        return confirm("Apakah Anda yakin ingin menghapus data ini?");
        }

    </script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
    <style>
        /* Styling untuk form input */
        label {
            font-weight: bold;
            margin-right: 10px;
        }
        input[type="text"] {
            padding: 5px;
            margin-bottom: 10px;
            width: 200px;
        }
        button, .delete-link {
            padding: 5px 10px;
            color: white;
            background-color: #4CAF50;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
        }
        .delete-link {
            background-color: #f44336; /* Warna merah untuk tombol Delete */
        }
        
        /* Styling untuk GridView */
        .gridview-container {
            margin-top: 20px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #4CAF50;
            color: white;
        }
        tr:hover {
            background-color: #f5f5f5;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Penimbangan</h2>
    <asp:Label ID="LblTinggiBadan" runat="server" Text="Tinggi Badan (Cm)"></asp:Label>
    <asp:TextBox ID="TxtTinggiBadan" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LblBeratBadan" runat="server" Text="Berat Badan (Kg)"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="BtnAddData" runat="server" Text="Masukan Data" OnClick="BtnAddData_Click"/>
    <br /><br />

    <!-- Tambahkan GridView untuk menampilkan riwayat penimbangan -->
<asp:GridView ID="GridViewRiwayatPenimbangan" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridViewRiwayatPenimbangan_RowDeleting" DataKeyNames="Tanggal">
    <Columns>
        <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false" />
        <asp:BoundField DataField="TinggiBadan" HeaderText="Tinggi Badan (Cm)" />
        <asp:BoundField DataField="BeratBadan" HeaderText="Berat Badan (Kg)" />
        <asp:TemplateField HeaderText="Aksi">
            <ItemTemplate>
                <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="delete-link" 
                                OnClientClick="return confirmDelete();" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
