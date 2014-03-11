using Adapters.Interfaces.Managment;
using Presentation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Managment
{
    public class SummaryPresenter : ControlPresenter<ISummaryView>
    {
        protected IProductsAdapters _adapter;
        public SummaryPresenter(IProductsAdapters adapter)
        {
            _adapter = adapter;
        }

        public void GetProducts()
        {
            View.ListProduct(_adapter.GetProducts());
        }

        public void GetMovements()
        {
            View.ListMovementsByAccount(_adapter.GetMovements());
        }
    }
}
