<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transfer_Demo.aspx.cs" Inherits="Views_Transfers_Transfer_Demo" MasterPageFile="~/MasterPages/Site.master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server" ID="upnShowData" ClientIDMode="Static" UpdateMode="Conditional">
        <ContentTemplate>
            <%--Form Data--%>
            <asp:Panel runat="server" ID="pnlFormData" CssClass="panel panel-default">
                <div class="panel-body">
                    <div class=" form-horizontal" role="form">
                        <div class="form-group">
                            <label for="txAccount" class="col-sm-2 control-label visible-md visible-lg">Account: </label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" CssClass="form-control" ID="txAccount" placeholder="Account Number"></asp:TextBox>
                            </div>
                        </div>
                        <uc:BarButtons runat="server" TextBtAccept="Demo" />
                    </div>
                </div>
            </asp:Panel>
            <%--Grid Data--%>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--Temporal--%>
    <asp:UpdatePanel runat="server" ID="updMessages" ClientIDMode="Static" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label runat="server" ID="msg"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
