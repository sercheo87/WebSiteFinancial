using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentation.Test;

public partial class Views__Tests_DataInputs : WebView<DataInputPresenter>, IDataInput
{
    #region "Interface"
    protected void messagesButton_OnClick(object sender, EventArgs e)
    {
        Presenter.Execute();
    }

    protected void flowButton_OnClick(object sender, EventArgs e)
    {
        FlowName = "TestFlow";
        WebNavigation.Next();
    }

    public string Code
    {
        get { return "codeVal"; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
}