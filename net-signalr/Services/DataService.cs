using DAL.Repositories;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using net_signalr.Models;
using DAL;
using DAL.UnitOfWork;

namespace net_signalr.Services
{
    public class DataService
    {
        private ShopContext _dbContext;

        private IUnitOfWork _uow;
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<Category> _categoryRepository;

        public DataService()
        {
            _dbContext = new ShopContext();

            _uow = new UnitOfWork(_dbContext);
            _productRepository = new GenericRepository<Product>(_dbContext);
            _categoryRepository = new GenericRepository<Category>(_dbContext);
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

        public Product Get(int productId)
        {
            return _productRepository.GetById(productId);
            //var product = _productRepository.GetById(productId);
            //return product.Where(p => p.ProductID == productId).FirstOrDefault();
        }

        public void Update(Product model)
        {
            var updatedProduct = _productRepository.GetById(model.ProductID);
            var catId = _categoryRepository.GetAll(c => c.CategoryName == model.Category.CategoryName).FirstOrDefault();

            updatedProduct.ProductName = model.ProductName;
            updatedProduct.Price = model.Price;
            updatedProduct.Quantity = model.Quantity;
            updatedProduct.Category = model.Category;

            //updatedProduct = new Product
            //{
            //    ProductName = model.ProductName,
            //    Price = model.Price,
            //    Quantity = model.Quantity,
            //    Category = model.Category
            //};

            _productRepository.Update(updatedProduct);
            _uow.SaveChanges();
        }
    }
}