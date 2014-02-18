<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Grid.ascx.cs" Inherits="Views_UserControls_Grid" %>
<script src="http://elvery.net/demo/responsive-tables/assets/js/prettify.js" type="text/javascript"></script>
<script>
    $(function () {
        prettyPrint();
    });
</script>

<asp:UpdatePanel ID="upGrid" runat="server" ClientIDMode="Static" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row">
            <asp:Panel ID="pnlToolbar" runat="server" CssClass="col-md-12">
                <div class="btn-group btn-group-sm">
                    <asp:LinkButton runat="server" ID="btSelectAll" CssClass="btn btn-default" OnClick="btSelectAll_Click"><i class="fa fa-check-square"></i> Select All</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btDeleteAll" CssClass="btn btn-default" OnClick="btDeleteAll_Click"><i class="fa fa-eraser"></i> Delete</asp:LinkButton>
                </div>

                <div class="btn-group btn-group-sm pull-right">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"><i class="fa fa-file"></i>Export <span class="caret"></span></button>
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
            </asp:Panel>

            <div id="flip-scroll" class="col-md-12">
                <asp:GridView ID="gvGrid"
                    OnPreRender="gvGrid_PreRender"
                    ClientIDMode="Static"
                    OnDataBound="CustomersGridView_DataBound"
                    OnRowDataBound="gvGrid_RowDataBound"
                    OnPageIndexChanging="gvGrid_PageIndexChanging"
                    EmptyDataText="No data available."
                    data-page-navigation="pagination"
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

                    <FooterStyle BackColor="LightCyan"
                        ForeColor="MediumBlue" />
                    <PagerTemplate>
                        <div class="form-inline pagination" role="form">
                            <div class="form-group">
                                <asp:Label ID="MessageLabel"
                                    CssClass="control-label"
                                    Text="Select a page:"
                                    runat="server" />
                                <asp:DropDownList ID="PageDropDownList"
                                    CssClass="form-control input-sm"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged"
                                    runat="server" />
                            </div>
                            <div class="form-group pull-right">
                                <label>
                                    Page 
                            <span class="badge">
                                <asp:Literal ID="CurrentPageLabel" runat="server"></asp:Literal>
                            </span>
                                    of 
                            <span class="badge">
                                <asp:Literal ID="TotalPageLabel" runat="server"></asp:Literal>
                            </span>
                                </label>
                            </div>
                        </div>
                    </PagerTemplate>
                </asp:GridView>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btExportXml" />
        <asp:PostBackTrigger ControlID="btExportPdf" />
        <asp:PostBackTrigger ControlID="btExportWord" />
        <asp:PostBackTrigger ControlID="btExportCsv" />
    </Triggers>
</asp:UpdatePanel>
