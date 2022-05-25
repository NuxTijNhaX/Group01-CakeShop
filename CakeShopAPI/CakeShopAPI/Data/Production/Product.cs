using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
   [Table("Products", Schema = "Production")]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double AvgRating { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfPurchases { get; set; }
        [Required]
        public DateTime DateRealease { get; set; }
        [Required]
        public string Photos { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
