using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        //atama işlemleri için:(ayrıca bir ctor oluşturmalıyız)
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderItemService _orderItemService;

        public MyAccountController(UserManager<AppUser> userManager, IOrderItemService orderItemService)
        {
            _userManager = userManager;
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //sisteme giren kullanıcın bilgilerini almak için:
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            //atamalar:
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            return View(userEditViewModel);
        }

        //verileri güncellemek için
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = p.name;
            user.Surname = p.surname;
            user.Email = p.mail;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
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
