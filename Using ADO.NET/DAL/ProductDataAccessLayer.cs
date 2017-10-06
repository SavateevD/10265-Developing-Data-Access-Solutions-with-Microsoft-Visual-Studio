
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

namespace DAL
{
    public class ProductDataAccessLayer : IProductDataAccessLayer
    {
        public ProductDataAccessLayer()
        {

        }

        #region IProductDataAccessLayer Members

        /// <summary>
        /// This method returns all of the Products from the Adventure Works Database
        /// </summary>
        /// <returns>A list of ProductDataObject's </returns>
        public List<ProductDataObject> GetProductList()
        {
            using (DataContext db = new DataContext(DAL.Properties.Settings.Default.AdventureWorksConnectionString))
            {
                return db.GetTable<ProductDataObject>().ToList();
            }
        }

        /// <summary>
        /// Return a specified product.  Products are identified by the Product ID
        /// </summary>
        /// <param name="productID">The Product ID to return</param>
        /// <returns>A ProductDataObject</returns>
        public ProductDataObject GetProduct(int productID)
        {
            using (DataContext db = new DataContext(DAL.Properties.Settings.Default.AdventureWorksConnectionString))
            {
                return db.GetTable<ProductDataObject>().Single(p => p.ProductID == productID);
            }
        }

        /// <summary>
        /// An overload of the GetProductList method that returns a list of products that match the specified color.
        /// </summary>
        /// <param name="color">The Color of the products to return</param>
        /// <returns>A list of ProductDataObject's that are match the specified color.</returns>
        public List<ProductDataObject> GetProductList(string color)
        {
            using (DataContext db = new DataContext(DAL.Properties.Settings.Default.AdventureWorksConnectionString))
            {
                var list = from p in db.GetTable<ProductDataObject>()
                           where String.Compare(p.Color, color, true) == 0
                           select p;

                return list.ToList();
            }
        }

        /// <summary>
        /// An overload of the GetProductList method that returns a list of products who's list price is less than or equal to the specified price.
        /// </summary>
        /// <param name="maxListPrice">The maximum list price</param>
        /// <returns>A list of ProductDataObject's who's list price is less than or equal to the specified maxListPrice</returns>
        public List<ProductDataObject> GetProductList(decimal maxListPrice)
        {
            using (DataContext db = new DataContext(DAL.Properties.Settings.Default.AdventureWorksConnectionString))
            {
                var list = from p in db.GetTable<ProductDataObject>()
                           where p.ListPrice <= maxListPrice
                           select p;

                return list.ToList();
            }
        }

        /// <summary>
        /// Updates a product in the database.
        /// </summary>
        /// <param name="product">The ProductDataObject to update</param>
        /// <returns>True if the update is successful</returns>
        public bool UpdateProduct(ProductDataObject product)
        {
            bool result = false;

            using (DataContext db = new DataContext(DAL.Properties.Settings.Default.AdventureWorksConnectionString))
            {
                try
                {
                    ProductDataObject prod = db.GetTable<ProductDataObject>().Single(p => p.ProductID == product.ProductID);

                    prod.Name = product.Name;
                    prod.ProductNumber = product.ProductNumber;
                    prod.Color = product.Color;
                    prod.ListPrice = product.ListPrice;
                    prod.ModifiedDate = DateTime.Today;
                    db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    result = true;
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict oce in db.ChangeConflicts)
                    {
                        oce.Resolve(RefreshMode.OverwriteCurrentValues);
                    }
                    throw;
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception("The product has already been deleted. Reload the product list.");
                }
                return result;
            }
        }

        /// <summary>
        /// Delete a product from the database.
        /// </summary>
        /// <param name="product">The ProductDataObject to delete</param>
        /// <returns>True if the delete is successful</returns>
        public bool DeleteProduct(ProductDataObject product)
        {
            bool result = false;

            using (DataContext db = new DataContext(DAL.Properties.Settings.Default.AdventureWorksConnectionString))
            {
                try
                {
                    ProductDataObject prod = db.GetTable<ProductDataObject>().Single(p => p.ProductID == product.ProductID);

                    db.GetTable<ProductDataObject>().DeleteOnSubmit(prod);
                    db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    result = true;
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict oce in db.ChangeConflicts)
                    {
                        oce.Resolve(RefreshMode.OverwriteCurrentValues);
                    }
                    throw;
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception("The product has already been deleted. Reload the product list.");
                }
                return result;
            }
        }

        #endregion
    }
}

