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
        public ProductViewModel Index(int productId)
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
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models/products.json");

                    #region read from file
                    using (var streamRead = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var r = new StreamReader(streamRead);

                        var json = r.ReadToEnd();
                        var jsonObj = JsonConvert.DeserializeObject<List<Product>>(json);

                        foreach (var val in jsonObj)
                        {
                            if (val.ProductID == model.ProductID)
                            {
                                val.ProductName = model.ProductName;
                                val.Category = model.Category;
                                val.Price = model.Price;
                                val.Quantity = model.Quantity;
                            }
                        }

                        output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);

                        r.Close();
                        streamRead.Close();
                    }
                    #endregion

                    #region write changes to file
                    using (var streamWrite = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var w = new StreamWriter(streamWrite);
                        w.Write(output);

                        w.Close();
                        streamWrite.Close();
                    }
                    #endregion
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