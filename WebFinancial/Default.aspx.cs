using DataObjects.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : WebView<object>
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
        grProducts.Grid.RowDeleting += gvGrid_RowDeleting;
        grProducts.Grid.RowCommand += gvGrid_RowCommand;
        grProducts.DataCollection = DataCollection.ToList<object>();
        grProducts.Refresh();
        grProducts.Grid_Events += new GridEventHandler(this.Grid_Events);
    }
    private void Grid_Events(object sender, GridEventArgs e)
    {
        
        string o = "";
    }
    #region "Event Commands Grid"
    protected void gvGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edit":
                break;
            case "Update":
                break;
            case "Delete":
                Product obj = DataCollection.Where(x => x.Account == e.CommandArgument.ToString()).SingleOrDefault();
                DataCollection.Remove(obj);
                grProducts.Grid.DataSource = DataCollection;
                grProducts.Grid.DataBind();
                break;
            case "Cancel":
                break;
            case "Sort":
                break;
            case "Select":
                break;
            case "Page":
                break;
        }
        if (e.CommandName == "AddToCart")
        {
            int index = Convert.ToInt32(e.CommandArgument);
        }
    }

    protected void gvGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        msg.Text = "gvGrid_RowCancelingEdit";
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
    }
    protected void gvGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        msg.Text = "gvGrid_RowUpdating";
    }
    #endregion
}