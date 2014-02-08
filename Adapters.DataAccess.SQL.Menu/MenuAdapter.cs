using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adapters.Interfaces.Menu;
using DataObjects.Menu;

namespace Adapters.DataAccess.SQL.Menu
{
    public class MenuAdapter : IMenuAdapter
    {
        public IEnumerable<MenuItem> GetMenu()
        {
            List<MenuItem> options = new List<MenuItem>();

            //TO DO: MENU RETRIEVAL PROCEDURE
            options.Add(new MenuItem() { ID = 990, Resource = "TST_TESTS" });
            options.Add(new MenuItem() { ID = 991, ParentID = 990, Resource = "TST_DATA_INPUTS", Link = "~/Tests/DataInputs" });
            options.Add(new MenuItem() { ID = 992, ParentID = 990, Resource = "TST_FLOW_1", Link = "~/Tests/Registro1" });
            options.Add(new MenuItem() { ID = 993, ParentID = 990, Resource = "TST_FLOW_2", Link = "~/Tests/Registro2" });
            options.Add(new MenuItem() { ID = 994, ParentID = 990, Resource = "TST_FLOW_3", Link = "~/Tests_Condition/RegisterCond1" });

            options.Add(new MenuItem() { ID = 10, Resource = "GRP_SETTINGS" });
            options.Add(new MenuItem() { ID = 11, ParentID = 10, Resource = "LNK_DISPLAY_SETTINGS", Link = "~/Settings/Display", Icon = "" });
            options.Add(new MenuItem() { ID = 12, ParentID = 10, Resource = "LNK_CHANGE_PASSWORD", Link = "~/Account/ChangePassword", Icon = "" });

            return options;
        }
    }
}
