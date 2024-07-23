using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _InstaPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
