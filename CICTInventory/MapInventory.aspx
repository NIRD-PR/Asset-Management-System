<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="MapInventory.aspx.cs" Inherits="CICTInventory_MapInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">
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
            $("#<%=ddl_EmpType.ClientID%>").select2(); 
            $("#<%=ddl_EmpName.ClientID%>").select2();
            $("#<%=ddl_ItemType.ClientID%>").select2(); 
            $("#<%=ddl_SerialNo.ClientID%>").select2();
            $("#<%=ddl_ItemTypes.ClientID%>").select2();
        }
        function dt() {
            var n = 'CICT-Idle Inventory Stock';
            $('#tb').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'pageLength', 'print',
                    {
                        extend: 'excel',
                        filename: n,
                        title: n
                    },
                    {
                        extend: 'pdf',
                        filename: n,
                        title: n
                    }
                ]
            });
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
<div class="panel-heading"><h3 class="panel-title">CIT Inventory Mapping</h3></div>
<div class="panel-body">
<div class="row" style="margin: 10px 0 20px 0">
    <a class="font-weight-bold text-danger" href='<%=ResolveUrl("../CIT_ExcelMAPInv/{0}") %>'>Want to Map using Excel? Click here</a>
</div>
<div class="row">
<div class="col-xs-2"><asp:HiddenField ID="HiddenField1" runat="server" />
<label>Select Emp Type <asp:Label ID="lbl_EmpType" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_EmpType" runat="server" CssClass="form-control" AutoPostBack="true" onselectedindexchanged="txt_Name_TextChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField2" runat="server" />
<label>Select EmpName <asp:Label ID="lbl_EmpName" runat="server" CssClass="lblr"></asp:Label></label>
<%--<asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" AutoPostBack="true" 
        ontextchanged="txt_Name_TextChanged"></asp:TextBox>--%>
<asp:DropDownList ID="ddl_EmpName" runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_EmpName_SelectedIndexChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-7">
<table width="100%" style="table-layout:fixed;width:100%;">
<tr>
<td width="10%"><label>EmpID : </label><br /><asp:Label ID="lbl_EmpID" runat="server" CssClass="lblg"></asp:Label></td>
<td width="40%"><label>Name : </label><br /><asp:Label ID="lbl_Name" runat="server" CssClass="lblg"></asp:Label><asp:HiddenField ID="hdn_Email" runat="server" /><asp:HiddenField ID="hdn_Mobile" runat="server" /></td>
<td width="35%"><label>Design : </label><br /><asp:Label ID="lbl_Design" runat="server" CssClass="lblg"></asp:Label><asp:HiddenField ID="hdn_DID" runat="server" /></td>
<td width="15%"><label>Dept : </label><br /><asp:Label ID="lbl_Dept" runat="server" CssClass="lblg"></asp:Label></td>

</tr>
</table>
</div>
</div>
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

<div class="row">
<div class="col-xs-12" align="center"><asp:Button ID="btn_Submit" runat="server" 
        CssClass="btn btn-success" Text="Allot Asset" onclick="btn_Submit_Click" /></div>
</div>
</div>
<%--<div class="panel panel-color panel-info" style="margin-bottom:300px">
<div class="panel-heading" class="pull-left"><h3 class="panel-title">Emp Wise Mapped IT Inventory <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body">
<div class="col-xs-12">
<table width="100%" class="table-responsive" style="table-layout:fixed; margin:0;">
<tr><td width="40%" align="right">Select Type :</td><td width="60%">
    <asp:DropDownList ID="ddl_ItemTypes" runat="server" CssClass="form-control" Width="250px" AutoPostBack="true" EnableViewState="true"
        onselectedindexchanged="ddl_ItemTypes_SelectedIndexChanged"></asp:DropDownList></td></tr>
</table>
<asp:Repeater ID="rptr_InventoryData" runat="server" onitemcommand="rptr_InventoryData_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr>
<th width="5%">SNO</th>
<th width="6%">EmpID</th>
<th width="16%">Name</th>
<th width="10%">Design</th>
<th width="10%">DeptID</th>
<th width="10%">Make</th>
<th width="10%">Model</th>
<th width="14%">Serial No</th>
<th width="10%">Warranty</th>
<th width="9%" colspan="3">Edit/Del/Release</th>

</tr>
</thead>
</table>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-bordered table-hover" width="100%" style="font-size:0.8em; margin-bottom:1px;">
<tbody><tr>
<td width="5%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="6%" align="center"><%#Eval("EmpID")%></td>
<td width="16%"><%#Eval("Name")%></td>
<td width="10%"><%#Eval("Design")%></td>
<td width="10%"  align="center"><%#Eval("DeptID")%></td>
<td width="10%"  align="center"><%#Eval("Manufacturer")%></td>
<td width="10%"  align="center"><%#Eval("Model")%></td>
<td width="14%"  align="center"><%#Eval("SerialNo")%></td>
<td width="10%"  align="center"><%#Eval("Warranty")%></td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%#Eval("MIID")%>' ToolTip="Edit"><i class="fa fa-pencil" style="font-size:large; color:Black;"></i></asp:LinkButton>
</td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("MIID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');" ToolTip="Delete"><i class="fa fa-trash" style="font-size:large; color:Red;"></i></asp:LinkButton>
</td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton2" runat="server" CommandName="Release" CommandArgument='<%#Eval("MIID")%>' OnClientClick= "return confirm('Are you Sure To Release?');" ToolTip="Delete"><i class="fa fa-unlock" style="font-size:large; color:Green;"></i></asp:LinkButton>
</td>
</tr>
</tbody>
</table>
</ItemTemplate>
<AlternatingItemTemplate>
<table class="table table-bordered table-hover" width="100%" style="font-size:0.8em; margin-bottom:0.5px;">
<tbody><tr style="background:#F0F4FF;">
<td width="5%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="6%" align="center"><%#Eval("EmpID")%></td>
<td width="16%"><%#Eval("Name")%></td>
<td width="10%"><%#Eval("Design")%></td>
<td width="10%"  align="center"><%#Eval("DeptID")%></td>
<td width="10%"  align="center"><%#Eval("Manufacturer")%></td>
<td width="10%"  align="center"><%#Eval("Model")%></td>
<td width="14%"  align="center"><%#Eval("SerialNo")%></td>
<td width="10%"  align="center"><%#Eval("Warranty")%></td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%#Eval("MIID")%>' ToolTip="Edit"><i class="fa fa-pencil" style="font-size:large; color:Black;"></i></asp:LinkButton>
</td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("MIID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');" ToolTip="Delete"><i class="fa fa-trash" style="font-size:large; color:Red;"></i></asp:LinkButton>
</td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton2" runat="server" CommandName="Release" CommandArgument='<%#Eval("MIID")%>' OnClientClick= "return confirm('Are you Sure To Release?');" ToolTip="Delete"><i class="fa fa-unlock" style="font-size:large; color:Green;"></i></asp:LinkButton>
</td>
</tr>
</tbody>
</table>
</AlternatingItemTemplate>
</asp:Repeater>
</div>
</div>
</div>--%>
<div class="panel panel-color panel-info" style="margin-bottom:200px">
<div class="panel-heading" class="pull-left"><h3 class="panel-title">List of Available Items &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton>  &nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body">
<div class="col-xs-12">
<table width="100%" class="table-responsive" style="table-layout:fixed;">
<tr><td width="40%" align="right">Select Type :</td><td width="60%">
    <asp:DropDownList ID="ddl_ItemTypes" runat="server" CssClass="form-control" Width="250px" AutoPostBack="true" EnableViewState="true"
        onselectedindexchanged="ddl_ItemTypes_SelectedIndexChanged"></asp:DropDownList></td></tr>
</table>
<asp:Panel ID="pnl_print" runat="server">
<center><img src="../assets/images/title.png" height="80" width="400"  alt=""/>
<p style="font-size:14px; margin-top:-3px;">CICT Inventory Stock of <asp:Label ID="lbl_ItemName" runat="server"></asp:Label>  as on <asp:Label ID="lbl_Date" runat="server"></asp:Label></p>
</center>
<asp:Repeater ID="rptr_InventoryData" runat="server" OnItemCommand="rptr_InventoryData_ItemCommand">
<HeaderTemplate>
<table id="tb" width="100%" border="1" class="table" style="table-layout:fixed; font-size:12px; line-height:30px; font-family:Tahoma; vertical-align:middle; border-collapse: collapse; margin:0;">
<thead><tr>
<th width="10%">SNO</th>
<th width="10%">Item Type</th>
<th width="10%">Item Name</th>
<th width="10%">Manufacture</th>
<th width="15%">Model</th>
<th width="15%">Serial No</th>
<th width="10%">Item No</th>
<th width="10%">Status</th>
<th width="10%">Warranty</th>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr  align='center'>
<td width="10%"><%#Container.ItemIndex+1 %></td>
<td width="10%"><%#Eval("ItemType")%></td>
<td width="10%"><%#Eval("ItemName")%></td>
<td width="10%"><%#Eval("Manufacturer")%></td>
<td width="15%"><%#Eval("Model")%></td>
<td width="15%"><asp:LinkButton ID="sn" runat="server" CommandName="select" CommandArgument='<%#Eval("ITID")+","+Eval("IID")%>'><%#Eval("SerialNo")%></asp:LinkButton></td>
<td width="10%"><%#Eval("ComputerNumber")%></td>
<td width="10%"><%#Eval("Status")%></td>
<td width="10%"><%#Eval("Warranty")%></td>
</tr>
</ItemTemplate>
<AlternatingItemTemplate>
<tr style="background:#F0F4FF; "  align='center'>
<td width="10%"><%#Container.ItemIndex+1 %></td>
<td width="10%"><%#Eval("ItemType")%></td>
<td width="10%"><%#Eval("ItemName")%></td>
<td width="10%"><%#Eval("Manufacturer")%></td>
<td width="15%"><%#Eval("Model")%></td>
<td width="15%"><asp:LinkButton ID="sn" runat="server" CommandName="select" CommandArgument='<%#Eval("ITID")+","+Eval("IID")%>'><%#Eval("SerialNo")%></asp:LinkButton></td>
<td width="10%"><%#Eval("ComputerNumber")%></td>
<td width="10%"><%#Eval("Status")%></td>
<td width="10%"><%#Eval("Warranty")%></td>
</tr>

</AlternatingItemTemplate>
    <FooterTemplate>
       </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
</asp:Panel>
</div>
</div>
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

