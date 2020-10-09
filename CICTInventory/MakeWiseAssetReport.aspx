<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="MakeWiseAssetReport.aspx.cs" Inherits="CICTInventory_MakeWiseAssetReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=600');
        printWindow.document.write('<html><head><title>NIRDPR: CICt Stock Inventory</title>');
        printWindow.document.write('</head><body>');
        var elements = document.getElementsByClassName("h");
        for (var i = 0; i < elements.length; i++) {
            elements[i].style["text-decoration"] = "none";
            elements[i].style.color = "black";
        }
        printWindow.document.write(panel.innerHTML);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        setTimeout(function () {
            printWindow.print();
            togglePageBreakAfter();
        }, 500);
        return false;
    }    
</script>
    <style type="text/css">
        .h{
            color: black;
        }
        .h:hover{
            color: red;
        }
    </style>
    <script type="text/javascript">
        function dt() {
            $('.table').DataTable({
                "autoWidth": false
            });
        }
        function show() {
            $('#exampleModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title"> Make-Wise CICT Inventory Report : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btn_print" runat="server" CssClass="btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton><asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body">
<div class="row">
<asp:Panel ID="pnl_print" runat="server">
<center> <img src="../assets/images/title.png" height="80" width="400"  alt=""/>
<h5> NIRDPR - CICT Inventory  Details </h5>
</center>
<table width="100%" style="table-layout:fixed; font-family:Tahoma; font-size:12px;">
<tr><td align="left" width="50%"><asp:Label ID="lbl_ItemCount" runat="server"></asp:Label></td><td align="right" width="50%">Printed Date : <asp:Label ID="lbl_Dated" runat="server"></asp:Label></td></tr>
</table>
<asp:Repeater ID="rptr_Inventory" runat="server" OnItemCommand="rptr_Inventory_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover table-striped" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:12px; border-collapse: collapse; vertical-align:middle; margin:0;">
<thead><tr align="center">
<td width="5%">SNo</td>
<td width="35%">Manufacturer</td>
<td  width="10%">Desktop</td>
<td  width="10%">Laptop</td>
<td  width="10%">Printer</td>
<td  width="10%">Scanner</td>
<td  width="10%">All-in-One</td>
<td  width="10%">Tablet</td>
</tr>
</thead>
 <tbody>
</HeaderTemplate>
<ItemTemplate>
<tr align="center">
<td width="5%"><%#Container.ItemIndex+1%></td>
<td width="35%"><asp:LinkButton CssClass="h" ID="make" runat="server" CommandName="make" CommandArgument='<%#Eval("Manufacturer")%>'><%#Eval("Manufacturer")%></asp:LinkButton></td>
<td width="10%"><asp:LinkButton CssClass="h" ID="desk" runat="server" CommandArgument='<%#Eval("Manufacturer") +"|Desktop"%>'><%#Eval("Desktop")%></asp:LinkButton></td>
<td width="10%"><asp:LinkButton CssClass="h" ID="laptop" runat="server" CommandArgument='<%#Eval("Manufacturer") +"|Laptop"%>'><%#Eval("Laptop")%></asp:LinkButton></td>
<td width="10%"><asp:LinkButton CssClass="h" ID="printer" runat="server" CommandArgument='<%#Eval("Manufacturer") +"|Printer"%>'><%#Eval("Printer")%></asp:LinkButton></td>
<td width="10%"><asp:LinkButton CssClass="h" ID="scanner" runat="server" CommandArgument='<%#Eval("Manufacturer") +"|Scanner"%>'><%#Eval("Scanner")%></asp:LinkButton></td>
<td width="10%"><asp:LinkButton CssClass="h" ID="allinone" runat="server" CommandArgument='<%#Eval("Manufacturer") +"|All-in-One"%>'><%#Eval("All-in-One")%></asp:LinkButton></td>
<td width="10%"><asp:LinkButton CssClass="h" ID="tablet" runat="server" CommandArgument='<%#Eval("Manufacturer") +"|Tablet"%>'><%#Eval("Tablet")%></asp:LinkButton></td>
</tr>
</ItemTemplate>
<FooterTemplate>
</tbody>
<%--<table width="100%" class="table" style="table-layout:fixed; font-size:12px; border-collapse: collapse; border:0px solid #000; margin:0;">--%>
<tbody><tr align="center">
<td width="40%" align="right" colspan="2"> Total : </td>
<td  width="10%"><asp:Label ID="d" runat="server" CssClass="lblb"></asp:Label></td>
<td  width="10%"><asp:Label ID="l" runat="server"  CssClass="lblb"></asp:Label></td>
<td  width="10%"><asp:Label ID="p" runat="server"  CssClass="lblb"></asp:Label></td>
<td  width="10%"><asp:Label ID="s" runat="server"  CssClass="lblb"></asp:Label></td>
<td  width="10%"><asp:Label ID="a" runat="server"  CssClass="lblb"></asp:Label></td>
<td  width="10%"><asp:Label ID="t" runat="server"  CssClass="lblb"></asp:Label></td>
</tr>
</tbody></table>
</FooterTemplate>
</asp:Repeater>
 <!--List Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document" style="width: 70%">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel"><asp:Label runat="server" ID="heading" Font-Bold="true"></asp:Label></h5>
      </div>
      <div class="modal-body">
         <asp:Repeater ID="rptr_list" runat="server">
            <HeaderTemplate>
            <table id="tb1" width="100%" class="table table-striped table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; margin:0;">
            <thead><tr>
            <td width="5%" align='center'>SNo</td>
            <td width="10%" align='center'>ItemName</td>
            <td width="15%" align='center'>Model</td>
            <td width="15%" align='center'>Serial No.</td>
            <td width="20%" align='center'>Specification</td>
            <td width="10%" align='center'>Status</td>
            <td width="10%" align='center'>Date of Purchase</td>
            <td width="15%" align='center'>Warranty</td>
            </tr>
            </thead>
            <tbody>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
            <td width="5%" align='center'><%#Container.ItemIndex+1%></td>
            <td width="10%" align="center"><%#Eval("ItemName")%></td>
            <td width="10%" align="center"><%#Eval("Model")%></td>
            <td width="15%" align="center"><%#Eval("SerialNo")%></td>
            <td width="20%" align="center"><%#Eval("ComputerNumber")%></td>
            <td width="10%" align="center"><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'> <%#Eval("Status")%></asp:Label></td>
            <td width="15%" align="center"><%#Eval("DOP")%></td>
            <td width="15%" align="center"><%#Eval("Warranty")%></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
         </asp:Repeater>
      </div>
    </div>
  </div>
</div>
</asp:Panel>
</div>
</div>
</div>
</div></div>
</div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

