using System.Web.Mvc;
using net_signalr.Services;
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
    }
}