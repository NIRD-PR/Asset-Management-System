<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="VehicleLogin.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="assets/sha1.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $("#form1").validationEngine('attach', { promptPosition: "topRight" });
     });
     function validateReg() {
         var userName = document.getElementById('<%=txt_UserID.ClientID%>').value;
         var pwd = document.getElementById('<%=txt_Password.ClientID%>').value;

         if (userName == "") {
             return false;
         }

         if (pwd == "") {

             return false;
             alert("Enter UserID & Password");
         }
         var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
         var myval = SHA1(keyGenrate);
         document.getElementById('<%=txtPwdHash.ClientID%>').value = '';
         var myval1 = SHA1(document.getElementById('<%=txt_Password.ClientID%>').value.toString());
         document.getElementById('<%=txt_Password.ClientID%>').value = '******';
         document.getElementById('<%=txtPwdHash.ClientID%>').value = SHA1(myval1 + myval);
     }
           
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="wrapper-page" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
        <div class="panel panel-color panel-primary panel-pages">
        <div class="panel-heading bg-img3">
        <div class="bg-overlay"></div>
        <h3 class="text-center m-t-10 text-white" style="text-shadow: 1px 1px 2px black, 0 0 25px white, 0 0 5px yellow;">Sign In to <strong>NIRDPR-Vehicle Management System</strong></h3></div>
        <div class="panel-body">
        <div class="form-horizontal m-t-20">
        <div class="form-group">
        <div class="col-xs-12">
        <label>Enter User Name</label>
        <asp:TextBox ID="txt_UserID" runat="server" CssClass="form-control"  required="" placeholder="Username"></asp:TextBox></div></div>

        <div class="form-group"><div class="col-xs-12">
        <label>Enter Password</label>
        <asp:TextBox ID="txt_Password" runat="server" CssClass="form-control"  TextMode="Password" required="" placeholder="Password"></asp:TextBox><asp:HiddenField ID="txtPwdHash"  runat="server" /></div></div>
        <div class="form-group"><div class="col-xs-12">
        <div class="col-xs-5" style="float:left;">
        <label>Enter Captcha</label>
        <asp:TextBox ID="txt_Captcha" runat="server" CssClass="form-control"  placeholder="Captcha"></asp:TextBox></div>
        <div class="col-xs-7" style="float:right;">
        <label style="color:#fff;">...</label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    <div class="col-sm-8"><cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
            CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
            FontColor="#D20B0C" NoiseColor="#B1B1B1" /></div><div class="col-sm-2" style="float:right;">
                                    
            <span class="text-right"><asp:ImageButton ID="ImageButton2" ImageUrl="assets/images/refresh.png" runat="server" CausesValidation="false" Width="25" /></span></div>
            <div class="col-xs-12"><asp:CustomValidator ID="CustomValidator1" ErrorMessage="Invalid Captcha" OnServerValidate="ValidateCaptcha"
            runat="server" /></div>  </ContentTemplate>
            <Triggers><asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />        
            </Triggers></asp:UpdatePanel> </div> </div></div>
        <div class="form-group"><div class="col-xs-12"><a href="#"><i class="fa fa-lock m-r-5"></i><span>Forgot your password?</a><br /></div></div>
        
        <div class="form-group text-center m-t-40">
        <div class="col-xs-12">
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Log In" OnClientClick="return validateReg();"
                onclick="btn_Submit_Click" /></div></div>
        <div class="form-group m-t-30">
        </div></div>
        </div>
    </div>
</div>
</asp:Content>

