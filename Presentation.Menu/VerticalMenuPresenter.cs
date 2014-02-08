using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;
using Adapters.Interfaces.Menu;
using Adapters.Interfaces.Commons;

namespace Presentation.Menu
{
    public class VerticalMenuPresenter : ControlPresenter<IVerticalMenuView>
    {
        protected IMenuAdapter _adapter;

        public VerticalMenuPresenter(IMenuAdapter adapter)
        {
            _adapter = adapter;
        }

        public void Load()
        {
            View.ShowMenu(_adapter.GetMenu());
        }
    }
}
