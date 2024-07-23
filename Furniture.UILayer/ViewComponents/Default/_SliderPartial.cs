using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
