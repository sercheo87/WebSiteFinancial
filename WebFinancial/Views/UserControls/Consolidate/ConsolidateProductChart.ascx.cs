using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using DataObjects.Managment;
using System.Globalization;
using Presentation.Managment;
using System.ComponentModel;

public partial class Views_UserControls_Consolidate_Product_Chart : WebUserControl<SummaryPresenter>, ISummaryView
{

    protected void Page_InitComplete(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public void ListProduct(IEnumerable<Product> dataProducts)
    {
        throw new NotImplementedException();
    }

    public void ListMovementsByAccount(IEnumerable<ProductMovements> productsMovements)
    {
        throw new NotImplementedException();
    }
}