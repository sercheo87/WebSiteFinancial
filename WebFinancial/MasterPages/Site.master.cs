using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects.Managment;

public partial class MasterPages_Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Product> data = new List<Product>();
        data.Add(new Product() { Account = "123456789", AmmountAvailable = 12.2, Currency = 4, Name = "Cuenta Amiga 1", Type = 4 });
        data.Add(new Product() { Account = "589663254", AmmountAvailable = 256.32, Currency = 4, Name = "Cuenta Amiga 2", Type = 3 });
        data.Add(new Product() { Account = "588963211", AmmountAvailable = 4000.2, Currency = 4, Name = "Cuenta Amiga 3", Type = 7 });
        data.Add(new Product() { Account = "588964555", AmmountAvailable = 122.2, Currency = 4, Name = "Cuenta Amiga 4", Type = 4 });

        chConsolidate.ProductTypeActives = new List<int>() { 3, 4 };
        chConsolidate.ProductTypePasives = new List<int>() { 7 };
        chConsolidate.ProductsCollection = data;
    }
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
