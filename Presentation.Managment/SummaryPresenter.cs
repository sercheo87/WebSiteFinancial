using Adapters.Interfaces.Managment;
using Presentation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Commons;

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

        public void GetProducts(UtilsConstants.TypeProductsFilters ProductType)
        {
            switch (ProductType)
            {
                case UtilsConstants.TypeProductsFilters.All:
                    View.ListProduct(_adapter.GetProducts());
                    break;
                case UtilsConstants.TypeProductsFilters.Actives:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.ProductsActives));
                    break;
                case UtilsConstants.TypeProductsFilters.Pasives:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.ProductsPasives));
                    break;
                case UtilsConstants.TypeProductsFilters.Saving:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.PRODUCT_SAVING_ID));
                    break;
                case UtilsConstants.TypeProductsFilters.Cheking:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.PRODUCT_CHECKING_ID));
                    break;
                case UtilsConstants.TypeProductsFilters.Loans:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.PRODUCT_LOANS_ID));
                    break;
                default:
                    View.ListProduct(_adapter.GetProducts());
                    break;
            };
        }

        public void GetProducts(UtilsConstants.TypeProductsFilters ProductType, int CurrencType)
        {
            switch (ProductType)
            {
                case UtilsConstants.TypeProductsFilters.All:
                    View.ListProduct(_adapter.GetProducts());
                    break;
                case UtilsConstants.TypeProductsFilters.Actives:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.ProductsActives, CurrencType));
                    break;
                case UtilsConstants.TypeProductsFilters.Pasives:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.ProductsPasives, CurrencType));
                    break;
                case UtilsConstants.TypeProductsFilters.Saving:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.PRODUCT_SAVING_ID, CurrencType));
                    break;
                case UtilsConstants.TypeProductsFilters.Cheking:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.PRODUCT_CHECKING_ID, CurrencType));
                    break;
                case UtilsConstants.TypeProductsFilters.Loans:
                    View.ListProduct(_adapter.GetProducts(UtilsConstants.PRODUCT_LOANS_ID, CurrencType));
                    break;
                default:
                    View.ListProduct(_adapter.GetProducts());
                    break;
            };
        }

        public void GetMovements()
        {
            View.ListMovementsByAccount(_adapter.GetMovements());
        }

    }
}
