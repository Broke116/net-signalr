using System;
using System.IO;
using System.Web.Mvc;
using net_signalr.Services;
//using net_signalr.Models;
using DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public ActionResult GetProductModal()
        {
            return PartialView("Partials/_InsertProductPartial");
        }

        [HttpGet]
        public ActionResult GetProductDetail(int id)
        {
            var product = service.Get(id);

            return PartialView("Partials/_EditProductPartial", product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product model)
        {
            string output = "";

            if (ModelState.IsValid)
            {
                try
                {
                    service.Update(model);
                }
                catch (IOException e)
                {
                    throw e;
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult InsertProduct(Product model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}