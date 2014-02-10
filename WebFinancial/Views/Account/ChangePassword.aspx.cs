using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentation.Security;

public partial class Views_Account_ChangePassword : WebView<ChangePasswordPresenter>, IChangePasswordView
{
    public string Password
    {
        get { return password.Text; }
    }

    public string NewPassword
    {
        get { return newPassword.Text; }
    }

    public string ConfirmPassword
    {
        get { return confirmPassword.Text; }
    }

    protected void Accept_OnClick(object sender, EventArgs e)
    {
        Presenter.ChangePassword();
    }
}
