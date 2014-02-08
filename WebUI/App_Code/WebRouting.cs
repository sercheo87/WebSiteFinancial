using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

/// <summary>
/// Summary description for WebNavigator
/// </summary>
public static class WebRouting
{
	public static void Initialize()
	{
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load(HttpContext.Current.Server.MapPath("~/Configuration/Navigation.config"));

        System.Xml.XmlNodeList nodes = doc.SelectNodes(@"configuration/routes/route");

        foreach (System.Xml.XmlNode n in nodes)
        {
            RouteTable.Routes.MapPageRoute(
                n.Attributes["name"].Value,
                n.Attributes["url"].Value,
                n.Attributes["file"].Value
            );
        }
    }
}