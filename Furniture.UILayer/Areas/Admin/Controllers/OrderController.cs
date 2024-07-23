using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;

        public OrderController(UserManager<AppUser> userManager, IOrderService orderService, IOrderItemService orderItemService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        public async Task<IActionResult> Index()
        {
            var results = _orderService.TGetAll();
            AccountOrdersModel accountOrdersModel = new AccountOrdersModel
            {
                Orders = results,
            };

            return View(accountOrdersModel); ;
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var results = _orderItemService.GetOrdersByOrderId(id);
            AccountOrdersModel accountOrdersModel = new AccountOrdersModel
            {
                OrderItems = results,
            };

            return View(accountOrdersModel);
        }
    }
}
