using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ICardItemService _cardItemService;
        private IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
		private IOrderService _orderService;
		private IOrderItemService _orderItemService;
		private ICardService _cardService;

		public CheckoutController(ICardItemService cardItemService, IAppUserService appUserService, UserManager<AppUser> userManager, IOrderService orderService, IOrderItemService orderItemService, ICardService cardService)
		{
			_cardItemService = cardItemService;
			_appUserService = appUserService;
			_userManager = userManager;
			_orderService = orderService;
			_orderItemService = orderItemService;
			_cardService = cardService;
		}

		public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = value.Id;
            
            return View(new CheckoutViewModel()
            {
                CardItems = _cardItemService.GetCardItemsWithProducts(),
                AppUser = _appUserService.TGetById(userId),
            });
        }
		[HttpPost]
		public async Task<IActionResult> Index(CheckoutViewModel checkoutViewModel)
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			var userId = value.Id;

			var cardItems = _cardItemService.GetCardItemsWithProducts();

			if (!ModelState.IsValid)
			{
				var order = new Order()
				{
					Name = checkoutViewModel.AppUser.Name,
					Surname = checkoutViewModel.AppUser.Surname,
					City = checkoutViewModel.Order.City,
					District = checkoutViewModel.Order.District,
					Address = checkoutViewModel.Order.Address,
					PostalCode = checkoutViewModel.Order.PostalCode,
					OrderNote = checkoutViewModel.Order.OrderNote,
					Email = checkoutViewModel.AppUser.Email,
					UserID = userId.ToString(),
					CreatedDate = DateTime.Now,
				};

				_orderService.TCreate(order);
				var orderid = _orderService.GetOrderByUserId(userId).OrderID;

				foreach (var item in cardItems)
				{
					var orderItem = new OrderItem()
					{
						OrderId = orderid,
						ProductId = item.Product.ProductID,
						Quantity = item.Quantity,
						Price = item.Product.Price,
					};

					_orderItemService.TCreate(orderItem);
				}

				var cardIdNew =_cardService.GetCardByUserID(userId.ToString()).CardID;
				_cardService.ClearCard(cardIdNew.ToString());

				return RedirectToAction("Done", "Checkout");
			}

			return View(new CheckoutViewModel()
			{
				CardItems = _cardItemService.GetCardItemsWithProducts(),
				AppUser = _appUserService.TGetById(userId),
			});
		}
		public IActionResult Done()
		{
            return View();
        }
	}
}
