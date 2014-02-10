using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_View : System.Web.UI.MasterPage
{
    protected void loginDisplay_Command(object sender, CommandEventArgs e)
    {
        switch (e.CommandName.ToUpper())
        {
            case "LOGIN": Response.Redirect("~/Views/Account/Login.aspx");
                break;
            case "LOGOUT": Response.Redirect("~/Views/Account/Logout.aspx");
                break;
        }
    }
}
