<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Views_Account_Login" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            $(document).validate({ actionButton: '#<%=accept.ClientID %>', successMessageItem: '[controlID=validationSuccess]', errorMessageItem: '[controlID=validationError]' });
        });
    </script>
    <div class="container-fluid">
        <div class="row">
            <uc:MessageZone ID="validationSuccess" CssClass="loginComplete" MessageType="Info" Text="<%$Resources: WebUIMessages, DefaultValidationSuccess%>" runat="server" />
            <uc:MessageZone ID="validationError" CssClass="loginComplete" MessageType="Warning" Text="<%$Resources: WebUIMessages, DefaultValidationError%>" runat="server" />
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="panel-title">
                        <asp:Literal runat="server" Text="<%$Resources: WebUILabels, LogIn %>" />
                    </h2>
                </div>
                <div class="panel-body">
                    <div role="form">

                        <div class="form-group">
                            <label for="inputEmail3" class="control-label">
                                <asp:Literal runat="server" Text="<%$Resources: WebUILabels, Username %>" />
                            </label>
                            <asp:TextBox ID="username" CssClass="form-control required" runat="server" data-toggle="tooltip" title="<%$Resources: WebUIMessages, ToolTipUsername %>" />
                        </div>

                        <div class="form-group">
                            <label for="inputPassword3" class="control-label">
                                <asp:Literal runat="server" Text="<%$Resources: WebUILabels, Password %>" />
                            </label>
                            <asp:TextBox ID="password" CssClass="form-control required" runat="server" TextMode="Password" data-toggle="tooltip" title="<%$Resources: WebUIMessages, ToolTipPassword %>" />
                        </div>

                        <div class="form-group">
                            <asp:Button ID="accept" runat="server" CssClass="btn btn-primary" Text="<%$Resources: WebUILabels, Accept %>" OnClick="Accept_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
