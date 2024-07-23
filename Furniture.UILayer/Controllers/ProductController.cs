using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private ICardService _cardService;
        private ICardItemService _cardItemService;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(IProductService productService, ICategoryService categoryService, ICardService cardService, ICardItemService cardItemService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _cardService = cardService;
            _cardItemService = cardItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? Id)
        {


            if (User.Identity.IsAuthenticated)
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                var userId = value.Id;

                var result = _cardService.GetCardByUserID(userId.ToString());
                var cardId = result.CardID;

                ViewBag.cardId = Convert.ToInt32(cardId);
            }

            if (!(Id == null))
            {
                int countProducts = _productService.GetCountByCategoryId(Id);
                ViewBag.CountProducts = countProducts;

                return View(new ProductListModel()
                {
                    Products = _productService.GetProductsByCategoryId(Id),
                    Categories = _categoryService.TGetAll(),
                });
            }
            else
            {
                int countProducts = _productService.TGetAll().Count;
                ViewBag.CountProducts = countProducts;

                return View(new ProductListModel()
                {
                    Products = _productService.TGetAll(),
                    Categories = _categoryService.TGetAll(),
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProductListModel ProductListModel)
        {
            CardItem createCardItem = new CardItem()
            {
                CardId = ProductListModel.ProductCardViewModel.CardItem.CardId,
                ProductId = ProductListModel.ProductCardViewModel.CardItem.ProductId,
                Quantity = ProductListModel.ProductCardViewModel.CardItem.Quantity,
            };

            _cardItemService.TCreate(createCardItem);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                var userId = value.Id;

                var result = _cardService.GetCardByUserID(userId.ToString());
                var cardId = result.CardID;
                ViewBag.cardId = Convert.ToInt32(cardId);
            }

            return View(new ProductCardViewModel()
            {
                Product = _productService.GetProductDetails(id),
                Products = _productService.GetLast8Products(),
                
            });
        }
        [HttpPost]
        public async Task<IActionResult> Detail(ProductCardViewModel productCardViewModel)
        {
            CardItem createCardItem = new CardItem()
            {
                CardId = productCardViewModel.CardItem.CardId,
                ProductId = productCardViewModel.CardItem.ProductId,
                Quantity = productCardViewModel.CardItem.Quantity,
            };

            _cardItemService.TCreate(createCardItem);
            return RedirectToAction("Detail");
        }
    }
}
