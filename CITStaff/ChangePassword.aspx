<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="CITStaff.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="CITStaff_ChangePassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../assets/sha1.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $("#form1").validationEngine('attach', { promptPosition: "topRight" });
     });
     function validateReg() {
         var oldpwd = document.getElementById('<%=txt_OldPwd.ClientID%>').value;
         var npwd = document.getElementById('<%=txt_NewPwd.ClientID%>').value;
         var cpwd = document.getElementById('<%=txt_CPwd.ClientID%>').value;

         if (oldpwd == "") {

             return false;

         }

         if (npwd == "") {

             return false;

         }
         if (cpwd == "") {

             return false;

         }
         var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
         var myval = SHA1(keyGenrate);

         document.getElementById('<%=opwd.ClientID%>').value = '';
         var oldp = SHA1(document.getElementById('<%=txt_OldPwd.ClientID%>').value.toString());
         document.getElementById('<%=txt_OldPwd.ClientID%>').value = '******';
         document.getElementById('<%=opwd.ClientID%>').value = oldp;

         document.getElementById('<%=npwd.ClientID%>').value = '';
         var newp = SHA1(document.getElementById('<%=txt_OldPwd.ClientID%>').value.toString());
         document.getElementById('<%=txt_OldPwd.ClientID%>').value = '******';
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
<div class="col-sm-4">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Update Password</h3></div>
<div class="panel-body">
<div class="col-xs-12">
<label>Enter Old Password</label>
<asp:TextBox ID="txt_OldPwd" runat="server" CssClass="form-control" placeholder="Old Password" TextMode="Password"></asp:TextBox><asp:HiddenField ID="opwd"  runat="server" />
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Old Password" ControlToValidate="txt_OldPwd"></asp:RequiredFieldValidator><br />

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
 <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" OnClientClick="return validateReg();" CausesValidation="false"
        Text="Update Password" onclick="btn_Submit_Click" />
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

