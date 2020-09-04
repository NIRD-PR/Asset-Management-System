<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="DetailedITInventory.aspx.cs" Inherits="CICTInventory_DetailedITInventory" %>

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
<tr><td align="left" width="50%">No. of Items Listed : <asp:Label ID="lbl_ItemCount" runat="server"></asp:Label></td><td align="right" width="50%">Printed Date : <asp:Label ID="lbl_Dated" runat="server"></asp:Label></td></tr>
</table>
<asp:DataList ID="dl_Inventory" runat="server" RepeatColumns="1">
<ItemTemplate>
<table width="100%" style="table-layout:fixed; font-family:Tahoma; font-size:14px;">
<tr><td><br /><b><%#Container.ItemIndex+1%>) <%#Eval("ItemType")%> :</b></td></tr>
<tr><td>
<asp:Repeater ID="rptr_Inventory" runat="server">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:12px; border-collapse: collapse; vertical-align:middle; border:0px solid #000; margin:0;">
<tbody><tr>
<td width="5%" align='center'>SNo</td>
<td width="35%" align='left'>Manufacturer</td>
<td  width="15%" align='center'>Under AMC</td>
<td  width="15%" align='center'>Under Warrenty</td>
<td  width="15%" align='center'>Widthout Warrenty/AMC</td>
<td  width="15%" align='center'>Total</td>
</tr>
</tbody>
</HeaderTemplate>
<ItemTemplate>
<tbody><tr>
<td width="5%" align='center'><%#Container.ItemIndex+1%></td>
<td width="35%"  style="padding-left:5px;" align="left"><%#Eval("Manufacturer")%></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_AMC" runat="server"></asp:Label></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_withwarrenty" runat="server"></asp:Label></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_withoutWarrenty" runat="server"></asp:Label></td>
<td  width="15%" style="padding-right:5px;" align="center"><asp:Label ID="lbl_total" runat="server"></asp:Label></td>
</tr>
</tbody>
</ItemTemplate>
<FooterTemplate>
<%--<table width="100%" class="table" style="table-layout:fixed; font-size:12px; border-collapse: collapse; border:0px solid #000; margin:0;">--%>
<tbody><tr>
<td width="40%" align='right' colspan="2"> Total : </td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_GAMC" runat="server" CssClass="lblb"></asp:Label></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_Gwithwarrenty" runat="server"  CssClass="lblb"></asp:Label></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_GwithoutWarrenty" runat="server"  CssClass="lblb"></asp:Label></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:Label ID="lbl_GTotal" runat="server"  CssClass="lblb"></asp:Label></td>
</tr>
</tbody></table>
</FooterTemplate>
</asp:Repeater>
</td></tr>
</table>
</ItemTemplate>
</asp:DataList>
</asp:Panel>
</div>
</div>
</div>
</div></div>
</div>
</div>
</div>

</asp:Content>

