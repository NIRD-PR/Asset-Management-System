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
                                    <div class="tab-content" style="background: #E4EDFA; text-align:center;">
                                        <div class="tab-pane active" id="login" style="min-height: 440px; height: 440px; overflow-y: auto; overflow-x: hidden; margin-bottom: 0; padding-bottom: 0;">
                                            <br />
                                            <asp:DataList ID="dl_Data" Visible="true" runat="server" AutoGenerateColumns="false"
                                                RepeatColumns="2" CellSpacing="5">
                                                <ItemTemplate>
                                                    <table width="100%" class="table table-bordered">
                                                        <tr><th><%# Eval("Description") %></th></tr>
                                                        <tr><td><a class="player" style="height: 300px; width: 500px; display: block" href='<%# Eval("Id", "../UploadVideoFile.ashx?Id={0}") %>'></a></td></tr>
                                                    </table>
                                                    
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <script src="../FlowPlayer/flowplayer-3.2.12.min.js" type="text/javascript"></script>
                                            <script type="text/javascript">
                                                flowplayer("a.player", "../FlowPlayer/flowplayer-3.2.16.swf", {
                                                    plugins: {
                                                        pseudo: { url: "../FlowPlayer/flowplayer.pseudostreaming-3.2.12.swf" }
                                                    },
                                                    clip: { provider: 'pseudo', autoPlay: false },
                                                });
                                            </script>

                                        </div>
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

