<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="InventoryHome.aspx.cs" Inherits="CICTInventory_InventoryHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write('<html><head><title>NIRDPR-Department-wise Tickets Status</title>');
        printWindow.document.write('</head><body >');
        printWindow.document.write(panel.innerHTML);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        setTimeout(function () {
            printWindow.print();
        }, 500);
        return false;
    }
    function dt() {
        var n = "CICT-Inventory Current Stats";
        $('#tb1').DataTable({
            dom: 'Bfrtip',
            buttons: [
                'pageLength', 'print',
                {
                    extend: 'excel',
                    filename: n,
                    title: n
                },
                {
                    extend: 'pdf',
                    filename: n,
                    title: n
                }
            ]
        });
        var t = 'CICT-' + $("#<%=heading.ClientID%>").text() + ' Inventory Report';
        $('#tb2').DataTable({
            dom: 'Bfrtip',
            buttons: [
                'pageLength', 'print',
                {
                    extend: 'excel',
                    filename: t,
                    title: t
                },
                {
                    extend: 'pdf',
                    filename: t,
                    title: t
                }
            ]
        });
    }
    function show() {
        $('#exampleModal').modal('show');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row" style="margin: 0 10px">
<div class="col-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title"> CICT Dashboard </h3></div>
<div class="panel-body">
<div class="row">
 <div class="col-sm-6 col-lg-3">
                                <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon bg-danger" ><i class="fa fa-desktop" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <p class="text-danger" style="font-size: 2rem">Desktop</p>
                                        <p style="font-size: 1.1em"><asp:Label ForeColor="Black" Font-Size="Small" Font-Bold="false" runat="server" ID="desktop"></asp:Label></p>
                                    </div>
                                </div>
                            </div>

<div class="col-sm-6 col-lg-3">
                                <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon" style=" background:#2DA01A;" ><i class="fa fa-laptop" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <p style="color: #2DA01A; font-size: 2rem">Laptop</p>
                                        <p style="font-size: 1.1em"><asp:Label ForeColor="Black" Font-Size="Small" Font-Bold="false" runat="server" ID="laptop"></asp:Label></p>
                                    </div>
                                </div>
                            </div>

<div class="col-sm-6 col-lg-3">
     <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon bg-info" ><i class="fa fa-print" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <p class="text-info" style="font-size: 2rem">Printer</p>
                                        <p style="font-size: 1.1em"><asp:Label ForeColor="Black" Font-Size="Small" Font-Bold="false" runat="server" ID="printer"></asp:Label></p>
                                    </div>
                                </div>
                            </div>

<div class="col-sm-6 col-lg-3">
     <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon" style=" background:#8010F3;" ><i class="fa fa-barcode" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <p class="counter" style="color:#8010F3; font-size: 2rem ">Scanner</p>
                                        <p style="font-size: 1.1em"><asp:Label ForeColor="Black" Font-Size="Small" Font-Bold="false" runat="server" ID="scanner"></asp:Label></p>
                                    </div>
                                </div>
                            </div>
</div>
</div>
</div>
</div>
</div>
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-info">
<div class="panel-heading"><h3 class="panel-title"> CICT Inventory Dashboard : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btn_print" runat="server" CssClass="btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton><asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
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
<table id="tb1" width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:12px; border-collapse: collapse; vertical-align:middle; border:0px solid #000; margin:0;">
<thead><tr>
<td width="5%" align='center'>SNo</td>
<td width="20%" align='left'>Item Type</td>
<td  width="15%" align='center' style="color: #E3F705">Active</td>
<td  width="15%" align='center' style="color: green">Idle</td>
<td  width="15%" align='center' style="color: blue">Inactive</td>
<td  width="15%" align='center' style="color: red">Abandoned</td>
<td  width="15%" align='center'>Total</td>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td width="5%" align='center'><%#Container.ItemIndex+1%></td>
<td width="20%"  style="padding-left:5px;" align="left"><%#Eval("ItemType")%></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="a" runat="server" CommandName="active" CommandArgument='<%#Eval("ItemType")%>'><asp:Label ID="lbl_active" runat="server"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="b" runat="server" CommandName="idle" CommandArgument='<%#Eval("ItemType")%>'><asp:Label ID="lbl_idle" runat="server"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="c" runat="server" CommandName="inactive" CommandArgument='<%#Eval("ItemType")%>'><asp:Label ID="lbl_inactive" runat="server"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="d" runat="server" CommandName="abandoned" CommandArgument='<%#Eval("ItemType")%>'><asp:Label ID="lbl_abandoned" runat="server"></asp:Label></asp:LinkButton></td>
<td  width="15%" style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="e" runat="server" CommandName="total" CommandArgument='<%#Eval("ITID")+ "|" +Eval("ItemType")%>'><asp:Label ID="lbl_total" runat="server"></asp:Label></asp:LinkButton></td>
</tr>

</ItemTemplate>
<FooterTemplate>
    </tbody>
<%--<table width="100%" class="table" style="table-layout:fixed; font-size:12px; border-collapse: collapse; border:0px solid #000; margin:0;">--%>
<tbody><tr>
<td width="25%" align='right' colspan="2"> Total : </td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="f" runat="server" CommandName="tstatus" CommandArgument='Active'><asp:Label ID="lbl_tactive" runat="server" CssClass="lblb"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="g" runat="server" CommandName="tstatus" CommandArgument='Idle'><asp:Label ID="lbl_tidle" runat="server"  CssClass="lblb"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="h" runat="server" CommandName="tstatus" CommandArgument='Inactive'><asp:Label ID="lbl_tinactive" runat="server"  CssClass="lblb"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="i" runat="server" CommandName="tstatus" CommandArgument='Abandoned'><asp:Label ID="lbl_tabandoned" runat="server"  CssClass="lblb"></asp:Label></asp:LinkButton></td>
<td  width="15%"  style="padding-right:5px;" align="center"><asp:LinkButton CssClass="h" ID="j" runat="server" CommandName="tall"><asp:Label ID="lbl_GTotal" runat="server"  CssClass="lblb"></asp:Label></asp:LinkButton></td>
</tr>
</tbody></table>
</FooterTemplate>
</asp:Repeater>
 <!--Modal-->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document" style="width: 70%">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel"><asp:Label runat="server" ID="heading" Font-Bold="true"></asp:Label></h5>
      </div>
      <div class="modal-body">
         <asp:Repeater ID="rptr_list" runat="server">
            <HeaderTemplate>
            <table id="tb2" width="100%" class="table table-striped table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; margin:0;">
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

