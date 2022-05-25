using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("Contacts", Schema = "Person")]
    public class Contact
    {
        [Key]
        [ForeignKey("Customer")]
        public int ContactId { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
