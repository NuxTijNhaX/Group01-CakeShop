using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    [Table("ProductCategories", Schema = "Production")]
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
