using System.Collections.Generic;

namespace DAL.Models
{
    public class Category
    {
        public Category()
        {

        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
