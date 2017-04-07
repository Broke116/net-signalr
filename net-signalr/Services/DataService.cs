using DAL.Repositories;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using net_signalr.Models;
using DAL;
using DAL.UnitOfWork;
using System.Web.Mvc;

namespace net_signalr.Services
{
    public class DataService/*<T> where T : class*/
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
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categoryRepository.GetAll().Distinct().ToList()
                .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName }).ToList();
        }

        public void Add(Product model)
        {
            _productRepository.Add(model);
            _uow.SaveChanges();
        }

        public void Update(Product model)
        {
            var updatedProduct = _productRepository.GetById(model.ProductID);
            var catId = _categoryRepository.GetAll(c => c.CategoryName == model.Category.CategoryName).FirstOrDefault();

            updatedProduct.ProductName = model.ProductName;
            updatedProduct.Price = model.Price;
            updatedProduct.Quantity = model.Quantity;
            updatedProduct.CategoryID = catId.CategoryID;

            _productRepository.Update(updatedProduct);
            _uow.SaveChanges();
        }
    }
}