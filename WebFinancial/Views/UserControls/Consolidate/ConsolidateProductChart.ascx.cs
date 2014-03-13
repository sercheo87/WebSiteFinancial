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

public partial class Views_UserControls_Consolidate_Product_Chart : WebUserControl<SummaryPresenter>, ISummaryView
{
    #region Clases Dto
    public class ChartExSeries
    {
        public string name { get; set; }
        //public List<object> data { get; set; }
        public string drilldown { get; set; }
        public object y { get; set; }
        public string msg { get; set; }
    }
    public class ChartExDrillDown
    {
        public string name { get; set; }
        public List<object> data { get; set; }
        public string id { get; set; }
    }
    #endregion

    #region Public Parameters Dto Product Collection
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
    public DotNet.Highcharts.Options.PlotOptions OptionsChart
    {
        get { }
        set { }
    }
    #endregion

    #region Public Properties Look&Feel
    public string GetSeparatorDecimal
    {
        get { return NumberFormatInfo.CurrentInfo.NumberDecimalSeparator; }
    }
    public string GetSeparatorGroup
    {
        get { return NumberFormatInfo.CurrentInfo.NumberGroupSeparator; }
    }
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
    public int? WidthChart
    {
        get
        {
            if (ViewState["WidthChart"] == null)
                return null;
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
    public string TypeChart
    {
        get
        {
            if (ViewState["TypeChart"] == null)
                return "column";
            else
                return (string)ViewState["TypeChart"];
        }
        set { ViewState["TypeChart"] = value; }
    }
    public string TypeXAxis
    {
        get
        {
            if (ViewState["TypeXAxis"] == null)
                return "category";
            else
                return (string)ViewState["TypeXAxis"];
        }
        set { ViewState["TypeXAxis"] = value; }
    }
    public bool ShowMovementsAccount
    {
        get
        {
            if (ViewState["ShowMovementsAccount"] == null)
                return false;
            else
                return (bool)ViewState["ShowMovementsAccount"];
        }
        set { ViewState["ShowMovementsAccount"] = value; }
    }
    public string NameChart
    {
        get
        {
            if (ViewState["NameChart"] == null)
                return "NameChart";
            else
                return (string)ViewState["NameChart"];
        }
        set { ViewState["NameChart"] = value; }
    }
    public string ContainerId
    {
        get { return (string)ViewState["ContainerId"]; }
        set { ViewState["ContainerId"] = value; }
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
    public string SeriesName
    {
        get
        {
            if (ViewState["SeriesName"] == null)
                return string.Empty;
            else
                return (string)ViewState["SeriesName"];
        }
        set { ViewState["SeriesName"] = value.ToString(); }
    }
    #endregion

    #region Properties Private
    private List<Product> ProductsCollection
    {
        get { return (List<Product>)ViewState["ProductsCollection"]; }
        set { ViewState["ProductsCollection"] = value; }
    }
    private List<ProductMovements> ProductMovementsCollection
    {
        get { return (List<ProductMovements>)ViewState["ProductMovementsCollection"]; }
        set { ViewState["ProductMovementsCollection"] = value; }
    }
    protected List<ChartExSeries> chListSeries = new List<ChartExSeries>();
    protected List<ChartExDrillDown> chListDrill = new List<ChartExDrillDown>();
    #endregion

    protected void Page_InitComplete(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (ShowMovementsAccount)
            Presenter.GetMovements();
        else
            Presenter.GetProducts();
    }

    protected void Render_Chart_Default()
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

    protected void Render_Chart_Line()
    {
        foreach (ProductMovements item in ProductMovementsCollection)
        {
            ChartExSeries chSerie = new ChartExSeries();
            chSerie.name = item.Date.ToShortDateString();
            chSerie.y = item.AmmountTransfer;
            chSerie.msg = item.Description;
            chListSeries.Add(chSerie);
        }
        JavaScriptSerializer oSerializer1 = new JavaScriptSerializer();
        dtSeries = oSerializer1.Serialize(chListSeries);

        JavaScriptSerializer oSerializer2 = new JavaScriptSerializer();
        dtDrillDownSeries = oSerializer2.Serialize(chListDrill);
    }

    protected void CreateSeries(int TypesProduct, List<Product> collectionDto)
    {
        string lbProduct = (GetGlobalResourceObject("WebUILabels", string.Concat("Product_", TypesProduct)) == null ? string.Empty : GetGlobalResourceObject("WebUILabels", String.Concat("Product_", TypesProduct)).ToString());
        string lbDrill = String.Concat("Cuentas", "");
        double totalAmmount = collectionDto.Where(x => x.Type == TypesProduct).Sum(x => x.AmmountAvailable);
        ChartExSeries chSerie = new ChartExSeries();
        chSerie.name = lbProduct;
        chSerie.y = totalAmmount;
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

    #region Interface
    public void ListProduct(IEnumerable<Product> dataProducts)
    {
        ProductsCollection = dataProducts.ToList();
        Render_Chart_Default();
    }

    public void ListMovementsByAccount(IEnumerable<ProductMovements> productsMovements)
    {
        ProductMovementsCollection = productsMovements.ToList();
        Render_Chart_Line();
    }
    #endregion
}