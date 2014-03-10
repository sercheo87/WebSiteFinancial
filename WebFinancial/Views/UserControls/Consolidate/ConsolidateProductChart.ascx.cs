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

public partial class Views_UserControls_Consolidate_Product : System.Web.UI.UserControl
{
    public class ChartExSeries
    {
        public string name { get; set; }
        //public List<object> data { get; set; }
        public string drilldown { get; set; }
        public object y { get; set; }
    }
    public class ChartExDrillDown
    {
        public string name { get; set; }
        public List<object> data { get; set; }
        public string id { get; set; }
    }

    #region Public Parameters Dto Product Collection
    /// <summary>
    /// Collection of data products
    /// </summary>
    public List<Product> ProductsCollection
    {
        get { return (List<Product>)ViewState["ProductsCollection"]; }
        set { ViewState["ProductsCollection"] = value; }
    }

    /// <summary>
    /// List product of type actives
    /// </summary>
    public List<int> ProductTypeActives
    {
        get { return (List<int>)ViewState["ProductTypeActives"]; }
        set { ViewState["ProductTypeActives"] = value; }
    }

    /// <summary>
    /// List product of type pasives
    /// </summary>
    public List<int> ProductTypePasives
    {
        get { return (List<int>)ViewState["ProductTypePasives"]; }
        set { ViewState["ProductTypePasives"] = value; }
    }
    #endregion

    #region Public Parameters Data
    public string dtSeries { get; set; }
    public string dtDrillDownSeries { get; set; }
    public string Xaxis { get; set; }
    #endregion

    #region Public Properties Look&Feel
    public int HeigthChart
    {
        get
        {
            if (ViewState["HeigthChart"] == null)
                return 400;
            else
                return (int)ViewState["HeigthChart"];
        }
        set { ViewState["HeigthChart"] = value; }
    }
    public int WidthChart
    {
        get
        {
            if (ViewState["WidthChart"] == null)
                return 0;
            else
                return (int)ViewState["WidthChart"];
        }
        set { ViewState["WidthChart"] = value; }
    }
    public string AllowExport
    {
        get { return (string)ViewState["AllowExport"]; }
        set { ViewState["AllowExport"] = value.ToString().ToLower(); }
    }
    #endregion

    #region Public Label's
    public string TitleXAxis
    {
        get
        {
            if (ViewState["TitleXAxis"] == null)
                return string.Empty;
            else
                return (string)ViewState["TitleXAxis"];
        }
        set { ViewState["TitleXAxis"] = value.ToString(); }
    }
    public string TitleYAxis
    {
        get
        {
            if (ViewState["TitleYAxis"] == null)
                return string.Empty;
            else
                return (string)ViewState["TitleYAxis"];
        }
        set { ViewState["TitleYAxis"] = value.ToString(); }
    }
    public string TitleChart
    {
        get
        {
            if (ViewState["TitleChart"] == null)
                return string.Empty;
            else
                return (string)ViewState["TitleChart"];
        }
        set { ViewState["TitleChart"] = value.ToString(); }
    }
    public string SubTitleChart
    {
        get
        {
            if (ViewState["SubTitleChart"] == null)
                return string.Empty;
            else
                return (string)ViewState["SubTitleChart"];
        }
        set { ViewState["SubTitleChart"] = value.ToString(); }
    }
    #endregion

    protected List<ChartExSeries> chListSeries = new List<ChartExSeries>();
    protected List<ChartExDrillDown> chListDrill = new List<ChartExDrillDown>();

    protected void Page_InitComplete(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Render_Chart();

        /*Activas - Yaxis*/
        //------------------------------------------------------------------
        ChartExSeries chSerieActivas = new ChartExSeries();
        chSerieActivas.name = "Activas";
        chSerieActivas.y = 2500;
        chSerieActivas.drilldown = "_DrillActivas";

        ChartExDrillDown _DrillActivas = new ChartExDrillDown();
        _DrillActivas.id = "_DrillActivas";
        _DrillActivas.name = "_DrillActivas";
        _DrillActivas.data = new List<object>();
        _DrillActivas.data.Add(new List<object>() { "Cta: 11111111", 1000 });
        _DrillActivas.data.Add(new List<object>() { "Cta: 22222222", 1000 });
        _DrillActivas.data.Add(new List<object>() { "Cta: 33333333", 500 });

        //chListDrill.Add(_DrillActivas);
        //chListSeries.Add(chSerieActivas);
        //------------------------------------------------------------------

        /*Pasivas - Yaxis*/
        //------------------------------------------------------------------       
        ChartExSeries chSeriePasivas = new ChartExSeries();
        chSeriePasivas.name = "Pasivas";
        chSeriePasivas.y = 1200;
        chSeriePasivas.drilldown = "_DrillPasivas";

        ChartExDrillDown _DrillPasivas = new ChartExDrillDown();
        _DrillPasivas.id = "_DrillPasivas";
        _DrillPasivas.name = "_DrillPasivas";
        _DrillPasivas.data = new List<object>();
        _DrillPasivas.data.Add(new List<object>() { "Cta: 44444444", 1000 });
        _DrillPasivas.data.Add(new List<object>() { "Cta: 55555555", 200 });

        // chListDrill.Add(_DrillPasivas);
        //chListSeries.Add(chSeriePasivas);
        //------------------------------------------------------------------

        //JavaScriptSerializer oSerializer1 = new JavaScriptSerializer();
        //dtSeries = oSerializer1.Serialize(chListSeries);

        //JavaScriptSerializer oSerializer2 = new JavaScriptSerializer();
        //dtDrillDownSeries = oSerializer2.Serialize(chListDrill);
    }

    protected void Render_Chart()
    {
        var obj = ProductsCollection.GroupBy(g => g.Type);
        foreach (var typeProduct in obj)
        {
            int valueFilter = int.Parse(typeProduct.Key.ToString());
            List<Product> collectionFilter = ProductsCollection.Where(x => x.Type == valueFilter).ToList();
            CreateSeries(valueFilter, collectionFilter);
        }
        JavaScriptSerializer oSerializer1 = new JavaScriptSerializer();
        dtSeries = oSerializer1.Serialize(chListSeries);

        JavaScriptSerializer oSerializer2 = new JavaScriptSerializer();
        dtDrillDownSeries = oSerializer2.Serialize(chListDrill);
    }

    protected void CreateSeries(int TypesProduct, List<Product> collectionDto)
    {
        string lbProduct = (GetGlobalResourceObject("WebUILabels", string.Concat("Product_", TypesProduct)) == null ? string.Empty : GetGlobalResourceObject("WebUILabels", String.Concat("Product_", TypesProduct)).ToString());
        string lbDrill = String.Concat("_Drill_", TypesProduct);
        ChartExSeries chSerie = new ChartExSeries();
        chSerie.name = lbProduct;
        chSerie.y = collectionDto.Where(x => ProductTypeActives.Contains(TypesProduct)).Sum(x => x.AmmountAvailable);
        chSerie.drilldown = lbDrill;

        ChartExDrillDown _Drill = new ChartExDrillDown();
        _Drill.id = lbDrill;
        _Drill.name = lbDrill;
        _Drill.data = new List<object>();

        foreach (Product item in collectionDto)
        {
            _Drill.data.Add(new List<object>() { 
                String.Concat("Cta:", item.Account), 
                item.AmmountAvailable
            });
        }

        chListDrill.Add(_Drill);
        chListSeries.Add(chSerie);
    }
}