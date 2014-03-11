using DataObjects.Managment;
using Presentation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Managment
{
    public interface ISummaryView : IControlView
    {
        void ListProduct(IEnumerable<Product> dataProducts);
        void ListMovementsByAccount(IEnumerable<ProductMovements> productsMovements);
    }
}
