<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" CodeFile="AddInventory.aspx.cs" Inherits="CICTInventory_AddInventory" %>

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
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnl_print.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>NIRDPR-CICT Inventory</title>');
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
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/css/select2.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script type="text/javascript">
        function ChosenDropDown() {
            $("#<%=ddl_ItemTypes.ClientID%>").select2();
            $("#<%=ddl_ItemType.ClientID%>").select2();
        }
    </script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.css" />
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.js"></script>
    <script type="text/javascript">
        function dt() {
            $('#tb').DataTable();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-sm-12">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Add CIT Inventory</h3></div>
<div class="panel-body">
<div class="row">
<div class="col-xs-3"><asp:HiddenField ID="hdn_IID" runat="server" />
<label>Item Category <asp:Label ID="lbl_ItemType" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_ItemType" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
<label>Item Type <asp:Label ID="lbl_OldNew" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_NewOld" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
<label>Model &nbsp;<label class="lblr">*</label></label>
<asp:TextBox ID="txt_Model" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Model"></asp:TextBox><br />
</div>
<div class="col-xs-3">
<label>Serial Number &nbsp;<label class="lblr">*</label></label>
<asp:TextBox ID="txt_SerialNo" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Serial Number"></asp:TextBox><br />
</div>
</div>
<div class="row">
<div class="col-xs-3">
<label>Manufacturer &nbsp;<label class="lblr">*</label></label>
<asp:TextBox ID="txt_Manufacturer" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" placeholder="Manufacturer"></asp:TextBox><br />
</div>
<div class="col-xs-3">
<label>Warranty &nbsp;<label class="lblr">*</label><asp:Label ID="lbl_Warranty" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_Warranty" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
<label>Warranty Expiry Date</label>
<asp:TextBox ID="txt_WarrantyDate" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox><br />
</div>
<div class="col-xs-3">
<label>Vendor</label>
<asp:TextBox ID="txt_Vendor" runat="server" CssClass="form-control" MaxLength="10" placeholder="Vendor"></asp:TextBox><br />
</div>
</div>
<div class="row">
<div class="col-xs-3">
<label>File Number</label>
<asp:TextBox ID="txt_ComputerNo" runat="server" CssClass="form-control" MaxLength="10" onkeyup="ToUpper(this)" placeholder="Number on Item"></asp:TextBox><br />
</div>
<div class="col-xs-3">
<label>Purchase Date</label>
<asp:TextBox ID="txt_PurchaseDate" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox><br />
</div>
<div class="col-xs-3">
<label>Status</label>&nbsp;<span data-toggle="tooltip" data-placement="right" data-html="true" title="Idle - Free / Not in use <br> Active - In Use <br> Inactive - Can't be alotted currently <br> Abandoned - Decomissioned / Not usable"><i class="fa fa-info"></i></span>
<asp:DropDownList ID="ddl_status" runat="server" CssClass="form-control">
        <asp:ListItem Selected="True">Idle</asp:ListItem>  
        <asp:ListItem>Active</asp:ListItem>  
        <asp:ListItem>Inactive</asp:ListItem>  
        <asp:ListItem>Abandoned</asp:ListItem>  
</asp:DropDownList>  
</div>
<div class="col-xs-3">
<label><br /></label><br />
<asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-success" Text="Add Inventory" onclick="btn_Submit_Click" />
</div>
</div>
</div>
</div>
<div class="panel panel-color panel-info" style="margin-bottom:200px">
<div class="panel-heading" class="pull-left"><h3 class="panel-title">List of Items &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton>  &nbsp; <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
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
<asp:Repeater ID="rptr_InventoryData" runat="server" onitemcommand="rptr_InventoryData_ItemCommand">
<HeaderTemplate>
<table id="tb" width="100%" border="1" class="table" style="table-layout:fixed; font-size:12px; line-height:30px; font-family:Tahoma; vertical-align:middle; border-collapse: collapse; margin:0;">
<thead><tr>
<th width="5%">SNO</th>
<th width="10%">Item Name</th>
<th width="10%">Manufacture</th>
<th width="10%">Model</th>
<th width="10%">Serial No</th>
<th width="5%">Status</th>
<th width="10%">Warranty</th>
<th width="5%">Edit</th>
<th width="5%">Delete</th>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr align="center">
<td width="5%"><%#Container.ItemIndex+1 %></td>
<td width="10%"><%#Eval("ItemType")%></td>
<td width="10%"><%#Eval("Manufacturer")%></td>
<td width="10%"><%#Eval("Model")%></td>
<td width="10%"><%#Eval("SerialNo")%></td>
<td width="5%" ><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'> <%#Eval("Status")%></asp:Label></td>
<td width="10%"><%#Eval("Warranty")%></td>
<td width="5%">
<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%#Eval("IID")%>' ToolTip="Edit"><i class="fa fa-pencil" style="font-size:large; color:Black;"></i></asp:LinkButton>
</td>
<td width="5%">
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("IID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');" ToolTip="Delete"><i class="fa fa-trash" style="font-size:large; color:Red;"></i></asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<AlternatingItemTemplate>
<tr style="background:#F0F4FF;" align="center">
<td width="5%"><%#Container.ItemIndex+1 %></td>
<td width="10%"><%#Eval("ItemType")%></td>
<td width="10%"><%#Eval("Manufacturer")%></td>
<td width="10%"><%#Eval("Model")%></td>
<td width="10%"><%#Eval("SerialNo")%></td>
<td width="5%"><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'> <%#Eval("Status")%></asp:Label></td>
<td width="10%"><%#Eval("Warranty")%></td>
<td width="5%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%#Eval("IID")%>' ToolTip="Edit"><i class="fa fa-pencil" style="font-size:large; color:Black;"></i></asp:LinkButton>
</td>
<td width="5%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("IID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');" ToolTip="Delete"><i class="fa fa-trash" style="font-size:large; color:Red;"></i></asp:LinkButton>
</td>
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
</div>
        </ContentTemplate>
</asp:Content>

