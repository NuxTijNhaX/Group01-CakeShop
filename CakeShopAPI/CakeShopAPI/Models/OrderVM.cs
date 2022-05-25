using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Models
{
    public class OrderVM
    {
        public int UserId { get; set; }
        public List<OrderLineVM> orderLines { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalCost { get; set; }
    }
}
