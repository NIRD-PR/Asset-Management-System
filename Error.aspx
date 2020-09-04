<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="col-md-12" style="margin-top:5em;  width:100%;" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
<div class="panel-body">
<div class="col-md-12" style="padding:8px 5px; margin:0; text-align:center;">
 <br /> 
<label class="lblr">Some thing went Wrong....</label>
<asp:Label ID="lbl_Error" runat="server"></asp:Label>
 <br />  <br />  <br /> 
<asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Click Here for Login" onclick="btn_Submit_Click" />


</div>
</div>
</div>
</asp:Content>

