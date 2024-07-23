using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.ViewComponents.MyAccount
{
    public class _MyAccountOldOrdersPartialView : ViewComponent
    {
        private IOrderItemService _orderItemService;
        private IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public _MyAccountOldOrdersPartialView(IOrderItemService orderItemService, IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = value.Id;

            var results = _orderService.GetOrders(userId.ToString());
            AccountOrdersModel accountOrdersModel = new AccountOrdersModel
            {
                Orders = results,
            };

            return View(accountOrdersModel);
        }
    }
}
