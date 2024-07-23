using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.EntityLayer.Concrete;

namespace Furniture.BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void TCreate(Brand entity)
        {
            _brandDal.Create(entity);
        }

        public void TDelete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public List<Brand> TGetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand TGetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public void TUpdate(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
