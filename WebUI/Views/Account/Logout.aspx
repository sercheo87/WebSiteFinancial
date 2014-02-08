<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true"
    CodeFile="Logout.aspx.cs" Inherits="Views_Account_Logout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        setTimeout(function () { window.location.href = "<%=Request.ApplicationPath %>"; }, 5000);
    </script>
    <div class="section logout">
        <asp:Literal runat="server" Text="<%$Resources: WebUIMessages, LogOutMessage %>"></asp:Literal>
    </div>
</asp:Content>

