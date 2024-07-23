using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.TCreate(product);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _productService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
