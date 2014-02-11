using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects.Menu;

namespace Adapters.Interfaces.Menu
{
    public interface IMenuAdapter
    {
        IEnumerable<MenuItem> GetMenu();
    }
}
