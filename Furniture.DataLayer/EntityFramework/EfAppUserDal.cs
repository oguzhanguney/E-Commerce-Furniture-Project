using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.DataLayer.Repository;
using Furniture.EntityLayer.Concrete;

namespace Furniture.DataLayer.EntityFramework
{
    public class EfAppUserDal : Repository<AppUser, Context>, IAppUserDal
    {
    }
}
