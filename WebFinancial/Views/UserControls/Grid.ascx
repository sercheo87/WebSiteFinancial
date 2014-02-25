<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Grid.ascx.cs" Inherits="Views_UserControls_Grid" %>
<script src="http://elvery.net/demo/responsive-tables/assets/js/prettify.js" type="text/javascript"></script>
<script>
    $(function () {
        prettyPrint();
    });
</script>

<asp:UpdatePanel ID="upGrid" runat="server" ClientIDMode="Static" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="panel panel-default">
            <asp:Panel ID="pnlToolbar" runat="server" CssClass="panel-heading">
                <div class="form-inline" role="form">
                    <div class="row">
                        <asp:Panel ID="pnlToolExport" runat="server" CssClass="col-sm-4">
                            <div class="form-group">
                                <div class="btn-group btn-group-sm ">
                                    <asp:LinkButton runat="server" ID="btSelectAll" CssClass="btn btn-default" OnClick="btSelectAll_Click"><i class="fa fa-check-square"></i> Select All</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btDeleteAll" CssClass="btn btn-default" OnClick="btDeleteAll_Click"><i class="fa fa-eraser"></i> Delete</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btPrint" CssClass="btn btn-default" OnClick="btPrint_Click"><i class="fa fa-print"></i> Print</asp:LinkButton>
                                    <button type="button" class="btn btn-sm btn-default dropdown-toggle" data-toggle="dropdown"><i class="fa fa-file"></i>Export <span class="caret"></span></button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="btExportXml" OnClick="btExportXml_Click">Xml</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="btExportPdf" OnClick="btExportPdf_Click">Pdf</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="btExportWord" OnClick="btExportWord_Click">Word</asp:LinkButton>
                                        </li>
                                        <li class="divider"></li>
                                        <li>
                                            <asp:LinkButton runat="server" ID="btExportCsv" OnClick="btExportCsv_Click">Csv</asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlToolFilter" runat="server" CssClass="col-sm-4">
                            <div class="form-group">
                                <div class="input-group input-group-sm">
                                    <%-- Filter Panel  --%>
                                    <asp:Panel runat="server" ID="pnlFilter" ClientIDMode="Static" CssClass="input-group-btn">
                                        <asp:LinkButton runat="server" ID="btFilterTagBy" CssClass="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">Filter by <span class="caret"></span></asp:LinkButton>
                                    </asp:Panel>
                                    <asp:TextBox runat="server" ID="txFilter" ClientIDMode="Static" CssClass="form-control input-sm" placeholder="Filter"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlToolGroups" runat="server" CssClass="col-sm-4">
                            <div class="form-group">
                                <label for="ddPagesSizes" class="hidden-xs control-label">Items:</label>
                                <asp:DropDownList runat="server" ID="ddPagesSizes" CssClass="input-sm form-control dropdown dropdown-toggle" ClientIDMode="Static">
                                    <asp:ListItem Selected="True">5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>

            <div class="flip-scroll">
                <asp:GridView ID="gvGrid"
                    OnPreRender="gvGrid_PreRender"
                    ClientIDMode="Static"
                    OnRowDataBound="gvGrid_RowDataBound"
                    EmptyDataText="No data available."
                    OnSorting="gvGrid_Sorting"
                    CellPadding="5"
                    CellSpacing="0"
                    EnableViewState="true"
                    runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>Selected</HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chSelected" CssClass="checkbox-inline" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Actions</HeaderTemplate>
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" CssClass="btn btn-default btn-xs" CommandName="Edit" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="DeleteButton" CssClass="btn btn-danger btn-xs" CommandName="Delete" runat="server"><i class="fa fa-eraser"></i></asp:LinkButton>
                                <asp:LinkButton ID="DetailButton" CssClass="btn btn-default btn-xs" CommandName="Detail" runat="server"><i class="fa fa-list-alt"></i></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-default btn-sm" CommandName="Update" Text="Update" />&nbsp;
                                <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-default btn-sm" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="upGrid">
                    <ProgressTemplate>
                        <div class="text-center">
                            <label><i class="fa fa-spinner fa-spin fa-2x"></i>Loagind..</label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>

            <asp:Panel runat="server" ID="pnlPaginator" ClientIDMode="Static" CssClass="panel-footer">
                <ul class="pager">
                    <li class="previous">
                        <asp:LinkButton runat="server" ID="btPrevios">&larr; Back</asp:LinkButton>
                    </li>
                    <li class="next">
                        <asp:LinkButton runat="server" ID="btNext" OnClick="btNext_Click">Next &rarr;</asp:LinkButton>
                    </li>
                </ul>
            </asp:Panel>
        </div>

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btNext" EventName="Click" />
        <asp:PostBackTrigger ControlID="btExportXml" />
        <asp:PostBackTrigger ControlID="btExportPdf" />
        <asp:PostBackTrigger ControlID="btExportWord" />
        <asp:PostBackTrigger ControlID="btExportCsv" />
    </Triggers>
</asp:UpdatePanel>
