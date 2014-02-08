<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/View.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Views_Account_ChangePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            $('.newPasswordValidation').validateEquality();
            $(document).validate({ actionButton: '#<%=accept.ClientID %>' });
        });
    </script>
    <div class="section">
        <h2><asp:Literal runat="server" Text="<%$Resources: WebUILabels, ChangePassword%>"></asp:Literal></h2>
        <table>
            <tr>
                <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, Password %>" /></td>
                <td><asp:TextBox ID="password" CssClass="required" runat="server" TextMode="Password" toolTipText="<%$Resources: WebUIMessages, ToolTipCurrentPassword %>" /></td>
            </tr>
            <tr>
                <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, NewPassword %>" /></td>
                <td><asp:TextBox ID="newPassword" CssClass="required newPasswordValidation" runat="server" TextMode="Password" toolTipText="<%$Resources: WebUIMessages, ToolTipNewPassword %>" /></td>
            </tr>
            <tr>
                <td class="label"><asp:Literal runat="server" Text="<%$Resources: WebUILabels, ConfirmPassword %>" /></td>
                <td><asp:TextBox ID="confirmPassword" CssClass="required newPasswordValidation" runat="server" TextMode="Password" toolTipText="<%$Resources: WebUIMessages, ToolTipConfirmPassword %>" /></td>
            </tr>
        </table>
        <div class="buttonsBar">
            <asp:Button ID="accept" runat="server" CssClass="default" Text="<%$Resources: WebUILabels, Change %>" OnClick="Accept_OnClick" />
        </div>
    </div>
</asp:Content>
