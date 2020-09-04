<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="CITStaff.master" AutoEventWireup="true" CodeFile="TicketComments.aspx.cs" Inherits="CITStaff_TicketComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row"><asp:HiddenField ID="hdn_TicketNo" runat="server" /><asp:HiddenField ID="hdn_EmpID" runat="server" /><asp:HiddenField ID="hdn_Name" runat="server" /><asp:HiddenField ID="hdn_UEmpID" runat="server" /><asp:HiddenField ID="hdn_UName" runat="server" /><asp:HiddenField ID="hdn_ProblemDesciption" runat="server" /><asp:HiddenField ID="hdn_ItemName" runat="server" /><asp:HiddenField ID="hdn_ITID" runat="server" />
<div class="col-xs-12">
<div class="panel panel-color panel-success" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">Engineer Comments on e-Ticket &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;">
<div class="row"><asp:HiddenField ID="hdn_QuertyString" runat="server" />

<label>Assigned Ticket Info :</label>
<asp:DataList ID="dl_TicketInfo" runat="server" Width="100%">
<ItemTemplate>
<table width="100%" class="table table-bordered table-hover table-responsive">
<tr><th width="10%">Dated</th><th width="5%">EmpID</th><th width="10%">Ticket No</th><th width="20%">Name</th><th width="15%">Problem With</th><th width="45%">Problem Description</th></tr>
<tr class="cd-primary"><td align="center"><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td><td align="center"><%#Eval("EmpID")%></td><td align="center"><%#Eval("TicketNo")%></td><td><%#Eval("Name")%></td><td align="center"><%#Eval("ItemName")%></td><td><%#Eval("ProblemDescription")%></td></tr>
</table>
</ItemTemplate>
</asp:DataList>
<table width="100%" class="table">
<tr class="alt"><td width="15%" align="left">Comments / Remarks</td><td width="60%"><asp:TextBox ID="txt_Comment" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="500" Height="35" style=" vertical-align:text-top;" placeholder="Comment"></asp:TextBox>
<asp:RegularExpressionValidator runat="server" ID="valInput" ControlToValidate="txt_Comment" ValidationExpression="^[\s\S]{0,500}$" CssClass="lblr" ErrorMessage="Please enter a maximum of 500 characters"  Display="Dynamic"></asp:RegularExpressionValidator>
</td><td width="15%"><asp:DropDownList ID="ddl_Status" runat="server" CssClass="form-control"></asp:DropDownList></td><td width="10%"><center><asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Submit Comment" onclick="btn_Submit_Click" /></center></td></tr>
</table>
</div>
</div>
</div>
</div>
</div>
<div class="panel panel-color panel-info" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title"> e-Ticket Comments of  <asp:Label ID="lbl_TicketNo" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_Counts" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;">
<table width="100%" class="table table-bordered table-hover table-responsive"><tr><th width="15%">Date</th><th width="70%">Comments</th><th width="15%">Status</th></tr></table>

<asp:Repeater ID="rptr_TicketComments" runat="server">
<ItemTemplate>
<table width="100%" class="table table-bordered table-hover table-responsive" style="margin:0;"><tr><td align="center" width="15%"><%#Eval("Dated")%></td><td width="70%"><%#Eval("Comment")%></td><td width="15%"><%#Eval("Status")%></td></tr></table>
</ItemTemplate>
</asp:Repeater>
</div>
</div>
</div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

