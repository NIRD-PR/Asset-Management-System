<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="AddRole.aspx.cs" Inherits="AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function dt() {
            var n = 'Roles List';
            $('.table').DataTable({
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

<div class="content-page" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
<div class="content">
<div class="container">
<div class="row">
<div class="col-sm-12">
<div class="row">
<div class="col-lg-6">
<div class="panel panel-color panel-primary">
<div class="panel-heading"><h3 class="panel-title">Add a Role</h3></div>
<div class="panel-body">
<div class="col-xs-4">
<label>Enter Role Number (Only number)</label>
<asp:TextBox ID="txt_role" runat="server" CssClass="form-control" required="" placeholder="Role Number"></asp:TextBox>
</div>
<div class="col-xs-8">
<label>Enter Application Name</label>
<asp:TextBox ID="txt_application" runat="server" CssClass="form-control" required="" placeholder="Application Name"></asp:TextBox>
</div>

<div class="col-xs-12"><br />
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" 
        Text="Add Role" onclick="btn_Submit_Click" /></div>
</div>        
</div></div>
<div class="col-lg-6">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Roles List <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body"><div class="col-xs-12">

<asp:Repeater ID="rptr_Data" runat="server">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr>
<th width="10%">SNO</th>
<th width="30%">Role Number</th>
<th width="60%">Application Name</th>
<%--<th width="15%" colspan="2">Actions</th>--%>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr class="gradeX" align="center">
<td width="10%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="30%"><%#Eval("Role")%></td>
<td width="60%"><%#Eval("Application")%></td>
<%--<td width="8%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Edit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("MID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
</td>
<td width="8%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("MID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');"><i class="fa fa-trash-o"></i></asp:LinkButton>
</td>--%>
</tr>
</ItemTemplate>
    <FooterTemplate>
        </tbody>
    </table>
    </FooterTemplate>
</asp:Repeater>
</div>
</div></div></div>
</div>

    </div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

