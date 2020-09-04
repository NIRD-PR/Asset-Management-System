<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Circulars" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="assets/sha1.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $("#form1").validationEngine('attach', { promptPosition: "topRight" });
     });
     function AdminLoginvalidateReg() {
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
<div class="col-md-12" style="margin-top:5em;  width:100%;" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
<div class="panel-body">
<div class="col-md-9" style="padding:8px 5px; margin:0;"> 
<div class="row"> 
                                <ul class="nav nav-tabs navtab-bg" > 
                                    <li class="active"> 
                                        <a href="#circulars" data-toggle="tab" aria-expanded="false"> 
                                            <span class="visible-xs"><i class="fa fa-home"></i></span> 
                                            <span class="hidden-xs" >e-Circulars</span> 
                                        </a> 
                                    </li> 
                                    <li class=""> 
                                        <a href="#oo" data-toggle="tab" aria-expanded="true"> 
                                            <span class="visible-xs"><i class="fa fa-user"></i></span> 
                                            <span class="hidden-xs">Office Orders</span> 
                                        </a> 
                                    </li> 
                                    <li class=""> 
                                        <a href="#notifications" data-toggle="tab" aria-expanded="false"> 
                                            <span class="visible-xs"><i class="fa fa-envelope-o"></i></span> 
                                            <span class="hidden-xs">Notifications</span> 
                                        </a> 
                                    </li> 
                                    
                                </ul> 
                                <div class="tab-content" style="box-shadow: 5px 5px 3px #888888; margin:0; padding:5px;"> 
                                    <div class="tab-pane active" id="circulars" > 
                                       <div class="panel panel-color panel-success" >
                                        <div class="panel-heading grad" class="pull-left"><h3 class="panel-title">e-Circulars <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
                                        <div class="panel-body" style="background-image: url('../images/header-shade.jpg');">
                                        <div class="col-xs-12" style="min-height: 350px; height:420px; overflow-y:auto; overflow-x:hidden; margin-bottom:0; padding-bottom:0;">
                                        
<asp:Repeater ID="rptr_Data" runat="server" onitemcommand="rptr_Data_ItemCommand">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px; border-bottom:1px solid #D9DCD9;">
<tbody><tr class="gradeX">
<td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
<td width="75%" align='justify'><asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
<td width="15%" align='right'> </td>
</tr>
</tbody>
</table>
</ItemTemplate>
<AlternatingItemTemplate>
<table class="table table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px; border-bottom:1px solid #D9DCD9;">
<tbody><tr>
<td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
<td width="75%" align='justify'><asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
<td width="15%" align='right'> </td>
</tr>
</tbody>
</table>
</AlternatingItemTemplate>
</asp:Repeater>

                                        </div>
                                        </div>
                                    </div>
                                    </div> 
                                    <div class="tab-pane" id="oo"> 
                                         <div class="panel panel-color panel-success" >
                                        <div class="panel-heading grad" class="pull-left"><h3 class="panel-title">e-Office Orders <asp:Label ID="lbl_oocount" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
                                        <div class="panel-body">
                                        <div class="col-xs-12" style="min-height: 350px; height:420px; overflow-y:auto; overflow-x:hidden; margin-bottom:0; padding-bottom:0;">
                                        <asp:Repeater ID="rptr_OO" runat="server" onitemcommand="rptr_OO_ItemCommand">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px; border-bottom:1px solid #D9DCD9;">
<tbody><tr class="gradeX">
<td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
<td width="75%" align='justify'><asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
<td width="15%" align='right'></td>
</tr>
</tbody>
</table>
</ItemTemplate>
<AlternatingItemTemplate>
<table class="table table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px; border-bottom:1px solid #D9DCD9;">
<tbody><tr>
<td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
<td width="75%" align='justify'><asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
<td width="15%" align='right'></td>
</tr>
</tbody>
</table>
</AlternatingItemTemplate>
</asp:Repeater>
                                        </div>
                                        </div>
                                    </div>
                                    </div> 
                                    
                                    
                                    <div class="tab-pane" id="notifications"> 
                                       <div class="panel panel-color panel-success" >
                                        <div class="panel-heading grad" class="pull-left"><h3 class="panel-title">Notifications <asp:Label ID="lbl_noticount" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
                                        <div class="panel-body">
                                        <div class="col-xs-12" style="min-height: 350px; height:420px; overflow-y:auto; overflow-x:hidden; margin-bottom:0; padding-bottom:0;">
                                         <asp:Repeater ID="rptr_noti" runat="server" onitemcommand="rptr_noti_ItemCommand">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px; border-bottom:1px solid #D9DCD9;">
<tbody><tr class="gradeX">
<td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
<td width="75%" align='justify'><asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
<td width="15%" align='right'> </td>
</tr>
</tbody>
</table>
</ItemTemplate>
<AlternatingItemTemplate>
<table class="table table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px; border-bottom:1px solid #D9DCD9;">
<tbody><tr>
<td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
<td width="75%" align='justify'><asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
<td width="15%" align='right'></td>
</tr>
</tbody>
</table>
</AlternatingItemTemplate>
</asp:Repeater>
                                        </div>
                                        </div>
                                    </div>
                                    </div> 
                                    
                                </div> 
                            </div> 
</div>
<div class="col-md-3">
<asp:Panel ID="pnl_Menu" runat="server" style="padding:3px 12px; width:100%; min-height: 620px; height:650px; overflow-y:auto; overflow-x: hidden;"  > <br /> 
<asp:LinkButton ID="btn_SMS" runat="server" PostBackUrl="http://nird.gov.in/sms/" OnClientClick="aspnetForm.target ='_blank';" style="color:#FFFFFF; background:#FF585E; border:1px solid #F7A8AB; box-shadow: 5px 5px 3px #888888; padding:10px; width:30%; margin:5px;" >S M S</asp:LinkButton>
<asp:LinkButton ID="btn_RC" runat="server" PostBackUrl="http://nird.gov.in/rc/" OnClientClick="aspnetForm.target ='_blank';" style="color:#FFFFFF; background:#40BDE8; border:1px solid #9FC9D7; box-shadow: 5px 5px 3px #888888; padding:10px; width:30%; margin:5px;" >Rural Connect</asp:LinkButton>
<asp:LinkButton ID="btn_SRMS" runat="server" PostBackUrl="http://10.10.20.182:1010/" OnClientClick="aspnetForm.target ='_blank';" style="color:#FFFFFF; background:#089508; border:1px solid #13B413; box-shadow: 5px 5px 3px #888888; padding:10px; width:40%; margin:5px;" >S R M S</asp:LinkButton> <br />  <br /> 

<asp:LinkButton ID="btn_Administration" runat="server" style="color:#FFFFFF; background:#7E3CF7; border:1px solid #A378F1; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">e-Administration</asp:LinkButton>
<asp:LinkButton ID="btn_Payroll" runat="server" style="color:#FFFFFF; background:#704165; border:1px solid #D19FC5; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">Payroll Management System</asp:LinkButton>
<asp:LinkButton ID="btn_Stores" runat="server" style="color:#FFFFFF; background:#FF2A07; border:1px solid #F5816E; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;"  class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">Store Management System</asp:LinkButton>
<asp:LinkButton ID="btn_Vehicle" runat="server" style="color:#FFFFFF; background:#0642EC; border:1px solid #6E8EEA; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;"  class="btn  waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">Vehicle Management System</asp:LinkButton>
<asp:LinkButton ID="btn_Hostel" runat="server" style="color:#FFFFFF; background:#541704; border:1px solid #854F3E; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">Guest House Management System</asp:LinkButton>
<asp:LinkButton ID="btn_Complaint" runat="server"  style="color:#FFFFFF; background:#B600F9; border:1px solid #BF6DDD; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">e-Complaint Management System</asp:LinkButton>
<asp:LinkButton ID="btn_Engineering" runat="server" style="color:#FFFFFF; background:#3E6485; border:1px solid #8C9EAD; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">e-Engineering Management System</asp:LinkButton>
<asp:LinkButton ID="btn_Visitors" runat="server" style="color:#FFFFFF; background:#AAAA72; border:1px solid #83E4BC; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">e-Visitors Monitoring System</asp:LinkButton>
<asp:LinkButton ID="btn_Grievance" runat="server" style="color:#FFFFFF; background:#399A72; border:1px solid #83E4BC; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;" class="btn waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">e-Grievance & Redressal System</asp:LinkButton>
<asp:LinkButton ID="btn_Sports" runat="server" style="color:#FFFFFF; background:#000; border:1px solid #969897; box-shadow: 5px 5px 3px #888888; padding:10px; width:100%; margin:5px;"  class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#panel-modal">e-Sports Complex Management System</asp:LinkButton> <br />  <br /> 
<asp:LinkButton ID="btn_HC" runat="server" PostBackUrl="http://10.10.20.182:82/" OnClientClick="aspnetForm.target ='_blank';" style="color:#FFFFFF; background:#1B3930; border:1px solid #E7BD98; box-shadow: 5px 5px 3px #888888; padding:10px; width:30%; margin:5px;" >Health Centre</asp:LinkButton>
<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="https://nirdpr.eoffice.gov.in/" OnClientClick="aspnetForm.target ='_blank';" style="color:#FFFFFF; background:#FF7800; border:1px solid #E7BD98; box-shadow: 5px 5px 3px #888888; padding:10px; width:30%; margin:5px;" >e-Office</asp:LinkButton>
<asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="http://mail.gov.in/" OnClientClick="aspnetForm.target ='_blank';" style="color:#FFFFFF; background:#217109; border:1px solid #E7BD98; box-shadow: 5px 5px 3px #888888; padding:10px; width:30%; margin:5px;" >gov.Mail</asp:LinkButton>
</asp:Panel>
</div>
</div>

 <div id="panel-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none; margin-top:60px; ">
   <div class="modal-dialog" style="box-shadow: 5px 5px 10px #000000;">
      <div class="modal-content p-0 b-0">
            <div class="panel panel-color panel-primary">
                  <div class="panel-heading"> 
                       <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button> 
                        <h3 class="panel-title">Login </h3> 
                        </div> 
                         <div class="panel-body"> 
                        <%--<center> <img src="assets/images/users/userlogon.jpg" Width="70" alt="testimoni"  /></center>	--%>
                           <div class="form-horizontal m-t-20" style="padding:0 80px;">
        <div class="form-group col-xs-12">
        <div class="col-xs-12" >
        <label>Enter UserID / EmpID</label>
        <asp:TextBox ID="txt_UserID" runat="server" CssClass="form-control"  required="" placeholder="Username"></asp:TextBox></div></div>

        <div class="form-group col-xs-12"><div class="col-xs-12">
        <label>Enter Password</label>
        <asp:TextBox ID="txt_Password" runat="server" CssClass="form-control"  TextMode="Password" required="" placeholder="Password"></asp:TextBox><asp:HiddenField ID="txtPwdHash"  runat="server" /></div></div>
        <div class="form-group col-xs-12"><div class="col-xs-12">
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
        <div class="form-group col-xs-12"><div class="col-xs-12"><a href="ResetPassword.aspx"><i class="fa fa-lock m-r-5"></i><span>Forgot your password?</a> <br /> </div></div>
        
        <div class="form-group text-center m-t-40">
        <div class="col-xs-12">
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Log In" Width="200px" OnClientClick="return AdminLoginvalidateReg();"
                onclick="btn_AdminLogin_Click" /></div></div>
        <div class="form-group m-t-30">
        </div></div>
                        
                          </div> 
                  </div>
             </div><!-- /.modal-content -->
         </div><!-- /.modal-dialog -->
  </div>
  <!-- /.modal -->

  <div id="panel_model" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none; margin-top:60px; ">
   <div class="modal-dialog" style="box-shadow: 5px 5px 10px #000000; width:65%;">
      <div class="modal-content p-0 b-0">
            <div class="panel panel-colr panel-danger" >
                  <div class="panel-heading"> 
                       <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button> 
                        <h3 class="panel-title" style="color:White;">Today Birthday's <asp:Label ID="lbl_ItemTypesCount" runat="server" CssClass="pull-right">0</asp:Label></h3>
                        </div> 
                         <div class="panel-body"> 
                        <%--<center> <img src="assets/images/users/userlogon.jpg" Width="70" alt="testimoni"  /></center>	--%>
                           <div class="form-horizontal m-t-20">
        <div class="form-group col-xs-12">
        <div class="col-xs-12">    
<asp:Repeater ID="rptr_BDays" runat="server">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<table width="100%" class="table-responsive table-hover" style="table-layout:fixed; font-size:11px; font-family:Tahoma; border-collapse: collapse; margin:0;">
<tbody><tr style="padding:0; margin:0;font-size:1em;">
<td width="5%" align='center'style="vertical-align:middle;"><%#Container.ItemIndex+1 %></td>
<td width="8%" align="center" style="vertical-align:middle;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" ImageUrl='<%#"~/SPhotos/"+Eval("Photo")%>' style="margin:0.5%;"></asp:ImageMap></td>
<td width="22%"><%#Eval("Name")%> <br /> <label style="font-size:10px;"><%#Eval("DeptID")%></label></td>
<td width="15%"><%#Eval("Design")%></td>
<td width="15%"><%#Eval("Email")%> <br /> <%#Eval("Mobile")%></td>
<%--<td width="10%" class="actions" align='center' >
<asp:LinkButton ID="lbtn_Issue" runat="server" CommandName="AddItem" CommandArgument='<%#Eval("STID")%>' OnClientClick="hideModal(); return true;"><i class="fa fa-plus-circle" style="font-size:20px;" aria-hidden="true"></i></asp:LinkButton>
</td>--%>
</tr>
</tbody>
</table>

</ItemTemplate>
</asp:Repeater>
<center><asp:Label ID="lbl_BDayWishes" runat="server" CssClass="lblg" Visible="false" Width="100%"></asp:Label></center>
<center><asp:Label ID="lbl_Nodata" runat="server" CssClass="btn btn-primary" Visible="false" Width="60%"></asp:Label></center>
        </div>
        </div>
        </div>
        </div>
         <div class="panel panel-color panel-success">
          <div class="panel-heading"> 
                       <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button> 
                        <h3 class="panel-title">Birthday's for the Month of <asp:Label ID="lbl_Month" runat="server"></asp:Label> <asp:Label ID="lbl_MonthlyCount" runat="server" CssClass="pull-right">0</asp:Label></h3>
                        </div> 
                         <div class="panel-body"> 
                        <%--<center> <img src="assets/images/users/userlogon.jpg" Width="70" alt="testimoni"  /></center>	--%>
                           <div class="form-horizontal m-t-20">
        <div class="form-group col-xs-12">
        <div class="col-xs-12">    
<asp:Repeater ID="rptr_MonthlyBDays" runat="server">
<HeaderTemplate>
</HeaderTemplate>
<ItemTemplate>
<table width="100%" class="table-responsive table-hover" style="table-layout:fixed; font-size:11px; font-family:Tahoma; border-collapse: collapse; margin:0;">
<tbody><tr style="padding:0; margin:0;font-size:1em;">
<td width="5%" align='center'style="vertical-align:middle;"><%#Container.ItemIndex+1 %></td>
<td width="8%" align="center" style="vertical-align:middle;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" ImageUrl='<%#"~/SPhotos/"+Eval("Photo")%>' style="margin:0.5%;"></asp:ImageMap></td>
<td width="22%"><%#Eval("Name")%> <br /> <label style="font-size:10px;"><%#Eval("DeptID")%></label></td>
<td width="15%"><%# DataBinder.Eval(Container.DataItem, "DOB", "{0:dd/MM/yyyy}") %></td>
<td width="15%"><%#Eval("Design")%></td>
<td width="15%"><%#Eval("Email")%> <br /> <%#Eval("Mobile")%></td>
<%--<td width="10%" class="actions" align='center' >
<asp:LinkButton ID="lbtn_Issue" runat="server" CommandName="AddItem" CommandArgument='<%#Eval("STID")%>' OnClientClick="hideModal(); return true;"><i class="fa fa-plus-circle" style="font-size:20px;" aria-hidden="true"></i></asp:LinkButton>
</td>--%>
</tr>
</tbody>
</table>

</ItemTemplate>
</asp:Repeater>
 <br /> 
<center><asp:Label ID="lbl_MonthlyNoData" runat="server" CssClass="btn btn-danger" Visible="false" Width="60%"></asp:Label></center>
        </div>
        </div>
        </div>
        </div>
        </div>
        </div>
        </div>
  
</div>
</div>


</asp:Content>

