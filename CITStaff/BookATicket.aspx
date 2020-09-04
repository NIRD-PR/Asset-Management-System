<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="CITStaff.master" AutoEventWireup="true" CodeFile="BookATicket.aspx.cs" Inherits="CITStaff_BookATicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row"><asp:HiddenField ID="hdn_TicketNo" runat="server" /><asp:HiddenField ID="hdn_TNO" runat="server" />
<div class="col-xs-12"><asp:HiddenField ID="hdn_EEmpID" runat="server" /><asp:HiddenField ID="hdn_EEmpName" runat="server" /><asp:HiddenField ID="hdn_EmpID" runat="server" /> <asp:HiddenField ID="hdn_EmpName" runat="server" /><asp:HiddenField ID="hdn_Design" runat="server" /><asp:HiddenField ID="hdn_DID" runat="server" /><asp:HiddenField ID="hdn_DeptID" runat="server" /><asp:HiddenField ID="hdn_Email" runat="server" /><asp:HiddenField ID="hdn_Mobile" runat="server" />
<div class="panel panel-color panel-success" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">Book A Ticket &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;">
<div class="row">
<div class="col-xs-3">
<label>Select Emp Name <asp:Label ID="lbl_NameCount" runat="server" CssClass="lblr">*</asp:Label> </label>
<asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" AutoPostBack="true"
        placeholder="Name or EmpID" ontextchanged="txt_Name_TextChanged"></asp:TextBox>
<asp:DropDownList ID="ddl_EmpName" runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_EmpName_SelectedIndexChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
<label>Select Your Location <asp:Label ID="Label2" runat="server" CssClass="lblr">*</asp:Label></label>
<asp:DropDownList ID="ddl_Location" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
<label>Select Floor <asp:Label ID="Label3" runat="server" CssClass="lblr">*</asp:Label></label>
<asp:DropDownList ID="ddl_Floor" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
<label>Select Room No <asp:Label ID="Label4" runat="server" CssClass="lblr">*</asp:Label></label>
<asp:DropDownList ID="ddl_RoomNo" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="row">
<div class="col-xs-12">
<div class="col-xs-3">
<label class="lblr">Enter your Available Time for Problem Resolve <asp:Label ID="Label5" runat="server" CssClass="lblr"></asp:Label></label>
<asp:TextBox ID="txt_AvailableTime" runat="server" CssClass="form-control" placeholder="eg. 10AM to 12PM"></asp:TextBox>
<label class="lblr">Note: Please Enter Available time between Office Hours only (i.e., 09:00AM to 05:30PM)</label>
</div>

<div class="col-xs-3">
<label>Complaint related <asp:Label ID="lbl_ItemType" runat="server" CssClass="lblr">*</asp:Label></label>
<asp:DropDownList ID="ddl_ItemType" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-6">
<label >Enter Detailed Problem Description <asp:Label ID="Label6" runat="server" CssClass="lblr">(max. 500 characters only) *</asp:Label></label>
<asp:TextBox ID="txt_ProblemDescription" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="500"  style=" vertical-align:text-top; " Height="80" placeholder="Comments / Remarks"></asp:TextBox>
<asp:RegularExpressionValidator runat="server" ID="valInput" ControlToValidate="txt_ProblemDescription" ValidationExpression="^[\s\S]{0,500}$" CssClass="lblr" ErrorMessage="Please enter a maximum of 500 characters"  Display="Dynamic"></asp:RegularExpressionValidator><br />

</div>
<center><asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" 
        Text="Book Complaint" onclick="btn_Submit_Click" /></center>
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
</asp:Content>

