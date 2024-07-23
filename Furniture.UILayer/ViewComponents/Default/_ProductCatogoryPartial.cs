using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _ProductCatogoryPartial:ViewComponent
    {
        //veritabanından getirmek için listeleme metodu ve manager çağıralacak.
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
