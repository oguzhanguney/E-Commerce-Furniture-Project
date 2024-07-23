using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.DataLayer.Repository;
using Furniture.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Furniture.DataLayer.EntityFramework
{
    public class EfProductDal : Repository<Product, Context>, IProductDal
    {
        public Product GetByIdWithBrands(int id)
        {
            using (var context = new Context())
            {
                return context.Products
                        .Where(i => i.BrandID == id)
                        .Include(i => i.Brand)
                        .FirstOrDefault();
            }
        }

        public int GetCountByCategoryId(int? categoryId)
        {
            using (var context = new Context())
            {
                return context.Products
                        .Where(i => i.CategoryID == categoryId)
                        .Count();
            }
        }

        public List<Product> GetLast8Products()
        {
            using (var context = new Context())
            {
                return context.Products
                    .OrderByDescending(i => i.ProductID)
                    .Include(i => i.Brand)
                    .Include(i => i.Category)
                    .Take(8)
                    .ToList();
            }
        }

        public List<Product> GetMostViewedProducts()
        {
            using (var context = new Context())
            {
                int productCount = context.Products.Count();

                Random random = new Random();
                int startIndex = random.Next(0, productCount - 8);

                var randomProducts = context.Products
                    .Skip(startIndex)
                    .Include(x => x.Brand)
                    .Include(y => y.Category)
                    .Take(8)
                    .ToList();

                return randomProducts;
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new Context())
            {
                return context.Products
                            .Where(i => i.ProductID == id)
                            .Include(x => x.Brand)
                            .Include(y => y.Category)
                            .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByBrand(string brand, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategoryId(int? categoryId)
        {
            using (var context = new Context())
            {
                return context.Products
                        .Where(i => i.CategoryID == categoryId)
                        .Include(i => i.Brand)
                        .ToList();
            }
        }

        public List<Product> GetRecommendedProducts()
        {
            using (var context = new Context())
            {
                int productCount = context.Products.Count();

                Random random = new Random();
                int startIndex = random.Next(0, productCount - 8);

                var randomProducts = context.Products
                    .Skip(startIndex)
                    .Include(x => x.Brand)
                    .Include(y => y.Category)
                    .Take(8)
                    .ToList();

                return randomProducts;
            }
        }

        public List<Product> GetSalonSetProducts()
        {
            using (var context = new Context())
            {
                return context.Products
                    .OrderByDescending(i => i.ProductID)
                    .Where(i => i.CategoryID == 1)
                    .Include(i => i.Brand)
                    .Include(i => i.Category)
                    .ToList();
            }
        }
    }
}
