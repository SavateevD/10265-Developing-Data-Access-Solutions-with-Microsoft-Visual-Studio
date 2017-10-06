using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.Data.Linq;


namespace Test_Application
{
    public partial class Form1 : Form
    {
        private ProductDataAccessLayer dal;
        private List<ProductDataObject> products;
        private List<ProductDataObject> updatedProducts = new List<ProductDataObject>();
        private List<ProductDataObject> deletedProducts = new List<ProductDataObject>();

        public Form1()
        {
            InitializeComponent();

            //Create a new instance of the DAL
            dal = new ProductDataAccessLayer();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            txtColor.Text = "";
            txtPrice.Text = "";
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            txtPrice.Text = "";
            txtProductID.Text = "";
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            txtColor.Text = "";
        }

        /// <summary>
        /// Populate the productDataGrid with all of the products in the Database
        /// </summary>
        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            UpdateProductsGrid();
        }

        /// <summary>
        /// Populate the productDataGrid with the product specified in the txtProductID textbox
        /// </summary>
        private void btnSearchByProduct_Click(object sender, EventArgs e)
        {
            int prodID;
            if (!Int32.TryParse(txtProductID.Text, out prodID))
            {
                MessageBox.Show("Product ID must be an integer value", "Error");
                return;
            }

            products = null;
            products = new List<ProductDataObject>();

            try
            {

                ProductDataObject prod = dal.GetProduct(prodID);
                if (prod != null)
                {
                    products.Add(dal.GetProduct(prodID));
                }
                else
                {
                    MessageBox.Show("Product not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            productDataGrid.DataSource = products;
        }

        /// <summary>
        /// Populate the productDataGrid with all products that match the color specified in the txtColor textbox
        /// </summary>
        private void btnSearchColor_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("You must enter a color", "Error");
                return;
            }


            products = null;

            try
            {
                products = dal.GetProductList(txtColor.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (products.Count == 0)
            {
                MessageBox.Show("No products found");
            }
            productDataGrid.DataSource = products;
        }

        /// <summary>
        /// Populate the productDataGrid with all products that cost less than the price specified in the txtPrice textbox
        /// </summary>
        private void bntSearchPrice_Click(object sender, EventArgs e)
        {
            decimal maxPrice;
            if (!decimal.TryParse(txtPrice.Text, out maxPrice))
            {
                MessageBox.Show("Maximum Price must be a decimal value", "Error");
                return;
            }


            products = null;

            try
            {
                products = dal.GetProductList(maxPrice);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            if (products.Count == 0)
            {
                MessageBox.Show("No products found");
            }
            productDataGrid.DataSource = products;
        }

        /// <summary>
        /// Delete the selected product from the Database
        /// </summary>
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the current position due to not allow empty datagrid.
                CurrencyManager cm =
                  (CurrencyManager)this.BindingContext[productDataGrid.DataSource];

                // Place cursor on position up
                int removeAt = cm.Position;
                if (removeAt > 0)
                {
                    cm.Position = removeAt - 1;
                }

                // Remove current Entry from the grid and add it to the deletedProducts list
                deletedProducts.Add(products[removeAt]);
                products.RemoveAt(removeAt);

                if (cm != null)
                {
                    cm.Refresh();
                }
            }
          
            catch (Exception ex)
            {
                MessageBox.Show("There was an error \n" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //apply updates
                foreach (ProductDataObject p in updatedProducts)
                {
                    dal.UpdateProduct(p);
                }

                //apply deletes
                foreach (ProductDataObject p in deletedProducts)
                {
                    dal.DeleteProduct(p);
                }
                updatedProducts.Clear();
                deletedProducts.Clear();
                UpdateProductsGrid();

            }
            catch (ChangeConflictException)
            {
                updatedProducts.Clear();
                deletedProducts.Clear();
                MessageBox.Show("A Concurrency Error occured, reload the product list");
            }
            catch (Exception ex)
            {
                updatedProducts.Clear();
                deletedProducts.Clear();
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProductsGrid()
        {            
            products = dal.GetProductList();
            productDataGrid.DataSource = products;
        }

        /// <summary>
        /// Validate the cell input
        /// </summary>
        private void productDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal newListPrice;
            productDataGrid.Rows[e.RowIndex].ErrorText = "";

            if (productDataGrid.Columns[e.ColumnIndex].DataPropertyName == "ListPrice")
            {
                if (!Decimal.TryParse(e.FormattedValue.ToString(), out newListPrice))
                {
                    productDataGrid.Rows[e.RowIndex].ErrorText = "Value must be a decimal";
                    e.Cancel = true;
                }
            }

            if ((productDataGrid.Columns[e.ColumnIndex].DataPropertyName == "Name") ||
                (productDataGrid.Columns[e.ColumnIndex].DataPropertyName == "ProductNumber"))
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    productDataGrid.Rows[e.RowIndex].ErrorText = "Value must be a string";
                    e.Cancel = true;
                }
            }
        }

        private void productDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ProductDataObject p = (ProductDataObject)productDataGrid.Rows[e.RowIndex].DataBoundItem;
            updatedProducts.Add(p);
        }
    }
}
