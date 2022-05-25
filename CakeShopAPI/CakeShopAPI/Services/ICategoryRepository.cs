using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public interface ICategoryRepository
    {
        List<ProductCategoryVM> GetAll();
        ProductCategoryVM GetById();
        ProductCategoryVM Add(ProductCategoryVM productCategory);
    }
}
