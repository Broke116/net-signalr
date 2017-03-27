using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using net_signalr.Models;

namespace net_signalr.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadAllText("Models/products.json"));
            return View();
        }
    }
}