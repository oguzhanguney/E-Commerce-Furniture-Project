using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DataLayer.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<Product> GetProductsByBrand(string brand, int page, int pageSize);
        List<Product> GetProductsByCategoryId(int? categoryId);

        Product GetProductDetails(int id);

        int GetCountByCategoryId(int? categoryId);
        Product GetByIdWithBrands(int id);
        List<Product> GetLast8Products();
        List<Product> GetSalonSetProducts();
        List<Product> GetMostViewedProducts();
        List<Product> GetRecommendedProducts();
    }
}
