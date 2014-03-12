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
        chChartColumnGroup.ProductTypeActives = new List<int>() { 3, 4 };
        chChartColumnGroup.ProductTypePasives = new List<int>() { 7 };

        consolidateProduct.ProductTypeActives = new List<int>() { 3, 4 };
        consolidateProduct.ProductTypePasives = new List<int>() { 7 };

        chChartLineMovement.ProductTypeActives = new List<int>() { 3, 4 };
        chChartLineMovement.ProductTypePasives = new List<int>() { 7 };
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        PanelControl1.Visible = true;
    }
}