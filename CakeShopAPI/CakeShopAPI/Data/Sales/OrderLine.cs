using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("OrderLines", Schema = "Sales")]
    public class OrderLine
    {
        public int Id { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public Guid OrderGuid { get; set; }
        public virtual Order Order { get; set; }

        public int SizeId { get; set; }
        public virtual Size Size { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
