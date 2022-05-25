using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public interface IProductRepository
    {
        List<ProductVM> GetByArray(string idArray);
        List<ProductVM> GetAll(string search, string category, string orderBy, int page);
        List<ProductVM> GetTrendingProducts(int top);
        List<ProductVM> GetNewProducts(int top);
        ProductVM GetById(int id);
        void Create(ProductVM product);
        void Update(ProductVM product);
        void Delete(int productId);
    }
}
