<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="CICTInventory_Roles" %>

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
            $("#<%=ddl_roles.ClientID%>").select2();
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
<div class="panel-heading"><h3 class="panel-title">Roles Assigning</h3></div>
<div class="panel-body">
<div class="row">
<div class="col-xs-2">
<label>Select Emp Type <asp:Label ID="lbl_EmpType" runat="server" CssClass="lblr"></asp:Label></label>
<asp:DropDownList ID="ddl_EmpType" runat="server" CssClass="form-control" AutoPostBack="true" onselectedindexchanged="txt_Name_TextChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-3">
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
<asp:HiddenField ID="hdn_DSID" runat="server" />
<asp:HiddenField ID="hdn_password" runat="server" />
<asp:HiddenField ID="hdn_photo" runat="server" />
</tr>
</table>
</div>
</div>
<div class="row" style="margin: 20px 0">
    <asp:DataList ID="dl_EmpDetails" runat="server" Width="100%">
<ItemTemplate>
<center>
<table width="100%" class="table" border="1px" style="table-layout:fixed; font-family:Tahoma; font-size:12px; font-weight:bold; line-height:18px; vertical-align:baseline; border-collapse: collapse; margin:0;">
<tr style="font-weight:bold; font-size:0.8em; color:#257A08; vertical-align:middle; text-align:center;">
<td rowspan="2" width="10%" align="center" style="background:#A591FA;"><asp:ImageMap ID="Album_Image" runat="server" CssClass="thumb-md img-circle" ImageUrl='<%#"../SPhotos/"+Eval("Photo")%>' Width="60" Height="65"></asp:ImageMap>  </td>
<td width="5%">EmpID</td>
<td width="25%">Name / Design [Dept]</td>
<td width="25%">Contact Details</td>
<td width="25%">Roles</td>
<td width="20%">DOJ / DOR</td>
</tr>
<tr align="center"><td width="5%" align="center" style="vertical-align:middle; font-weight:bold;"><%#Eval("EmpID")%></td>
<td width="25%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Name")%> <br /><label class="lblr"><%#Eval("Design")%></label> [<label class="lblr"><%#Eval("DeptID")%></label>]</td>
<td width="25%" style="vertical-align:middle; font-size:0.9em;"><%#Eval("Email")%><br /><%#Eval("Mobile")%></td>
<td width="25%"><asp:Label ID="lbl_roles" runat="server"></asp:Label></td>
<td width="20%" style="vertical-align:middle; text-align:center;"><%# DataBinder.Eval(Container.DataItem, "DOJ", "{0:dd/MM/yyyy}") %> <br /> <asp:Label ID="lbl_DOR" runat="server" CssClass="lblr"></asp:Label></td>
</table>
</center>
</ItemTemplate>
</asp:DataList>
</div>
<div class="row">
<div class="col-xs-3"><asp:HiddenField ID="hdn_MIID" runat="server" />
<label>Roles </label>
<asp:DropDownList ID="ddl_roles" runat="server" CssClass="form-control"></asp:DropDownList><br />
</div>
<div class="col-xs-3"><asp:HiddenField ID="HiddenField3" runat="server" />
<label>UserID </label>
<asp:Textbox ID="userid" runat="server" CssClass="form-control"></asp:Textbox><br />
</div>
</div>
</div>

<div class="row">
<div class="col-xs-12" align="center"><asp:Button ID="btn_Submit" runat="server" 
        CssClass="btn btn-success" Text="Assign Role" onclick="btn_Submit_Click" /></div>
</div>
</div>
<div class="panel panel-color panel-info" style="margin-bottom:200px">
<div class="panel-heading"><h3 class="panel-title">Assigned Roles &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" CssClass="middle btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton>  &nbsp;</h3></div>
<div class="panel-body">
<div class="col-xs-12">
<asp:Panel ID="pnl_print" runat="server">
<asp:Repeater ID="rptr_InventoryData" runat="server">
<HeaderTemplate>
<table id="tb" width="100%" border="1" class="table" style="table-layout:fixed; font-size:12px; line-height:30px; font-family:Tahoma; vertical-align:middle; border-collapse: collapse; margin:0;">
<thead><tr>
<th width="5%">SNO</th>
<th width="10%">UserID</th>
<th width="10%">EmpID</th>
<th width="15%">Name</th>
<th width="15%">Designation</th>
<th width="15%">Email</th>
<th width="10%">Application</th>
<th width="10%">Role</th>
<th width="10%">Mobile</th>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr  align='center'>
<td width="5%"><%#Container.ItemIndex+1 %></td>
<td width="10%"><%#Eval("UserID")%></td>
<td width="10%"><%#Eval("EmpID")%></td>
<td width="15%"><%#Eval("Name")%></td>
<td width="15%"><%#Eval("Design")%></td>
<td width="15%"><%#Eval("Email")%></td>
<td width="10%"><%#Eval("Application")%></td>
<td width="10%"><%#Eval("Role")%></td>
<td width="10%"><%#Eval("Mobile")%></td>
</tr>
</ItemTemplate>
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
