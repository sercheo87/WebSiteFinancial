using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Threading;
using Shared.Commons;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class WebEnvironment
{
    public static void SetCultureConfiguration()
    {
        CultureInfo cultureInfo = new CultureInfo(MemoryBag.Current["CultureName"] as string);
        
        string currencyDecimalDigits = ConfigurationManager.AppSettings["CurrencyDecimalDigits." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["CurrencyDecimalDigits"];
        string currencyDecimalSeparator = ConfigurationManager.AppSettings["CurrencyDecimalSeparator." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["CurrencyDecimalSeparator"];
        string currencyGroupSeparator = ConfigurationManager.AppSettings["CurrencyGroupSeparator." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["CurrencyGroupSeparator"];
        string currencySymbol = ConfigurationManager.AppSettings["CurrencySymbol." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["CurrencySymbol"];
        string numberDecimalDigits = ConfigurationManager.AppSettings["NumberDecimalDigits." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["NumberDecimalDigits"];
        string numberDecimalSeparator = ConfigurationManager.AppSettings["NumberDecimalSeparator." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["NumberDecimalSeparator"];
        string numberGroupSeparator = ConfigurationManager.AppSettings["NumberGroupSeparator." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["NumberGroupSeparator"];
        string shortDatePattern = ConfigurationManager.AppSettings["ShortDatePattern." + cultureInfo.Name] ?? ConfigurationManager.AppSettings["ShortDatePattern"];
        int value = 0;

        if (!string.IsNullOrWhiteSpace(currencyDecimalDigits) && int.TryParse(currencyDecimalDigits, out value)) cultureInfo.NumberFormat.CurrencyDecimalDigits = value;
        if (!string.IsNullOrWhiteSpace(currencyDecimalSeparator)) cultureInfo.NumberFormat.CurrencyDecimalSeparator = currencyDecimalSeparator;
        if (!string.IsNullOrWhiteSpace(currencyGroupSeparator)) cultureInfo.NumberFormat.CurrencyGroupSeparator = currencyGroupSeparator;
        if (!string.IsNullOrWhiteSpace(currencySymbol)) cultureInfo.NumberFormat.CurrencySymbol = currencySymbol;
        if (!string.IsNullOrWhiteSpace(numberDecimalDigits) && int.TryParse(numberDecimalDigits, out value)) cultureInfo.NumberFormat.NumberDecimalDigits = value;
        if (!string.IsNullOrWhiteSpace(numberDecimalSeparator)) cultureInfo.NumberFormat.NumberDecimalSeparator = numberDecimalSeparator;
        if (!string.IsNullOrWhiteSpace(numberGroupSeparator)) cultureInfo.NumberFormat.NumberGroupSeparator = numberGroupSeparator;
        if (!string.IsNullOrWhiteSpace(shortDatePattern)) cultureInfo.DateTimeFormat.ShortDatePattern = shortDatePattern;

        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }

    public static void SetPageControls(Page Page)
    {
        if (Page != null)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            string language = cultureInfo.Name;
            string fileMask = "~/Scripts/DatePicker/jquery.ui.datepicker-{0}.js";
            int index = -1;

            while (!string.IsNullOrWhiteSpace(language) && !File.Exists(Page.Server.MapPath(string.Format(fileMask, language))))
                language = (index = language.LastIndexOf("-")) == -1 ? string.Empty : language.Substring(0, index);

            if (!string.IsNullOrWhiteSpace(language))
            {
                ScriptManager scriptManager = WebCommons.FindControl<ScriptManager>(Page, "scriptManager");

                if (scriptManager != null)
                    scriptManager.Scripts.Add(new ScriptReference(string.Format(fileMask, language)));
            }

            Page.ClientScript.RegisterHiddenField("currencyDecimalDigits", cultureInfo.NumberFormat.CurrencyDecimalDigits.ToString());
            Page.ClientScript.RegisterHiddenField("currencyDecimalSeparator", cultureInfo.NumberFormat.CurrencyDecimalSeparator.ToString());
            Page.ClientScript.RegisterHiddenField("numberDecimalDigits", cultureInfo.NumberFormat.NumberDecimalDigits.ToString());
            Page.ClientScript.RegisterHiddenField("numberDecimalSeparator", cultureInfo.NumberFormat.NumberDecimalSeparator.ToString());
            Page.ClientScript.RegisterHiddenField("datepickerDateFormat", cultureInfo.DateTimeFormat.ShortDatePattern.Replace("yyyy", "yy").ToLower());
            Page.ClientScript.RegisterHiddenField("datepickerLanguageName", language);
        }
    }
}