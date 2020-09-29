<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="DeptWiseInventoryMappedReport_New.aspx.cs" Inherits="CICTInventory_DeptWiseInventoryMappedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=600');
        printWindow.document.write('<html><head><title>NIRDPR: CICt Stock Inventory</title>');
        printWindow.document.write('</head><body>');
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
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.css" />
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.js"></script>
    <script type="text/javascript">
        function dt() {
            $('.table').DataTable();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title"> CICT Inventory Report : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btn_print" runat="server" CssClass="btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton><asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body">
<div class="row">
<asp:Panel ID="pnl_print" runat="server">
<center> <img src="../assets/images/title.png" height="80" width="400"  alt=""/>
<h5> NIRDPR - CICT Inventory  Details </h5>
</center>
<table width="100%" style="table-layout:fixed; font-family:Tahoma; font-size:12px;">
<tr><td align="left" width="50%"><asp:Label ID="lbl_ItemCount" runat="server"></asp:Label></td><td align="right" width="50%">Printed Date : <asp:Label ID="lbl_Dated" runat="server"></asp:Label></td></tr>
</table>
<asp:Repeater ID="rptr_Inventory" runat="server">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover table-striped" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:12px; border-collapse: collapse; vertical-align:middle; margin:0;">
<thead><tr>
<td width="5%">SNo</td>
<td width="35%">Department</td>
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
<tr>
<td width="5%"><%#Container.ItemIndex+1%></td>
<td width="35%"><%#Eval("DeptID")%></td>
<td width="10%"><%#Eval("Desktop")%></td>
<td width="10%"><%#Eval("Laptop")%></td>
<td width="10%"><%#Eval("Printer")%></td>
<td width="10%"><%#Eval("Scanner")%></td>
<td width="10%"><%#Eval("All-in-One")%></td>
<td width="10%"><%#Eval("Tablet")%></td>
</tr>
</ItemTemplate>
<FooterTemplate>
</tbody>
<%--<table width="100%" class="table" style="table-layout:fixed; font-size:12px; border-collapse: collapse; border:0px solid #000; margin:0;">--%>
<tbody><tr>
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
</asp:Panel>
</div>
</div>
</div>
</div></div>
</div>
</div>
</div>

</asp:Content>

