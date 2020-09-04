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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row"><asp:HiddenField ID="hdn_EmpID" runat="server" /><asp:HiddenField ID="hdn_Email" runat="server" />
<div class="panel panel-color panel-success" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">CIT  e-Tickets Dashboard &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;background:#E2F7FE;">
<div class="row" style="background:#E2F7FE;">
 <div class="col-sm-6 col-lg-3">
                                <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon bg-danger" ><i class="fa fa-ticket" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <span class="counter text-danger"><asp:Label ID="lbl_TotTicketsCount" runat="server" Text="0" style="color:#FF0000;"></asp:Label></span>
                                        New Tickets
                                    </div>
                                    <div class="tiles-progress">
                                        <div class="m-t-20">
                                            <h5 class="text-uppercase">New <span class="pull-right"><asp:Label ID="lbl_totTckPer" runat="server"></asp:Label></span></h5>
                                            <div class="progress progress-sm m-0">
                                                <div id="tot_Pbar" runat="server" class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="<%=lbltotCount%>" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only"><asp:Label ID="lbl_TotCounts" runat="server" Text="0" style="color:#FF0000;"></asp:Label> Complete</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

<div class="col-sm-6 col-lg-3">
                                <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon" style=" background:#2DA01A;" ><i class="fa fa-ticket" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <span class="counter text-danger"><asp:Label ID="lbl_ProgTicketsCount" runat="server" Text="0" style="color:#2DA01A;"></asp:Label></span>
                                        In-Progess Tickets
                                    </div>
                                    <div class="tiles-progress">
                                        <div class="m-t-20">
                                            <h5 class="text-uppercase">In-Progress <span class="pull-right"><asp:Label ID="lbl_ProgTckPer" runat="server"></asp:Label></span></h5>
                                            <div class="progress progress-sm m-0">
                                                <div id="Prog_Pbar" runat="server" class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="<%=lblProgCount%>" aria-valuemin="0" aria-valuemax="100" >
                                                    <span class="sr-only"><asp:Label ID="lbl_ProgCounts" runat="server" Text="0" style="color:#FF0000;"></asp:Label> Complete</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

<div class="col-sm-6 col-lg-3">
     <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon bg-info" ><i class="fa fa-ticket" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <span class="counter text-danger"><asp:Label ID="lbl_HoldTicketsCount" runat="server" Text="0" style="color:#5DA6F9;"></asp:Label></span>
                                        Hold Tickets
                                    </div>
                                    <div class="tiles-progress">
                                        <div class="m-t-20">
                                            <h5 class="text-uppercase">Hold <span class="pull-right"><asp:Label ID="lbl_HoldTckPer" runat="server"></asp:Label></span></h5>
                                            <div class="progress progress-sm m-0">
                                                <div id="Hold_Pbar" runat="server" class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="<%=lblHoldCount%>" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only"><asp:Label ID="lbl_HoldCounts" runat="server" Text="0" style="color:#FF0000;"></asp:Label> Complete</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

<div class="col-sm-6 col-lg-3">
     <div class="mini-stat clearfix bx-shadow bg-white">
                                    <span class="mini-stat-icon" style=" background:#8010F3;" ><i class="fa fa-ticket" style="margin-top:15px;"></i></span>
                                    <div class="mini-stat-info text-right text-dark">
                                        <span class="counter text-danger"><asp:Label ID="lbl_ClosedTicketsCount" runat="server" Text="0" style="color:#8010F3;"></asp:Label></span>
                                        Closed Tickets
                                    </div>
                                    <div class="tiles-progress">
                                        <div class="m-t-20">
                                            <h5 class="text-uppercase">Closed <span class="pull-right"><asp:Label ID="lbl_ClosedTckPer" runat="server"></asp:Label></span></h5>
                                            <div class="progress progress-sm m-0">
                                                <div id="Closed_Pbar" runat="server" class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="<%=lblClosedCount%>" aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only"><asp:Label ID="lbl_ClosedCounts" runat="server" Text="0" style="color:#FF0000;"></asp:Label>  Complete</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
</div>
</div>
</div>
<div class="row" style="background:#E2F7FE;">
<div class="col-xs-12">
<div class="panel panel-color panel-primary" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">Department wise CICT e-Tickets Status &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-success" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton> <asp:Label ID="lbl_IndentsCount" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;">
<asp:Panel ID="pnl_print" runat="server">

<table width="100%" style="font-family:Tahoma;">
<tr><td colspan="5" align="center"><img src="../assets/images/title.png" height="80" width="400"  alt=""/></td></tr>
<tr><td colspan="5" align="center"><h5>Department wise CICT e-Tickets Status </h5></td></tr>
</table>
<table width="100%" style="table-layout:fixed; font-family:Tahoma; font-size:12px;"><tr><td align="left" width="30%">From Date : 20/06/2018</td><td align="left" width="30%">To Date :<asp:Label ID="lbl_today" runat="server"></asp:Label></td><td align="right" width="40%"><asp:Label ID="lbl_noofdepts" runat="server"></asp:Label></td></tr></table>
<table width="100%" border="1" class="table" style="table-layout:fixed; font-size:11px; font-family:Tahoma; vertical-align:middle; border-collapse: collapse; margin:0;">
<thead>
<tr>
<th width="5%">SNO</th>
<th width="35%">Name of the Department</th>
<th width="10%">New Tickets</th>
<th width="10%">Assigned</th>
<th width="10%">In-Progress</th>
<th width="10%">Tickets on Hold</th>
<th width="10%">Closed Tickets</th>
<th width="10%">Total Tickets</th>
</tr>
</thead>
</table>

<asp:Repeater ID="rptr_deptTicketsStatus" runat="server">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<table width="100%" border="1" class="table" style="table-layout:fixed; font-size:11px; font-family:Tahoma; border-collapse: collapse; margin:0;">
<tbody><tr style="padding:0; margin:0;font-size:1em;">
<td width="5%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="35%"><%#Eval("DeptID")%></td>
<td width="10%" align="center"><asp:Label ID="lbl_NewTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_totTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_ProgTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_HoldTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_ClosedTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_TotlTickets" runat="server"></asp:Label></td>
</tr>
</tbody>
</table>
</ItemTemplate>
<FooterTemplate>
<table width="100%" border="1" class="table"  cellpadding="0" cellspacing="0" style="font-size:0.8em; border-width:thin; border-collapse: collapse;  margin-bottom:1px; table-layout:fixed;">
<tr style="background:#ccc; font-family:Tahoma; font-size:x-large;"><th colspan="2" style="text-align:right; color:#0307AE;">Total : </th>
<td width="10%" align="center"><asp:Label ID="lbl_gNewTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_gtotTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_gProgTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_gHoldTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_gClosedTickets" runat="server"></asp:Label></td>
<td width="10%" align="center"><asp:Label ID="lbl_gTotlTickets" runat="server"></asp:Label></td>
</tr>
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
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

