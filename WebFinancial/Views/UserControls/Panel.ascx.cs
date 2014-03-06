using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserControls_Panel : System.Web.UI.UserControl
{
    #region Public Property
    public enum TypePanelList
    {
        primary,
        success,
        info,
        warning,
        danger,
        DEFAULT
    }

    private TypePanelList _typePanel = TypePanelList.DEFAULT;
    public TypePanelList TypePanel
    {
        get
        {
            return _typePanel;
        }
        set
        {
            _typePanel = value;
        }
    }

    private string _title = String.Empty;
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
    #endregion
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.CreateContainer();
    }
    [TemplateContainer(typeof(ContentContainer)), PersistenceMode(PersistenceMode.InnerDefaultProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), TemplateInstance(TemplateInstance.Single)]
    public ITemplate Content { get; set; }

    protected void CreateContainer()
    {
        if (Content != null)
        {
            ContentContainer container = new ContentContainer();
            Content.InstantiateIn(container);
            this.placeHolderContent.Controls.Add(container);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlCtrlPanel.CssClass = "panel panel-" + TypePanel.ToString().ToLower();
    }
}
public class ContentContainer : Control, INamingContainer
{
}