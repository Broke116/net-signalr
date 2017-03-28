using net_signalr.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace net_signalr.Services
{
    public class DataService
    {
        public DataService() { }

        public List<Product> GetData()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models/products.json");
            using(var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                var model = JsonConvert.DeserializeObject<List<Product>>(json);
                return model;
            }
        }

        public Product Get(int productId)
        {
            var product = GetData();
            return product.Where(p => p.ProductID == productId).FirstOrDefault();
        }
    }
}