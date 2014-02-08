using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Views_UserControls_MessageZone : WebUserControl<object>
{
    public enum MessageTypeEnum { Error, Warning, Info, Success };

    protected void Page_PreRender(object sender, EventArgs e)
    {
        SetControlStyle();
    }

    protected void SetControlStyle()
    {
        mainFrame.CssClass = string.Format("alert alert-{0} {1}", MessageType.ToString().ToLower(), CssClass).Trim();
    }

    public string CssClass
    {
        get
        {
            object value = GetPersistentValue("CssClass");

            if (value == null)
                return string.Empty;

            return (string)value;
        }
        set { SetPersistentValue("CssClass", value); }
    }

    public override string ID
    {
        get { return base.ID; }
        set
        {
            base.ID = value;
            mainFrame.Attributes["controlID"] = value;
        }
    }

    public MessageTypeEnum MessageType
    {
        get
        {
            object value = GetPersistentValue("MessageType");

            if (value == null)
                return MessageTypeEnum.Info;

            return (MessageTypeEnum)value;
        }
        set { SetPersistentValue("MessageType", value); }
    }

    public string Text
    {
        get { return message.Text; }
        set { message.Text = value; }
    }
}