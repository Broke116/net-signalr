using DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace net_signalr.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }

        //public SelectList CategoryList { get; set; }
        public string SelectedCategory { get; set; }

        public Category Category { get; set; }
    }
}