<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Website.master" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
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
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">


    <!--start wrapper-->
    <section class="wrapper" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
        <!--Start Slider-->
        <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
                <div class="slider-wrapper">
                    <div class="slider">
                        <div class="fs_loader"></div>
                        <div class="slide">
                            <img src="websiteassets/images/fraction-slider/base.jpg" width="1920" height="auto" data-in="fade" data-out="fade" />

                            <%-- <img src="websiteassets/images/fraction-slider/slider-boy.png" width="600" height="600" data-position="30,1100" data-in="left" data-out="right" data-delay="700"/>--%>

                            <p class="slide-1" data-position="50,610" data-in="fade" data-out="fade" data-delay="800">NIRDPR - ERP</p>
                            <%--<p class="slide-1" data-position="100,560" data-in="fade" data-out="fade" data-delay="1200">Our latest designs </p>
                    <p class="slide-1" data-position="150,500" data-in="fade" data-out="fade" data-delay="1600">Simply & Clear Design</p>

                    <p class="slide-1a" data-position="220,770" data-in="bottom" data-out="bottom" data-delay="2000" data-ease-in="easeOutBounce">SEO Friendly Website</p>
                    <p class="slide-1a" data-position="267,698" data-in="bottom" data-out="bottom" data-delay="3200"  data-ease-in="easeOutBounce">7 combination color option</p>
                    <p class="slide-1a" data-position="314,760" data-in="bottom" data-out="bottom" data-delay="4200"  data-ease-in="easeOutBounce">Animated layer slider</p>
                    <p class="slide-1a" data-position="361,753" data-in="bottom" data-out="bottom" data-delay="5200"  data-ease-in="easeOutBounce">Much More Featured...</p>--%>
                        </div>

                        <div class="slide">
                            <img src="websiteassets/images/fraction-slider/base_2.jpg" width="1920" height="auto" data-in="fade" data-out="fade" />

                            <%--<img src="websiteassets/images/fraction-slider/slider-girl.png" width="600" height="545" data-position="20,400" data-in="right" data-0ut="bottom" data-delay="500"/>

                    <p class="slide-2 " data-position="120,900" data-in="bottom" data-out="top" data-delay="2000">Your-Business</p>
                    <p class="slide-2a " data-position="210,900" data-in="left" data-out="right" data-delay="3000">A responsive multipurpose Theme</p>
                    <p class="slide-2b " data-position="270,900" data-in="top" data-out="bottom" data-delay="4000" data-ease-in="easeOutBounce">For Your Prestigious World !</p>--%>
                        </div>

                        <div class="slide">
                            <img src="websiteassets/images/fraction-slider/base_3.jpg" width="1920" height="auto" data-in="fade" data-out="fade" />

                            <%-- <p class="slide-heading" data-position="130,370" data-in="top" data-out="top" data-ease-in="easeOutBounce" data-delay="1500">Electrify theme</p>

                    <p class="sub-line" data-position="230,370" data-in="right" data-out="left" data-delay="2500">grid system and responsive design</p>

                    <img src="websiteassets/images/fraction-slider/gadgets/laptop.png" width="456" height="272" data-position="115,1180" data-in="bottom" data-out="bottom" data-delay="400">

                    <img src="websiteassets/images/fraction-slider/gadgets/mack.png" width="357" height="313" data-position="90,1040" data-in="top" data-out="bottom" data-delay="200">

                    <img src="websiteassets/images/fraction-slider/gadgets/ipad.png" width="120" height="170" data-position="230,1030" data-in="left" data-out="left" data-delay="300">

                    <img src="websiteassets/images/fraction-slider/gadgets/smartphone.png" width="70" height="140" data-position="270,1320" data-in="right" data-out="right" data-delay="300">

                    <a href="#"	class="btn btn-lg btn-default" data-position="320,370" data-in="bottom"  data-out="bottom" data-delay="3700" data-ease-in="easeOutBounce">Free Download</a>--%>
                        </div>

                    </div>
                </div>       

           
       
        <!--End Slider-->
        <div class="container" id="my_modelPopUp" runat="server">
            <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog"  style="box-shadow: 5px 5px 10px #000000; width:55%;">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <i class="fa fa-times-circle" style="font-size:30px;color:red"></i></button>
                    <h4 class="modal-title">fdfds
                    </h4>
                </div>
                <div class="modal-body" style="height:auto; text-align:center; vertical-align:middle;">
                <asp:ImageMap ID="img_popup" runat="server" class="img-responsive"></asp:ImageMap>
            </div>
                </div>
                <%--<div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>--%>
            </div>
        </div>
    </div>
                 </ContentTemplate>
        </asp:UpdatePanel>
    <!-- Modal Popup -->
    <script type="text/javascript">
        function ShowPopup(title) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html();
            $("#MyPopup").modal("show"); 
           // setTimeout(function() { $('#MyPopup').fadeOut('slow');}, 4000);
        }
    </script>
            <section class="feature_bottom">
                <div class="container">
                    <div class="row sub_content">
                        <div class="col-md-3">
                            <div class="row">
                                <ul class="nav nav-tabs navtab-bg">
                                    <li class="active">
                                        <a href="#login" data-toggle="tab" aria-expanded="false">
                                            <span class="visible-xs"><i class="fa fa-sign-in"></i></span>
                                            <span class="hidden-xs">Login</span>
                                        </a>
                                    </li>
                                </ul>
                                <div class="tab-content" style="padding: 0 20px; background: #E4EDFA;">
                                    <div class="tab-pane active" id="login" style="min-height: 440px; height: 440px; overflow-y: auto; overflow-x: hidden; margin-bottom: 0; padding-bottom: 0;">
                                        <br />
                                        <label>Enter Login ID / EmpID <span class="lblr">*</span></label>
                                        <asp:TextBox ID="txt_UserID" runat="server" CssClass="form-control" AutoCompleteType="Disabled" placeholder="Login ID/ EmpID"></asp:TextBox>
                                        <br />
                                        <label>Enter Password <span class="lblr">*</span></label>
                                        <asp:TextBox ID="txt_Password" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled" placeholder="Password"></asp:TextBox><asp:HiddenField ID="txtPwdHash" runat="server" />

                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="col-sm-8" style="float:left;">
                                                    <%--<cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                                        CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                                        FontColor="#D20B0C" NoiseColor="#B1B1B1" />--%>
                                                    <asp:Image ID="imgCaptcha" runat="server" Height="35" Width="150" />
                                                </div>
                                                <div class="col-sm-4" style="float: right;">

                                                    <span class="text-right">
                                                        <asp:ImageButton ID="ImageButton2" ImageUrl="assets/images/refresh.png" runat="server" CausesValidation="false" Width="25" OnClick="ImageButton2_Click" /></span>
                                                </div>
                                                <div class="col-xs-12">
                                                    <%--<asp:CustomValidator ID="CustomValidator1" ErrorMessage="Invalid Captcha" OnServerValidate="ValidateCaptcha"
                                                        runat="server" />--%>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                        <br />
                                        <label>Enter Captcha <span class="lblr">*</span></label>
                                        <asp:TextBox ID="txt_Captcha" runat="server" CssClass="form-control" autocomplete="off" placeholder="Captcha"></asp:TextBox>
                                        <br />
                                        <a href="ResetPassword.aspx"><i class="fa fa-lock m-r-5"></i>Forgot password?</a>
                                        <br />
                                        <br />
                                        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Log In" Width="200px" OnClientClick="return AdminLoginvalidateReg();"
                                            OnClick="btn_AdminLogin_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <ul class="nav nav-tabs navtab-bg">
                                    <li class="active">
                                        <a href="#circulars" data-toggle="tab" aria-expanded="false">
                                            <span class="visible-xs"><i class="fa fa-home"></i></span>
                                            <span class="hidden-xs">e-Circulars &nbsp; &nbsp; [
                                                <asp:Label ID="lbl_Count" runat="server" CssClass="lblr">0</asp:Label>
                                                ]</span>
                                        </a>
                                    </li>
                                    <li class="">
                                        <a href="#oo" data-toggle="tab" aria-expanded="true">
                                            <span class="visible-xs"><i class="fa fa-user"></i></span>
                                            <span class="hidden-xs">Office Orders &nbsp; &nbsp; [
                                                <asp:Label ID="lbl_oocount" runat="server" CssClass="lblr">0</asp:Label>
                                                ]</span>
                                        </a>
                                    </li>
                                    <li class="">
                                        <a href="#notifications" data-toggle="tab" aria-expanded="false">
                                            <span class="visible-xs"><i class="fa fa-envelope-o"></i></span>
                                            <span class="hidden-xs">Notifications &nbsp; &nbsp; [
                                                <asp:Label ID="lbl_noticount" runat="server" CssClass="lblr">0</asp:Label>
                                                ]</span>
                                        </a>
                                    </li>

                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="circulars" style="height: 400px; overflow-y: auto; overflow-x: hidden; margin-bottom: 0; padding-bottom: 0;">
                                        <div class="col-md-12">

                                            <asp:Repeater ID="rptr_Data" runat="server" OnItemCommand="rptr_Data_ItemCommand">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table class="table table-hover" width="100%" id="datatable-editable" style="font-size: 0.9em; margin-bottom: 1px; border-bottom: 1px solid #D9DCD9;">
                                                        <tbody>
                                                            <tr class="gradeX">
                                                                <td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
                                                                <td width="90%" align='justify'>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <table class="table table-hover" width="100%" id="datatable-editable" style="font-size: 0.9em; margin-bottom: 1px; border-bottom: 1px solid #D9DCD9;">
                                                        <tbody>
                                                            <tr>
                                                                <td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
                                                                <td width="90%" align='justify'>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </AlternatingItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="oo" style="height: 400px; overflow-y: auto; overflow-x: hidden; margin-bottom: 0; padding-bottom: 0;">
                                        <div class="col-md-12">
                                            <asp:Repeater ID="rptr_OO" runat="server" OnItemCommand="rptr_OO_ItemCommand">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table class="table table-hover" width="100%" id="datatable-editable" style="font-size: 0.9em; margin-bottom: 1px; border-bottom: 1px solid #D9DCD9;">
                                                        <tbody>
                                                            <tr class="gradeX">
                                                                <td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
                                                                <td width="90%" align='justify'>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <table class="table table-hover" width="100%" id="datatable-editable" style="font-size: 0.9em; margin-bottom: 1px; border-bottom: 1px solid #D9DCD9;">
                                                        <tbody>
                                                            <tr>
                                                                <td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
                                                                <td width="90%" align='justify'>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </AlternatingItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </div>

                                    <div class="tab-pane" id="notifications" style="height: 400px; overflow-y: auto; overflow-x: hidden; margin-bottom: 0; padding-bottom: 0;">

                                        <div class="col-md-12">
                                            <asp:Repeater ID="rptr_noti" runat="server" OnItemCommand="rptr_noti_ItemCommand">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table class="table table-hover" width="100%" id="datatable-editable" style="font-size: 0.9em; margin-bottom: 1px; border-bottom: 1px solid #D9DCD9;">
                                                        <tbody>
                                                            <tr class="gradeX">
                                                                <td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
                                                                <td width="90%" align='justify'>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <table class="table table-hover" width="100%" id="datatable-editable" style="font-size: 0.9em; margin-bottom: 1px; border-bottom: 1px solid #D9DCD9;">
                                                        <tbody>
                                                            <tr>
                                                                <td width="10%" align='center'><%# DataBinder.Eval(Container.DataItem, "Dated", "{0:dd/MM/yyyy}") %></td>
                                                                <td width="90%" align='justify'>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="download" CommandArgument='<%#Eval("PCID")%>' Text='<%#Eval("Title")%>' CausesValidation="false"><i class="fa fa-print"></i></asp:LinkButton>
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
                        <div class="col-md-3">
                             <div class="row">
                            <a class="twitter-timeline" data-width="100%" data-height="480" data-chrome="noheader nofooter transparent"
                                data-link-color="#DC143C" href="https://twitter.com/NIRDPR_India?ref_src=twsrc%5Etfw">
                            </a>
                            <script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
                  </div> 
                        </div>
                    </div>
                </div>
            </section>
            <div class="texture-section texture1" style="padding: 0; margin: 0;">
                <div class="container">
                    <div class="col-md-3">
                        <div class="col-md-12">
                            <div class="dividerHeading">
                                <h4><span>Today BDay's</span></h4>
                            </div>
                            <marquee behavior="scroll" direction="left" scrollamount="4" style="width: 100%; vertical-align: middle; cursor: pointer;" onmouseover="javascript:this.setAttribute('scrollamount','0');" onmouseout="javascript:this.setAttribute('scrollamount','4');">
<asp:DataList ID="rptr_BDays" runat="server" RepeatDirection="Horizontal" Width="100%">
<ItemTemplate>
                        <div class="recent-item box">
                            <figure class="touching ">
                                <asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" Height="160px" Width="160px" ImageUrl='<%#"~/SPhotos/"+Eval("Photo")%>' style="margin:0.5%;"></asp:ImageMap>
                                <div class="option inner">
                                     <div>
                                        <label class="label-success"><%#Eval("Name")%></label>
                                       <%-- <a href='~/SPhotos/"+Eval("Photo")%>' class="fa fa-search mfp-image"></a> --%>                                       
                                        <label class="lblr"> <%#Eval("DeptID")%>  <br /> [ <%# DataBinder.Eval(Container.DataItem, "DOB", "{0:dd/MMM}") %> ]</label>
                                    </div>
                                </div>
                            </figure>
                        </div>
    </ItemTemplate>
</asp:DataList></marquee>
                        </div>
                        <label class="btn btn-danger">Happy Birthday to You...NIRD Family</label>
                    </div>
                    <div class="col-md-9">

                        <div class="col-md-12">
                            <div class="dividerHeading">
                                <h4><span>Birth Day's in the Month of
                                    <asp:Label ID="lbl_Month" runat="server"></asp:Label>
                                </span></h4>
                            </div>
                            <marquee behavior="scroll" direction="right" scrollamount="4" style="width: 100%; vertical-align: middle; cursor: pointer;" onmouseover="javascript:this.setAttribute('scrollamount','0');" onmouseout="javascript:this.setAttribute('scrollamount','4');">
<asp:DataList ID="rptr_MonthlyBDays" runat="server" RepeatDirection="Horizontal" Width="100%">
<ItemTemplate>
                        <div class="recent-item box">
                            <figure class="touching ">
                                <asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" Height="160px" Width="160px" ImageUrl='<%#"~/SPhotos/"+Eval("Photo")%>' style="margin:0.5%;"></asp:ImageMap>
                                <div class="option inner">
                                     <div>
                                        <label class="label-success"><%#Eval("Name")%></label>
                                       <%-- <a href='~/SPhotos/"+Eval("Photo")%>' class="fa fa-search mfp-image"></a> --%>                                       
                                        <label class="lblr"> <%#Eval("Design")%> [<%#Eval("DeptID")%>] <br /> [DOB: <%# DataBinder.Eval(Container.DataItem, "DOB", "{0:dd/MMM}") %> ]</label>
                                    </div>
                                </div>
                            </figure>
                        </div>
    </ItemTemplate>
</asp:DataList></marquee>
                        </div>

                        <asp:Label ID="lbl_BDayWishes" runat="server" CssClass="btn btn-success" Visible="false" Width="100%"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
           
            <%-- <section class="texture-section texture1">
            <div class="container">
                <div class="row sub_content">
                    <div class="col-lg-6 col-md-6 col-sm-6 wow slideInLeft" data-wow-duration="1s">
                        <div class="dividerHeading">
                            <h4><span>About Us</span></h4>
                        </div>
                        <p>
                            Cras mattis consectetur purus sit amet fermen. Lorem ipsum dolor sit amet, consec adipiscing elit. Maecenas sed diam eget risus varius bland sit amet non fringilla ullamcorper magna. Nulla eu mi magna. Etiam suscipit commodo ad gravida.
                        </p>
                        <ul class="list_style square">
                            <li><a href="#"> Donec convallis, metus nec tempus aliquet</span></a></li>
                            <li><a href="#"> Aenean commodo ligula eget dolor</span></a></li>
                            <li><a href="#"> Lorem ipsum dolor sit amet cons adipiscing</span></a></li>
                            <li><a href="#"> Nunc aliquet tincidunt metus sit amet</span></a></li>
                            <li><a href="#"> Accumsan vulputate faucibus turpis dictum</span></a></li>
                        </ul>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 wow slideInRight" data-wow-duration="1s">
                        <img src="websiteassets/images/apple-devices-2.png" class="img-responsive" alt=""/>
                    </div>
                </div>
            </div>
        </section>

		<section class="feature_bottom">
			<div class="container">
				<div class="row sub_content">
                    <!-- TESTIMONIALS -->
                    <div class="col-sm-6 wow fadeInDown">
                        <div class="dividerHeading">
                            <h4><span>Electrify Features</span></h4>
                        </div>
                        <div class="widget widget_tab">
                            <ul  class="nav nav-tabs">
                                <li class="active"><a href="#Popular" data-toggle="tab">Popular</span></a></li>
                                <li class=""><a href="#Recent" data-toggle="tab">Recent</span></a></li>
                                <li class="last-tab"><a href="#Recent-Comment" data-toggle="tab"><i class="fa fa-comments-o"></i></span></a></li>
                            </ul>

                            <div  class="tab-content clearfix">
                                <div class="tab-pane fade active in" id="Popular">
                                    <h3>Unique & Clean Design</h3>
                                    <p>Fusce lacinia tempor malesuada. Ut lacus sapien, placerat a ornare nec, elementum sit amet felis. Maecenas pretium lorem hendrerit eros sagittis fermentum. Donec in ut odio libero, at vulputate urna. Nulla tristique mi a massa convallis cursus. Nulla eu mi magna. Etiam suscipit commodo ad gravida.</p>
                                    <ul class="list_style circle">
                                        <li><a href="#">Donec convallis, metus nec tempus aliquet</span></a></li>
                                        <li><a href="#">Aenean commodo ligula eget dolor</span></a></li>
                                        <li><a href="#">Cum sociis natoque penatibus mag dis parturient</span></a></li>
                                    </ul>
                                </div>
                                <div class="tab-pane fade" id="Recent">
                                    <h3>Easy to Customize</h3>
                                    <p>Fusce lacinia tempor malesuada. Ut lacus sapien, placerat a ornare nec, elementum sit amet felis. Maecenas pretium lorem hendrerit eros sagittis fermentum. Donec in ut odio libero, at vulputate urna. Nulla tristique mi a massa convallis cursus. Nulla eu mi magna. Etiam suscipit commodo ad gravida.</p>
                                    <ul class="list_style">
                                        <li><a href="#">Donec convallis, metus nec tempus aliquet</span></a></li>
                                        <li><a href="#">Aenean commodo ligula eget dolor</span></a></li>
                                        <li><a href="#">Cum sociis natoque penatibus mag dis parturient</span></a></li>
                                    </ul>
                                </div>
                                <div class="tab-pane fade" id="Recent-Comment">
                                    <h3>Free Support & Updates</h3>
                                    <p>Fusce lacinia tempor malesuada. Ut lacus sapien, placerat a ornare nec, elementum sit amet felis. Maecenas pretium lorem hendrerit eros sagittis fermentum. Donec in ut odio libero, at vulputate urna. Nulla tristique mi a massa convallis cursus. Nulla eu mi magna. Etiam suscipit commodo ad gravida.</p>
                                    <ul class="list_style square">
                                        <li><a href="#">Donec convallis, metus nec tempus aliquet</span></a></li>
                                        <li><a href="#">Aenean commodo ligula eget dolor</span></a></li>
                                        <li><a href="#">Cum sociis natoque penatibus mag dis parturient</span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div><!-- TESTIMONIALS END -->

					<div class="col-sm-6 wow fadeInUp">
						<div class="dividerHeading">
							<h4><span>Recent Post</span></h4>
						</div>

                        <div class="post-recent">
                            <div class="post-images">
                                <a href="#">
                                    <img src="websiteassets/images/blog/blog_1.jpg" alt=""/>
                                </a>
                            </div>

                            <div class="post-detail">
                                <h5><a href="#">Nalibero Tempore Soluta Nobis</a></h5>
                                <span>
                                    <i class="fa fa-clock-o"></i>
                                    mar,25,2015
                                </span>
                                <span>
                                    <i class="fa fa-user"></i>
                                    <a href="#">2 Comments</a>
                                </span>
                                <p>
                                    Ut enim ad minima veniam numquam eius modi tempora incidunt magnam quis nostrum exercitationem ullam corporis suscipit ut aliquid commodi...
                                    <a class="read-more" href="#">Read more</a>
                                </p>
                            </div>
                        </div>
                        <hr class="dashed">
                        <div class="post-recent">
                            <div class="post-images">
                                <a href="#">
                                    <img src="websiteassets/images/blog/blog_2.jpg" alt=""/>
                                </a>
                            </div>

                            <div class="post-detail">
                                <h5><a href="#">Nalibero Tempore Soluta Nobis</a></h5>
                                <span>
                                    <i class="fa fa-clock-o"></i>
                                    mar,25,2015
                                </span>
                                <span>
                                    <i class="fa fa-user"></i>
                                    <a href="#">4 Comments</a>
                                </span>
                                <p>
                                    Ut enim ad minima veniam numquam eius modi tempora incidunt magnam quis nostrum exercitationem ullam corporis suscipit ut aliquid commodi...
                                    <a class="read-more" href="#">Read more</a>
                                </p>
                            </div>
                        </div>
					</div>
				</div>
			</div>
		</section>
		<section class="clients">
			<div class="container">
				<div class="row sub_content">
					<div class="col-lg-12 col-md-12 col-sm-12">
						<div class="dividerHeading">
							<h4><span>Our Clients</span></h4>
						</div>
						
						<div class="our_clients">
							<ul class="client_items clearfix">
								<li class="col-sm-3 col-md-3 col-lg-3"><a href="services.html"  data-placement="bottom" data-toggle="tooltip" title="Client 1" ><img src="websiteassets/images/clients/1.png" alt="" /></span></a></li>
								<li class="col-sm-3 col-md-3 col-lg-3"><a href="services.html" data-placement="bottom" data-toggle="tooltip" title="Client 2" ><img src="websiteassets/images/clients/2.png" alt="" /></span></a></li>
								<li class="col-sm-3 col-md-3 col-lg-3"><a href="services.html" data-placement="bottom" data-toggle="tooltip" title="Client 3" ><img src="websiteassets/images/clients/3.png" alt="" /></span></a></li>
								<li class="col-sm-3 col-md-3 col-lg-3"><a href="services.html" data-placement="bottom" data-toggle="tooltip" title="Client 4" ><img src="websiteassets/images/clients/4.png" alt="" /></span></a></li>
							</ul><!--/ .client_items-->
						</div>
					</div>
				</div>
			</div>
		</section>--%>
       
    </section>
    <!--end wrapper-->
</asp:Content>

