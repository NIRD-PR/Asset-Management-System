<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="CITStaff.master" AutoEventWireup="true" CodeFile="CITSSDatewiseNewTickets.aspx.cs" Inherits="CITStaff_CITSSHome" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
    .GridDock
    {
        overflow-x: auto;
        overflow-y: hidden;
        width: 100%;
        padding: 0 0 17px 0;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row"><asp:HiddenField ID="hdn_EmpID" runat="server" /><asp:HiddenField ID="hdn_Email" runat="server" />
<div class="panel panel-color panel-success" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">New e-Tickets Dashboard &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px;">
<table><tr><td width="35%" align="right" style="vertical-align:middle;">From Date :</td><td width="20%" align="left" style="vertical-align:middle;"><asp:TextBox ID="txt_FromDate" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"></asp:TextBox>
                <Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1"  ID="Calendar1"  PopupButtonID="txt_FromDate" runat="server" TargetControlID="txt_FromDate" Format="dd/MM/yyyy"> </Ajax:CalendarExtender>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txt_FromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Enter like DD/MM/YYYY" ValidationGroup="Group1" />
</td><td width="10%" align="right" style="vertical-align:middle;">To Date :</td><td width="20%" align="left" style="vertical-align:middle;"><asp:TextBox ID="txt_ToDate" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"></asp:TextBox>
<Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1"  ID="CalendarExtender1"  PopupButtonID="txt_ToDate" runat="server" TargetControlID="txt_ToDate" Format="dd/MM/yyyy"> </Ajax:CalendarExtender>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_ToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Enter like DD/MM/YYYY" ValidationGroup="Group1" />
</td><td width="20%" align="center"><asp:Button ID="btn_GetDetails" runat="server" CausesValidation="false" 
            CssClass="btn btn-primary" Text="Get Details" onclick="btn_GetDetails_Click" /></td></tr></table>
<div class="GridDock" id="dvGridWidth">
<asp:GridView ID="gv_Tickets" runat="server" CssClass="table table-bordered table-hover"  ShowHeader="false" AlternatingRowStyle-CssClass="accordion-toggle" RowStyle-HorizontalAlign="Center"  AllowSorting="true" 
        onrowdatabound="gv_Tickets_RowDataBound">
          </asp:GridView>

</div>
<center><asp:Label ID="lbl_NoData" runat="server" CssClass="btn-danger" Visible="false"></asp:Label></center>
</div>
</div>
</div>
</div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

