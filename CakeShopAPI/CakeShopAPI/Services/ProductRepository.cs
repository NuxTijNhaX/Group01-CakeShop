using CakeShopAPI.Data;
using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CakeShopDbContext _dbContext;
        public static int PAGE_SIZE { get; set; } = 12;

        public ProductRepository(CakeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ProductVM product)
        {
            var categoryId = (from cate in _dbContext.ProductCategories
                            where cate.Name == product.Category
                            select cate.Id).FirstOrDefault();

            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                AvgRating = product.AvgRating,
                NumberOfPurchases = product.NumberOfPurchases,
                DateRealease = DateTime.Now,
                Photos = product.Photos,
                ProductCategoryId = categoryId
            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
        }

        public List<ProductVM> GetAll(string search, string category, string orderBy, 
            int page = 1)
        {
            var allProducts = (from pro in _dbContext.Products
                               select pro).AsQueryable();

            #region Category
            if (!string.IsNullOrEmpty(category))
            {
                allProducts = (from pro in allProducts
                               join proCate in _dbContext.ProductCategories
                               on pro.ProductCategoryId equals proCate.Id
                               where proCate.Name == category
                               select pro).AsQueryable();
            }
            #endregion

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(pro => pro.Name.Contains(search.Trim()));
            }
            #endregion

            #region Sorting
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "price_asc":
                        allProducts = allProducts.OrderBy(pro => pro.Price);
                        break;
                    case "price_desc":
                        allProducts = allProducts.OrderByDescending(pro => pro.Price);
                        break;
                    case "rating_asc":
                        allProducts = allProducts.OrderBy(pro => pro.AvgRating);
                        break;
                    case "rating_desc":
                        allProducts = allProducts.OrderByDescending(pro => pro.AvgRating);
                        break;
                    case "numOfPur_asc":
                        allProducts = allProducts.OrderBy(pro => pro.NumberOfPurchases);
                        break;
                    case "numOfPur_desc":
                        allProducts = allProducts.OrderByDescending(pro => pro.NumberOfPurchases);
                        break;
                    default:
                        break;
                }
            }
            #endregion

            int totalPage = (int)Math.Ceiling(allProducts.Count() * 1.0 / PAGE_SIZE);

            #region Paging
            allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            #endregion

            var products = (from pro in allProducts
                            join proCate in _dbContext.ProductCategories
                            on pro.ProductCategory.Id equals proCate.Id
                            select new ProductVM
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                Price = pro.Price,
                                Description = pro.Description,
                                AvgRating = pro.AvgRating,
                                NumberOfPurchases = pro.NumberOfPurchases,
                                DateRealease = pro.DateRealease,
                                Photos = pro.Photos,
                                Category = proCate.Name,
                                totalPage = totalPage,
                            }).ToList();

            return products;
        }

        public ProductVM GetById(int id)
        {
            var product = (from pro in _dbContext.Products
                           join proCate in _dbContext.ProductCategories
                           on pro.ProductCategory.Id equals proCate.Id
                           where pro.Id == id
                           select new ProductVM
                           {
                               Id = pro.Id,
                               Name = pro.Name,
                               Price = pro.Price,
                               Description = pro.Description,
                               AvgRating = pro.AvgRating,
                               NumberOfPurchases = pro.NumberOfPurchases,
                               DateRealease = pro.DateRealease,
                               Photos = pro.Photos,
                               Category = proCate.Name
                           }).FirstOrDefault();

            return product;
        }

        public List<ProductVM> GetTrendingProducts(int top)
        {
            var product = (from pro in _dbContext.Products
                           join proCate in _dbContext.ProductCategories
                           on pro.ProductCategory.Id equals proCate.Id
                           orderby pro.NumberOfPurchases descending
                           select new ProductVM
                           {
                               Id = pro.Id,
                               Name = pro.Name,
                               Price = pro.Price,
                               Description = pro.Description,
                               AvgRating = pro.AvgRating,
                               NumberOfPurchases = pro.NumberOfPurchases,
                               DateRealease = pro.DateRealease,
                               Photos = pro.Photos,
                               Category = proCate.Name
                           }).Take(top).ToList();

            return product;
        }

        public List<ProductVM> GetNewProducts(int top)
        {
            var product = (from pro in _dbContext.Products
                           join proCate in _dbContext.ProductCategories
                           on pro.ProductCategory.Id equals proCate.Id
                           orderby pro.DateRealease descending
                           select new ProductVM
                           {
                               Id = pro.Id,
                               Name = pro.Name,
                               Price = pro.Price,
                               Description = pro.Description,
                               AvgRating = pro.AvgRating,
                               NumberOfPurchases = pro.NumberOfPurchases,
                               DateRealease = pro.DateRealease,
                               Photos = pro.Photos,
                               Category = proCate.Name
                           }).Take(top).ToList();

            return product;
        }

        public void Update(ProductVM product)
        {
            var _product = _dbContext.Products.SingleOrDefault(pro => pro.Id == product.Id);

            var categoryId = (from cate in _dbContext.ProductCategories
                              where cate.Name == product.Category
                              select cate.Id).FirstOrDefault();

            _product.Name = product.Name;
            _product.Price = product.Price;
            _product.Description = product.Description;
            _product.AvgRating = product.AvgRating;
            _product.NumberOfPurchases = product.NumberOfPurchases;
            _product.DateRealease = product.DateRealease;
            _product.Photos = product.Photos;
            _product.ProductCategoryId = categoryId;

            _dbContext.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = _dbContext.Products.SingleOrDefault(pro => pro.Id == productId);

            if(product != null)
            {
                _dbContext.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public List<ProductVM> GetByArray(string idArray)
        {
            List<ProductVM> results = new List<ProductVM>();
            var _idArray = idArray.Split(",");

            foreach (var item in _idArray)
            {
                results.Add(GetById(int.Parse(item)));
            }

            return results;
        }

        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }
    }
}
