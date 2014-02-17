<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Grid.ascx.cs" Inherits="Views_UserControls_Grid" %>

<asp:UpdatePanel runat="server" ID="cntGrid" ClientIDMode="Static" UpdateMode="Conditional" class="table-responsive">
    <ContentTemplate>
        <div class="panel panel-default">
            <div class="panel-heading">
                <asp:Panel runat="server" ID="Toolbar" CssClass="btn-group btn-group-sm">
                    <asp:LinkButton runat="server" ID="btSelectAll" CssClass="btn btn-default" OnClick="btSelectAll_Click"><i class="fa fa-check-square"></i> Select All</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btDeleteAll" CssClass="btn btn-default" OnClick="btDeleteAll_Click"><i class="fa fa-eraser"></i> Delete</asp:LinkButton>
                </asp:Panel>

                <div class="btn-group btn-group-sm pull-right">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"><i class="fa fa-file"></i>Export <span class="caret"></span></button>
                    <ul class="dropdown-menu" role="menu">
                        <li>
                            <asp:LinkButton runat="server" ID="btExportXml" OnClick="btExportXml_Click">Xml</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="btExportPdf" OnClick="btExportPdf_Click">Pdf</asp:LinkButton>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <asp:LinkButton runat="server" ID="btExportTxt" OnClick="btExportTxt_Click">Txt</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gvGrid"
                    ClientIDMode="Static"
                    OnDataBound="CustomersGridView_DataBound"
                    OnRowDataBound="gvGrid_RowDataBound"
                    OnPageIndexChanging="gvGrid_PageIndexChanging"
                    EmptyDataText="No data available."
                    AllowPaging="true"
                    AllowSorting="true"
                    OnSorting="gvGrid_Sorting"
                    PageSize="5"
                    AutoGenerateColumns="true"
                    AutoGenerateSelectButton="false"
                    GridLines="None"
                    CellPadding="5"
                    CellSpacing="0"
                    EnableViewState="true"
                    ShowHeader="true"
                    data-page-navigation="pagination"
                    ShowFooter="false"
                    runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chSelected" CssClass="checkbox-inline" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" CssClass="btn btn-default btn-sm" CommandName="Edit" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="DeleteButton" CssClass="btn btn-danger btn-sm" CommandName="Delete" runat="server"><i class="fa fa-eraser"></i></asp:LinkButton>
                                <asp:LinkButton ID="DetailButton" CssClass="btn btn-default btn-sm" CommandName="Detail" runat="server"><i class="fa fa-list-alt"></i></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-default btn-sm" CommandName="Update" Text="Update" />&nbsp;
                                <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-default btn-sm" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <div class="form-inline" role="form">
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
</asp:UpdatePanel>
