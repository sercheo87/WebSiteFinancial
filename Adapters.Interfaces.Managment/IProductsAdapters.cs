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
        IEnumerable<ProductMovements> GetMovements();
    }
}
