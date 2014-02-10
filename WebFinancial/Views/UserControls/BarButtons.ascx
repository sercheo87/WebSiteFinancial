<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarButtons.ascx.cs" Inherits="Views_UserControls_BarButtons" %>

<footer class="row">
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-lg-4 col-lg-offset-4">
                <asp:Button runat="server" ID="btAccept" Text="Acceptar" type="button" class="btn btn-success actionButton" />
                <asp:Button runat="server" ID="btCancel" Text="Cancelar" type="button" class="btn btn-danger actionButton" />
                <asp:Button runat="server" ID="btBack" Text="Retroceder" type="button" class="btn btn-default actionButton" />
                <asp:Button runat="server" ID="btConfirm" Text="Confirmar" type="button" class="btn btn-success actionButton" />
                <asp:Button runat="server" ID="btHelp" Text="Ayuda" type="button" class="btn btn-info actionButton" />
            </div>
        </div>
    </div>
</footer>
