using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _BlogPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
