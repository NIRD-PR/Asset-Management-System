<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="Manufacturer.aspx.cs" Inherits="CITInventory_Manufacturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
        function dt() {
            var n = 'CICT- Manufacturers List';
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
<div class="panel-heading"><h3 class="panel-title">Add Manufacturer</h3></div>
<div class="panel-body">
<div class="col-xs-12">
<label>Enter Manufacturer Name</label>
<asp:TextBox ID="txt_Manufacturer" runat="server" CssClass="form-control" onkeyup="ToUpper(this)"  required="" placeholder="Manufacturer Name"></asp:TextBox>
</div>

<div class="col-xs-12"><br />
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" 
        Text="Add Manufacturer" onclick="btn_Submit_Click" /></div>
</div>        
</div></div>
<div class="col-lg-6">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Manufacturer's List <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body"><div class="col-xs-12">

<asp:Repeater ID="rptr_Data" runat="server" onitemcommand="rptr_Data_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr>
<th width="10%">SNO</th>
<th width="75%">Manufacturer</th>
<%--<th width="15%" colspan="2">Actions</th>--%>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr class="gradeX" align="center">
<td width="10%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="75%"><%#Eval("Name")%></td>
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

