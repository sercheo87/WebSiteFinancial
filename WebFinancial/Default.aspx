<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.master" CodeFile="Default.aspx.cs" Inherits="Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

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
