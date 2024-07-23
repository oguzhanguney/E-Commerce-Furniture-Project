using Furniture.EntityLayer.Concrete;

namespace Furniture.BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        AppUser GetLastUser();
    }
}
