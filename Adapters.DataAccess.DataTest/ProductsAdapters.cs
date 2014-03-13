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
        List<Product> dataProducts = new List<Product>(new[] { 
            new Product() { Account = "123456789", AmmountAvailable = 12.2, Currency = 4, Name = "Cuenta Amiga 1", Type = 4 },
            new Product() { Account = "589663254", AmmountAvailable = 256.32, Currency = 4, Name = "Cuenta Amiga 2", Type = 3 },
            new Product() { Account = "588963211", AmmountAvailable = 4000.2, Currency = 4, Name = "Cuenta Amiga 3", Type = 7 },
            new Product() { Account = "588964555", AmmountAvailable = 122.2, Currency = 4, Name = "Cuenta Amiga 4", Type = 4 } 
        });

        List<ProductMovements> dataMovements = new List<ProductMovements>(new[]{
            new ProductMovements() { Date = DateTime.Parse("2014-09-10"), AmmountTransfer = 1200, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-11"), AmmountTransfer = 23, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-12"), AmmountTransfer = 34, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-13"), AmmountTransfer = 33, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-14"), AmmountTransfer = 234, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-15"), AmmountTransfer = 234, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-26"), AmmountTransfer = 34, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-02"), AmmountTransfer = 234, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-10"), AmmountTransfer = 234, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-22"), AmmountTransfer = 34, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-23"), AmmountTransfer = 24, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-23"), AmmountTransfer = 234, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-23"), AmmountTransfer = 23, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-25"), AmmountTransfer = 44, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-01"), AmmountTransfer = 1200, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-03"), AmmountTransfer = 2222, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-05"), AmmountTransfer = 24343, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-06"), AmmountTransfer = 33, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-10"), AmmountTransfer = 666, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-10"), AmmountTransfer = 12, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-10"), AmmountTransfer = 3434, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-15"), AmmountTransfer = 23, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-20"), AmmountTransfer = 43, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-25"), AmmountTransfer = 233, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-26"), AmmountTransfer = 44, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-30"), AmmountTransfer = 34, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-30"), AmmountTransfer = 222, Description = "Transferencia a Familia", TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-31"), AmmountTransfer = 34, Description = "Transferencia a Familia", TypeTransfer = "D" }

        });

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return dataProducts;
        }

        /// <summary>
        /// Get All Movements
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductMovements> GetMovements()
        {
            return dataMovements;
        }

        /// <summary>
        /// Get Products by Product type.
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(int ProductType)
        {
            return dataProducts.Where(x => x.Type == ProductType);
        }

        /// <summary>
        /// Get Products by array of Product Type
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(int[] ProductType)
        {
            return dataProducts.Where(x => ProductType.Contains(x.Type));
        }

        /// <summary>
        /// Get Products by Product Type and Currency Type.
        /// </summary>
        /// <param name="ProductType"></param>
        /// <param name="CurrencyType"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(int ProductType, int CurrencyType)
        {
            return dataProducts.Where(x => x.Type == ProductType && x.Currency == CurrencyType);
        }

        /// <summary>
        /// Get Products by array of Product Type and Currency Type.
        /// </summary>
        /// <param name="ProductType"></param>
        /// <param name="CurrencyType"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(int[] ProductType, int CurrencyType)
        {
            return dataProducts.Where(x => ProductType.Contains(x.Type) && x.Currency == CurrencyType);
        }
    }
}
