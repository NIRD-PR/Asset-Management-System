<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="Models.aspx.cs" Inherits="CITInventory_Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
        function ChosenDropDown() {
            $("#<%=ddl_manufacturer.ClientID%>").select2();
        }
        function dt() {
            var n = 'CICT-' + $("#<%=manufacturer.ClientID%>").text() + ' Stock';
            $('.table').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'pageLength','print',
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
<div class="panel-heading"><h3 class="panel-title">Add Model</h3></div>
<div class="panel-body">
<div class="col-xs-12">
<label>Select Manufacturer</label>
<asp:DropDownList ID="ddl_manufacturer" runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_manufacturer_SelectedIndexChanged"></asp:DropDownList><br />
</div>
<div class="col-xs-12">
<label>Enter Models Name</label>
<asp:TextBox ID="txt_model" runat="server" CssClass="form-control" onkeyup="ToUpper(this)" required="" placeholder="Model Name"></asp:TextBox>
</div>
<div class="col-xs-12"><br />
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" 
        Text="Add Model" onclick="btn_Submit_Click" /></div>
</div>        
</div></div>
<div class="col-lg-6">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title"><asp:Label runat="server" ID="manufacturer" ></asp:Label> Models List</h3></div>
<div class="panel-body"><div class="col-xs-12">

<asp:Repeater ID="rptr_Data" runat="server" onitemcommand="rptr_Data_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr align="center">
<th width="10%">SNO</th>
<th width="30%">Manufacturer</th>
<th width="45%">Model</th>
<%--<th width="8%">Edit</th>--%>
<%--<th width="8%">Delete</th>--%>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr align="center">
<td width="10%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="30%"><%#Eval("Manufacturer")%></td>
<td width="45%"><%#Eval("Model")%></td>
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

