using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentation.Menu;
using Menu = DataObjects.Menu;
using System.Web.UI.HtmlControls;
using Resources;
using Shared.Commons;

public partial class Views_UserControls_VerticalMenu : WebUserControl<VerticalMenuPresenter>, IVerticalMenuView
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            MemoryBag.Current["VerticalMenu.LastKey"] = lastKey.Value;
        else
            lastKey.Value = MemoryBag.Current["VerticalMenu.LastKey"] as string ?? string.Empty;

        Presenter.Load();
    }

    public bool Ordered { get; set; }

    public void ShowMenu(IEnumerable<Menu.MenuItem> options)
    {
        foreach (Menu.MenuItem option in options)
            option.Resource = WebUIMenu.ResourceManager.GetString(option.Resource) ?? string.Format("[{0}: {1}]", CultureInfo.CurrentUICulture.Name, option.Resource);

        RenderOptions(root, (Ordered ? options.OrderBy(x => x.Resource) : options), null);
    }

    protected void RenderOptions(Control root, IEnumerable<Menu.MenuItem> options, int? ParentID)
    {
        foreach (Menu.MenuItem option in options.Where(x => x.ParentID == ParentID))
        {
            //ITEM PARENT MENU
            HtmlGenericControl li = new HtmlGenericControl("li");

            if (options.Where(x => x.ParentID == option.ID).Count() > 0)
            {
                HtmlGenericControl a = new HtmlGenericControl("a");
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                HtmlGenericControl b = new HtmlGenericControl("b");


                b.Attributes.Add("class", "caret");
                a.Attributes.Add("class", "dropdown-toggle");
                a.Attributes.Add("data-toggle", "dropdown");
                a.Attributes.Add("key", option.ID.ToString());
                a.Attributes.Add("href", "#");
                a.InnerText = option.Resource.Trim();
                ul.Attributes.Add("class", "dropdown-menu");

                if (!string.IsNullOrWhiteSpace(option.Icon))
                    a.Attributes.Add("icon", option.Icon.Trim());

                RenderOptions(ul, options, option.ID);
                a.Controls.Add(b);
                li.Attributes.Add("class", "dropdown");
                li.Controls.Add(a);
                li.Controls.Add(ul);
            }
            else if (string.IsNullOrWhiteSpace(option.Link))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");

                div.Attributes.Add("class", "menu-header");
                div.Attributes.Add("key", option.ID.ToString());
                div.InnerText = option.Resource.Trim();

                if (!string.IsNullOrWhiteSpace(option.Icon))
                    div.Attributes.Add("icon", option.Icon.Trim());

                li.Controls.Add(div);
            }
            else
            {
                LinkButton lb = new LinkButton();

                lb.Attributes.Add("key", option.ID.ToString());
                lb.Text = option.Resource.Trim();
                lb.CommandArgument = option.Link;
                lb.Command += new CommandEventHandler(link_Command);
                li.Controls.Add(lb);
            }

            root.Controls.Add(li);
        }
    }

    void link_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect(e.CommandArgument as string);
    }
}