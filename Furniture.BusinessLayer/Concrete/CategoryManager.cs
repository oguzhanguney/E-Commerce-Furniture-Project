using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.EntityFramework;
using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void DeleteFromCategory(int categoryId, int productId)
        {
            _categoryDal.DeleteFromCategory(categoryId, productId);
        }

        public Category GetByIdWithProducts(int id)
        {
            return _categoryDal.GetByIdWithProducts(id);
        }

        public void TCreate(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
