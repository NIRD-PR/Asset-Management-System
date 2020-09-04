<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="Floors.aspx.cs" Inherits="CITInventory_Floors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="content-page" onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
<div class="content">
<div class="container">
<div class="row">
<div class="col-sm-12">
<%--<h4 class="pull-left page-title">Floors</h4><ol class="breadcrumb pull-right"><li><a href="#">Payrolls</span></a></li><li><a href="#">Admin</span></a></li><li class="active">Floorss</li></ol></div></div>--%>
<div class="row">
<div class="col-lg-4">
<div class="panel panel-color panel-primary">
<div class="panel-heading"><h3 class="panel-title">Add Floor</h3></div>
<div class="panel-body">
<div class="col-xs-12"><asp:HiddenField ID="hdn_FLID" runat="server" />
<label>Enter Floor #</label>
<asp:TextBox ID="txt_Floors" runat="server" CssClass="form-control"  required="" placeholder="I Floor"></asp:TextBox>
</div>

<div class="col-xs-12"><br />
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" 
        Text="Add Floor" onclick="btn_Submit_Click" /></div>
</div>        
</div></div>
<div class="col-lg-8">
<div class="panel panel-color panel-success">
<div class="panel-heading" class="pull-left"><h3 class="panel-title">Floors List <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body"><div class="col-xs-12">

<asp:Repeater ID="rptr_Data" runat="server" onitemcommand="rptr_Data_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr>
<th width="10%">SNO</th>
<th width="75%">Floor</th>
<th width="15%" colspan="2">Actions</th>
</tr>
</thead>
</table>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-bordered table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px;">
<tbody><tr class="gradeX">
<td width="10%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="75%"><%#Eval("Floor")%></td>
<td width="8%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Edit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("FLID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
</td>
<td width="8%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("FLID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');"><i class="fa fa-trash-o"></i></asp:LinkButton>
</td>
</tr>
</tbody>
</table>
</ItemTemplate>
</asp:Repeater>
</div>
</div></div></div>
</div>

    </div>
</div>
</div>
</div>
</div>
</asp:Content>

