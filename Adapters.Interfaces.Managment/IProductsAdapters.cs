using DataObjects.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.Interfaces.Managment
{
    public interface IProductsAdapters
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(int ProductType);
        IEnumerable<Product> GetProducts(int[] ProductType);
        IEnumerable<Product> GetProducts(int ProductType, int CurrencyType);
        IEnumerable<Product> GetProducts(int[] ProductType, int CurrencyType);
        IEnumerable<ProductMovements> GetMovements();
    }
}
