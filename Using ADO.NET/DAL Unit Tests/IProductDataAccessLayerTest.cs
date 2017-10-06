using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;


namespace DAL_Unit_Tests
{


    /// <summary>
    ///This is a test class for IProductDataAccessLayerTest and is intended
    ///to contain all IProductDataAccessLayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IProductDataAccessLayerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

    
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {

            using (var connection = new SqlConnection(AWDatabase.DatabaseConnectionString))
            {
                connection.Open();
                Stream s = (Stream)Assembly.GetExecutingAssembly().GetManifestResourceStream("DAL_Unit_Tests.SQL.resetProducts.sql");
                string resetString = new StreamReader(s).ReadToEnd();
                SqlCommand resetProductsTable = new SqlCommand(resetString, connection);

                resetProductsTable.ExecuteNonQuery();

            }
        }
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IProductDataAccessLayer CreateIProductDataAccessLayer()
        {
            IProductDataAccessLayer target = new ProductDataAccessLayer();
            return target;
        }

        
        private static List<ProductDataObject> GetLocalProductList()
        {
            List<ProductDataObject> productList = new List<ProductDataObject>();
            ProductDataObject prod1 = new ProductDataObject() { ProductID = 1, Name = "Adjustable Race", ProductNumber = "AR-5381", Color = null, ListPrice = 0.00M,  ModifiedDate = new DateTime(2004, 03, 11,10,01,36,827) };
            ProductDataObject prod2 = new ProductDataObject() { ProductID = 2, Name = "Bearing Ball", ProductNumber = "BA-8327", Color = null, ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod3 = new ProductDataObject() { ProductID = 3, Name = "BB Ball Bearing", ProductNumber = "BE-2349", Color = null, ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod4 = new ProductDataObject() { ProductID = 4, Name = "Headset Ball Bearings", ProductNumber = "BE-2908", Color = null, ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod5 = new ProductDataObject() { ProductID = 316, Name = "Blade", ProductNumber = "BL-2036", Color = null, ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod6 = new ProductDataObject() { ProductID = 317, Name = "LL Crankarm", ProductNumber = "CA-5965", Color = "Black", ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod7 = new ProductDataObject() { ProductID = 318, Name = "ML Crankarm", ProductNumber = "CA-6738", Color = "Black", ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod8 = new ProductDataObject() { ProductID = 319, Name = "HL Crankarm", ProductNumber = "CA-7457", Color = "Black", ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod9 = new ProductDataObject() { ProductID = 320, Name = "Chainring Bolts", ProductNumber = "CB-2903", Color = "Silver", ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };
            ProductDataObject prod10 = new ProductDataObject() { ProductID = 321, Name = "Chainring Nut", ProductNumber = "CN-6137", Color = "Silver", ListPrice = 0.00M, ModifiedDate = new DateTime(2004, 03, 11, 10, 01, 36, 827) };

            productList.Add(prod1);
            productList.Add(prod2);
            productList.Add(prod3);
            productList.Add(prod4);
            productList.Add(prod5);
            productList.Add(prod6);
            productList.Add(prod7);
            productList.Add(prod8);
            productList.Add(prod9);
            productList.Add(prod10);
            return productList;
        }

      

        /// <summary>
        ///A test for GetProductList
        ///</summary>
        [TestMethod()]
        public void GetProductListTest()
        {
            IProductDataAccessLayer target = CreateIProductDataAccessLayer(); 

            List<ProductDataObject> expected = GetLocalProductList();

            List<ProductDataObject> actual;
            actual = target.GetProductList();

            for (int i = 0; i <= actual.Count-1; i++)
            {
                Assert.AreEqual(actual[i].Color, expected[i].Color);
                Assert.AreEqual(actual[i].ListPrice, expected[i].ListPrice);
                Assert.AreEqual(actual[i].ModifiedDate, expected[i].ModifiedDate);
                Assert.AreEqual(actual[i].Name, expected[i].Name);
                Assert.AreEqual(actual[i].ProductID, expected[i].ProductID);
                Assert.AreEqual(actual[i].ProductNumber, expected[i].ProductNumber);
            }

        }

        /// <summary>
        ///A test for GetProduct
        ///</summary>
        [TestMethod()]
        public void GetProductByProductIDTest()
        {
            IProductDataAccessLayer target = CreateIProductDataAccessLayer(); 
            int productID = 319;
            ProductDataObject expected = GetLocalProductList().Find(p => p.ProductID == productID);
            ProductDataObject actual;
            actual = target.GetProduct(productID);

            Assert.AreEqual(actual.Color, expected.Color);
            Assert.AreEqual(actual.ListPrice, expected.ListPrice);
            Assert.AreEqual(actual.ModifiedDate, expected.ModifiedDate);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.ProductID, expected.ProductID);
            Assert.AreEqual(actual.ProductNumber, expected.ProductNumber);
        }

    

        /// <summary>
        ///A test for GetProductList
        ///</summary>
        [TestMethod()]
        public void GetProductListByMaxPriceTest()
        {
            IProductDataAccessLayer target = CreateIProductDataAccessLayer(); 
            Decimal maxListPrice = new Decimal(100.00);
            List<ProductDataObject> expected = GetLocalProductList().FindAll(p => p.ListPrice <= maxListPrice);
            List<ProductDataObject> actual;
            actual = target.GetProductList(maxListPrice);
            for (int i = 0; i <= actual.Count - 1; i++)
            {
                Assert.AreEqual(actual[i].Color, expected[i].Color);
                Assert.AreEqual(actual[i].ListPrice, expected[i].ListPrice);
                Assert.AreEqual(actual[i].ModifiedDate, expected[i].ModifiedDate);
                Assert.AreEqual(actual[i].Name, expected[i].Name);
                Assert.AreEqual(actual[i].ProductID, expected[i].ProductID);
                Assert.AreEqual(actual[i].ProductNumber, expected[i].ProductNumber);
            }
        }

        /// <summary>
        ///A test for GetProductList
        ///</summary>
        [TestMethod()]
        public void GetProductListByColorTest()
        {
            IProductDataAccessLayer target = CreateIProductDataAccessLayer();
            string color = "Silver";
            List<ProductDataObject> expected = GetLocalProductList().FindAll(p=>p.Color==color);
            List<ProductDataObject> actual;
            actual = target.GetProductList(color);
            for (int i = 0; i <= actual.Count-1; i++)
            {
                Assert.AreEqual(actual[i].Color, expected[i].Color);
                Assert.AreEqual(actual[i].ListPrice, expected[i].ListPrice);
                Assert.AreEqual(actual[i].ModifiedDate, expected[i].ModifiedDate);
                Assert.AreEqual(actual[i].Name, expected[i].Name);
                Assert.AreEqual(actual[i].ProductID, expected[i].ProductID);
                Assert.AreEqual(actual[i].ProductNumber, expected[i].ProductNumber);
            }
        }

      

        /// <summary>
        ///A test for UpdateProduct
        ///</summary>
        [TestMethod()]
        public void UpdateProductTest()
        {
            bool result = false;
            IProductDataAccessLayer target = CreateIProductDataAccessLayer();
            ProductDataObject product = GetLocalProductList().Find(p => p.ProductID == 1);
            product.Color = "Red";
            product.ListPrice = 12.99M;
            result=target.UpdateProduct(product);

            Assert.IsTrue(result);
          
        }

        /// <summary>
        ///A test for DeleteProduct
        ///</summary>
        [TestMethod()]
        public void DeleteProductTest()
        {
            bool result = false;
            IProductDataAccessLayer target = CreateIProductDataAccessLayer(); 
            ProductDataObject product = GetLocalProductList().Find(p => p.ProductID == 1);
            result = target.DeleteProduct(product);
            Assert.IsTrue(result);
        }
    }
}
