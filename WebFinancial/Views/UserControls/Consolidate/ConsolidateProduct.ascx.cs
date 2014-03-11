using ASP;
using DataObjects.Managment;
using Presentation.Managment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Views_UserControls_ConsolidateProduct : WebUserControl<SummaryPresenter>, ISummaryView
{
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

    #region Properties Private
    /// <summary>
    /// Collection of data products
    /// </summary>
    public List<Product> ProductsCollection
    {
        get { return (List<Product>)ViewState["ProductsCollection"]; }
        set { ViewState["ProductsCollection"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Presenter.GetProducts();
    }

    protected void GetAllSummaryProduts()
    {

        var obj = ProductsCollection.GroupBy(g => g.Type);
        foreach (var typeProduct in obj)
        {
            int valueFilter = int.Parse(typeProduct.Key.ToString());
            var collectionFilter = ProductsCollection.Where(x => x.Type == valueFilter).ToList();
            pnlParent.Controls.Add(CreateSectionBalance(collectionFilter));
        }
    }
    protected Views_UserControls_Panel CreateSectionBalance(List<Product> collecctionData)
    {
        Views_UserControls_Panel pnlControlItem = (Views_UserControls_Panel)Page.LoadControl("~/Views/UserControls/Containers/Panel.ascx");
        pnlControlItem.ShowHeader = true;
        pnlControlItem.IdParentContainer = pnlParent.ClientID;
        pnlControlItem.TypePanel = Views_UserControls_Panel.TypePanelList.primary;

        //Header
        HtmlGenericControl itemIcon = new HtmlGenericControl("i");
        Literal ltText = new Literal();
        string lbProduct = (GetGlobalResourceObject("WebUILabels", string.Concat("Product_", collecctionData[0].Type)) == null ? string.Empty : GetGlobalResourceObject("WebUILabels", String.Concat("Product_", collecctionData[0].Type)).ToString());
        ltText.Text = String.Concat(" ", lbProduct, " : ", collecctionData.Sum(x => x.AmmountAvailable).ToString("C2"));
        itemIcon.Attributes["class"] = "fa fa-money fa-lg";
        pnlControlItem.PlaceHeaderContent.Controls.Add(itemIcon);
        pnlControlItem.PlaceHeaderContent.Controls.Add(ltText);

        //Content
        Repeater rpBodyContent = new Repeater();
        rpBodyContent.DataSource = collecctionData;
        rpBodyContent.DataBind();
        foreach (RepeaterItem repeatItem in rpBodyContent.Items)
        {
            int index = repeatItem.ItemIndex;
            Product productItem = ((IList<Product>)rpBodyContent.DataSource)[index];
            // Add ItemTemplate DataItems Dynamically
            RepeaterItem repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Item);
            //fila
            Panel pnRow = new Panel();
            pnRow.CssClass = "row";
            //columna etiqueta
            Panel pnlColEtq = new Panel();
            pnRow.Controls.Add(pnlColEtq);
            pnlColEtq.CssClass = "col-md-7";
            HtmlGenericControl lbEtqDl = new HtmlGenericControl("dl");
            pnlColEtq.Controls.Add(lbEtqDl);
            HtmlGenericControl lbEtqDt = new HtmlGenericControl("dt");
            lbEtqDl.Controls.Add(lbEtqDt);
            HtmlGenericControl hgIcon = new HtmlGenericControl("i");
            hgIcon.Attributes["class"] = "fa fa-bars";
            lbEtqDt.Controls.Add(hgIcon);
            //lbEtqDt.Attributes["class"] = "text-right";
            Literal ltEtiqueta = new Literal();
            lbEtqDt.Controls.Add(ltEtiqueta);
            HtmlGenericControl lbEtqDd = new HtmlGenericControl("dd");
            lbEtqDl.Controls.Add(lbEtqDd);
            HtmlGenericControl lbEtqSmall = new HtmlGenericControl("small");
            lbEtqDd.Controls.Add(lbEtqSmall);

            ltEtiqueta.Text = " " + String.Format("{0:#####-####-####}", double.Parse(productItem.Account));
            lbEtqSmall.InnerText = productItem.Name;
            //columna Valor
            Panel pnlColValue = new Panel();
            pnRow.Controls.Add(pnlColValue);
            pnlColValue.CssClass = "col-md-5 text-right";
            Label lbValue = new Label();
            pnlColValue.Controls.Add(lbValue);
            lbValue.Text = productItem.AmmountAvailable.ToString("C2");

            repeatItem.Controls.Add(pnRow);
        }

        pnlControlItem.PlaceHolderContent.Controls.Add(rpBodyContent);
        return pnlControlItem;
    }

    protected Views_UserControls_Panel CreateSectionTotal()
    {
        Views_UserControls_Panel pnlControlItem = (Views_UserControls_Panel)Page.LoadControl("~/Views/UserControls/Containers/Panel.ascx");
        pnlControlItem.ShowHeader = false;
        pnlControlItem.IdParentContainer = pnlParent.ClientID;
        pnlControlItem.TypePanel = Views_UserControls_Panel.TypePanelList.primary;

        DataTable dtSummaryBalance = new DataTable();
        dtSummaryBalance.Columns.Add("key");
        dtSummaryBalance.Columns.Add("value");
        dtSummaryBalance.Columns.Add("tendency");
        dtSummaryBalance.Columns.Add("final");

        double valActives = ProductsCollection.Where(x => ProductTypeActives.Contains(x.Type)).Sum(x => x.AmmountAvailable);
        double valPasives = ProductsCollection.Where(x => ProductTypePasives.Contains(x.Type)).Sum(x => x.AmmountAvailable);
        double valReal = valActives - valPasives;

        dtSummaryBalance.Rows.Add(new object[] { Resources.WebUILabels.Total_Actives, valActives.ToString("C2"), (valActives >= 0 ? "+" : "-"), false });
        dtSummaryBalance.Rows.Add(new object[] { Resources.WebUILabels.Total_Passive, valPasives.ToString("C2"), (valPasives >= 0 ? "+" : "-"), false });
        dtSummaryBalance.Rows.Add(new object[] { Resources.WebUILabels.Total_Real, valReal.ToString("C2"), (valReal >= 0 ? "+" : "-"), true });
        //Content
        Repeater rpBodyContent = new Repeater();
        rpBodyContent.DataSource = dtSummaryBalance;
        rpBodyContent.DataBind();
        foreach (RepeaterItem repeatItem in rpBodyContent.Items)
        {
            DataRow dr = dtSummaryBalance.Rows[repeatItem.ItemIndex];
            RepeaterItem repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Item);
            Panel pnRow = new Panel();
            pnlControlItem.PlaceHolderContent.Controls.Add(pnRow);
            pnlControlItem.PlaceHolderContent.Controls.Add(rpBodyContent);
            pnRow.CssClass = "row";
            if (bool.Parse(dr["final"].ToString()))
            {
                pnRow.ForeColor = (dr["tendency"].ToString().Equals("+") ? Color.Green : Color.Red);
            }

            //Etiqueta
            Panel pnCol = new Panel();
            pnRow.Controls.Add(pnCol);
            pnCol.CssClass = "col-md-6 text-right";

            HtmlGenericControl hgH4 = new HtmlGenericControl((bool.Parse(dr["final"].ToString()) ? "h4" : "span"));
            pnCol.Controls.Add(hgH4);
            hgH4.InnerText = string.Concat(dr["key"]);

            HtmlGenericControl hgIcon = new HtmlGenericControl("i");
            hgH4.Controls.Add(hgIcon);
            hgIcon.Attributes["class"] = string.Concat("fa fa-arrow-circle-", (dr["tendency"].ToString().Equals("+") ? "right" : "down"));

            //Valor
            Panel pnColValue = new Panel();
            pnRow.Controls.Add(pnColValue);
            pnColValue.CssClass = "col-md-6 text-right";

            HtmlGenericControl hgSpanValue = new HtmlGenericControl((bool.Parse(dr["final"].ToString()) ? "h4" : "span"));
            pnColValue.Controls.Add(hgSpanValue);
            hgSpanValue.Attributes["class"] = string.Concat("", (dr["tendency"].ToString().Equals("+") ? "success" : "danger"));
            hgSpanValue.InnerText = string.Concat(dr["value"]);
            repeatItem.Controls.Add(pnRow);

            //Linea
            Literal hgLine = new Literal();
            hgLine.Text = "<hr>";
            repeatItem.Controls.Add(hgLine);
        }
        pnlControlItem.PlaceHolderContent.Controls.Add(rpBodyContent);
        return pnlControlItem;
    }

    public void ListProduct(IEnumerable<Product> dataProducts)
    {
        ProductsCollection = dataProducts.ToList();
        GetAllSummaryProduts();
        pnlParent.Controls.Add(CreateSectionTotal());
    }


    public void ListMovementsByAccount(IEnumerable<ProductMovements> productsMovements)
    {
        throw new NotImplementedException();
    }
}