<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarButtons.ascx.cs" Inherits="Views_UserControls_BarButtons" %>

<div class="text-center">
    <asp:LinkButton runat="server" ID="btAccept" Text="Acceptar" type="button" class="btn btn-success actionButton"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="btCancel" Text="Cancelar" type="button" class="btn btn-danger actionButton"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="btBack" Text="Retroceder" type="button" class="btn btn-default actionButton"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="btConfirm" Text="Confirmar" type="button" class="btn btn-success actionButton"><%#TextBtConfirm %> <i class="fa fa-floppy-o"></i></asp:LinkButton>
    <asp:LinkButton runat="server" ID="btHelp" Text="Ayuda" type="button" class="btn btn-info actionButton"></asp:LinkButton>
</div>
