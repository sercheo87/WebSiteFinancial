﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views__Tests_Registro2 : WebView<object>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.FlowName = "Flow2";
    }

    protected void buttonNext_Click(object sender, EventArgs e)
    {
        WebNavigation.Next();
    }
}