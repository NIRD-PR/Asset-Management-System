<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="CICTETickets_AllbyDates.aspx.cs" Inherits="Inventory_CICTIniatedETicketsHold" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function showModal() {
        $("#panel_modal").modal('show');
    }

    $(function () {
        $("#btnClick").click(function () {
            showModal();
        });
    });

    function showDivModal() {
        $("#panel1_modal").modal('show');
    }

    $(function () {
        $("#btnClick1").click(function () {
            showDivModal();
        });
    });
    </script>
<style>
table tr th td
{
    border:0.2pt solid #999;
}
</style>
<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write('<html><head><title>NIRDPR CIT-eTicket Details</title>');
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
    <script type = "text/javascript">
        function PrintPopUpPanel() {
            var panel = document.getElementById("<%=pnl_printpopup.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>NIRDPR CIT-eTicket Details</title>');
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
<div class="panel-heading"><h3 class="panel-title"> e-Tickets Status between Dates &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;">
<div class="row"><asp:HiddenField ID="hdn_QuertyString" runat="server" />
     <table width="100%" style="table-layout:fixed;">
     <tr><td width="15%" align="right">Select From Date : </td><td align="left" width="15%"><asp:TextBox ID="txt_FromDate" runat="server" CssClass="form-control" placeholder="DD/MMM/YYYY"></asp:TextBox><Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1" ID="Calendar2"  PopupButtonID="txt_FromDate" runat="server" TargetControlID="txt_FromDate" Format="dd/MMM/yyyy"> </Ajax:CalendarExtender></td><td width="15%" align="right">Select To Date : </td><td align="left" width="15%"><asp:TextBox ID="txt_ToDate" runat="server" CssClass="form-control" placeholder="DD/MMM/YYYY"></asp:TextBox><Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1" ID="CalendarExtender1"  PopupButtonID="txt_ToDate" runat="server" TargetControlID="txt_ToDate" Format="dd/MMM/yyyy"> </Ajax:CalendarExtender></td><td width="10%" align="center"><asp:Button ID="btn_GetData" runat="server" CssClass="btn btn-primary" Text="Get Data" OnClick="btn_GetData_Click" /></td></tr>
 </table>
    <br />
<asp:Panel ID="pnl_print" runat="server">

<asp:Repeater ID="rptr_TicketData" runat="server" onitemcommand="rptr_TicketData_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<thead><tr>
<th width="5%">SNO</th>
<th width="10%">Ticket #</th>
<th width="20%">Ticket From</th>
<th width="15%">Ticket for</th>
<th width="10%">Available Time</th>
<th width="40%">Status</th>
<th width="5%">History</th>
</tr>
</thead>
</table>
</HeaderTemplate>
<ItemTemplate>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:1px ;">
<tbody><tr>
<td width="5%" rowspan="2" align='center'><%#Container.ItemIndex+1 %></td>
<td width="10%" align="center"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument='<%#Eval("TicketNo")%>' ToolTip="View Complete Details to Initiate the Work"><%#Eval("TicketNo")%></asp:LinkButton></td>
<td width="20%" align="center" style="font-size:11px;"><%#Eval("Name")%><br /><%#Eval("Dated")%></td>
<td width="15%" align="center" style="font-size:11px;"><%#Eval("ItemName")%></td>
<td width="10%" style="font-size:11px;"><%#Eval("AvailableTime")%></td>
<td width="40%" align="center" id="td_status" runat="server"><asp:Label ID="lbl_Status" runat="server" Text=""></asp:Label></td>
<td width="5%" align="center" style="font-size:11px;"><asp:LinkButton ID="LinkButton3" runat="server" CommandName="History" CommandArgument='<%#Eval("TicketNo")%>'  ToolTip="Close Ticket"><i class="fa fa-history" style="font-size:X-large; color:Red;"></i></asp:LinkButton></td>
</tr>
<tr><td width="100%" colspan="6" style="font-size:11px;"><%#Eval("ProblemDescription")%></td></tr>
</tbody>
</table>
</ItemTemplate>
<AlternatingItemTemplate>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tbody><tr style="background:#EFFBFF;">
<td width="5%" rowspan="2" align='center'><%#Container.ItemIndex+1 %></td>
<td width="10%" align="center"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument='<%#Eval("TicketNo")%>' ToolTip="View Complete Details to Initiate the Work"><%#Eval("TicketNo")%></asp:LinkButton></td>
<td width="20%" align="center" style="font-size:11px;"><%#Eval("Name")%><br /><%#Eval("Dated")%></td>
<td width="15%" align="center" style="font-size:11px;"><%#Eval("ItemName")%></td>
<td width="10%" style="font-size:11px;"><%#Eval("AvailableTime")%></td>
<td width="40%" align="center" ID="td_status" runat="server"><asp:Label ID="lbl_Status" runat="server" Text=""></asp:Label></td>
<td width="5%" align="center" style="font-size:11px;"><asp:LinkButton ID="LinkButton3" runat="server" CommandName="History" CommandArgument='<%#Eval("TicketNo")%>'  ToolTip="Close Ticket"><i class="fa fa-history" style="font-size:X-large; color:Red;"></i></asp:LinkButton></td>
</tr>
<tr><td width="100%" colspan="6" style="font-size:11px;"><%#Eval("ProblemDescription")%></td></tr>
</tbody>
</table>
</AlternatingItemTemplate>
</asp:Repeater>
</asp:Panel>
<br />
<center><asp:Label ID="lbl_NoData" runat="server" CssClass="label-danger" Visible="false"></asp:Label></center>
</div>
</div>
</div>
</div>
</div>
<div id="panel_modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none; margin-top:60px; ">
   <div class="modal-dialog" style="box-shadow: 5px 5px 10px #000000; width:75%;">
      <div class="modal-content p-0 b-0">
            <div class="panel panel-color panel-primary">
                  <div class="panel-heading"> 
                       <button type="button" class="close label-inverse" data-dismiss="modal" aria-hidden="true">x</button> 
                        <h3 class="panel-title">Details of e-Ticket with the No.<asp:Label ID="lbl_Tickt" runat="server"></asp:Label> &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-success" OnClientClick = "return PrintPopUpPanel();"><i class="fa fa-print"></i></asp:LinkButton> <asp:Label ID="Label1" runat="server" CssClass="pull-right">0</asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;</h3>
                        </div> 
                         <div class="panel-body"> 
                        <%--<center> <img src="assets/images/users/userlogon.jpg" Width="70" alt="testimoni"  /></center>	--%>
                           <div class="form-horizontal m-t-20" style="padding:0 80px;">
        <div class="form-group col-xs-12" style="padding:0; margin:0;">
        <div class="col-xs-12"> <asp:HiddenField ID="HiddenField1" runat="server" />
        
        <asp:Panel ID="pnl_printpopup" runat="server">
<table width="100%" style="font-family:Tahoma;">
<tr><td colspan="5" align="center"><img src="../assets/images/title.png" height="80" width="400"  alt=""/></td></tr>
<tr><td colspan="5" align="center"><h3>Details of e-Ticket No. <asp:Label ID="lbl_TicketNo" runat="server"></asp:Label> </h3></td></tr>
</table>
<asp:DataList ID="dl_EmpDetails" runat="server" Width="100%">
<ItemTemplate>
<label class="pull-left"><b>e-Ticket raised by :</b></label>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tr style="font-weight:bold; font-size:0.8em; color:#257A08; vertical-align:middle; text-align:center;">
<td rowspan="2" width="10%" align="center" style="background:#A591FA;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" ImageUrl='<%#"../SPhotos/"+Eval("Photo")%>' Width="60" Height="65"></asp:ImageMap>  </td>
<td width="10%">EmpID</td>
<td width="25%">Name / Design [Dept]</td>
<td width="25%">Contact Details</td>
<td width="20%">EType / Sex</td>
<td width="20%">DOJ / DOR</td>
</tr>
<tr><td width="10%" align="center" style="vertical-align:middle; font-weight:bold;"><%#Eval("EmpID")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Name")%> <br /><label class="lblr"><%#Eval("Design")%></label> [<label class="lblr"><%#Eval("DeptID")%></label>]</td>
<td width="25%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Email")%><br /><%#Eval("Mobile")%></td>
<td width="20%"><%#Eval("EmpGroup")%><br /><%#Eval("Gender")%>[<asp:Label ID="lbl_Age" runat="server" CssClass="lblr"></asp:Label>] </td>
<td width="20%" style="vertical-align:middle; text-align:center;"><%# DataBinder.Eval(Container.DataItem, "DOJ", "{0:dd/MM/yyyy}") %> <br /> <asp:Label ID="lbl_DOR" runat="server" CssClass="lblr"></asp:Label></td>
</table>
</ItemTemplate>
</asp:DataList>
<br /><br />

<label class="pull-left"><b>e-Ticket raised for :</b></label>
<asp:Repeater ID="rptr_Items" runat="server">
<ItemTemplate>
<table width="100%" class="table" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tr><td colspan="5" class="pull-left"><b><%#Eval("ItemName")%></b> :</td></tr>
<tr><td colspan="5">
<asp:DataList ID="dl_CITData" runat="server" Width="100%">
<HeaderTemplate>

</HeaderTemplate>
<ItemTemplate>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tr style="font-weight:bold; font-size:0.8em; color:#257A08; vertical-align:middle; text-align:center;">
<td width="20%">Manufacturer</td>
<td width="15%">Model</td>
<td width="15%">SerialNo</td>
<td width="25%">Warranty</td>
<td width="25%">Office No.</td>
</tr>

<tr><td width="20%" align="center" style="vertical-align:middle;text-align:center; "><%#Eval("Manufacturer")%></td>
<td width="15%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("Model")%></td>
<td width="15%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("SerialNo")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("Warranty")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("ComputerNumber")%></td></tr>

</table>
 </ItemTemplate>
</asp:DataList>
</td></tr>
<tr><td colspan="5"><br /></td></tr>
</table>
</ItemTemplate>
</asp:Repeater><br />
<label class="pull-left"><i><asp:Label ID="lbl_NoDevice" runat="server"></asp:Label></i></label>
<br /><br />
<label class="pull-left"><b>Ticket Location Details :</b></label><br />
<table class="table" width="100%" style="table-layout:fixed; font-family:Tahoma; vertical-align:top; font-size:12px;">
<tr><td width="20%">Dated</td><td width="1%">:</td><td><asp:Label ID="lbl_Date" runat="server"></asp:Label></td></tr>
<tr><td width="20%">Location / Block</td><td width="1%">:</td><td><asp:Label ID="lbl_Location" runat="server"></asp:Label></td></tr>
<tr><td width="20%">Floor</td><td width="1%">:</td><td><asp:Label ID="lbl_Floor" runat="server"></asp:Label></td></tr>
<tr><td width="20%">Room No</td><td width="1%">:</td><td><asp:Label ID="lbl_RoomNo" runat="server"></asp:Label></td></tr>
<tr><td width="20%">Available Time</td><td width="1%">:</td><td><asp:Label ID="lbl_AvailableTime" runat="server"></asp:Label></td></tr>
<tr><td width="20%">Problem Description</td><td width="1%">:</td><td><b><asp:Label ID="lbl_ProblemDescription" runat="server"></asp:Label></b></td></tr>
</table>

<br />
<label class="pull-left"><b>Ticket Assigned to CICT Supporting Engineer :</b></label><br />
<table class="table" width="100%" style="table-layout:fixed; font-family:Tahoma; vertical-align:top; font-size:12px;">
<tr><td width="25%">Supporting Engineer</td><td width="1%">:</td><td><asp:Label ID="lbl_UName" runat="server"></asp:Label></td></tr>
<tr><td width="25%">Email</td><td width="1%">:</td><td><asp:Label ID="lbl_UEmail" runat="server"></asp:Label></td></tr>
<tr><td width="25%">Mobile</td><td width="1%">:</td><td><asp:Label ID="lbl_UMobile" runat="server"></asp:Label></td></tr>
</table>

<%--<i>Note: If any item Approved Quantity is '0', it means "Requested item is out of Stock".</i>--%>
  </asp:Panel>      
  </div>
        </div>
        </div>
        </div>
        </div>
        </div>
        </div>
        </div>

<br />
<div id="panel1_modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLbl" aria-hidden="true" style="display: none; margin-top:60px; ">
   <div class="modal-dialog" style="box-shadow: 5px 5px 10px #000000; width:75%;">
      <div class="modal-content p-0 b-0">
            <div class="panel panel-color panel-success">
                  <div class="panel-heading"> 
                       <button type="button" class="close label-inverse" data-dismiss="modal" aria-hidden="true">x</button> 
                        <h3 class="panel-title">History of e-Ticket with the No.<asp:Label ID="lbl_CTicketno" runat="server"></asp:Label> &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <asp:LinkButton ID="LinkButton2" runat="server" CssClass="middle btn btn-success" OnClientClick = "return PrintHistoryPanel();"><i class="fa fa-print"></i></asp:LinkButton> <asp:Label ID="lbl_pCount" runat="server" CssClass="pull-right">0</asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;</h3>
                        </div> 
                         <div class="panel-body"> 
                        <%--<center> <img src="assets/images/users/userlogon.jpg" Width="70" alt="testimoni"  /></center>	--%>
                           <div class="form-horizontal m-t-20" style="padding:0 80px;">
        <div class="form-group col-xs-12" style="padding:0; margin:0;">
        <div class="col-xs-12"> <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:Panel ID="printHistory" runat="server"> 
        <center><img src="../assets/images/title.png" height="80" width="400"  alt=""/><br /><h3><asp:Label ID="lbl_Ticketnos" runat="server"></asp:Label></h3></center>
        <table width="100%">
        <tr><td width="10%">Item Type</td><td width="1%">:</td><td align="left"><asp:Label ID="lbl_ItemName" runat="server"></asp:Label></td><td></td></tr>
        <tr><td width="10%">Problem</td><td width="1%">:</td><td align="left"><asp:Label ID="lbl_Problem" runat="server"></asp:Label></td><td align="right"><asp:Label ID="lbl_PDated" runat="server"></asp:Label></td></tr>
        </table>
        <table width="100%" class="table table-responsive" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
        <tr><th>Dated</th><th>Action Description</th><th>Actioned By</th></tr>
        <tr><td><asp:Label ID="lbl_EDated" runat="server"></asp:Label></td><td>Ticket Created</td><td><asp:Label ID="lbl_ENames" runat="server"></asp:Label></td></tr>
        <tr><td><asp:Label ID="lbl_IDated" runat="server"></asp:Label></td><td>Ticket Initiated</td><td><asp:Label ID="lbl_UNames" runat="server"></asp:Label></td></tr>
       
        <asp:Repeater ID="rptr_History" runat="server">
        <ItemTemplate>
        <tr><td><%#Eval("Dated")%></td><td><%#Eval("Comment")%></td><td><%#Eval("UName")%></td></tr>
        </ItemTemplate>
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
</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed;top:0;left:0; background-color: black;z-index: 99; opacity: 0.8;filter: alpha(opacity=80);-moz-opacity: 0.8;min-height: 100%; width: 100%;">
           Please wait...<br /> <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../loader.gif"  AlternateText="Loading ..." Width="120" ToolTip="Loading ..." style="font-family: Arial;font-size: 10pt;border: 5px solid #67CFF5; top:40%; left:45%;width:120;position: fixed; background-color: White; z-index: 999;" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>  
</asp:Content>

