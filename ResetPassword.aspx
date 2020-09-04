<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Site_ResetPassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../assets/sha1.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $("#form1").validationEngine('attach', { promptPosition: "topRight" });
     });
     function validateReg() {
         var npwd = document.getElementById('<%=txt_NewPwd.ClientID%>').value;
         var cpwd = document.getElementById('<%=txt_CPwd.ClientID%>').value;

          if (npwd == "") {

             return false;
         }
         if (cpwd == "") {

             return false;

         }
         var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
         var myval = SHA1(keyGenrate);

         document.getElementById('<%=npwd.ClientID%>').value = '';
         var newp = SHA1(document.getElementById('<%=txt_NewPwd.ClientID%>').value.toString());
         document.getElementById('<%=txt_NewPwd.ClientID%>').value = '******';
         document.getElementById('<%=npwd.ClientID%>').value = newp;

         document.getElementById('<%=cpwd.ClientID%>').value = '';
         var cp = SHA1(document.getElementById('<%=txt_CPwd.ClientID%>').value.toString());
         document.getElementById('<%=txt_CPwd.ClientID%>').value = '******';
         document.getElementById('<%=cpwd.ClientID%>').value = cp;
     }          
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="content-page" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
<div class="content">
<div class="container">
<div class="row">
<div class="col-sm-12">
<br />
<br />

<div class="col-sm-4"></div>
<div class="col-sm-4"><asp:HiddenField ID="hdn_Random" runat="server" />
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Reset Password</h3></div>
<div class="panel-body">
<div class="col-xs-12">
<label>Enter EmpID</label>
<asp:TextBox ID="txt_EmpID" runat="server" CssClass="form-control" placeholder="EmpID" ></asp:TextBox><br />
<label>Registered Mobile</label>
<asp:TextBox ID="txt_Mobile" runat="server" CssClass="form-control" placeholder="Mobile" MaxLength="10"></asp:TextBox>
<asp:RegularExpressionValidator ID="regPhone" runat="server" ControlToValidate="txt_Mobile" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" Text="Invalid Mobile No." style="font-size:0.75em;" /><br />
<asp:Button ID="btn_SendOTP" runat="server" CssClass="btn btn-primary" 
        Text="Send OTP" onclick="btn_SendOTP_Click" />

<asp:Panel ID="pnl_Reset" runat="server" Visible="false">
<label>Enter OTP <label class="lblr">*</label></label>
<asp:TextBox ID="txt_OTP" runat="server" CssClass="form-control" placeholder="OTP" TextMode="Password"></asp:TextBox><br />
<label>New Password <label class="lblr">(eg. Abcd@12345)</label></label>
<asp:TextBox ID="txt_NewPwd" runat="server" CssClass="form-control" placeholder="New Password" TextMode="Password"></asp:TextBox><asp:HiddenField ID="npwd"  runat="server" />
 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter New Password" ControlToValidate="txt_NewPwd"></asp:RequiredFieldValidator>
 
<br />
<label>Confirm Password</label>
<asp:TextBox ID="txt_CPwd" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox><asp:HiddenField ID="cpwd"  runat="server" />
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_CPwd" ControlToCompare="txt_NewPwd" ErrorMessage="*"></asp:CompareValidator><br />
<asp:RegularExpressionValidator ID="Regex2" runat="server" ControlToValidate="txt_NewPwd"
    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"
    ErrorMessage="Minimum 8 characters atleast 1 Uppercase, 1 Number and 1 Special Character" ForeColor="Red" />
 <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" OnClientClick="return validateReg();"
        Text="Update Password" onclick="btn_Submit_Click" />

</asp:Panel>
</div>
</div>
</div>
<div class="col-sm-4"></div>
</div>
</div>
</div>
</div>
</div>
</div>
</asp:Content>

