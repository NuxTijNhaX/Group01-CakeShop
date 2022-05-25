using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("Invoices", Schema = "Sales")]
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey("Order")]
        public Guid OrderGuid { get; set; }
        public virtual Order Order { get; set; }
    }
}
