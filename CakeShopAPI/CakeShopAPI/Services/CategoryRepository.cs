using CakeShopAPI.Data;
using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CakeShopDbContext _dbContext;

        public CategoryRepository(CakeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductCategoryVM Add(ProductCategoryVM productCategory)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryVM> GetAll()
        {
            var categories = _dbContext.ProductCategories.Select(pro => new ProductCategoryVM
            {
                Id = pro.Id,
                Name = pro.Name
            }).ToList();

            return categories;
        }

        public ProductCategoryVM GetById()
        {
            throw new NotImplementedException();
        }
    }
}
