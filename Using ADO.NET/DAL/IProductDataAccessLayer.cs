using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
     interface IProductDataAccessLayer
    {
        /// <summary>
        /// Get an Enumerable collection of ProductDataObjects
        /// </summary>
        /// <returns>An IEnumerable collection of ProductDataObjects</returns>
         List<ProductDataObject> GetProductList();

        /// <summary>
        /// Get an Enumerable collection of ProductDataObjects
        /// </summary>
        /// <param name="color">Only return products that match this color</param>
        /// <returns></returns>
         List<ProductDataObject> GetProductList(string color);


        /// <summary>
        /// Get an Enumerable collection of ProductDataObjects
        /// </summary>
        /// <param name="maxListPrice">Only return products where the ListPrice is equal to or less that maxListPrice</param>
        /// <returns></returns>
         List<ProductDataObject> GetProductList(decimal maxListPrice);

        /// <summary>
        /// Get a single ProductDataObject by providing the ProductID
        /// </summary>
        /// <param name="productID">The Int ProductID of the ProductDataObject to return</param>
        /// <returns>A ProductDataObject</returns>
         ProductDataObject GetProduct(int productID);

        /// <summary>
        /// Updates a ProductDataObject in the Database
        /// </summary>
        /// <param name="product">The ProductDataObject to update</param>
         bool UpdateProduct(ProductDataObject product);

        /// <summary>
        /// Deletes a single Product from the Database
        /// </summary>
        /// <param name="product">The ProjectDataObject to delete</param>
         bool DeleteProduct(ProductDataObject product);

    }
}
