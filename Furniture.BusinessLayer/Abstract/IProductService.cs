using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Product GetByIdWithBrands(int id);
        Product GetProductDetails(int id);
        List<Product> GetProductsByBrand(string brand, int page, int pageSize);
        List<Product> GetProductsByCategoryId(int? categoryId);
        int GetCountByCategoryId(int? categoryId);
        List<Product> GetLast8Products();
        List<Product> GetSalonSetProducts();
        List<Product> GetMostViewedProducts();
        List<Product> GetRecommendedProducts();
    }
}
