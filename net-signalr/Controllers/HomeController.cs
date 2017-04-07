using System;
using System.Web.Mvc;
using net_signalr.Services;
using DAL.Models;
using System.Data.Common;
using net_signalr.Models;

namespace net_signalr.Controllers
{
    public class HomeController : Controller
    {
        DataService service;

        public HomeController()
        {
            service = new DataService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = service.GetData();

            return View(products);
        }

        [Route("product/{productId}")]
        public Product Index(int productId)
        {
            var product = service.Get(productId);

            return product;
        }
        
        [HttpGet]
        public ActionResult GetProductDetail(int id)
        {
            var product = service.Get(id);

            return PartialView("Partials/_EditProductPartial", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Update(model);
                }
                catch (DbException e)
                {
                    throw e;
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetProductModal()
        {
            var categories = service.GetCategories();
            ViewBag.categories = categories;
            return PartialView("Partials/_InsertProductPartial"/*, model*/);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Add(model);
                }
                catch (DbException e)
                {
                    throw e;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}