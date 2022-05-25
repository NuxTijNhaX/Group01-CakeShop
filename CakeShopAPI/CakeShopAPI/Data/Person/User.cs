using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("Users", Schema = "Person")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
