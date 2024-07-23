using Furniture.BusinessLayer.Abstract;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _OurProductsPartial: ViewComponent
    {
        private IProductService _productService;

        public _OurProductsPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _productService.GetLast8Products();
            var result2 = _productService.GetSalonSetProducts();
            var result3 = _productService.GetMostViewedProducts();
            var result4 = _productService.GetRecommendedProducts();

            DefaultViewModel defaultViewModel = new DefaultViewModel
            {
                GetLast8 = result,
                GetSalonSet = result2,
                GetMostViewedProducts = result3,
                GetRecommendedProducts = result4
            };
            return View(defaultViewModel);
        }
    }
}
