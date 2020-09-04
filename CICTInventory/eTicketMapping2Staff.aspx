<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="eTicketMapping2Staff.aspx.cs" Inherits="CICTInventory_eTicketMapping2Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<div class="panel-heading" class="pull-left"><h3 class="panel-title">e - Ticket Mapping to Supporting Staff <asp:Label ID="lbl_Count" runat="server" CssClass="pull-right">0</asp:Label></h3></div>
<div class="panel-body">
<div class="row">
<table width="100%" class="table-responsive" style="table-layout:fixed; margin:0;">
<tr><td width="30%" align="left"><asp:Button ID="btn_CheckAll" runat="server" CssClass="btn btn-success" Text="Check All" onclick="btn_CheckAll_Click" /> <asp:Button ID="btn_UnCheckAll" CssClass="btn btn-danger" runat="server" Text="UnCheck All" onclick="btn_UnCheckAll_Click" /></td><td width="40%"></td><td width="30%" align="right">
    <asp:Button ID="btn_MapTicket" runat="server" CssClass="btn btn-primary" 
        Text="Assign Tickets to Staff" onclick="btn_MapTicket_Click" /></td></tr>
</table>
<div class="col-lg-12">
<div class="alt" style="overflow-x:auto; padding:0; overflow-y: auto; min-height:300px; max-height:550px;">
<asp:GridView ID="gv_Tickets" runat="server" AutoGenerateColumns="false" 
                           BackColor="White" GridLines="Horizontal" 
                           AlternatingRowStyle-BackColor = "#D8FAE0" 
                           CssClass="table table-bordered table-hover" 
        Width="100%" > 
                   <Columns>
                   <asp:TemplateField  ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center" HeaderText="Check"> 
                    <ItemTemplate>  
                       <asp:CheckBox ID="cb_Emp" runat="server" ItemStyle-HorizontalAlign="Center" CssClass="checkbox-circle" Checked="false" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TicketNo" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" HeaderText="Ticket No" ItemStyle-Font-Size="X-Small"/>
                    <asp:BoundField DataField="Dated" HeaderText="Date" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}" ItemStyle-Width="10%" ItemStyle-Font-Size="X-Small" />
                    <asp:BoundField DataField="Name" HeaderText="Ticket From" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" ItemStyle-Font-Size="X-Small" />
                    <asp:BoundField DataField="DeptID" HeaderText="Dept ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" ItemStyle-Font-Size="X-Small" />
                    <asp:BoundField DataField="ItemName" HeaderText="Problem with" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="17%" ItemStyle-Font-Size="X-Small" />
                    <asp:BoundField DataField="ProblemDescription" HeaderText="Problem Description" ItemStyle-Width="25%" ItemStyle-Font-Size="XX-Small" /> 
                    <asp:TemplateField  ItemStyle-Width="15%" HeaderText="Supporting Staff"> 
                    <ItemTemplate>  
                       <asp:DropDownList ID="ddl_EmpName"  runat="server" CssClass="form-control" AutoPostBack="true" 
        onselectedindexchanged="ddl_EmpName_SelectedIndexChanged"></asp:DropDownList>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField  ItemStyle-Width="10%" Visible="false"> 
                    <ItemTemplate>  
                       <asp:Label ID="lbl_UEmail" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>     
                    <asp:TemplateField  ItemStyle-Width="10%" Visible="false"> 
                    <ItemTemplate>  
                       <asp:Label ID="lbl_UMobile" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>            
                   </Columns>
                   </asp:GridView>
                   <br /><br />
                   <center><asp:Label ID="lbl_NoData" runat="server" CssClass="label-danger" Visible="false"></asp:Label></center>
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

