using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects.Managment;
using DataObjects.User;

public partial class Views__TestCondition_Registro1 : WebView<Object>
{
    List<Product> objProducts = new List<Product>();

    List<Product> objSelectedProducts = new List<Product>();

    Entity objUserNatural = new Entity()
    {
        ID = 1,
        Names = "PEPITO PEREZ",
        EMail = "pepitoperez@cobiscorp.com",
        FirstLastName = "Pepito Perez",
        SecondLastName = "Ramonez",
        Username = "pepito",
        Type = "P"
    };
    Entity objUserCompany = new Entity()
    {
        ID = 2,
        Names = "CASTRO MANUEL",
        EMail = "castromanuel@cobiscorp.com",
        FirstLastName = "Castro Manuel",
        SecondLastName = "Perero",
        Username = "cmanuel",
        Type = "C"
    };
    Entity objUserGroup = new Entity()
    {
        ID = 3,
        Names = "GROUP PEPSICO",
        EMail = "pepsico@cobiscorp.com",
        FirstLastName = "GRUPO PAPA CORPORATION",
        SecondLastName = "GROUP PEPSICO",
        Username = "GPEPSICO",
        Type = "G"
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        this.FlowName = "Flow3Condition";

        objProducts.Add(new Product() { Account = "111111111", AmmountAvailable = 12.25, Currency = 0, Type = 3, Name = "CORRIENTE JUAN" });
        objProducts.Add(new Product() { Account = "222222222", AmmountAvailable = 1000, Currency = 1, Type = 3, Name = "CORRIENTE PEDRO" });
        objProducts.Add(new Product() { Account = "333333333", AmmountAvailable = 500.25, Currency = 1, Type = 4, Name = "AHORROS MARIA" });
        objProducts.Add(new Product() { Account = "444444444", AmmountAvailable = 700.25, Currency = 0, Type = 4, Name = "AHORROS MARIA" });
        objProducts.Add(new Product() { Account = "555555555", AmmountAvailable = 200, Currency = 1, Type = 4, Name = "AHORROS JULIA" });

        if (!this.IsPostBack)
        {
            grdProducts.DataSource = objProducts;
            grdProducts.DataBind();
        }

    }

    protected void buttonNext_Click(object sender, EventArgs e)
    {
        int obfFlag = int.Parse((string.IsNullOrWhiteSpace(txtFlag.Text) ? "0" : txtFlag.Text.Trim()));

        Dictionary<string, object> dicParameters = new Dictionary<string, object>();
        switch (ddnTypePerson.SelectedValue)
        {
            case "N":
                dicParameters.Add("MyEntity", objUserNatural);
                break;
            case "E":
                dicParameters.Add("MyEntity", objUserCompany);
                break;
            case "G":
                dicParameters.Add("MyEntity", objUserGroup);
                break;
        }

        foreach (GridViewRow row in grdProducts.Rows)
        {
            if (((CheckBox)row.Cells[0].Controls[1]).Checked)
            {
                objSelectedProducts.Add(new Product
                {
                    Account = row.Cells[1].Text,
                    Type = int.Parse(row.Cells[2].Text),
                    AmmountAvailable = double.Parse(row.Cells[3].Text),
                    Currency = int.Parse(row.Cells[4].Text),
                    Name = row.Cells[5].Text,
                });
            }
        }
        objSelectedProducts.Where(x => x.Account == "c");
        dicParameters.Add("MyProducts", objSelectedProducts);
        dicParameters.Add("MyFlag", obfFlag);

        WebNavigation.Next(dicParameters);
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdProducts.Rows)
        {
            ((CheckBox)row.Cells[0].Controls[1]).Checked = true;

        }
    }
}