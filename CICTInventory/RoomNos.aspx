<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="RoomNos.aspx.cs" Inherits="CITInventory_RoomNos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="content-page"  onkeypress="return WebForm_FireDefaultButton(event, '<%= btn_Submit.ClientID %>')">
<div class="content">
<div class="container">
<div class="row">
<div class="col-md-12" style="padding:8px 5px; margin:0;">
<div class="row">
<div class="col-lg-4">
<div class="panel panel-color panel-primary">
<div class="panel-heading"><h3 class="panel-title">Add RoomNo</h3></div>
<div class="panel-body">
<div class="col-xs-12"><asp:HiddenField ID="hdn_RMID" runat="server" />
<label>Select Location <label class="lblr">* <asp:Label ID="lbl_Location" runat="server"></asp:Label></label></label>
<asp:DropDownList ID="ddl_Location" runat="server" CssClass="form-control"></asp:DropDownList><br />

<label>Select Floor <label class="lblr">* <asp:Label ID="lbl_Floor" runat="server"></asp:Label></label></label>
<asp:DropDownList ID="ddl_Floor" runat="server" CssClass="form-control"></asp:DropDownList><br />

<label>Enter RoomNo <label class="lblr">* <asp:Label ID="lbl_RoomNo" runat="server"></asp:Label></label></label>
<asp:TextBox ID="txt_RoomNo" runat="server" CssClass="form-control"  required="" placeholder="V01"></asp:TextBox><br />

<asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" 
        Text="Add RoomNo" onclick="btn_Submit_Click" />
</div>
</div>
</div>
</div>

<div class="col-lg-8">
<div class="panel panel-color panel-success">
<div class="panel-heading" class="pull-left"><h3 class="panel-title">Rooms List <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body"><div class="col-xs-12">

<asp:Repeater ID="rptr_Data" runat="server" onitemcommand="rptr_Data_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-striped" id="datatable-editable" style="font-size:0.8em; margin-bottom:1px;">
<thead><tr>
<th width="5%">SNo</th>
<th width="25%">Hostel Type</th>
<th width="25%">Floor Type</th>
<th width="10%">Room No</th>
<th width="10%">Status</th>
<th width="10%" colspan="2">Actions</th>
</tr>
</thead>
</table>
</HeaderTemplate>
<ItemTemplate>
<table class="table table-bordered table-hover" width="100%" id="datatable-editable" style="font-size:0.9em; margin-bottom:1px;">
<tbody><tr class="gradeX">
<td width="5%" align='center'><%#Container.ItemIndex+1 %></td>
<td width="25%"><%#Eval("Location")%></td>
<td width="25%" ><%#Eval("Floor")%></td>
<td width="10%" align="center"><%#Eval("RoomNo")%></td>
<td width="10%" align="center"><%#Eval("Status")%></td>
<td width="5%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Edit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("RMID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
</td>
<td width="5%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("RMID")%>' OnClientClick= "return confirm('Are you Sure To Delete?');"><i class="fa fa-trash-o"></i></asp:LinkButton>
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

