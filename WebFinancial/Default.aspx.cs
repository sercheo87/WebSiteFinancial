using DataObjects.Managment;
using Presentation.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : WebView<SummaryPresenter>, ISummaryView
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

    #region Public Parameters Data
    public string dtSeries { get; set; }
    public string dtDrillDownSeries { get; set; }
    public string Xaxis { get; set; }
    protected List<ChartExSeries> chListSeries = new List<ChartExSeries>();
    protected List<ChartExDrillDown> chListDrill = new List<ChartExDrillDown>();
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
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        consolidateProduct.ProductTypeActives = new List<int>() { 3, 4 };
        consolidateProduct.ProductTypePasives = new List<int>() { 7 };

        GetDataProducts();
    }

    public void GetDataProducts()
    {
        Presenter.GetProducts();

        var obj = ProductsCollection.GroupBy(g => g.Type);
        foreach (var typeProduct in obj)
        {
            int valueFilter = int.Parse(typeProduct.Key.ToString());
            List<Product> collectionFilter = ProductsCollection.Where(x => x.Type == valueFilter).ToList();
            CreateDtoStructure(valueFilter, collectionFilter);
        }
        JavaScriptSerializer oSerializer1 = new JavaScriptSerializer();
        dtSeries = oSerializer1.Serialize(chListSeries);

        JavaScriptSerializer oSerializer2 = new JavaScriptSerializer();
        dtDrillDownSeries = oSerializer2.Serialize(chListDrill);
    }

    protected string GetDataProductsMovements()
    {
        Presenter.GetMovements();
        foreach (ProductMovements item in ProductMovementsCollection)
        {
            ChartExSeries chSerie = new ChartExSeries();
            chSerie.name = item.Date.ToShortDateString();
            chSerie.y = item.AmmountTransfer;
            chSerie.msg = item.Description;
            chListSeries.Add(chSerie);
        }
        JavaScriptSerializer oSerializer1 = new JavaScriptSerializer();
        return oSerializer1.Serialize(chListSeries);
    }

    protected void CreateDtoStructure(int TypesProduct, List<Product> collectionDto)
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
    }

    public void ListMovementsByAccount(IEnumerable<ProductMovements> productsMovements)
    {
        ProductMovementsCollection = productsMovements.ToList();
    }
    #endregion
}