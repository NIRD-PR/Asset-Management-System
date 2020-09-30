<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="ItemHistoryReport.aspx.cs" Inherits="CICTInventory_ItemHistoryReport" %>

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
    <script type="text/javascript">
        function ChosenDropDown() {
            $("#<%=ddl_ItemType.ClientID%>").select2(); 
            $("#<%=ddl_SerialNo.ClientID%>").select2();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">CIT Inventory Item-Wise Report</h3></div>
<div class="panel-body">
<div class="row">
<div class="col-xs-2"><asp:HiddenField ID="hdn_MIID" runat="server" />
<label>Item Category <asp:Label ID="lbl_ItemType" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_ItemType" runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_ItemType_SelectedIndexChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="hdn_SNO" runat="server" />
<label>Select Serial No. <asp:Label ID="lbl_SNO" runat="server" CssClass="lblr"  onkeyup="ToUpper(this)"></asp:Label></label>
<%--<asp:TextBox ID="txt_SNo" runat="server" CssClass="form-control" AutoPostBack="true" 
        ontextchanged="txt_SNo_TextChanged"></asp:TextBox>--%>
    <asp:DropDownList ID="ddl_SerialNo" runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_SerialNo_SelectedIndexChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-7">
<table width="100%" style="table-layout:fixed;width:100%;">
<tr>
<td width="20%"><label>Make : </label><br /><asp:Label ID="lbl_Manufacturer" runat="server" CssClass="lblg"></asp:Label></td>
<td width="20%"><label>Model : </label><br /><asp:Label ID="lbl_Model" runat="server" CssClass="lblg"></asp:Label></td>
<td width="20%"><label>SerialNo : </label><br /><asp:Label ID="lbl_SerialNo" runat="server" CssClass="lblg"></asp:Label></td>
<td width="20%"><label>Warranty : </label><br /><asp:Label ID="lbl_Warranty" runat="server" CssClass="lblg"></asp:Label></td>
<td width="20%"><label>Item No : </label><br /><asp:Label ID="lbl_ItemNo" runat="server" CssClass="lblg"></asp:Label></td>
</tr>
</table>
</div>
</div>
<div class="row" style="margin: 60px 0 40px 0">
    <center> <img src="../assets/images/title.png" height="80" width="400"  alt=""/>
<h5> NIRDPR - Item-History CICT Inventory  Details </h5>
</center>
<asp:Repeater ID="rptr_Inventory" runat="server">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; border:0px solid #000; margin:0;">
<thead><tr>
<td width="5%" align='center'>SNo</td>
<td width="10%" align='center'>DeptID</td>
<td width="10%" align='center'>EmpID</td>
<td width="15%" align='center'>Name & Design</td>
<td  width="10%" align='center'>Dept ID</td>
<td width="10%" align='center'>Date</td>
<td width="10%" align='center'>Returned On</td>
</tr>
</thead>
</HeaderTemplate>
<ItemTemplate>
<tbody><tr>
<td width="5%" align='center'><%#Container.ItemIndex+1%></td>
<td width="10%" align="center"><%#Eval("DeptID")%></td>
<td  width="10%" align="center"><%#Eval("EmpID")%></td>
<td  width="15%" align="left"><%#Eval("Name")%> <br /> <%#Eval("Design")%></td>
<td  width="10%" align="center"><%#Eval("DeptID")%></td>
<td  width="10%" align="center"><%#Eval("Dated")%></td>
<td  width="10%" align="center"><%#Eval("Returned")%></td>
</tr>
</tbody>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div></ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

