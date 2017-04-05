using DAL.Models;

namespace net_signalr.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        
        public Category Category { get; set; }
    }
}