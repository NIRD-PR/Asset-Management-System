<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="GovMailRequestForm.aspx.cs" Inherits="GovMailRequestForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript">
    function ToUpper(ctrl) {
        var t = ctrl.value;
        ctrl.value = t.toUpperCase();
    }
    function ToLower(ctrl) {
        var t = ctrl.value;
        ctrl.value = t.toLowerCase();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content" style="margin-top:6em;  width:100%;"  onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Send.ClientID %>')">
<div class="container">
<div class="row">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Requisition for .GOV Mail</h3></div>
<div class="panel-body">
<div class="col-lg-12">
<div class="col-lg-3">
<label>Employee Type<label class="lblr">&nbsp; *</label></label>
<asp:DropDownList ID="ddl_EmpType" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-lg-3">
<label>Select Department<label class="lblr">&nbsp; *</label></label>
<asp:DropDownList ID="ddl_Dept" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-lg-3">
<label>Emp ID<label class="lblr">&nbsp; Note: if Not available, Enter Last 8 Digits of Aadhar</label></label>
<asp:TextBox ID="txt_EmpID" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Emp ID"></asp:TextBox><br />
</div>
<div class="col-lg-3">
<label>Sur Name / Last Name<label class="lblr">&nbsp; *</label></label>
<asp:TextBox ID="txt_SurName" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Last Name"></asp:TextBox><br />
</div>
</div>
<div class="col-lg-12">
<div class="col-lg-3">
<label>Name of the Employee<label class="lblr">&nbsp; *</label></label>
<asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Name of the Employee"></asp:TextBox><br />
</div>
<div class="col-lg-3">
<label>Designation<label class="lblr">&nbsp; *</label></label>
<asp:TextBox ID="txt_Designation" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Designation"></asp:TextBox><br />
</div>
<div class="col-lg-3">
<label>Email<label class="lblr">&nbsp; *</label></label>
<asp:TextBox ID="txt_Email" runat="server" CssClass="form-control" placeholder="Current Email"></asp:TextBox>
<asp:RegularExpressionValidator ID="TxtEmailRegEx" runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt_Email" style="font-size:0.75em;" /><br />
</div>
<div class="col-lg-3">
<label>Mobile<label class="lblr">&nbsp; *</label></label>
<asp:TextBox ID="txt_Mobile" runat="server" CssClass="form-control" placeholder="Mobile"  MaxLength="10"></asp:TextBox>
<asp:RegularExpressionValidator ID="regPhone" runat="server" ControlToValidate="txt_Mobile" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" Text="Invalid Mobile" style="font-size:0.75em;" /><br />
</div>
</div>
<div class="col-lg-12">
<div class="col-lg-3">
<label>Expected Gov Mail<label class="lblr">&nbsp; *</label></label>
<asp:TextBox ID="txt_GovMail" runat="server" CssClass="form-control" placeholder="Short Name"></asp:TextBox>
<label class="lblg">.nird@gov.in</label>
</div>
<div class="col-lg-3">
<label>Project Title<label class="lblr"> &nbsp; (if Project / Consultant Staff)</label></label>
<asp:TextBox ID="txt_ProjectTitle" runat="server" CssClass="form-control" placeholder="Title of the Project"></asp:TextBox>
</div>
<div class="col-lg-3">
<label>Date of Birth<label class="lblr">&nbsp;&nbsp; *</label></label>
<asp:TextBox ID="txt_DOB" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY" required=""  MaxLength="10"></asp:TextBox>
<Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1"  ID="Calendar1"  PopupButtonID="txt_DOB" runat="server" TargetControlID="txt_DOB" Format="dd/MM/yyyy"> </Ajax:CalendarExtender>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txt_DOB" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Enter like DD/MM/YYYY" ValidationGroup="Group1" />
</div>
<div class="col-lg-3">
<label>Date of Join<label class="lblr">&nbsp;&nbsp; *</label></label>
<asp:TextBox ID="txt_DOJ" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY" required=""  MaxLength="10"></asp:TextBox>
<Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1"  ID="CalendarExtender1"  PopupButtonID="txt_DOJ" runat="server" TargetControlID="txt_DOJ" Format="dd/MM/yyyy"> </Ajax:CalendarExtender>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_DOJ" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Enter DD/MM/YYYY" ValidationGroup="Group1" />
</div>
</div>
<div class="col-lg-12">
<div class="col-lg-3">
<label>Date of Retirement / Valid Upto<label class="lblr">&nbsp;&nbsp; *</label></label>
<asp:TextBox ID="txt_DOR" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY" required="" MaxLength="10"></asp:TextBox>
<Ajax:CalendarExtender DefaultView="Years" CssClass="cal_Theme1"  ID="CalendarExtender2"  PopupButtonID="txt_DOR" runat="server" TargetControlID="txt_DOR" Format="dd/MM/yyyy"> </Ajax:CalendarExtender>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_DOR" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Enter DD/MM/YYYY" ValidationGroup="Group1" />
</div>
<div class="col-lg-3">
<br />
<asp:Button ID="btn_Send" runat="server" CssClass="btn btn-primary" Text="Submit Data" CausesValidation="false" 
        onclick="btn_Send_Click" />
</div>
</div>
</div>
</div>
</div>
</div><br /><br /><br /><br /><br /><br /><br />
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

