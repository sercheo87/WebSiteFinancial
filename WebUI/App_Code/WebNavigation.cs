using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using System.Xml;
using System.Reflection;
using Shared.Commons;

/// <summary>
/// Summary description for WebWorkflow
/// </summary>
public static class WebNavigation
{
    private static XmlDocument _config = null;

    private static XmlDocument Config
    {
        get
        {
            if (_config == null)
            {
                _config = new XmlDocument();
                _config.Load(HttpContext.Current.Server.MapPath("~/Configuration/Navigation.config"));
            }

            return _config;
        }
    }

    public static string FlowName
    {
        get
        {
            string navid = HttpContext.Current.Request["navid"];

            if (!string.IsNullOrWhiteSpace(navid))
                return (MemoryBag.Current[navid] as object[])[0] as string;

            return null;
        }
    }

    public static Dictionary<string, object> parameters
    {
        get
        {
            string navid = HttpContext.Current.Request["navid"];

            if (!string.IsNullOrWhiteSpace(navid))
                return (MemoryBag.Current[navid] as object[])[1] as Dictionary<string, object>;

            return null;
        }
    }

    private static void Navigate(string url, string flow, Dictionary<string, object> parameters)
    {
        string navigationId = System.Guid.NewGuid().ToString();
        MemoryBag.Current[navigationId] = new object[] { flow, parameters };
        HttpContext.Current.Response.Redirect(url + "?navid=" + HttpContext.Current.Server.UrlEncode(navigationId));
    }

    public static void Clean()
    {
        string navid = HttpContext.Current.Request["navid"];

        if (!string.IsNullOrWhiteSpace(navid))
            MemoryBag.Current.Remove(navid);
    }

    public static void Next()
    {
        Next(null);
    }

    public static void Next(Dictionary<string, object> parameters)
    {
        string flowName = string.Empty;
        PropertyInfo flowNameProperty = HttpContext.Current.Handler.GetType().GetProperty("FlowName");

        if (flowNameProperty != null)
            flowName = flowNameProperty.GetValue(HttpContext.Current.Handler, null) as string;

        if (!string.IsNullOrWhiteSpace(flowName))
        {
            XmlNodeList flows = Config.SelectNodes(@"configuration/workflow/flow");

            foreach (XmlNode flowNode in flows)
            {
                if (string.Compare(flowNode.Attributes["name"].Value, flowName, true) == 0)
                {
                    string routeUrl = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;

                    if (routeUrl.StartsWith("~/"))
                    {
                        routeUrl = routeUrl.Substring(2);
                    }

                    foreach (XmlNode routeNode in flowNode.SelectNodes("route"))
                    {
                        if (string.Compare(routeNode.Attributes["url"].Value, routeUrl, true) == 0)
                        {
                            foreach (XmlNode navigateNode in routeNode.SelectNodes("navigate"))
                            {
                                if (navigateNode.Attributes["url"] != null && !string.IsNullOrWhiteSpace(navigateNode.Attributes["url"].Value))
                                {
                                    bool conditionSucceed = true;

                                    if (navigateNode.Attributes["condition"] != null)
                                    {
                                        string conditionsNode = navigateNode.Attributes["condition"].Value;
                                        NavigationUtils NavigationUtils = new NavigationUtils(parameters, conditionsNode);
                                        conditionSucceed = NavigationUtils.GetResultsEvaluation();
                                    }

                                    if (conditionSucceed)
                                    {
                                        Navigate("~/" + navigateNode.Attributes["url"].Value, flowName, parameters);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}