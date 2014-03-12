<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.master" CodeFile="Default.aspx.cs" Inherits="Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <section>
        <!-- Nav tabs -->
        <ul id="mytab" class="nav nav-tabs">
            <li class="active">
                <asp:LinkButton runat="server" ID="btTam1" href="#home" Text="Ayuda" data-toggle="tab">Consolidado</asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton runat="server" href="#profile" ID="LinkButton1" data-toggle="tab" Text="Ayuda" OnClick="LinkButton1_Click">Movimientos de Cuenta</asp:LinkButton>
            </li>
            <li><a href="#messages" data-toggle="tab">Messages</a></li>
            <li><a href="#settings" data-toggle="tab">Settings</a></li>
        </ul>
        <!-- Tab panels -->
        <div class="tab-content">
            <div class="tab-pane active" id="home">

                <%-- Posicion Consolidada --%>
                <asp:Panel runat="server" ID="chart1">
                    <uc:ConsolidateProductChart ID="chChartColumnGroup"
                        runat="server"
                        HeigthChart="300"
                        AllowExport="false"
                        TypeXAxis="category"
                        SeriesName="Producto"
                        TitleXAxis="Productos"
                        TitleYAxis="Valor"
                        NameChart="chardemo1"
                        TitleChart="Posicion Consolidada"
                        PanelNameChart="id_pnl_chart1"
                        SubTitleChart="Detalle de Totalizado de Cuentas" />

                </asp:Panel>
            </div>
            <div class="tab-pane" id="profile">
                <%-- Movimientos por Cuenta --%>
                <uc:PanelControl ID="PanelControl1" runat="server" ShowHeader="false">
                    <ContentBody>
                        <div class="form-horizontal">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="inputPassword3" class="col-md-2 control-label">Cuenta: </label>
                                    <div class="col-sm-10">
                                        <uc:Products ID="Products1" runat="server" ShowProducts="Actives" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="inputPassword3" class="col-md-2 control-label">Moneda: </label>
                                    <div class="col-sm-10">
                                        <uc:Products ID="Products2" runat="server" ShowProducts="Pasives" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <uc:ConsolidateProductChart ID="chChartLineMovement" EnableViewState="true" ViewStateMode="Enabled"
                            runat="server"
                            HeigthChart="300"
                            AllowExport="false"
                            TypeXAxis="category"
                            ShowMovementsAccount="true"
                            TypeChart="line"
                            SeriesName="Fecha"
                            TitleXAxis="Fechas"
                            TitleYAxis="Valor"
                            TitleChart="Movimientos de Transacciones"
                            PanelNameChart="home"
                            SubTitleChart="Detalle de las transacciones por Cuentas" />
                    </ContentBody>
                </uc:PanelControl>
            </div>
            <div class="tab-pane" id="messages">tabulador3</div>
            <div class="tab-pane" id="settings">tabulador4</div>
        </div>
    </section>
    <uc:PanelControl runat="server" ID="pnlConsolidate" Title="Consolidado" TypePanel="primary">
        <ContentBody>
            <p>sdsdsds</p>
        </ContentBody>
    </uc:PanelControl>
</asp:Content>

<asp:Content ID="LateralContent" runat="server" ContentPlaceHolderID="LateralContent">
    <uc:ConsolidateProduct runat="server" ID="consolidateProduct"></uc:ConsolidateProduct>
    <div class="list-group">
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item active">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
        <a href="#" class="list-group-item">Link</a>
    </div>
</asp:Content>

<asp:Content ID="HelpContent" runat="server" ContentPlaceHolderID="HelpContent">
</asp:Content>
