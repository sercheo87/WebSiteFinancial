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
       
        consolidateProduct.ProductTypeActives = new List<int>() { 3, 4 };
        consolidateProduct.ProductTypePasives = new List<int>() { 7 };

        chConsolidate2.ProductTypeActives = new List<int>() { 3, 4 };
        chConsolidate2.ProductTypePasives = new List<int>() { 7 };
    }
}