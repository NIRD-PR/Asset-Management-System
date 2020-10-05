<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="Inventory.master" AutoEventWireup="true" CodeFile="AddInventoryBulk.aspx.cs" Inherits="CICTInventory_AddInventoryBulk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="content-page">
        <div class="content">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-color panel-success">
                                    <div class="panel-heading"><asp:HiddenField ID="hdn_EmpID" runat="server" Value="0" /><asp:HiddenField ID="hdn_Name" runat="server" Value="0" />
                                        <h3 class="panel-title">Adding inventory in bulk by Excel File</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row" style="margin: 10px 0 20px 10px">
                                            <asp:LinkButton runat="server" ID="download" OnClick="download_Click" CssClass="font-weight-bold text-danger">Please upload the excel file only in this format. Click to download.</asp:LinkButton> 
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="col-xs-3">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <label>Select Excel File<label class="lblr">*</label></label>
                                                <asp:FileUpload ID="fu_Excel" runat="server" CssClass="form-control" />
                                                <br />
                                            </div>
                                            <div class="col-xs-3">
                                                <br />
                                                <center>
                                                    <asp:Button ID="btn_Submit" runat="server" Text="Add Inventory By Excel File" CssClass="btn btn-primary" OnClick="btn_Submit_Click" /></center>
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
</asp:Content>

