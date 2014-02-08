using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using Adapters.Interfaces.Commons;
using Adapters.Interfaces.Menu;
using Adapters.Interfaces.Security;

using Adapters.DataAccess.Web.Commons;
using Adapters.DataAccess.SQL.Menu;
using Adapters.DataAccess.SQL.Security;

/// <summary>
/// Summary description for BootStrapper
/// </summary>
public class BootStrapper
{
    public static void ConfigureStructureMap()
    {
        ObjectFactory.Initialize(x =>
        {
            x.AddRegistry<ModuleRegistry>();
        });
    }
}

public class ModuleRegistry : Registry
{
    public ModuleRegistry()
    {
        For<IMemoryBag>().Use<MemoryBag>();
        For<IMenuAdapter>().Use<MenuAdapter>();
        For<IUserAdapter>().Use<UserAdapter>();
    }
}