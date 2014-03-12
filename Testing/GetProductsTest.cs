using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DataAccess.Managment;
using Adapters.Interfaces.Managment;
using DataObjects.Managment;
using NUnit.Framework;
using Presentation.Managment;
using Rhino.Mocks;
using StructureMap;

namespace Testing
{
    public class GetProductsTest
    {
        MockRepository mocks;
        IProductsAdapters mockIProductsAdaptersView;
        [SetUp]
        public void Init()
        {
            mocks = new MockRepository();
            mockIProductsAdaptersView = mocks.DynamicMock<IProductsAdapters>();
            ObjectFactory.Initialize(x =>
            {
                // Mocks
            });
        }

        [Category("Products")]
        [Test(Description = "Obtener Listado de Productos")]
        public void GetAllProductsTest()
        {
            ProductsAdapters loginPresenter = ObjectFactory.With<IProductsAdapters>(mockIProductsAdaptersView as IProductsAdapters).GetInstance<ProductsAdapters>();
            Assert.AreNotEqual(loginPresenter.GetProducts().Count(), 0);
        }

        [Category("Products")]
        [Test(Description = "Obtener Listado de Productos por un array de Tipo de producto")]
        public void GetProductsByArrProductTypeTest()
        {
            ProductsAdapters loginPresenter = ObjectFactory.With<IProductsAdapters>(mockIProductsAdaptersView as IProductsAdapters).GetInstance<ProductsAdapters>();
            int[] filterProductType = new int[] { 3 };
            List<Product> ret = loginPresenter.GetProducts(filterProductType).ToList();
            Assert.AreEqual(ret.Count, 1);
        }

        [Category("Products")]
        [Test(Description = "Obtener Listado de Productos por Tipo de producto y tipo de moneda")]
        public void GetProductsByProductTypeAndCureencyTypeTest()
        {
            ProductsAdapters loginPresenter = ObjectFactory.With<IProductsAdapters>(mockIProductsAdaptersView as IProductsAdapters).GetInstance<ProductsAdapters>();
            int filterProductType = 3;
            int filterCurrencyType = 4;
            List<Product> ret = loginPresenter.GetProducts(filterProductType, filterCurrencyType).ToList();
            Assert.AreEqual(ret.Count, 1);
        }

        [Category("Products")]
        [Test(Description = "Obtener Listado de Productos por un array de Tipo de producto y por  tipo de moneda")]
        public void GetProductsByArrProductTypeAndCureencyTypeTest()
        {
            ProductsAdapters loginPresenter = ObjectFactory.With<IProductsAdapters>(mockIProductsAdaptersView as IProductsAdapters).GetInstance<ProductsAdapters>();
            int[] filterProductType = new int[] { 4 };
            int filterCurrencyType = 4;
            List<Product> ret = loginPresenter.GetProducts(filterProductType, filterCurrencyType).ToList();
            Assert.AreEqual(ret.Count, 2);
        }
    }
}
