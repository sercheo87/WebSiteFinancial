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
    public enum TypePanelList { primary, success, info, warning, danger, DEFAULT }

    private TypePanelList _typePanel = TypePanelList.DEFAULT;
    public TypePanelList TypePanel
    {
        get { return _typePanel; }
        set { _typePanel = value; }
    }

    private string _title = String.Empty;
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    private bool _showHeader = false;
    public bool ShowHeader
    {
        get { return _showHeader; }
        set { _showHeader = value; }
    }

    private string _IdParentContainer = string.Empty;
    public string IdParentContainer
    {
        get { return _IdParentContainer; }
        set { _IdParentContainer = value; }
    }
    #endregion

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.CreateContainer();
    }

    [TemplateContainer(typeof(ContentContainer))]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    [TemplateInstance(TemplateInstance.Single)]
    public ITemplate ContentBody { get; set; }

    [TemplateContainer(typeof(ContentContainer))]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    [TemplateInstance(TemplateInstance.Single)]
    public ITemplate ContentHeader { get; set; }

    protected ContentContainer containerBody = new ContentContainer();
    protected ContentContainer containerHeader = new ContentContainer();

    public PlaceHolder PlaceHeaderContent
    {
        get { return placeHeaderContent; }
    }
    public PlaceHolder PlaceHolderContent
    {
        get { return placeHolderContent; }
    }
    protected void CreateContainer()
    {
        if (ContentBody != null)
        {
            ContentBody.InstantiateIn(containerBody);
            this.placeHolderContent.Controls.Add(containerBody);
        }
        if (ContentHeader != null)
        {
            ContentHeader.InstantiateIn(containerHeader);
            this.placeHeaderContent.Controls.Add(containerHeader);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        pnHeaderPanel.Attributes.Add("data-parent", "#" + IdParentContainer);
        pnHeaderPanel.Attributes.Add("data-target", "#" + pnCollapse.ClientID);
        pnlCtrlPanel.CssClass = "panel panel-" + TypePanel.ToString().ToLower();

        pnHeaderPanel.Visible = _showHeader;
        if (_showHeader)
        {
            pnHeaderPanel.Attributes.Add("data-toggle", "collapse");
            pnCollapse.CssClass = "collapse";
        }
    }
}
public class ContentContainer : Control, INamingContainer
{
}