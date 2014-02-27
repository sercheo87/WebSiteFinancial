<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.master" CodeFile="Default.aspx.cs" Inherits="Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<div class="publicity">
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <p>ddddddddddddd</p>
                </div>
                <div class="item">
                    <p>3333333333333</p>
                </div>
                <div class="item">
                    <p>44444444444</p>
                </div>
            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
            </a>
        </div>
    </div>--%>

    <uc:GridControl ID="grProducts" runat="server" TypeSelected="Cheked" idCode="Account" idSelection="Selected" />


    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="mdlItem" runat="server"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="updMessages" ClientIDMode="Static" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label runat="server" ID="msg"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>

<asp:Content ID="HelpContent" runat="server" ContentPlaceHolderID="HelpContent">
</asp:Content>
