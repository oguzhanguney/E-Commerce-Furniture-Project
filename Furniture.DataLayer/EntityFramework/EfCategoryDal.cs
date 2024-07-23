using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.DataLayer.Repository;
using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DataLayer.EntityFramework
{
    public class EfCategoryDal : Repository<Category, Context>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            //
        }

        Category ICategoryDal.GetByIdWithProducts(int id)
        {
            using (var context = new Context())
            {
                return context.Categories
                        .Where(i => i.CategoryID == id)
                        .FirstOrDefault();
            }
        }
    }
}
