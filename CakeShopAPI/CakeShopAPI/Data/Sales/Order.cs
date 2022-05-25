using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("Orders", Schema = "Sales")]
    public class Order
    {
        [Key]
        public Guid guidOrder { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double TotalCost { get; set; }

        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
