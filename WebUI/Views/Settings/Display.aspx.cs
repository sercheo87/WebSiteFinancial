using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Configuration;
using System.Globalization;
using Resources;
using Shared.Commons;

public partial class Views_Settings_Display : WebView<object>
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
            MasterPageFile = "~/MasterPages/View.master";
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        LoadLanguages();
        LoadThemes();
    }

    protected void LoadLanguages()
    {
        foreach (string key in ConfigurationManager.AppSettings.Keys)
            if (key.StartsWith("LANG_", true, null))
                languages.Items.Add(new ListItem(WebUILabels.ResourceManager.GetString(key) ?? string.Format("[{0}: {1}]", CultureInfo.CurrentUICulture.Name, key), ConfigurationManager.AppSettings[key]));

        languages.SelectedValue = Thread.CurrentThread.CurrentUICulture.Name;
    }

    protected void LoadThemes()
    {
        foreach (string key in ConfigurationManager.AppSettings.Keys)
            if (key.StartsWith("THEME_", true, null))
                themes.Items.Add(new ListItem(WebUILabels.ResourceManager.GetString(key) ?? string.Format("[{0}: {1}]", CultureInfo.CurrentUICulture.Name, key), ConfigurationManager.AppSettings[key]));

        themes.SelectedValue = Page.Theme;
    }

    protected void Accept_OnClick(object sender, EventArgs e)
    {
        MemoryBag.Current["CultureName"] = languages.SelectedValue;
        MemoryBag.Current["Theme"] = themes.SelectedValue;

        //TO DO: Validate name of the cookie
        HttpCookie settings = new HttpCookie("Settings");
        settings["CultureName"] = languages.SelectedValue;
        settings["Theme"] = themes.SelectedValue;
        settings.Expires = DateTime.Now.AddDays(15d);
        Response.Cookies.Add(settings);

        Response.Redirect(Request.RawUrl);
    }
}