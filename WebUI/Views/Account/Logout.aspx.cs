using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Presentation.Security;

public partial class Views_Account_Logout : WebView<LogoutPresenter>, ILogoutView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Presenter.Logout();
    }

    public void DoLogoutSuccess()
    {
        FormsAuthentication.SignOut();
    }
}