using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    public class CartController : Controller
    {
        private ICardItemService _cardItemService;

        public CartController(ICardItemService cardItemService)
        {
            _cardItemService = cardItemService;
        }

        public async Task<IActionResult> Index()
        {
            var value = _cardItemService.TGetAll().FirstOrDefault();
            if(value != null)
            {
                ViewBag.CardIdLast = value.CardId;
            }

            return View(new CardItemViewModel()
            {
                CardItems = _cardItemService.GetCardItemsWithProducts(),
            });
        }

        public async Task<IActionResult> Remove(int id)
        {
            var value = _cardItemService.GetCardItemsByCardId(id);

            foreach(var item in value)
            {
                _cardItemService.TDelete(item);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var item = _cardItemService.TGetById(id);

            _cardItemService.TDelete(item);

            return RedirectToAction("Index");
        }
    }
}
