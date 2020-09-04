<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="DeptWiseInventoryMappedReport.aspx.cs" Inherits="CICTInventory_DeptWiseInventoryMappedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=600');
        printWindow.document.write('<html><head><title>NIRDPR: CICT Emp-Wise Inventory</title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Department-wise CICT Inventory Report : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btn_print" runat="server" CssClass="btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton><asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body">
    <table width="100%">
        <tr><td width="10%" align="right">Select Item :</td><td width="15%"><asp:DropDownList ID="ddl_Item" runat="server" CssClass="form-control"></asp:DropDownList></td><td width="10%"><asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Get Report" OnClick="btn_Submit_Click" /></td></tr>
    </table>
<div class="row">
<asp:Panel ID="pnl_print" runat="server">
<center> <img src="../assets/images/title.png" height="80" width="400"  alt=""/>
<h5> NIRDPR - ITem-wise CICT Inventory  Details </h5>
</center>
<asp:Repeater ID="rptr_Inventory" runat="server">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; border:0px solid #000; margin:0;">
<thead><tr>
<td width="5%" align='center'>SNo</td>
<td width="10%" align='center'>DeptID</td>
<td width="10%" align='center'>EmpID</td>
<td width="20%" align='center'>Name & Design</td>
<td  width="10%" align='center'>ItemType</td>
<td width="15%" align='center'>Make & Model</td>
<td  width="15%" align='center'>Serial No</td>
<td  width="15%" align='center'>Remarks</td>
</tr>
</thead>
</HeaderTemplate>
<ItemTemplate>
<tbody><tr>
<td width="5%" align='center'><%#Container.ItemIndex+1%></td>
<td width="10%" align="center"><%#Eval("DeptID")%></td>
<td  width="10%" align="center"><%#Eval("EmpID")%></td>
<td  width="20%" align="left"><%#Eval("Name")%> <br /> <%#Eval("Design")%></td>
<td  width="10%" align="center"><%#Eval("ItemName")%></td>
<td  width="15%" align="center"><%#Eval("Manufacturer")%>  <br /> <%#Eval("Model")%></td>
<td  width="15%" align="center"><%#Eval("SerialNo")%> </td>
<td  width="15%" align="center"></td>
</tr>
</tbody>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
</asp:Panel>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>

</asp:Content>

