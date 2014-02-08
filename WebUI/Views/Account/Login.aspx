<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Views_Account_Login" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            $(document).validate({ actionButton: '#<%=accept.ClientID %>', successMessageItem: '[controlID=validationSuccess]', errorMessageItem: '[controlID=validationError]' });
        });
    </script>
    <div class="section login center">
        <uc:MessageZone ID="validationSuccess" CssClass="loginComplete" MessageType="Information" Text="<%$Resources: WebUIMessages, DefaultValidationSuccess%>" runat="server" />
        <uc:MessageZone ID="validationError" CssClass="loginComplete" MessageType="Warning" Text="<%$Resources: WebUIMessages, DefaultValidationError%>" runat="server" />
        <h2><asp:Literal runat="server" Text="<%$Resources: WebUILabels, LogIn %>" /></h2>
        <div class="center">
            <table>
                <tr>
                    <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, Username %>" /></td>
                    <td><asp:TextBox ID="username" CssClass="required" runat="server" toolTipText="<%$Resources: WebUIMessages, ToolTipUsername %>" /></td>
                </tr>
                <tr>
                    <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, Password %>" /></td>
                    <td><asp:TextBox ID="password" CssClass="required" runat="server" TextMode="Password" toolTipText="<%$Resources: WebUIMessages, ToolTipPassword %>" /></td>
                </tr>
            </table>
        </div>
        <div class="buttonsBar">
            <asp:Button ID="accept" runat="server" CssClass="default" Text="<%$Resources: WebUILabels, Accept %>" OnClick="Accept_OnClick" />
        </div>
    </div>
</asp:Content>