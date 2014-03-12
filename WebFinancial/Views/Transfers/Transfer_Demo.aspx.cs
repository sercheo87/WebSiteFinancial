using DataObjects.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Transfers_Transfer_Demo : WebView<object>
{
    List<Product> DataCollection = new List<Product>() 
        { 
            new Product {Account = "5555555555555",AmmountAvailable = 100, Currency = 1,Name = "eee",Type = 4 } ,
            new Product {Account = "6666666666666",AmmountAvailable = 100, Currency = 1,Name = "ffff",Type = 4 } ,
            new Product {Account = "7777777777777",AmmountAvailable = 100, Currency = 1,Name = "ggg",Type = 4 } ,
            new Product {Account = "8888888888888",AmmountAvailable = 100, Currency = 1,Name = "hhh",Type = 4 } ,
            new Product {Account = "1111111111111",AmmountAvailable = 100, Currency = 1,Name = "aaa",Type = 4 } ,
            new Product {Account = "2222222222222",AmmountAvailable = 100, Currency = 1,Name = "bbb",Type = 4 } ,
            new Product {Account = "3333333333333",AmmountAvailable = 100, Currency = 1,Name = "cc",Type = 4 } ,
            new Product {Account = "4444444444444",AmmountAvailable = 100, Currency = 1,Name = "ddd",Type = 4 } ,
            new Product {Account = "9999999999999",AmmountAvailable = 100, Currency = 1,Name = "iii",Type = 4 } ,       
        };
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }
    #region "Event Commands Grid"
    protected void gvGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edit":
                msg.Text = "Edit gvGrid_RowCommand";
                break;
            case "Update":
                msg.Text = "Update gvGrid_RowCommand";
                break;
            case "Delete":
                Product obj = DataCollection.Where(x => x.Account == e.CommandArgument.ToString()).SingleOrDefault();
                DataCollection.Remove(obj);
                grProducts.Grid.DataSource = DataCollection;
                grProducts.Grid.DataBind();
                break;
            case "Cancel":
                msg.Text = "Cancel gvGrid_RowCommand";
                break;
            case "Sort":
                break;
            case "Select":
                break;
            case "Page":
                break;
            case "EditInForm":
            case "Detail":
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append(@"$(function() {");
                sb.Append("$('#myModal').modal('show');");
                sb.Append(@"});");
                sb.Append(@"</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                mdlItem.Text = e.CommandArgument.ToString();
                break;
        }
        if (e.CommandName == "AddToCart")
        {
            int index = Convert.ToInt32(e.CommandArgument);
        }
    }

    private void BindData()
    {
        grProducts.Grid.RowDeleting += gvGrid_RowDeleting;
        grProducts.Grid.RowCommand += gvGrid_RowCommand;
        grProducts.Grid.RowEditing += gvGrid_RowEditing;
        grProducts.Grid.RowUpdating += gvGrid_RowUpdating;
        grProducts.Grid.RowUpdated += gvGrid_RowUpdated;
        grProducts.Grid.RowCancelingEdit += gvGrid_RowCancelingEdit;

        grProducts.DataCollection = DataCollection.ToList<object>();
        grProducts.Refresh();
        grProducts.Grid_Events += new GridEventHandler(this.Grid_Events);
    }

    private void Grid_Events(object sender, GridEventArgs e)
    {
    }

    protected void gvGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        msg.Text = "gvGrid_RowCancelingEdit";
        grProducts.Grid.EditIndex = -1;
        updMessages.Update();
    }

    protected void gvGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        msg.Text = "gvGrid_RowDeleting";
        object it = new object();
        foreach (System.Collections.DictionaryEntry item in e.Values as System.Collections.IEnumerable)
        {
            if (item.Key.ToString() == "Account")
            {
                it = item;
                break;
            }
        }
    }

    protected void gvGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        msg.Text = "gvGrid_RowEditing";
    }

    protected void gvGrid_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        msg.Text = "gvGrid_RowDeleted";
    }

    protected void gvGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        msg.Text = "gvGrid_RowUpdated";
        BindData();
        updMessages.Update();
    }

    protected void gvGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        msg.Text = "gvGrid_RowUpdating";
        grProducts.Grid.EditIndex = -1;
        updMessages.Update();
    }
    #endregion
}