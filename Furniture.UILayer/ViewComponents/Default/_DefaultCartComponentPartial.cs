using Furniture.BusinessLayer.Abstract;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.Default
{
    public class _DefaultCartComponentPartial : ViewComponent
    {
        private ICardItemService _cardItemService;

        public _DefaultCartComponentPartial(ICardItemService cardItemService)
        {
            _cardItemService = cardItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = _cardItemService.TGetAll().FirstOrDefault();
            if (value != null)
            {
                ViewBag.CardIdLast = value.CardId;
            }

            return View(new CardItemViewModel()
            {
                CardItems = _cardItemService.GetCardItemsWithProducts(),
            });
        }
        public async Task<IViewComponentResult> RemoveItem(int id)
        {
            var item = _cardItemService.TGetById(id);

            _cardItemService.TDelete(item);

            return View();
        }
    }
}
