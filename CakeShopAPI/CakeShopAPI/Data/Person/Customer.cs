using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("Customers", Schema = "Person")]
    public class Customer
    {
        [Key]
        [ForeignKey("User")]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }

        public virtual User User { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
