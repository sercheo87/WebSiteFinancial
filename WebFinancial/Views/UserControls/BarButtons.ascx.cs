using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserControls_BarButtons : System.Web.UI.UserControl
{
    public enum TypeBarEnum { ConfirmOnly, ConfirmCancelBack, Accept };

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        SetControlStyle();
    }

    protected void SetControlStyle()
    {
        Initialize(_typeBarEnum);
    }

    public void Initialize(TypeBarEnum config)
    {
        btBack.Visible = false;
        btCancel.Visible = false;
        btConfirm.Visible = false;
        btAccept.Visible = false;
        btHelp.Visible = false;

        switch (config)
        {
            case TypeBarEnum.ConfirmOnly:
                btConfirm.Visible = true;
                break;
        }
    }

    #region "Properties Public"
    private TypeBarEnum _typeBarEnum;
    public TypeBarEnum BarType
    {
        set
        {
            _typeBarEnum = value;
            Initialize(value);
        }
        get
        {
            return _typeBarEnum;
        }
    }
    #endregion

    #region "Button Public"
    public Button getButtonAccept
    {
        get { return btAccept; }
    }
    #endregion

}