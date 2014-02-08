using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects.Managment;
using DataObjects.User;
using NUnit.Framework;
using Shared.Commons;

namespace Testing
{
    public class EvaluatedNavigationTest
    {

        #region "Parameters default evaluation"
        List<Product> testObjProducts = new List<Product>();
        Entity testObjUserNatural = new Entity();
        Entity testObjUserCompany = new Entity();
        Entity testObjUserGroup = new Entity();

        Dictionary<string, object> testParameters = new Dictionary<string, object>();
        string testCondition = string.Empty;
        #endregion

        [SetUp]
        public void Init()
        {
            testObjUserNatural = new Entity()
            {
                ID = 1,
                Names = "PEPITO PEREZ",
                EMail = "pepitoperez@cobiscorp.com",
                FirstLastName = "Pepito Perez",
                SecondLastName = "Ramonez",
                Username = "pepito",
                Type = "P"
            };

            testObjUserCompany = new Entity()
            {
                ID = 2,
                Names = "CASTRO MANUEL",
                EMail = "castromanuel@cobiscorp.com",
                FirstLastName = "Castro Manuel",
                SecondLastName = "Perero",
                Username = "cmanuel",
                Type = "C"
            };

            testObjUserGroup = new Entity()
            {
                ID = 3,
                Names = "GROUP PEPSICO",
                EMail = "pepsico@cobiscorp.com",
                FirstLastName = "GRUPO PAPA CORPORATION",
                SecondLastName = "GROUP PEPSICO",
                Username = "GPEPSICO",
                Type = "G"
            };

            testObjProducts.Add(new Product() { Account = "111111111", AmmountAvailable = 12.25, Currency = 0, Type = 3, Name = "CORRIENTE JUAN" });
            testObjProducts.Add(new Product() { Account = "222222222", AmmountAvailable = 1000, Currency = 1, Type = 3, Name = "CORRIENTE PEDRO" });
            testObjProducts.Add(new Product() { Account = "333333333", AmmountAvailable = 500.25, Currency = 1, Type = 4, Name = "AHORROS MARIA" });
            testObjProducts.Add(new Product() { Account = "444444444", AmmountAvailable = 700.25, Currency = 0, Type = 4, Name = "AHORROS MARIA" });
            testObjProducts.Add(new Product() { Account = "555555555", AmmountAvailable = 200, Currency = 1, Type = 4, Name = "AHORROS JULIA" });
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation Flag 700")]
        public void NavigationSimpleFlagTest()
        {
            testCondition = @"([MyFlag]==700);";

            testParameters.Clear();
            testParameters.Add("MyFlag", 700);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation Products>5")]
        public void NavigationSimpleTest()
        {
            testCondition = @"([MyProducts].Count>=5) #AND# ([MyFlag]==100);";

            testParameters.Clear();
            testParameters.Add("MyProducts", testObjProducts);
            testParameters.Add("MyFlag", 100);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation 1 Entity Natural")]
        public void NavigationByTypeEntityTest()
        {
            testCondition = @"([MyEntity].Type=='P') #AND# ([MyFlag]==200);";

            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserNatural);
            testParameters.Add("MyFlag", 200);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation 1 Entity Company or Group")]
        public void NavigationByTypeEntityCompanyOrGroupTest()
        {
            testCondition = @"(([MyEntity].Type=='C') #OR# ([MyEntity].Type=='G')) #AND# ([MyFlag]==300);";

            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserCompany);
            testParameters.Add("MyFlag", 300);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation 1 Entity Natural with Saving Products >= 2")]
        public void NavigationByTypeEntityAndProducts1Test()
        {
            testCondition = @"([MyEntity].Type=='P') #AND# ([[({COUNT}[MyProducts].Type=='4')]]>=2) #AND# ([MyFlag]==400);";

            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserNatural);
            testParameters.Add("MyProducts", testObjProducts);
            testParameters.Add("MyFlag", 400);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation 1 Entity Natural with Ckecking Products >= 1")]
        public void NavigationByTypeEntityAndProducts2Test()
        {
            testCondition = @"([MyEntity].Type=='P') #AND# ([[({COUNT}[MyProducts].Type=='3')]]>=1) #AND# ([MyFlag]==500);";

            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserNatural);
            testParameters.Add("MyProducts", testObjProducts);
            testParameters.Add("MyFlag", 500);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Test(Description = "Evaluate Navigation 1 Entity Group and 2 Saving Products with Ammount Available >=500 ")]
        public void NavigationByTypeEntityAndProducts3Test()
        {
            testCondition = @"([MyEntity].Type=='G') #AND# ([[({COUNT}[MyProducts].Type=='4')#AND#([MyProducts].AmmountAvailable>='500')]]>=2) #AND# ([MyFlag]==600);";

            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserGroup);
            testParameters.Add("MyProducts", testObjProducts);
            testParameters.Add("MyFlag", 600);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Navigation 1 Entity Group and 2 Saving Products with Ammount Available >=200 and total >= 1200.50")]
        public void NavigationByTypeEntityAndProducts4Test()
        {
            testCondition = @"([MyEntity].Type=='G') #AND# ([[({COUNT}[MyProducts].Type=='4')]]>=2) #AND# ([[({SUM}([MyProducts].AmmountAvailable>='200')#AND#([MyProducts].Type=='4'))]]>=1200.50) #AND# ([MyFlag]==1000);";

            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserGroup);
            testParameters.Add("MyProducts", testObjProducts);
            testParameters.Add("MyFlag", 1000);


            NavigationUtils NavigationUtils = new NavigationUtils(testParameters, testCondition);
            bool conditionSucceed = NavigationUtils.GetResultsEvaluation();

            Assert.IsTrue(conditionSucceed, "The result must be true");
        }

        [Category("Navigation")]
        [Test(Description = "Evaluate Complete steps for firts to seven step finalize")]
        public void NavigationFullTest()
        {
            testParameters.Clear();
            testParameters.Add("MyEntity", testObjUserGroup);
            testParameters.Add("MyProducts", testObjProducts);
            testParameters.Add("MyFlag", 1000);

            string[] conditions = new string[]{
                "([MyProducts].Count>=5) #AND# ([MyFlag]==100);",
                "([MyEntity].Type=='P') #AND# ([MyFlag]==200);",
                "(([MyEntity].Type=='C') #OR# ([MyEntity].Type=='G')) #AND# ([MyFlag]==300);",
                "([MyEntity].Type=='P') #AND# ([[({COUNT}[MyProducts].Type=='4')]]>=2) #AND# ([MyFlag]==400);",
                "([MyEntity].Type=='P') #AND# ([[({COUNT}[MyProducts].Type=='3')]]>=1) #AND# ([MyFlag]==500);",
                "([MyEntity].Type=='G') #AND# ([[({COUNT}[MyProducts].Type=='4')#AND#([MyProducts].AmmountAvailable>='500')]]>=2) #AND# ([MyFlag]==600);",
                "([MyEntity].Type=='G') #AND# ([[({COUNT}[MyProducts].Type=='4')]]>=2) #AND# ([[({SUM}([MyProducts].AmmountAvailable>='200')#AND#([MyProducts].Type=='4'))]]>=1200.50) #AND# ([MyFlag]==1000);"
            };

            bool conditionSucceed = false;
            int id = 0;

            foreach (string condition in conditions)
            {
                if (!conditionSucceed)
                {
                    id+=1;
                    NavigationUtils NavigationUtils = new NavigationUtils(testParameters, condition);
                    conditionSucceed = NavigationUtils.GetResultsEvaluation();
                }
            }

            Assert.AreEqual(id, 7, "The result step in : " + id.ToString());
            Assert.IsTrue(conditionSucceed, "The result step in : " + id.ToString());
        }
    }
}
