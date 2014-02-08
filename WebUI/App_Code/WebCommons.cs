using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for WebCommons
/// </summary>
public static class WebCommons
{
    public static T FindControl<T>(Page Page, string ControlID)
	{
        if (Page != null)
        {
            Control control = Page.FindControl(ControlID);
            MasterPage master = Page.Master;

            while (master != null && (control == null || control != null && !(control is T)))
            {
                control = master.FindControl(ControlID);
                master = master.Master;
            }

            if (control != null && control is T)
                return (T)(object)control;
        }

        return (T)(object)null;
	}
}