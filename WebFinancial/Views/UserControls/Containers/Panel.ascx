<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Panel.ascx.cs" Inherits="Views_UserControls_Panel" %>
<style>
    .panel-heading {
        cursor: pointer;
    }

    /* CSS Method for adding Font Awesome Chevron Icons */
    .accordion-toggle:after {
        /* symbol for "opening" panels */
        font-family: 'FontAwesome';
        content: "\f077";
        float: right;
        color: inherit;
    }

    .panel-heading.collapsed .accordion-toggle:after {
        /* symbol for "collapsed" panels */
        content: "\f078";
    }
</style>
<asp:Panel ID="pnlCtrlPanel" runat="server" CssClass="panel">
    <asp:Panel runat="server" CssClass="panel-heading collapsed" ID="pnHeaderPanel" ClientIDMode="AutoID">
        <span class="panel-title accordion-toggle"><%=Title %>
            <asp:PlaceHolder ID="placeHeaderContent" runat="server" />
        </span>
    </asp:Panel>
    <asp:Panel runat="server" CssClass="panel-collapse" ID="pnCollapse" ClientIDMode="AutoID">
        <div class="panel-body">
            <asp:PlaceHolder ID="placeHolderContent" runat="server" />
        </div>
    </asp:Panel>
</asp:Panel>
