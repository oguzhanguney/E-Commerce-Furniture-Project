using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.EntityLayer.Concrete;

namespace Furniture.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public AppUser GetLastUser()
        {
            using (var context = new Context())
            {
                return context.Set<AppUser>().OrderByDescending(x => x.Id).FirstOrDefault();
            }
        }

        public void TCreate(AppUser entity)
        {
            _appUserDal.Create(entity);
        }

        public void TDelete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public List<AppUser> TGetAll()
        {
            return _appUserDal.GetAll();
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}
