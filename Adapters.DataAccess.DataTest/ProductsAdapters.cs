using Adapters.Interfaces.Managment;
using DataObjects.Managment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.DataAccess.Managment
{
    public class ProductsAdapters : IProductsAdapters
    {
        public IEnumerable<Product> GetProducts()
        {
            List<Product> data = new List<Product>();
            data.Add(new Product() { Account = "123456789", AmmountAvailable = 12.2, Currency = 4, Name = "Cuenta Amiga 1", Type = 4 });
            data.Add(new Product() { Account = "589663254", AmmountAvailable = 256.32, Currency = 4, Name = "Cuenta Amiga 2", Type = 3 });
            data.Add(new Product() { Account = "588963211", AmmountAvailable = 4000.2, Currency = 4, Name = "Cuenta Amiga 3", Type = 7 });
            data.Add(new Product() { Account = "588964555", AmmountAvailable = 122.2, Currency = 4, Name = "Cuenta Amiga 4", Type = 4 });

            return data;
        }
        public IEnumerable<ProductMovements> GetMovements()
        {
            List<ProductMovements> data = new List<ProductMovements>();
            data.Add(new ProductMovements() { Date = DateTime.Parse("3/9/2014"), AmmountTransfer = 1200, Description = "Transferencia a Familia", TypeTransfer = "D" });
            data.Add(new ProductMovements() { Date = DateTime.Parse("5/10/2014"), AmmountTransfer = 200, Description = "Pago de Luz", TypeTransfer = "D" });
            data.Add(new ProductMovements() { Date = DateTime.Parse("10/10/2014"), AmmountTransfer = 12, Description = "Almuerzo de Homero", TypeTransfer = "D" });
            data.Add(new ProductMovements() { Date = DateTime.Parse("13/12/2014"), AmmountTransfer = 55.32, Description = "Prestamo banco", TypeTransfer = "D" });
            data.Add(new ProductMovements() { Date = DateTime.Parse("23/12/2014"), AmmountTransfer = 0.25, Description = "Impuesto de Amazon", TypeTransfer = "D" });
            return data;
        }
    }
}
