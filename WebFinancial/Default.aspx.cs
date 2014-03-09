using DataObjects.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : WebView<object>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Product> data = new List<Product>();
        data.Add(new Product() { Account = "123456789", AmmountAvailable = 12.2, Currency = 4, Name = "Cuenta Amiga 1", Type = 4 });
        data.Add(new Product() { Account = "589663254", AmmountAvailable = 256.32, Currency = 4, Name = "Cuenta Amiga 2", Type = 3 });
        data.Add(new Product() { Account = "588963211", AmmountAvailable = 4000.2, Currency = 4, Name = "Cuenta Amiga 3", Type = 7 });
        data.Add(new Product() { Account = "588964555", AmmountAvailable = 122.2, Currency = 4, Name = "Cuenta Amiga 4", Type = 4 });

        consolidateProduct.ProductTypeActives = new List<int>() { 3, 4 };
        consolidateProduct.ProductTypePasives = new List<int>() { 7 };
        consolidateProduct.ProductsCollection = data;
    }
}