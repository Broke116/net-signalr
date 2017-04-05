using DAL.Repositories;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using net_signalr.Models;

namespace net_signalr.Services
{
    public class DataService
    {
        private readonly IGenericRepository<Product> _productRepository;
        public DataService()
        {
            _productRepository = new GenericRepository<Product>();
        }

        public List<ProductViewModel> GetData()
        {
            var products = _productRepository.GetAll()
                .Select(p => new ProductViewModel
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Category = p.Category
                })
                .ToList();

            return products;
        }

        public ProductViewModel Get(int productId)
        {
            var product = GetData();
            return product.Where(p => p.ProductID == productId).FirstOrDefault();
        }
    }
}