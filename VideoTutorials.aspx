<%@ Page Title="" Language="C#" MasterPageFile="Website.master" AutoEventWireup="true" CodeFile="VideoTutorials.aspx.cs" Inherits="VideoTutorials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <section class="wrapper">
        <!--Start Slider-->
        <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
                <section class="feature_bottom">
                    <div class="container">
                        <div class="row sub_content">
                            <div class="col-md-12">
                                <div class="row">
                                    <ul class="nav nav-tabs navtab-bg">
                                        <li class="active">
                                            <a href="#login" data-toggle="tab" aria-expanded="false">
                                                <span class="visible-xs"><i class="fa fa-sign-in"></i></span>
                                                <span class="hidden-xs">A C R Video Manual</span>
                                            </a>
                                        </li>
                                    </ul>
                                    <div class="tab-content" style="background: #E4EDFA; text-align: center;">
                                       <center>
                                            <asp:DataList ID="dl_Data" Visible="true" runat="server" AutoGenerateColumns="false"
                                                RepeatColumns="4" CellSpacing="5">
                                                <ItemTemplate>
                                                    <table width="100%" class="table table-bordered">
                                                        <tr>
                                                            <th><%# Eval("Description") %></th>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <video width='100%' height='200' controls>
                                                                    <source src='<%#"../MediaPlayer/File/"+Eval("FileName")%>' type='video/mp4' />
                                                                </video>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </ItemTemplate>
                                            </asp:DataList>
                                           </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

