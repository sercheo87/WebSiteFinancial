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
            HtmlGenericControl li = new HtmlGenericControl("li");

            if (options.Where(x => x.ParentID == option.ID).Count() > 0)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                HtmlGenericControl ul = new HtmlGenericControl("ul");

                div.Attributes.Add("class", "menu-header");
                div.Attributes.Add("key", option.ID.ToString());
                div.InnerText = option.Resource.Trim();

                if (!string.IsNullOrWhiteSpace(option.Icon))
                    div.Attributes.Add("icon", option.Icon.Trim());

                RenderOptions(ul, options, option.ID);

                li.Controls.Add(div);
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
                HtmlGenericControl div = new HtmlGenericControl("div");
                LinkButton a = new LinkButton();

                div.Attributes.Add("class", "menu-item");
                div.Attributes.Add("key", option.ID.ToString());

                if (!string.IsNullOrWhiteSpace(option.Icon))
                    div.Attributes.Add("icon", option.Icon.Trim());
                
                a.Text = option.Resource.Trim();
                a.CommandArgument = option.Link;
                a.Command += new CommandEventHandler(link_Command);

                div.Controls.Add(a);
                li.Controls.Add(div);
            }

            root.Controls.Add(li);
        }
    }

    void link_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect(e.CommandArgument as string);
    }
}