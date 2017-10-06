using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Test_Application.Models;

namespace Test_Application.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            ViewData["Message"] = "Test Application";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BrowseColor(ProductResponse productResponse)
        {
            if (string.IsNullOrEmpty(productResponse.Color))
            {
                ModelState.AddModelError("error", "Please enter a color");

            }
            if (ModelState.IsValid)
            {
                ProductDataAccessLayer dal = new ProductDataAccessLayer();
                List<ProductDataObject> products = dal.GetProductList(productResponse.Color);
                return View("Products", products);
            }
            else
            {
                return View("Index");
            }
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BrowsePrice(ProductResponse productResponse)
        {
            if (string.IsNullOrEmpty(productResponse.Price))
            {
                ModelState.AddModelError("error", "Please enter a price");

            }
            if (ModelState.IsValid)
            {
                
                decimal maxprice;
                bool valid = decimal.TryParse(productResponse.Price, out maxprice);

                ProductDataAccessLayer dal = new ProductDataAccessLayer();
                List<ProductDataObject> products = dal.GetProductList(maxprice);
                return View("Products", products);
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Products()
        {
            //create a new instance of the DAL

            ProductDataAccessLayer dal = new ProductDataAccessLayer();

            //Get a list of products
            List<ProductDataObject> products = dal.GetProductList();

            //Return the Products view, passing "products" the the view model
            return View(products);

        }


        public ActionResult Details(int id)
        {
            //create a new instance of the DAL

            ProductDataAccessLayer dal = new ProductDataAccessLayer();

            //Get the product who's productID matched id
            ProductDataObject product = dal.GetProduct(id);

            //Return the Details view, passing "product" the the view model
            return View(product);

        }
    }
}
