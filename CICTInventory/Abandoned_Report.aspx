<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="Abandoned_Report.aspx.cs" Inherits="CICTInventory_AbandonedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=pnl_print.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=600');
        printWindow.document.write('<html><head><title>NIRDPR: CICT Emp-Wise Inventory</title>');
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
    </script>
    <script type="text/javascript">
        function ChosenDropDown() {
            $("#<%=ddl_fy.ClientID%>").select2();
            $("#<%=start.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            });
            $("#<%=end.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            });
        }
        function dt() {
            var n = "CICT- Abandoned Inventory";
            $('#tb1').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'pageLength', 'print',
                    {
                        extend: 'excel',
                        filename: n,
                        title: n,
                        messageTop: 'Abandoned Assets from ' + $("#<%=stdate.ClientID%>").text() + ' to ' + $("#<%=enddate.ClientID%>").text() 
                    },
                    {
                        extend: 'pdf',
                        filename: n,
                        title: n,
                        messageTop: 'Abandoned Assets from ' + $("#<%=stdate.ClientID%>").text() + ' to ' + $("#<%=enddate.ClientID%>").text()
                    }
                ]
            });
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
        <asp:UpdatePanel ID="up" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="rptr_Inventory" />
            </Triggers>
    <ContentTemplate>
    <div class="content-page">
<div class="content">
<div class="container">
<div class="row">
<div class="col-lg-12">
<div class="panel panel-color panel-success">
<div class="panel-heading"><h3 class="panel-title">Abandoned Assets Report : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btn_print" runat="server" CssClass="btn btn-primary" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i></asp:LinkButton><asp:Label ID="lbl_Count" runat="server" CssClass="pull-right"></asp:Label></h3></div>
<div class="panel-body">
    <div class="row" style="margin: 20px 0">
        <label> Select Financial Year : </label>  <asp:DropDownList ID="ddl_fy" runat="server" Width="20%" OnSelectedIndexChanged="ddl_fy_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="row" style="margin: 20px 0">
        <strong>OR</strong>
    </div>
    <div class="row" style="margin: 20px 0">
        <label> Start Date : </label> <asp:TextBox runat="server" ID="start" ClientIDMode="Static"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <label> End Date : </label>  <asp:TextBox runat="server" ID="end" ClientIDMode="Static"></asp:TextBox>
    </div>
    <div class="row" style="margin: 20px 0">
        <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Get Report" OnClick="btn_Submit_Click" />
    </div>
<div class="row">
<asp:Panel ID="pnl_print" runat="server">
<center> <img src="../assets/images/title.png" height="80" width="400"  alt=""/>
<h5> NIRDPR - Abandoned-assets CICT Inventory  Details </h5>
</center>
<div class="row" style="margin: 20px">
    <strong>Abandoned Assets from <asp:Label runat="server" ID="stdate"></asp:Label> to <asp:Label runat="server" ID="enddate"></asp:Label></strong>
</div>
<asp:Repeater ID="rptr_Inventory" runat="server" OnItemCommand="rptr_Inventory_ItemCommand">
<HeaderTemplate>
<table id="tb1" width="100%" class="table table-bordered table-hover" border="1" style="table-layout:fixed; font-family:Tahoma; font-size:11px; border-collapse: collapse; vertical-align:middle; margin:0;">
<thead><tr align="center">
<td width="5%">SNo</td>
<td width="10%">Item Category</td>
<td width="10%">Model</td>
<td width="10%">Serial Number</td>
<td  width="10%">Manufacturer</td>
<td  width="13%">Date of Purchase</td>
<td  width="13%">Credited To Govt. On</td>
<td  width="13%">Disposed On</td>
<td width="10%">Disposal Remark</td>
<td  width="6%">Disposal Details</td>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr align="center">
<td width="5%"><%#Container.ItemIndex+1%></td>
<td width="10%"><%#Eval("ItemName")%></td>
<td  width="10%"><%#Eval("Model")%></td>
<td  width="10%"><%#Eval("SerialNo")%></td>
<td  width="10%"><%#Eval("Manufacturer")%></td>
<td  width="13%"><%#Eval("DOP")%> </td>
<td  width="13%"><%#Eval("Dated")%> </td>
<td  width="13%"><%#Eval("DisposedOn")%></td>
<td  width="10%"><%#Eval("DisposalRemark")%></td>
<td  width="6%"><asp:LinkButton runat="server" ID="download" CssClass="font-weight-bold text-danger" CommandArgument='<%#Eval("DisposalFile")%>'><i class="fa fa-download" style="transform: scale(2)"></i></asp:LinkButton></td>
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
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

