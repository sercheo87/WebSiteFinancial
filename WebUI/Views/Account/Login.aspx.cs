using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Shared.Infrastructure.Messaging;
using Presentation.Security;

public partial class Views_Account_Login : WebView<LoginPresenter>, ILoginView
{
    public string Username
    {
        get { return username.Text; }
    }

    public string Password
    {
        get { return password.Text; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack && HttpContext.Current.User.Identity.IsAuthenticated)
            Response.Redirect("~/Default");
    }

    protected void Accept_OnClick(object sender, EventArgs e)
    {
        Presenter.Authenticate();
    }

    public void DoAuthenticateSuccess()
    {
        FormsAuthentication.RedirectFromLoginPage(Username, false);
    }
}
