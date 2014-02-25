using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
    }

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
    }
    #endregion

    #region Methods Forms
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
        FillFilterOptions();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
    }

    protected void Page_Init(object sender, EventArgs e)
    {
    }
    #endregion

    #region Events Grid

    protected void gvGrid_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        DataTable dt = new DataTable();
        CheckBoxField chkField = new CheckBoxField();
        chkField.DataField = idSelection;
        chkField.ReadOnly = false;
        chkField.ControlStyle.CssClass = "checkbox-inline";

        gvGrid.AllowPaging = false;
        gvGrid.AllowSorting = true;
        gvGrid.AutoGenerateColumns = true;
        gvGrid.AutoGenerateSelectButton = false;
        gvGrid.AllowCustomPaging = true;
        gvGrid.ShowFooter = false;
        gvGrid.ShowHeader = true;
        gvGrid.PageSize = 5;

        gvGrid.PagerStyle.CssClass = "paginator-toolbar";
        gvGrid.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
        gvGrid.PagerSettings.Position = PagerPosition.Bottom;

        gvGrid.GridLines = GridLines.None;

        gvGrid.DataSource = DataCollection;
        gvGrid.DataBind();

        gvGrid.UseAccessibleHeader = true;
        gvGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (gvGrid.ShowFooter)
        {
            gvGrid.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        gvGrid.CssClass = "table table-bordered table-striped table-condensed cf table-hover";
        gvGrid.RowStyle.CssClass = "";
        gvGrid.AlternatingRowStyle.CssClass = "";
        gvGrid.HeaderStyle.CssClass = "";

    }

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

    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
    {
        GridViewRow pagerRow = gvGrid.BottomPagerRow;
        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
        gvGrid.PageIndex = pageList.SelectedIndex;
        BindData();
    }

    protected void gvGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataCollection = DynamicSort1<object>(DataCollection, e.SortExpression, e.SortDirection.ToString());
        BindData();
    }
    #endregion

    #region Sorting Dynamic Reflection
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

    protected void btPrint_Click(object sender, EventArgs e)
    {

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
        //Export the GridView to Excel
        PrepareGridViewForExport(gvGrid);
        ExportGridViewExcel();
    }

    protected void btExportWord_Click(object sender, EventArgs e)
    {
        PrepareGridViewForExport(gvGrid);
        ExportGridViewWord();
    }

    protected void btExportPdf_Click(object sender, EventArgs e)
    {
        PrepareGridViewForExport(gvGrid);
        ExportGridViewPdf();
    }

    protected void btExportCsv_Click(object sender, EventArgs e)
    {
        PrepareGridViewForExport(gvGrid);
        ExportGridViewCsv();
    }
    #endregion

    #region Methods Export
    private void PrepareGridViewForExport(Control gv)
    {
        LinkButton lb = new LinkButton();
        Literal l = new Literal();
        string name = String.Empty;
        for (int i = 0; i < gv.Controls.Count; i++)
        {
            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {
                l.Text = (gv.Controls[i] as LinkButton).Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(DropDownList))
            {
                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(CheckBox))
            {
                l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            if (gv.Controls[i].HasControls())
            {
                PrepareGridViewForExport(gv.Controls[i]);
            }
        }
    }

    private void ExportGridViewExcel()
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page page = new Page();
        HtmlForm form = new HtmlForm();

        gvGrid.AllowPaging = false;
        gvGrid.DataSource = dataCollection;
        gvGrid.DataBind();
        page.EnableEventValidation = false;

        gvGrid.Columns[0].Visible = false;
        gvGrid.Columns[1].Visible = false;

        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(gvGrid);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=nombreDocumento.xls");
        Response.Charset = "UTF-8";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentEncoding = System.Text.Encoding.Default;

        Response.Write(sb.ToString());
        Response.End();


        gvGrid.Columns[0].Visible = true;
        gvGrid.Columns[1].Visible = true;

        gvGrid.AllowPaging = true;
        gvGrid.DataBind();
    }

    private void ExportGridViewWord()
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page page = new Page();
        HtmlForm form = new HtmlForm();

        gvGrid.AllowPaging = false;
        gvGrid.DataSource = dataCollection;
        gvGrid.DataBind();
        page.EnableEventValidation = false;

        gvGrid.Columns[0].Visible = false;
        gvGrid.Columns[1].Visible = false;

        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(gvGrid);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-word";
        Response.AddHeader("Content-Disposition", "attachment;filename=nombreDocumento.doc");
        Response.Charset = "UTF-8";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentEncoding = System.Text.Encoding.Default;

        Response.Write(sb.ToString());
        Response.End();


        gvGrid.Columns[0].Visible = true;
        gvGrid.Columns[1].Visible = true;

        gvGrid.AllowPaging = true;
        gvGrid.DataBind();
    }

    private void ExportGridViewPdf()
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page page = new Page();
        HtmlForm form = new HtmlForm();
        gvGrid.AllowSorting = false;
        gvGrid.AllowPaging = false;
        gvGrid.DataSource = dataCollection;
        gvGrid.DataBind();
        page.EnableEventValidation = false;

        gvGrid.Columns[0].Visible = false;
        gvGrid.Columns[1].Visible = false;

        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(gvGrid);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentEncoding = System.Text.Encoding.Default;


        StringReader sr = new StringReader(sw.ToString());
        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
        iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
        iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();


        gvGrid.Columns[0].Visible = true;
        gvGrid.Columns[1].Visible = true;

        gvGrid.AllowSorting = true;
        gvGrid.AllowPaging = true;
        gvGrid.DataBind();
    }

    private void ExportGridViewCsv()
    {
        StringBuilder sb = new StringBuilder();

        Page page = new Page();
        HtmlForm form = new HtmlForm();
        gvGrid.AllowSorting = false;
        gvGrid.AllowPaging = false;
        gvGrid.DataSource = dataCollection;
        gvGrid.DataBind();
        page.EnableEventValidation = false;

        gvGrid.Columns[0].Visible = false;
        gvGrid.Columns[1].Visible = false;

        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(gvGrid);


        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/text";
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentEncoding = System.Text.Encoding.Default;
        sb = new StringBuilder();
        for (int k = 0; k < gvGrid.Columns.Count; k++)
        {
            //add separator
            sb.Append(gvGrid.Columns[k].HeaderText + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < gvGrid.Rows.Count; i++)
        {
            for (int k = 0; k < gvGrid.Columns.Count; k++)
            {
                //add separator
                sb.Append(gvGrid.Rows[i].Cells[k].Text + ',');
            }
            //append new line
            sb.Append("\r\n");
        }
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        page.RenderControl(htw);
        Response.Output.Write(sb.ToString());
        Response.End();


        gvGrid.Columns[0].Visible = true;
        gvGrid.Columns[1].Visible = true;

        gvGrid.AllowSorting = true;
        gvGrid.AllowPaging = true;
        gvGrid.DataBind();
    }
    #endregion

    #region Filter Option
    private void FillFilterOptions()
    {
        HtmlGenericControl ul = new HtmlGenericControl("ul");
        ul.Attributes.Add("class", "dropdown-menu");

        foreach (Object item in DataCollection)
        {
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                string nameRow = prop.Name;
                string valueRow = prop.GetValue(item, null).ToString();

                HtmlGenericControl li = new HtmlGenericControl("li");
                LinkButton lbColFilter = new LinkButton();
                lbColFilter.Click += new EventHandler(filterEvent_Click); ;
                lbColFilter.CommandArgument = nameRow;
                lbColFilter.Command += new CommandEventHandler(filterEvent_Command);
                lbColFilter.Text = nameRow;
                lbColFilter.CausesValidation = false;
                li.Controls.Add(lbColFilter);
                ul.Controls.Add(li);
            }
            break;
        }

        pnlFilter.Controls.Add(ul);
    }

    protected void filterEvent_Command(object sender, CommandEventArgs e)
    {
        LinkButton x = (LinkButton)sender;
        btFilterTagBy.Text = String.Concat("Filter By: ", x.CommandArgument," <span class='caret'></span>");
    }
    protected void filterEvent_Click(object sender, EventArgs e)
    {
    }
    #endregion

    #region "Navigation Events"
    protected void btNext_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(2000);
    }
    #endregion
}