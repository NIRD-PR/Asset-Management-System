<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="AssetRequest.aspx.cs" Inherits="CICTInventory_AssetRequest" %>

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
        function show() {
            $('#exampleModal').modal('show');
        }
        function show1() {
            $('#editModal').modal('show');
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
<div class="panel-heading"><h3 class="panel-title">CIT Inventory Pending Requests</h3></div>
<div class="panel-body">
<div class="row" style="margin: 20px 0 10px 0">
<asp:Repeater ID="rptr_reqPending" runat="server" OnItemCommand="rptr_request_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; border:0px solid #000; margin:0;">
<thead><tr>
<td width="5%" align='center'>SNo</td>
<td width="10%" align='center'>Item Name</td>
<td width="5%" align='center'>EmpID</td>
<td width="15%" align='center'>EmpName</td>
<td width="15%" align='center'>Date</td>
<td width="15%" align='center'>Status</td>
<td width="25%" align='center'>Note</td>
<td width="10%" colspan="2" align="center">Actions</td>
</tr>
</thead>
</HeaderTemplate>
<ItemTemplate>
<tbody><tr>
<td width="5%" align='center'><%#Container.ItemIndex+1%></td>
<td width="10%" align="center"><%#Eval("ItemName")%></td>
<td  width="5%" align="center"><%#Eval("EmpID")%></td>
<td  width="15%" align="center"><%#Eval("Name")%></td>
<td  width="15%" align="center"><%#Eval("Date")%></td>
<td width="15%" align="center"><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'><%#Eval("Status")%></asp:Label></td>
<td  width="25%" align="center"><%#Eval("Note")%></td>
<td width="5%" class="actions" align='center'>
<asp:LinkButton ID="lbl_approve" runat="server" CommandName="Approve" OnClientClick= "return confirm('Are you Sure To Approve Request?');" CommandArgument='<%#Eval("RID")%>' ToolTip="Approve"><i class="fa fa-check" style="font-size:large; color:Green;"></i></asp:LinkButton>
</td>
<td width="5%" class="actions" align='center'>
<asp:LinkButton ID="lbl_Del" runat="server" ToolTip="Reject" CommandName="rid" CommandArgument='<%#Eval("RID")%>'><i class="fa fa-times" style="font-size:large; color:Red;"></i></asp:LinkButton>
</td>

</tr>
</tbody>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
 <!--Reject Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Reject Request</h5>
      </div>
      <div class="modal-body">
        <label>Please Enter Remarks </label>
          <asp:HiddenField ID="hdn_rid" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control"></asp:TextBox><br />
        <asp:LinkButton ID="btn_Submit" runat="server" CssClass="btn btn-success" Text="Reject" OnClick="btn_Submit_Click"/>
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
</div>
</div>
<div class="panel panel-color panel-info">
<div class="panel-heading"><h3 class="panel-title">CIT Inventory Past Requests</h3></div>
<div class="panel-body">
<div class="row" style="margin: 20px 0 10px 0">
<asp:Repeater ID="rptr_req" runat="server" OnItemCommand="rptr_req_ItemCommand">
<HeaderTemplate>
<table width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; border:0px solid #000; margin:0;">
<thead><tr>
<td width="5%" align='center'>SNo</td>
<td width="10%" align='center'>Item Name</td>
<td width="7%" align='center'>EmpID</td>
<td width="20%" align='center'>EmpName</td>
<td width="10%" align='center'>Date</td>
<td  width="15%" align='center'>Status</td>
<td  width="30%" align='center'>Remarks</td>
<td width="3%" align="center">Action</td>
</tr>
</thead>
</HeaderTemplate>
<ItemTemplate>
<tbody><tr>
<td width="5%" align='center'><%#Container.ItemIndex+1%></td>
<td width="10%" align="center"><%#Eval("ItemName")%></td>
<td  width="7%" align="center"><%#Eval("EmpID")%></td>
<td  width="20%" align="center"><%#Eval("Name")%></td>
<td  width="10%" align="center"><%#Eval("Date")%></td>
<td  width="15%" align="center"><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'><%#Eval("Status")%></asp:Label></td>
<td  width="30%" align="center"><%#Eval("Remark")%></td>
<td width="3%" class="actions" align='center'>
<asp:LinkButton ID="lbl_edit" runat="server" ToolTip="Edit" CommandName="rid" CommandArgument='<%#Eval("RID")%>'><i class="fa fa-pencil" style="font-size:large; color:Blue;"></i></asp:LinkButton>
</td>
</tr>
</tbody>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
<!--Edit Modal -->
<div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="editModalLabel">Edit Remark</h5>
      </div>
      <div class="modal-body">
        <label>Please Enter Remarks </label>
          <asp:HiddenField ID="hdn_rid1" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="txt_remark1" runat="server" CssClass="form-control"></asp:TextBox><br />
        <asp:LinkButton ID="btn_submit1" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btn_Submit_Click1"/>
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
</div>
</div>
</div>
        </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

