﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.master" CodeFile="Default.aspx.cs" Inherits="Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <section>
        <!-- Nav tabs -->
        <ul class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">Home</a></li>
            <li><a href="#profile" data-toggle="tab">Profile</a></li>
            <li><a href="#messages" data-toggle="tab">Messages</a></li>
            <li><a href="#settings" data-toggle="tab">Settings</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div class="tab-pane active" id="home">
                <uc:ConsolidateProductChart ID="chConsolidate2"
                    runat="server"
                    HeigthChart="300"
                    AllowExport="false"
                    TypeXAxis="category"
                    ShowMovementsAccount="true"
                    TypeChart="line"
                    SeriesName="Producto"
                    TitleXAxis="Productos"
                    TitleYAxis="Valor"
                    TitleChart="Posicion Consolidada"
                    SubTitleChart="Detalle de Totalizado de Cuentas" />
                <p>dddd</p>
            </div>
            <div class="tab-pane" id="profile">tabulador2</div>
            <div class="tab-pane" id="messages">tabulador3</div>
            <div class="tab-pane" id="settings">tabulador4</div>
        </div>
    </section>
    <uc:PanelControl runat="server" ID="pnlConsolidate" Title="Consolidado" TypePanel="DEFAULT">
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
