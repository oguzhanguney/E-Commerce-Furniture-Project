using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Furniture.BusinessLayer.Concrete;
using Furniture.BusinessLayer.Abstract;

namespace Furniture.UILayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        //sisteme authentic olmak için:
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICardService _cardService;
        private readonly IAppUserService _appUserService;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICardService cardService, IAppUserService appUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cardService = cardService;
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p) //identity'e ait işlemler yapacagımız için metodun async olması gerekir.
        {
            //atama işlemleri:
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username,
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    var lastUser = _appUserService.GetLastUser();
                    Card card = new Card
                    {
                        UserID = lastUser.Id.ToString(),
                    };

                    _cardService.TCreate(card);

                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }



        [HttpGet]
        public IActionResult SignIn()
        {
            // Eğer kullanıcı zaten giriş yapmışsa, profil düzenleme sayfasına yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "MyAccount");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete(".AspNetCore.Antiforgery.eWWUK21ORIU");
            Response.Cookies.Delete(".AspNetCore.Identity.Application");
            Response.Cookies.Delete("1P_JAR");
            return RedirectToAction("SignIn", "Login");
        }
    }
}
