<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="CITEmp_Inventory.aspx.cs" Inherits="Inventory_CITInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write('<html><head><title>NIRDPR-Stores</title>');
        printWindow.document.write('</head><body >');
        printWindow.document.write(panel.innerHTML);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        setTimeout(function () {
            printWindow.print();
        }, 500);
        return false;
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
<div class="col-xs-12"><asp:HiddenField ID="hdn_EmpID" runat="server" />
<div class="panel panel-color panel-success" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">IT Infrastructure assigned to you &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton>  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body" style="width:100%; font-size:12px; table-layout:fixed;">
<div class="row">
<div class="col-xs-2"><asp:HiddenField ID="HiddenField1" runat="server" />
<label>Select Emp Type <asp:Label ID="lbl_EmpType" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_EmpType" runat="server" CssClass="form-control" ></asp:DropDownList><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField2" runat="server" />
<label>Select EmpName <asp:Label ID="lbl_EmpName" runat="server" CssClass="lblr"></asp:Label></label>
<asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" AutoPostBack="true" 
        ontextchanged="txt_Name_TextChanged"></asp:TextBox><asp:DropDownList ID="ddl_EmpName" runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_EmpName_SelectedIndexChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-7">
<table width="100%" style="table-layout:fixed;width:100%;">
<tr>
<td width="10%"><label>EmpID : </label><br /><asp:Label ID="lbl_EmpID" runat="server" CssClass="lblg"></asp:Label></td>
<td width="40%"><label>Name : </label><br /><asp:Label ID="Label2" runat="server" CssClass="lblg"></asp:Label><asp:HiddenField ID="hdn_Email" runat="server" /><asp:HiddenField ID="hdn_Mobile" runat="server" /></td>
<td width="35%"><label>Design : </label><br /><asp:Label ID="lbl_Design" runat="server" CssClass="lblg"></asp:Label><asp:HiddenField ID="hdn_DID" runat="server" /></td>
<td width="15%"><label>Dept : </label><br /><asp:Label ID="lbl_Dept" runat="server" CssClass="lblg"></asp:Label></td>

</tr>
</table>
</div>
</div>
<asp:Panel ID="pnl_print" runat="server">
<table width="100%" style="font-family:Tahoma;">
<tr><td colspan="5" align="center"><img src="../assets/images/title.png" height="80" width="400"  alt=""/></td></tr>
<tr><td colspan="5" align="center"><h5>CICT Stock available with <asp:Label ID="lbl_Name" runat="server"></asp:Label></h5></td></tr>
</table>
<asp:DataList ID="dl_EmpDetails" runat="server" Width="100%">
<ItemTemplate>
<center>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tr style="font-weight:bold; font-size:0.8em; color:#257A08; vertical-align:middle; text-align:center;">
<td rowspan="2" width="10%" align="center" style="background:#A591FA;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" ImageUrl='<%#"../SPhotos/"+Eval("Photo")%>' Width="60" Height="65"></asp:ImageMap>  </td>
<td width="5%">EmpID</td>
<td width="25%">Name / Design [Dept]</td>
<td width="25%">Contact Details</td>
<td width="25%">EType[ECat] / Sex[Age]-[PF]</td>
<td width="20%">DOJ / DOR</td>
</tr>
<tr><td width="5%" align="center" style="vertical-align:middle; font-weight:bold;"><%#Eval("EmpID")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Name")%> <br /><label class="lblr"><%#Eval("Design")%></label> [<label class="lblr"><%#Eval("DeptID")%></label>]</td>
<td width="25%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Email")%><br /><%#Eval("Mobile")%></td>
<td width="25%"><%#Eval("EmpType")%> [<%#Eval("EmpCategory")%>]<br /><%#Eval("Gender")%>[<asp:Label ID="lbl_Age" runat="server" CssClass="lblr"></asp:Label>] - [<asp:Label ID="Label1" runat="server" CssClass="label-info"><%#Eval("PFAccType")%></asp:Label>]</td>
<td width="20%" style="vertical-align:middle; text-align:center;"><%# DataBinder.Eval(Container.DataItem, "DOJ", "{0:dd/MM/yyyy}") %> <br /> <asp:Label ID="lbl_DOR" runat="server" CssClass="lblr"></asp:Label></td>
</table>
</center>
</ItemTemplate>
</asp:DataList>
<br />
<asp:Repeater ID="rptr_Items" runat="server">
<ItemTemplate>
<table width="100%" style="font-family:Tahoma;">
<tr><td colspan="5"><b><%#Container.ItemIndex+1 %>. <%#Eval("ItemName")%></b> :</td></tr>
<tr><td colspan="5">
<asp:DataList ID="dl_CITData" runat="server" Width="100%">
<HeaderTemplate>

</HeaderTemplate>
<ItemTemplate>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tr style="font-weight:bold; font-size:0.8em; color:#257A08; vertical-align:middle; text-align:center;">
<td width="20%">Manufacturer</td>
<td width="15%">Model</td>
<td width="15%">SerialNo</td>
<td width="25%">Warranty</td>
<td width="25%">Office No.</td>
</tr>
<tr><td width="20%" align="center" style="vertical-align:middle;text-align:center; "><%#Eval("Manufacturer")%></td>
<td width="15%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Model")%></td>
<td width="15%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("SerialNo")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("Warranty")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em; text-align:center;"><%#Eval("ComputerNumber")%></td>
</table>
 </ItemTemplate>
</asp:DataList>
</td></tr>
<tr><td colspan="5"><br /></td></tr>
</table>
</ItemTemplate>
</asp:Repeater>
<br /><br />

<table width="100%">
<tr><td colspan="3">All the above information is true and verified, all the components are with me.</td></tr>
<tr><td colspan="3"><br />
<br />
<br />
</td></tr>
<tr><td width="30%" align="center"><b>Signature of the Employee</b></td><td width="40%"></td><td width="30%" align="center"><b>Signature of the HOC</b></td></tr>
<tr><td width="30%" align="left"><b>Name:</b></td><td width="40%"></td><td width="30%" align="left"><b>Name: </b></td></tr>
</table>
 </asp:Panel>
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

