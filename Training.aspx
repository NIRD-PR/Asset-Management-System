<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Website.master" AutoEventWireup="true" CodeFile="Training.aspx.cs" Inherits="Training" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<section class="wrapper">
        <section class="page_head">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="page_title">
                            <h2>Training Schedules</h2>
                        </div>
                        <nav id="breadcrumbs">
                            <ul>
                                <li><a href="Default.aspx">Home</a>/</li>
                                <li>Training Schedules</li>
                            </ul> 
                        </nav>
                    </div>
                </div>
            </div>
        </section>
<section class="content faq">
			<div class="container">
				<div class="row">
<div class="col-md-7">
 
           <ul class="nav nav-tabs navtab-bg" > 
            <li class="active"> 
              <a href="#rollout" data-toggle="tab" aria-expanded="false"> 
                   <span class="visible-xs"><i class="fa fa-sign-in"></i></span> 
                         <span class="hidden-xs" >Roll Out Training Sessions</span> 
              </a> 
             </li> 
            </ul>
    <div class="tab-content" style="padding:0 20px;"> 
            <div class="tab-pane active" id="rollout" style="min-height:300px; height:340px; overflow-y:auto; overflow-x:hidden; margin-bottom:0; padding-bottom:0;">
             <br /> 
                <div>Leave Management, Tour Management and Bio-Metric Attendance Modules of ERP will live from <b>20/11/2018</b>.</div>
                <b>Venue:</b> II Floor, Computer Lab, CICT, Ambedkar Block.<br />
                <b>Time:</b> Morning Session : 11:00 am to 12:30pm;  Evening Session : 03:00pm to 04:30pm <br />
                <br />
                <table width="100%" class="tabs table-bordered" style="table-layout:fixed;">
                    <tr><th width="10%">Date</th><th width="25%">Employee Type</th><th width="25%">Morning Session</th><th width="25%">Evening Session</th></tr>
                    <tr><td>12/Nov/2018 (Monday)</td><td>Regular Staff</td><td> Group A & B</td><td> Group C & C(RC)</td></tr>
                    <tr class="alt"><td>13/Nov/2018 (Tuesday)</td><td>Project Staff</td><td> DDU-GKY,CGARD, NRLM,CRTCN, CRI,CFL, CFIE,CC&DM </td><td> CHRD,CGSD, CAS,CPME, CWE,CIAT, CSR,CPR, CGG,CDP, CSA & Others</td></tr>
                    
                </table>
            </div>
        </div>
</div>
<div class="col-md-5">
<ul class="nav nav-tabs navtab-bg" > 
            <li class="active"> 
              <a href="#weekly" data-toggle="tab" aria-expanded="false"> 
                   <span class="visible-xs"><i class="fa fa-sign-in"></i></span> 
                         <span class="hidden-xs" >Weekly Training Sessions</span> 
              </a> 
             </li> 
            </ul>
    <div class="tab-content" style="padding:0 20px;"> 
            <div class="tab-pane active" id="weekly" style="min-height: 300px; height:340px; overflow-y:auto; overflow-x:hidden; margin-bottom:0; padding-bottom:0;">
             <br /> 
                <div>Daily basis Training cum Hands on Sessions for Clarifying doubts in various CICT Applications are from <b>19/11/2018</b>.</div>
                <b>Venue:</b> II Floor, Computer Lab, CICT, Ambedkar Block.<br />
                <b>Time:</b>Evening Session : 04:00pm to 05:00pm <br />
                <br />
                <table width="100%" class="tabs table-bordered">
                    <tr><th>Day</th><th>Name of Application</th></tr>
                    <tr><td class="alt">Monday</td><td>e-Office & Tranining Management Portal</td></tr>
                    <tr><td>Tuesday</td><td>Smart Meeting System (SMS) & Rural Connect (RC)</td></tr>
                    <tr><td>Wednesday</td><td>Smart Research Monitoring System</td></tr>
                    <tr><td>Thursday</td><td>NIRDPR - ERP</td></tr>
                    <tr><td>Friday</td><td> LMS & DMS</td></tr>
                   
                </table>
            </div>
        </div>
</div>
</div>
</div>
    <br /><br /><br />
</section>
</asp:Content>

