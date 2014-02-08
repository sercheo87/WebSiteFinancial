using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Presentation.Commons;
using Commons = Adapters.Interfaces.Commons;
using Shared.Infrastructure.Messaging;
using Messaging = Shared.Infrastructure.Messaging;
using StructureMap;
using Shared.Commons;

/// <summary>
/// Summary description for WebView
/// </summary>
public abstract class WebView<PRESENTER_TYPE> : Page, IView
{
    private PRESENTER_TYPE _presenter;

    public PRESENTER_TYPE Presenter
    {
        get { return _presenter; }
    }

    public string FlowName
    {
        get { return GetPersistentValue("_flowName") as string; }
        set { SetPersistentValue("_flowName", value); }
    }

    protected override void InitializeCulture()
    {
        base.InitializeCulture();
        WebEnvironment.SetCultureConfiguration();
    }

    protected override void OnPreInit(EventArgs e)
    {
        string theme = MemoryBag.Current["Theme"] as string;

        base.OnPreInit(e);

        if (!string.IsNullOrWhiteSpace(theme))
            Page.Theme = theme;
    }

    protected override void OnInit(EventArgs e)
    {
        PropertyInfo viewProperty = null;

        base.OnInit(e);

        WebEnvironment.SetPageControls(this);
        OnButtonCommandEventHandler += new ButtonCommandEventHandler(this.OnButtonCommand);
        HideMessage();

        _presenter = ObjectFactory.GetInstance<PRESENTER_TYPE>();

        if ((viewProperty = _presenter.GetType().GetProperty("View")) != null)
            viewProperty.SetValue(_presenter, this, null);
    }

    protected override void OnInitComplete(EventArgs e)
    {
        base.OnInitComplete(e);

        if (!IsPostBack && Request.QueryString["navid"] != null)
            FlowName = WebNavigation.FlowName;
    }

    protected override void OnUnload(EventArgs e)
    {
        base.OnUnload(e);
        WebNavigation.Clean();
    }

    protected void Page_Error(object sender, EventArgs e)
    {
        WebNavigation.Clean();

        //TO DO: Write unhandled exception managing code
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
        Dictionary<string, object> dictionary = null;

        if (ViewState[this.ID + "_persistentValues"] == null)
            ViewState[this.ID + "_persistentValues"] = new Dictionary<string, object>();

        dictionary = ViewState[this.ID + "_persistentValues"] as Dictionary<string, object>;
        dictionary[name] = value;
    }

    #region MESSAGE HANDLING

    public ButtonCommandEventHandler OnButtonCommandEventHandler;

    private string ButtonCommandEventHandlerName
    {
        get { return GetPersistentValue("_buttonCommandEventHandlerName") as string; }
        set { SetPersistentValue("_buttonCommandEventHandlerName", value); }
    }

    private void OnButtonCommand(Messaging.Button SelectedButton)
    {
        string buttonCommandEventHandlerName = ButtonCommandEventHandlerName;

        HideMessage();

        if (_presenter != null && !string.IsNullOrEmpty(buttonCommandEventHandlerName))
        {
            foreach(MethodInfo method in _presenter.GetType().GetMethods())
                if (method.Name == buttonCommandEventHandlerName)
                    if (Delegate.CreateDelegate(typeof(ButtonCommandEventHandler), null, method, false) != null)
                    {
                        method.Invoke(_presenter, new object[] { SelectedButton });
                        break;
                    }
        }
    }

    public void ShowMessage(string TextCode)
    {
        WebModal.ShowMessage(this, TextCode, null, false, null, null);
    }

    public void ShowMessage(string TextCode, string CaptionCode)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, null, null);
    }

    public void ShowMessage(string TextCode, Buttons Buttons)
    {
        WebModal.ShowMessage(this, TextCode, null, false, Buttons, null);
    }

    public void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), null, null);
    }

    public void ShowMessage(string TextCode, Icon Icon)
    {
        WebModal.ShowMessage(this, TextCode, null, false, null, Icon);
    }

    public void ShowMessage(string TextCode, params object[] TextParams)
    {
        WebModal.ShowMessage(this, TextCode, null, false, null, null, TextParams);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, Buttons, null);
    }

    public void ShowMessage(string TextCode, string CaptionCode, ButtonCommandEventHandler ButtonCommandEventHandler)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), null, null);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Icon Icon)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, null, Icon);
    }

    public void ShowMessage(string TextCode, string CaptionCode, params object[] TextParams)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, null, null, TextParams);
    }

    public void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), Buttons, null);
    }

    public void ShowMessage(string TextCode, Buttons Buttons, Icon Icon)
    {
        WebModal.ShowMessage(this, TextCode, null, false, Buttons, Icon);
    }

    public void ShowMessage(string TextCode, Buttons Buttons, params object[] TextParams)
    {
        WebModal.ShowMessage(this, TextCode, null, false, Buttons, null, TextParams);
    }

    public void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), null, Icon);
    }

    public void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), null, null, TextParams);
    }

    public void ShowMessage(string TextCode, Icon Icon, params object[] TextParams)
    {
        WebModal.ShowMessage(this, TextCode, null, false, null, Icon, TextParams);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), Buttons, null);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, Icon Icon)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, Buttons, Icon);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, params object[] TextParams)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, Buttons, null, TextParams);
    }

    public void ShowMessage(string TextCode, string CaptionCode, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), null, Icon);
    }

    public void ShowMessage(string TextCode, string CaptionCode, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), null, null, TextParams);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Icon Icon, params object[] TextParams)
    {
        WebModal.ShowMessage(this, TextCode, CaptionCode, false, null, Icon, TextParams);
    }

    public void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), Buttons, Icon);
    }

    public void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), Buttons, null, TextParams);
    }

    public void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), null, Icon, TextParams);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), Buttons, Icon);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), Buttons, null, TextParams);
    }

    public void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, null, (ButtonCommandEventHandler != null), Buttons, Icon, TextParams);
    }

    public void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon, params object[] TextParams)
    {
        ButtonCommandEventHandlerName = (ButtonCommandEventHandler == null ? null : ButtonCommandEventHandler.Method.Name);
        WebModal.ShowMessage(this, TextCode, CaptionCode, (ButtonCommandEventHandler != null), Buttons, Icon, TextParams);
    }

    public void HideMessage()
    {
        WebModal.HideMessage(this);
    }

    #endregion
}