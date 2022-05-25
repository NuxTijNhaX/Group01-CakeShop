using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
   [Table("Sizes", Schema = "Production")]
    public class Size
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
