<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="Emp_Active.aspx.cs" Inherits="Inventory_Emp_Active" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write('<html><head><title>NIRDPR e-Leave Workflow</title>');
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
<div class="content-page"><%-- onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">--%>
<div class="content">
<div class="container">
<div class="row">
<div class="col-sm-12">
<div class="panel panel-color panel-success" style="margin-bottom:1px;">
<div class="panel-heading"><h3 class="panel-title">Active Employees &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton> <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body">
<div class="col-xs-12">
<center><table width="100%"><tr><td width="40%" align="right">Select Employee Type :</td><td width="60%" align="left"><asp:DropDownList ID="ddl_EmpType" runat="server" width="40%"
        CssClass="form-control"  AutoPostBack="true" 
        onselectedindexchanged="ddl_EmpGroup_SelectedIndexChanged"></asp:DropDownList><asp:HiddenField ID="hdn_st" runat="server" /></td></tr></table><br /></center>
<asp:Panel ID="pnl_print" runat="server"> 
<table width="100%" style="font-family:Tahoma;">
<tr><td align="center"><img src="../assets/images/titlenew.png" height="50" width="450"  alt=""/></td></tr>
<tr><td align="center"><h4><u>List of <asp:Label ID="lbl_EmpGroup" runat="server"></asp:Label> Employees </u></h4></td></tr>
</table>
<asp:Repeater ID="rptr_Data" runat="server" onitemcommand="rptr_Data_ItemCommand">
<HeaderTemplate>
<table width="100%" border="1" class="table" style="table-layout:fixed;font-family:Tahoma; font-size:11px; line-height:22px; vertical-align:middle; border-collapse: collapse; border:1px solid #888888;margin:0;">
<thead><tr>
<th width="5%">SNO</th>
<th width="10%">EmpID/ Attendance ID</th>
<th width="8%">Photo</th>
<th width="20%">Name / Designation</th>
<th width="10%">Department</th>
<th width="8%">Desktop/All in One</th>
<th width="8%">Laptop</th>
<th width="8%">Printer </th>
<th width="8%">Scanner</th>
<th width="15%">Signature</th>
</tr>
</thead>
</table>
</HeaderTemplate>
<ItemTemplate>
<table width="100%" border="1" class="table" style="table-layout:fixed;font-family:Tahoma; font-size:11px; line-height:22px; vertical-align:middle; border-collapse: collapse; border:1px solid #888888;margin:0;">
<tbody><tr class="gradeX">
<td width="5%" align='center'style="vertical-align:middle;font-size:11px; font-family:Tahoma;"><%#Container.ItemIndex+1 %></td>
<td width="10%" align="center" style="vertical-align:middle; font-weight:bold; font-size:11px; font-family:Tahoma;"><asp:Label ID="lbl_NewEmpID" runat="server"></asp:Label><br /> <asp:Label ID="lbl_AttID" runat="server"></asp:Label><asp:Label ID="lbl_RegAttID" runat="server"></asp:Label></td>
<td width="8%" align="center" style="vertical-align:middle;text-align:center;font-size:11px; font-family:Tahoma;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" Width="50" Height="50"></asp:ImageMap></td>
<td width="20%" style="vertical-align:middle;font-size:11px; font-family:Tahoma;"><%#Eval("Name")%>  <br /> <%#Eval("Design")%></td>
<td width="10%" style="vertical-align:middle;font-size:11px; font-family:Tahoma; text-align:center;"><%#Eval("DeptID")%></td>
<td width="8%" style="vertical-align:middle;font-size:11px; font-family:Tahoma;"></td>
<td width="8%" style="vertical-align:middle;font-size:11px; font-family:Tahoma;"></td>
<td width="8%" style="vertical-align:middle;font-size:11px; font-family:Tahoma;"></td>
<td width="8%" style="vertical-align:middle;font-size:11px; font-family:Tahoma;"></td>
<td width="15%" style="vertical-align:middle;font-size:11px; font-family:Tahoma;"></td>

</tr>
</tbody>
</table>

</ItemTemplate>
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
</asp:Content>

