using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Models
{
    public class OrderLineVM
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
    }
}
