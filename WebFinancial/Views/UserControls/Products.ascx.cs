using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentation.Managment;
using Shared.Commons;

public partial class Views_UserControls_Products : WebUserControl<SummaryPresenter>, ISummaryView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadProducts();
    }

    private void LoadProducts()
    {
        if (CurrencyType == null)
            Presenter.GetProducts(ShowProducts);
        else
            Presenter.GetProducts(ShowProducts, (int)CurrencyType);
    }
    #region Public Properties

    public DropDownList ProductList
    {
        get { return ddProductList; }
    }

    public UtilsConstants.TypeProductsFilters ShowProducts
    {
        get { return (UtilsConstants.TypeProductsFilters)ViewState["ShowProducts"]; }
        set { ViewState["ShowProducts"] = value; }
    }

    public int? CurrencyType
    {
        get { return (int?)ViewState["CurrencyType"]; }
        set { ViewState["CurrencyType"] = value; }
    }
    #endregion

    #region Interface
    public void ListProduct(IEnumerable<DataObjects.Managment.Product> dataProducts)
    {
        var dt = dataProducts.Select(x => new { key = String.Format("[{0}] - {1}", x.Name, x.Account), value = x.Account });
        ddProductList.DataTextField = "key";
        ddProductList.DataValueField = "value";
        ddProductList.DataSource = dt;
        ddProductList.DataBind();
    }

    public void ListMovementsByAccount(IEnumerable<DataObjects.Managment.ProductMovements> productsMovements)
    {
        throw new NotImplementedException();
    }
    #endregion
}