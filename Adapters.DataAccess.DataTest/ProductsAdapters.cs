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
            
            new ProductMovements() { Date = DateTime.Parse("2014-09-10 08:10:20"),Description = "Transferencia a Familia 1", AmmountTransfer = 1200,  TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-11 12:20:15"),Description = "Transferencia a Familia 2", AmmountTransfer = 23,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-12 15:25:25"),Description = "Transferencia a Familia 3", AmmountTransfer = 34,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-13 07:28:20"),Description = "Transferencia a Familia 4", AmmountTransfer = 33,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-14 08:28:20"),Description = "Transferencia a Familia 5", AmmountTransfer = 234,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-15 09:28:20"),Description = "Transferencia a Familia 6", AmmountTransfer = 234,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-09-26 02:28:20"),Description = "Transferencia a Familia 7", AmmountTransfer = 34,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-02 03:28:20"),Description = "Transferencia a Familia 8", AmmountTransfer = 234,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-10 04:28:20"),Description = "Transferencia a Familia 9", AmmountTransfer = 234,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-22 05:28:20"),Description = "Transferencia a Familia 10", AmmountTransfer = 34.25,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-23 06:28:20"),Description = "Transferencia a Familia 11", AmmountTransfer = 24.1,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-23 07:28:20"),Description = "Transferencia a Familia 12", AmmountTransfer = 234,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-23 08:28:20"),Description = "Transferencia a Familia 13", AmmountTransfer = 23,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-10-25 09:28:20"),Description = "Transferencia a Familia 14", AmmountTransfer = 44,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-01 10:28:20"),Description = "Transferencia a Familia 15", AmmountTransfer = 1200,  TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-03 11:28:20"),Description = "Transferencia a Familia 16", AmmountTransfer = 2222.6,  TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-05 12:28:20"),Description = "Transferencia a Familia 17", AmmountTransfer = 24343.48, TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-06 13:28:20"),Description = "Transferencia a Familia 18", AmmountTransfer = 33,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-10 14:28:20"),Description = "Transferencia a Familia 19", AmmountTransfer = 666,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-10 15:28:20"),Description = "Transferencia a Familia 20", AmmountTransfer = 12.5,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-10 16:28:20"),Description = "Transferencia a Familia 21", AmmountTransfer = 3434,  TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-11-15 08:28:20"),Description = "Transferencia a Familia 22", AmmountTransfer = 23,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-20 02:28:20"),Description = "Transferencia a Familia 23", AmmountTransfer = 43,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-25 03:28:20"),Description = "Transferencia a Familia 24", AmmountTransfer = 233,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-26 04:28:20"),Description = "Transferencia a Familia 25", AmmountTransfer = 44,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-30 05:28:20"),Description = "Transferencia a Familia 26", AmmountTransfer = 34,    TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-30 06:28:20"),Description = "Transferencia a Familia 27", AmmountTransfer = 222,   TypeTransfer = "D" },
            new ProductMovements() { Date = DateTime.Parse("2014-12-31 06:28:20"),Description = "Transferencia a Familia 29", AmmountTransfer = 34,    TypeTransfer = "D" }
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
