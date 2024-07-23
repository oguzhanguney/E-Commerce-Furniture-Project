using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetByIdWithBrands(int id)
        {
            return _productDal.GetByIdWithBrands(id);
        }

        public int GetCountByCategoryId(int? categoryId)
        {
            return _productDal.GetCountByCategoryId(categoryId);
        }

        public List<Product> GetLast8Products()
        {
            return _productDal.GetLast8Products();
        }

        public List<Product> GetMostViewedProducts()
        {
            return _productDal.GetMostViewedProducts();
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByBrand(string brand, int page, int pageSize)
        {
            return _productDal.GetProductsByBrand(brand, page, pageSize);
        }

        public List<Product> GetProductsByCategoryId(int? categoryId)
        {
            return _productDal.GetProductsByCategoryId(categoryId);
        }

        public List<Product> GetRecommendedProducts()
        {
            return _productDal.GetRecommendedProducts();
        }

        public List<Product> GetSalonSetProducts()
        {
            return _productDal.GetSalonSetProducts();
        }

        public void TCreate(Product entity)
        {
            _productDal.Create(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
