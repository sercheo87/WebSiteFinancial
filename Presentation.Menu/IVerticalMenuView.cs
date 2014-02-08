using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects.Menu;
using Presentation.Commons;

namespace Presentation.Menu
{
    public interface IVerticalMenuView : IControlView
    {
        void ShowMenu(IEnumerable<MenuItem> options);
    }
}
