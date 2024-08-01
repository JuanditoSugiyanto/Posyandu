<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginKader/HeaderChild.Master" AutoEventWireup="true" CodeBehind="ControlAnak.aspx.cs" Inherits="Posyandu.AfterLoginKader.ControlAnak" %>
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

      <br />
  <asp:Label ID="ZScore" runat="server" Text="Label"></asp:Label>
    <br />

  <asp:Chart ID="Chart1" runat="server" Width="1000px" Height="700px">
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

</asp:Content>
