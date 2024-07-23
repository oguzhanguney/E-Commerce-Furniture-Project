using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _BannerPartial: ViewComponent
    {
        //veritabanı bağlantısı için manager eklenecek metot oluşturalacak.
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
