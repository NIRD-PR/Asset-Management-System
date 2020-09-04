<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="CITSupportingStaff.aspx.cs" Inherits="CICTInventory_CITSupportingStaff" %>

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
    <style type="text/css" media="print,screen" >
     table { page-break-inside:auto }
    tr    { page-break-inside:avoid; page-break-after:auto }
    thead { display:table-header-group }
    tfoot { display:table-footer-group }
table tr th td {
    border:1px solid gray;
    padding:2px;
}
th {
font-family:Tahoma;
color:black;
background-color:#EDF6FA;
}
thead {
    display:table-header-group;
    
}
tbody {
    display:table-row-group;
}

 @media print
 {
   thead {display: table-header-group;}
    table {
        border: solid #000 !important;
        border-width: 1px 0 0 1px !important;
    }
    th, td {
        border: solid #000 !important;
        border-width: 0 1px 1px 0 !important;
    }
 }
</style>

<%--<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=600');
        printWindow.document.write('<html><head><title>NIRDPR-Employee: Category_wise IT Statement</title>');
        printWindow.document.write('</head><body>');
        printWindow.document.write(panel.innerHTML);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        setTimeout(function () {
            printWindow.print();
            togglePageBreakAfter();
        }, 500);
        return false;
    }
    
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">CICT Supprting Staff Registration</h3></div>
<div class="panel-body">
<div class="row">

<div class="col-xs-3"><asp:HiddenField ID="hdn_CSID" runat="server" />
<label>EmpID <asp:Label ID="lbl_EmpID" runat="server" CssClass="lblr"></asp:Label><label CssClass="lblr">*</label></label>
<asp:TextBox ID="txt_EmpID" runat="server" CssClass="form-control" placeholder="EmpID"></asp:TextBox><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField2" runat="server" />
<label>Name<asp:Label ID="Label1" runat="server" CssClass="lblr"></asp:Label><label CssClass="lblr">*</label></label>
<asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField3" runat="server" />
<label>Design <asp:Label ID="Label2" runat="server" CssClass="lblr"></asp:Label><label CssClass="lblr">*</label></label>
<asp:TextBox ID="txt_Design" runat="server" CssClass="form-control" placeholder="Designation"></asp:TextBox><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField4" runat="server" />
<label>Email <asp:Label ID="Label3" runat="server" CssClass="lblr"></asp:Label><label CssClass="lblr">*</label></label>
<asp:TextBox ID="txt_Email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox><br />
</div>
</div>
<div class="row">
<div class="col-xs-3"><asp:HiddenField ID="HiddenField5" runat="server" />
<label>Mobile <asp:Label ID="Label4" runat="server" CssClass="lblr"></asp:Label><label CssClass="lblr">*</label></label>
<asp:TextBox ID="txt_Mobile" runat="server" CssClass="form-control" placeholder="Mobile"></asp:TextBox><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField7" runat="server" />
<label>Upload Photo <asp:Label ID="lbl_Photo" runat="server" CssClass="lblr"></asp:Label><label CssClass="lblr">*</label></label>
<asp:FileUpload ID="fu_Photo" runat="server" CssClass="form-control" /><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField6" runat="server" />
<br />
<asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-success" 
        Text="Register" onclick="btn_Submit_Click" />
</div>
</div>
</div>
<div class="panel panel-color panel-info">
<div class="panel-heading" class="pull-left"><h3 class="panel-title">Emp Wise Mapped IT Inventory <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body">
<div class="col-xs-12">
<asp:Repeater ID="rptr_CITSS" runat="server" onitemcommand="rptr_CITSS_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr>
<th width="5%">SNO</th>
<th rowspan="2" width="10%" align="center">Photo </th>
<th width="10%">EmpID</th>
<th width="20%">Name</th>
<th width="15%">Design</th>
<th width="20%">Email</th>
<th width="10%">Mobile</th>
<th width="10%" colspan="3">Edit/Del/Block</th>

</tr>
</thead>
</table>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-bordered table-hover" width="100%" style="font-size:0.8em; margin-bottom:1px;">
<tbody><tr >
<td width="5%" align='center' style="vertical-align:middle;"><%#Container.ItemIndex+1 %></td>
<td width="10%" align="center" style="vertical-align:middle;"><%#Eval("EmpID")%></td>
<td width="10%" align="center" style="vertical-align:middle;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" ImageUrl='<%#"../SPhotos/"+Eval("Photo")%>' Width="40" Height="40"></asp:ImageMap> </td>
<td width="20%" style="vertical-align:middle;"><%#Eval("Name")%></td>
<td width="15%" style="vertical-align:middle;"><%#Eval("Design")%></td>
<td width="20%"  align="center" style="vertical-align:middle;"><%#Eval("Email")%></td>
<td width="10%"  align="center" style="vertical-align:middle;"><%#Eval("Mobile")%></td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%#Eval("CSID")%>' ToolTip="Edit"><i class="fa fa-pencil" style="font-size:large; color:Black;"></i></asp:LinkButton>
</td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("CSID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');" ToolTip="Delete"><i class="fa fa-trash" style="font-size:large; color:Red;"></i></asp:LinkButton>
</td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="LinkButton2" runat="server" CommandName="Block" CommandArgument='<%#Eval("CSID")%>' OnClientClick= "return confirm('Are you Sure To Block?');" ToolTip="Block"><i class="fa fa-lock" style="font-size:large; color:Green;"></i></asp:LinkButton>
</td>
</tr>
</tbody>
</table>
</ItemTemplate>
</asp:Repeater>
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

</asp:Content>

