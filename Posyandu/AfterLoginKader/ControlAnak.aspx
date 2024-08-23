<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderChild.Master" AutoEventWireup="true" CodeBehind="ControlAnak.aspx.cs" Inherits="Posyandu.AfterLoginKader.ControlAnak" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="LblNamaAnak" runat="server" Text="Nama Anak: "></asp:Label>
<asp:Label ID="LabelNama" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="LblNamaOrangTua" runat="server" Text="Nama Orang Tua: "></asp:Label>
<asp:Label ID="LblOrtu" runat="server" Text=""></asp:Label>
<br />
    <asp:Label ID="LblUmur" runat="server" Text="Umur (Bulan): "></asp:Label>
    <asp:Label ID="LblUmurDB" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="NIK" runat="server" Text="NIK: "></asp:Label>
    <asp:Label ID="LblNIK" runat="server" Text="Label"></asp:Label>
      <br />
    <asp:Label ID="Tinggi" runat="server" Text="Tinggi (Terakhir): "></asp:Label>
    <asp:Label ID="LblTinggi" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Berat" runat="server" Text="Berat Badan (Terakhir): "></asp:Label>
    <asp:Label ID="LblBerat" runat="server" Text=""></asp:Label>
    <br />
    
    <asp:Label ID="JenisKelamin" runat="server" Text="Jenis Kelamin"></asp:Label>
    <asp:Label ID="LblJenisKelamin" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Alamat" runat="server" Text="Alamat Anak: "></asp:Label>
    <asp:Label ID="LblAlamat" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="StatusGizi" runat="server" Text="Status Gizi: "></asp:Label>
    <asp:Label ID="LblStatus" runat="server" Text=""></asp:Label>
    <br />

  <asp:Label ID="ZScore" runat="server" Text="Label"></asp:Label>
    <br />

  <asp:Chart ID="Chart1" runat="server" Width="1200px" Height="700px">
      <Series>
          <asp:Series Name="Series1" ChartType="Line" Legend="Median Height">

              <Points>
                  <asp:DataPoint XValue="0" YValues="0" />
                  <asp:DataPoint XValue="60" YValues="35" />
              </Points>
          </asp:Series>     
      </Series>
      <ChartAreas>
          <asp:ChartArea Name="ChartArea1">
              <AxisX Title="Umur (Bulan)" Minimum="0" Maximum="60" Interval="1">
                  <MajorGrid LineColor="LightGray" />
              </AxisX>
              <AxisY Title="Berat Badan (Kg)" Minimum="0" Maximum="35" Interval="1">
                  <MajorGrid LineColor="LightGray" />
              </AxisY>
          </asp:ChartArea>
      </ChartAreas>
  </asp:Chart>
    
    <img src="../Content/Legend%20Graph%20Posyandu.png"/>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Grafik Berdasarkan PMK No.2 Tahun 2020 tentang Standar Antoropometri Anak"></asp:Label>
    <br />
    <br />
    <br />
    <br />

    <!------------------------------------------------------------>
     <asp:Chart ID="Chart2" runat="server" Width="1000px" Height="700px">
     <Series>
         <asp:Series Name="Series1" ChartType="Line" Legend="Median Height">

             <Points>
                 <asp:DataPoint XValue="0" YValues="0" />
                 <asp:DataPoint XValue="60" YValues="125" />
             </Points>
         </asp:Series>     
     </Series>
     <ChartAreas>
         <asp:ChartArea Name="ChartArea1">
             <AxisX Title="Umur (Bulan)" Minimum="0" Maximum="60" Interval="1">
                 <MajorGrid LineColor="LightGray" />
             </AxisX>
             <AxisY Title="Tinggi Badan (Cm)" Minimum="30" Maximum="125" Interval="5">
                 <MajorGrid LineColor="LightGray" />
             </AxisY>
         </asp:ChartArea>
     </ChartAreas>
 </asp:Chart>
<br />
<br />
    <img src="../Content/Legend%20Graph%20POsyandu%202.png" />
    <asp:Label ID="Label2" runat="server" Text="Grafik Berdasarkan PMK No.2 Tahun 2020 tentang Standar Antoropometri Anak"></asp:Label>
</asp:Content>
