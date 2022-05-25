using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double AvgRating { get; set; }
        public int NumberOfPurchases { get; set; }
        public DateTime DateRealease { get; set; }
        public string Photos { get; set; }
        public string Category { get; set; }
        public int totalPage { get; set; }
    }
}
