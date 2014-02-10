using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Reflection;
using Presentation.Commons;
using StructureMap;

/// <summary>
/// Summary description for WebUserControl
/// </summary>
public class WebUserControl<PRESENTER_TYPE> : UserControl, IControlView
{
    private PRESENTER_TYPE _presenter;

    public PRESENTER_TYPE Presenter
    {
        get { return _presenter; }
    }

    protected override void OnInit(EventArgs e)
    {
        PropertyInfo viewProperty = null;

        base.OnInit(e);

        _presenter = ObjectFactory.GetInstance<PRESENTER_TYPE>();

        if ((viewProperty = _presenter.GetType().GetProperty("View")) != null)
            viewProperty.SetValue(_presenter, this, null);
    }

    protected object GetPersistentValue(string name)
    {
        Dictionary<string, object> dictionary = null;

        if (ViewState[this.ID + "_persistentValues"] != null)
        {
            dictionary = ViewState[this.ID + "_persistentValues"] as Dictionary<string, object>;

            if (dictionary.ContainsKey(name))
                return dictionary[name];
        }

        return null;
    }

    protected void SetPersistentValue(string name, object value)
    {
        Dictionary<string,object> dictionary = null;

        if (ViewState[this.ID + "_persistentValues"] == null)
            ViewState[this.ID + "_persistentValues"] = new Dictionary<string,object>();

        dictionary = ViewState[this.ID + "_persistentValues"] as Dictionary<string,object>;
        dictionary[name] = value;
    }
}