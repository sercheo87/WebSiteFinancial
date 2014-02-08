<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        BootStrapper.ConfigureStructureMap();
        WebRouting.Initialize();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e) 
    {
        HttpCookie settings = Request.Cookies["Settings"]; //TO DO: Validate name of the cookie

        Shared.Commons.MemoryBag.Current["CultureName"] = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        Shared.Commons.MemoryBag.Current["Theme"] = string.Empty;
        
        if (settings != null)
        {
            string cultureName = settings["CultureName"];
            string theme = settings["Theme"];
                
            if (!string.IsNullOrWhiteSpace(cultureName))
            {
                //Validates that retrived cookie culture matches a defined culture in web.config
                foreach(string key in ConfigurationManager.AppSettings.Keys)
                    if (key.StartsWith("LANG_", true, null))
                        if (string.Compare(ConfigurationManager.AppSettings[key], cultureName, true) == 0)
                        {
                            Shared.Commons.MemoryBag.Current["CultureName"] = cultureName;
                            break;
                        }
            }

            if (!string.IsNullOrWhiteSpace(theme))
            {
                //Validates that retrieved theme matches a defined theme in web.config
                foreach (string key in ConfigurationManager.AppSettings.Keys)
                    if (key.StartsWith("THEME_", true, null))
                        if (string.Compare(ConfigurationManager.AppSettings[key], theme, true) == 0)
                        {
                            Shared.Commons.MemoryBag.Current["Theme"] = theme;
                            break;
                        }
            }
        }
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
       
</script>
