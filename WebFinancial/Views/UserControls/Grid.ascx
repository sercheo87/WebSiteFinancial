<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Grid.ascx.cs" Inherits="Views_UserControls_Grid" %>

<div class="table-responsive">
    <asp:UpdatePanel runat="server" ClientIDMode="AutoID" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvGrid" runat="server">
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
