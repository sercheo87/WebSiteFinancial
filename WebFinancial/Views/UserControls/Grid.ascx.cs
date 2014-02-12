using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserControls_Grid : WebUserControl<object>
{
    private List<Object> dataCollection;
    public List<Object> DataCollection
    {
        get
        {
            return dataCollection;
        }
        set
        {
            dataCollection = value;
        }
    }

    public void Refresh()
    {
        Format();
        BindData();
    }

    private void BindData()
    {
        gvGrid.DataSource = DataCollection;
        gvGrid.DataBind();
    }

    private void Format()
    {
        gvGrid.CssClass = "table table-striped table-hover table-bordered table-condensed";
        gvGrid.RowStyle.CssClass = "";
        gvGrid.AlternatingRowStyle.CssClass = "active";
        gvGrid.HeaderStyle.CssClass = "col";
        gvGrid.AllowPaging = true;
        gvGrid.AllowSorting = true;
        gvGrid.PageSize = 5;
        gvGrid.AutoGenerateColumns = true;
        gvGrid.PageIndexChanging += gvGrid_PageIndexChanging;

        gvGrid.PagerSettings.Mode = PagerButtons.NextPrevious;
        gvGrid.PagerSettings.PageButtonCount = 4;
        gvGrid.PagerSettings.FirstPageText = "Firts";
        gvGrid.PagerSettings.LastPageText = "Last";
        gvGrid.PagerSettings.NextPageText = "Next";
        gvGrid.PagerSettings.PreviousPageText = "Previous";
    }

    protected void gvGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGrid.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}