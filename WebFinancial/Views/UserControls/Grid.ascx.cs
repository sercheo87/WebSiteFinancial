using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public delegate void GridEventHandler(object sender, GridEventArgs e);

public class GridEventArgs : System.EventArgs
{
    public List<object> CollectionDataSelected { get; set; }
}
public partial class Views_UserControls_Grid : WebUserControl<object>
{
    #region Public Parameters
    public enum TypeSelectedGrid { None, Option, Cheked }

    private List<Object> dataCollection;

    public List<Object> DataCollection
    {
        get { return dataCollection; }
        set { dataCollection = value; }
    }

    public TypeSelectedGrid TypeSelected
    {
        get
        {
            object value = GetPersistentValue("TypeSelected");

            if (value == null)
                return TypeSelectedGrid.None;

            return (TypeSelectedGrid)value;
        }
        set { SetPersistentValue("TypeSelected", value); }
    }

    public string idCode
    {
        get
        {
            object value = GetPersistentValue("idCode");

            if (value == null)
                return string.Empty;

            return (string)value;
        }
        set { SetPersistentValue("idCode", value); }
    }

    public string idSelection
    {
        get
        {
            object value = GetPersistentValue("idSelection");

            if (value == null)
                return string.Empty;

            return (string)value;
        }
        set { SetPersistentValue("idSelection", value); }
    }

    public GridView Grid { get { return gvGrid; } }

    public enum TypeCommandGrid { Edit, Delete, Update }

    public event GridEventHandler Grid_Events;
    #endregion

    #region Binding Data
    private void BindData()
    {
        DataTable dt = new DataTable();
        CheckBoxField chkField = new CheckBoxField();
        chkField.DataField = idSelection;
        chkField.ReadOnly = false;
        chkField.ControlStyle.CssClass = "checkbox-inline";

        gvGrid.DataSource = DataCollection;
        gvGrid.DataBind();
        gvGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    //Convert List To DataTable.
    static DataTable ListToDataTable<T>(IEnumerable<T> list)
    {
        var dt = new DataTable();
        foreach (Object item in list)
        {
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                string nameRow = prop.Name;
                string valueRow = prop.GetValue(item, null).ToString();
                DataColumn newColumn = new DataColumn(nameRow, prop.PropertyType);
                newColumn.Caption = "1111";
                dt.Columns.Add(newColumn);
            }
            break;
        }

        foreach (var t in list)
        {
            var row = dt.NewRow();
            foreach (var info in t.GetType().GetProperties())
            {
                var propertyInfo = t.GetType().GetProperty(info.Name);
                var value = propertyInfo.GetValue(t, null);
                row[info.Name] = value;
            }
            dt.Rows.Add(row);
        }
        return dt;
    }
    private void Format()
    {
        gvGrid.CssClass = "table table-striped table-hover";
        gvGrid.RowStyle.CssClass = "";
        gvGrid.AlternatingRowStyle.CssClass = "";
        gvGrid.HeaderStyle.CssClass = "";
        gvGrid.UseAccessibleHeader = true;
    }
    #endregion

    #region "Mothods Forms"
    public void Refresh()
    {
        Format();
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    #endregion

    #region "Events Grid"
    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
    {
        GridViewRow pagerRow = gvGrid.BottomPagerRow;
        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
        gvGrid.PageIndex = pageList.SelectedIndex;
        BindData();
    }
    protected void CustomersGridView_DataBound(Object sender, EventArgs e)
    {
        GridViewRow pagerRow = gvGrid.BottomPagerRow;
        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
        Literal pageLabel = (Literal)pagerRow.Cells[0].FindControl("CurrentPageLabel");
        Literal TotalLabel = (Literal)pagerRow.Cells[0].FindControl("TotalPageLabel");

        if (pageList != null)
        {
            for (int i = 0; i < gvGrid.PageCount; i++)
            {
                int pageNumber = i + 1;
                ListItem item = new ListItem(pageNumber.ToString());
                if (i == gvGrid.PageIndex)
                {
                    item.Selected = true;
                }
                pageList.Items.Add(item);
            }
        }

        if (pageLabel != null)
        {
            int currentPage = gvGrid.PageIndex + 1;
            pageLabel.Text = currentPage.ToString();
            TotalLabel.Text = gvGrid.PageCount.ToString();

        }

    }
    protected void gvGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGrid.PageIndex = e.NewPageIndex;
    }
    protected void gvGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataCollection = DynamicSort1<object>(DataCollection, e.SortExpression, e.SortDirection.ToString());
        BindData();
    }
    #endregion

    #region "Sorting Dynamic Reflection"
    private static List<T> DynamicSort1<T>(List<T> genericList, string sortExpression, string sortDirection)
    {
        int sortReverser = sortDirection.ToLower().StartsWith("asc") ? 1 : -1;
        Comparison<T> comparisonDelegate = new Comparison<T>(delegate(T x, T y)
        {
            //Just to get the compare method info to compare the values.
            MethodInfo compareToMethod = GetCompareToMethod<T>(x, sortExpression);
            //Getting current object value.
            object xSortExpressionValue = x.GetType().GetProperty(sortExpression).GetValue(x, null);
            //Getting the previous value. 
            object ySortExpressionValue = y.GetType().GetProperty(sortExpression).GetValue(y, null);
            //Comparing the current and next object value of collection.
            object result = compareToMethod.Invoke(xSortExpressionValue, new object[] { ySortExpressionValue });
            // result tells whether the compared object is equal,greater,lesser.
            return sortReverser * Convert.ToInt16(result);
        });
        //here we using the comparison delegate to sort the object by its property
        genericList.Sort(comparisonDelegate);

        return genericList;
    }
    private static MethodInfo GetCompareToMethod<T>(T genericInstance, string sortExpression)
    {
        Type genericType = genericInstance.GetType();
        object sortExpressionValue = genericType.GetProperty(sortExpression).GetValue(genericInstance, null);
        Type sortExpressionType = sortExpressionValue.GetType();
        MethodInfo compareToMethodOfSortExpressionType = sortExpressionType.GetMethod("CompareTo", new Type[] { sortExpressionType });
        return compareToMethodOfSortExpressionType;
    }
    #endregion
    protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].GetType() == typeof(System.Web.UI.WebControls.DataControlFieldCell))
            {
                TableCell tc = e.Row.Cells[1];

                if (tc.Controls.Count > 0)
                {
                    LinkButton btEdit = (LinkButton)tc.FindControl("EditButton");
                    LinkButton btDelete = (LinkButton)tc.FindControl("DeleteButton");
                    LinkButton btDetail = (LinkButton)tc.FindControl("DetailButton");

                    btEdit.CommandArgument = e.Row.Cells[2].Text;
                    btDelete.CommandArgument = e.Row.Cells[2].Text;
                    btDetail.CommandArgument = e.Row.Cells[2].Text;
                }
            }
        }
    }

    #region Toolbar
    protected void btSelectAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvGrid.Rows)
        {
            CheckBox obj = (CheckBox)item.Cells[0].FindControl("chSelected");
            obj.Checked = true;
        }
    }
    protected void btDeleteAll_Click(object sender, EventArgs e)
    {
        GridEventArgs args = new GridEventArgs();
        args.CollectionDataSelected = new List<object>();

        foreach (GridViewRow item in gvGrid.Rows)
        {
            if (((CheckBox)item.Cells[0].FindControl("chSelected")).Checked)
            {
                var m_values = this.GetValues(item);

                foreach (object itemObject in DataCollection)
                {
                    if (m_values[idCode].ToString() == itemObject.GetType().GetProperty(idCode).GetValue(itemObject, null).ToString())
                    {
                        args.CollectionDataSelected.Add(itemObject);
                        break;
                    }
                }
            }
        }
        Grid_Events(sender, args);
    }
    public IDictionary<string, object> GetValues(GridViewRow row)
    {
        IOrderedDictionary dictionary = new OrderedDictionary();

        foreach (Control control in row.Controls)
        {
            DataControlFieldCell cell = control as DataControlFieldCell;

            if ((cell != null) && cell.Visible)
            {
                cell.ContainingField.ExtractValuesFromCell(dictionary, cell, row.RowState, true);
            }
        }

        IDictionary<string, object> values = new Dictionary<string, object>();

        foreach (DictionaryEntry de in dictionary)
        {
            values[de.Key.ToString()] = de.Value;
        }

        return values;
    }
    #endregion

    #region Exports
    protected void btExportXml_Click(object sender, EventArgs e)
    {

    }
    protected void btExportPdf_Click(object sender, EventArgs e)
    {

    }
    protected void btExportTxt_Click(object sender, EventArgs e)
    {

    }
    #endregion
}