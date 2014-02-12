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
        grProducts.DataCollection = new List<Object>() 
        { 
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 } ,
            new Product {Account = "1253658954215",AmmountAvailable = 100, Currency = 1,Name = "Pepito",Type = 4 }            
        };
        grProducts.Refresh();
    }
}