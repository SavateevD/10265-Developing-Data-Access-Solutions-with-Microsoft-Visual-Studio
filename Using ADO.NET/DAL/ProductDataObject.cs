using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.ComponentModel;

namespace DAL
{
    [Table(Name = "AdventureWorks.Production.Product")]
    public class ProductDataObject : IDataErrorInfo
    {
        private int productID;
        private string name;
        private string productNumber;
        private string color;
        private decimal listPrice;
        private DateTime modifiedDate;

        [Column(Name = "ProductID", IsPrimaryKey = true, CanBeNull = false)]
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        [Column(Name = "Name", CanBeNull = false)]
        public string Name
        {
            get { return name.ToUpper(); }
            set { name = value; }
        }

        [Column(Name = "ProductNumber", CanBeNull = false)]
        public string ProductNumber
        {
            get { return productNumber; }
            set { productNumber = value; }
        }

        [Column(Name = "Color", CanBeNull = true)]
        public string Color
        {
            get 
            {
                if (!String.IsNullOrEmpty(color))
                {
                    return color.ToUpper();
                }
                return null;
            }
            set
            {
                color = value != null ? value.ToUpper() : String.Empty;
            }
        }

        [Column(Name = "ListPrice", CanBeNull = false)]
        public decimal ListPrice
        {
            get { return listPrice; }
            set { listPrice = value; }
        }

        [Column(Name = "ModifiedDate", CanBeNull = false)]
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        #region IDataErrorInfo Members

        public string this[string columnName]
        {
            get
            {
                if ((columnName == "Name") && String.IsNullOrEmpty(Name))
                {
                    return "Name cannot be null";
                }
                if ((columnName == "ProductNumber") && String.IsNullOrEmpty(ProductNumber))
                {
                    return "Product Number cannot be null";
                }
                if ((columnName == "ListPrice") && listPrice < 10)
                {
                    return "List Price must be at least 10.00";
                }
                return null;
            }
        }

        public string Error
        {
            get { return null; } // Not required
        }

        #endregion
    }
}
