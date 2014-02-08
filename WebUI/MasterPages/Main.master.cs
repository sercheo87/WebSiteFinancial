using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Shared.Infrastructure.Messaging;
using Messaging = Shared.Infrastructure.Messaging;

public partial class MasterPages_Main : System.Web.UI.MasterPage
{
    protected void messageButton_OnCommand(object sender, CommandEventArgs e)
    {
        if (Page != null)
        {
            FieldInfo fieldInfo = Page.GetType().GetField("OnButtonCommandEventHandler");
            ButtonCommandEventHandler handler;

            if (fieldInfo != null && fieldInfo.FieldType.Equals(typeof(ButtonCommandEventHandler)))
                if ((handler = (ButtonCommandEventHandler)fieldInfo.GetValue(Page)) != null)
                    switch (e.CommandArgument as string)
                    {
                        case "ACCEPT":
                            handler.Invoke(Messaging.Button.Accept);
                            break;
                        case "ABORT":
                            handler.Invoke(Messaging.Button.Abort);
                            break;
                        case "RETRY":
                            handler.Invoke(Messaging.Button.Retry);
                            break;
                        case "IGNORE":
                            handler.Invoke(Messaging.Button.Ignore);
                            break;
                        case "YES":
                            handler.Invoke(Messaging.Button.Yes);
                            break;
                        case "NO":
                            handler.Invoke(Messaging.Button.No);
                            break;
                        case "CANCEL":
                            handler.Invoke(Messaging.Button.Cancel);
                            break;
                    }
        }
    }
}
