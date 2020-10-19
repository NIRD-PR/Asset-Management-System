<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="DisposeAsset.aspx.cs" Inherits="CICTInventory_DisposeAsset" %>

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
            
        }
        function dt() {
            $('#tb').DataTable();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:UpdatePanel ID="up" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="final" />
        </Triggers>
    <ContentTemplate>
<div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-sm-12">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">List of Items</h3></div>
<div class="panel-body">
<asp:Repeater ID="rptr_InventoryData" runat="server">
<HeaderTemplate>
<table id="tb" width="100%" border="1" class="table" style="table-layout:fixed; font-size:12px; line-height:30px; font-family:Tahoma; vertical-align:middle; border-collapse: collapse; margin:0;">
<thead><tr>
<th width="5%">Select to dispose</th>
<th width="10%">Item Name</th>
<th width="10%">Manufacture</th>
<th width="10%">Model</th>
<th width="10%">Serial No</th>
<th width="5%">Status</th>
<th width="10%">Warranty</th>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr align="center">
<asp:HiddenField runat="server" ID="iid" Value='<%#Eval("IID") %>'/>
<td width="5%"><asp:CheckBox ID="del" runat="server"/></td>
<td width="10%"><%#Eval("ItemType")%></td>
<td width="10%"><%#Eval("Manufacturer")%></td>
<td width="10%"><%#Eval("Model")%></td>
<td width="10%"><%#Eval("SerialNo")%></td>
<td width="5%" ><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'> <%#Eval("Status")%></asp:Label></td>
<td width="10%"><%#Eval("Warranty")%></td>
</tr>
</ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Button runat="server" CssClass="btn btn-success" ID="Button1" OnClick="btn_submit_Click"  Text="Select the checked assets"/>
</div>
</div>
<div class="panel panel-color panel-info" style="margin-bottom:200px">
<div class="panel-heading"><h3 class="panel-title">Dipose Assets</h3></div>
<div class="panel-body">
<asp:Label runat="server" ID="isChoosen" CssClass="text-danger text"></asp:Label>
<asp:Repeater ID="rptr_del" runat="server">
<HeaderTemplate>
<table id="tb" width="100%" border="1" class="table" style="table-layout:fixed; font-size:12px; line-height:30px; font-family:Tahoma; vertical-align:middle; border-collapse: collapse; margin:0;">
<thead><tr>
<th width="5%">S No.</th>
<th width="10%">Item Name</th>
<th width="10%">Manufacture</th>
<th width="10%">Model</th>
<th width="10%">Serial No</th>
<th width="5%">Status</th>
<th width="10%">Warranty</th>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr align="center">
<asp:HiddenField runat="server" ID="iid" Value='<%#Eval("IID") %>'/>
<td width="5%"><%#Container.ItemIndex+1 %></td>
<td width="10%"><%#Eval("ItemType")%></td>
<td width="10%"><%#Eval("Manufacturer")%></td>
<td width="10%"><%#Eval("Model")%></td>
<td width="10%"><%#Eval("SerialNo")%></td>
<td width="5%" ><asp:Label runat="server" CssClass='<%#GetColor(Eval("Status").ToString()) %>'> <%#Eval("Status")%></asp:Label></td>
<td width="10%"><%#Eval("Warranty")%></td>
</tr>
</ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
<div class="col-12" style="margin-top: 20px">
    <label>Why and How Disposed of ?<label class="lblr">*</label></label>
    <asp:FileUpload ID="dispose" runat="server"/>
</div>
<div class="col-12" style="margin-top: 20px">
    <label>Sale price (if any)</label>
    <asp:TextBox runat="server" ID="sale"></asp:TextBox>
</div>
<div class="col-12" style="margin-top: 20px">
    <label>Enter Remarks <label class="lblr">*</label></label>
    <asp:TextBox runat="server" ID="remarks"></asp:TextBox>
</div>
<div class="col-12" style="margin-top: 20px">
    <asp:Button runat="server" ID="final" OnClick="final_Click" Text="Submit" CssClass="btn btn-danger"/>
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


