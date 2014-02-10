<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true" 
    CodeFile="Display.aspx.cs" Inherits="Views_Settings_Display" %>

<asp:Content ID="BodyContent" Runat="Server" ContentPlaceHolderID="MainContent">
    <div class="section">
        <h2><asp:Literal runat="server" Text="<%$Resources: WebUILabels, DisplaySettings%>" /></h2>
        <table>
            <tr>
                <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, Language %>" /></td>
                <td><asp:DropDownList ID="languages" runat="server" toolTipText="<%$Resources: WebUIMessages, ToolTipLanguage %>" /></td>
            </tr>
            <tr>
                <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, Theme %>" /></td>
                <td><asp:DropDownList ID="themes" runat="server" toolTipText="<%$Resources: WebUIMessages, ToolTipTheme %>" /></td>
            </tr>
        </table>
        <div class="buttonsBar">
            <asp:Button ID="accept" runat="server" CssClass="default" Text="<%$Resources: WebUILabels, Apply %>" OnClick="Accept_OnClick" />
        </div>
    </div>
</asp:Content>

