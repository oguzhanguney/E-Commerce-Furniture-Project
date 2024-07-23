using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]//aynı sayfaya yönlendirme yapabilmek için:
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetAll();
            return View(values);
        }

        //Kullanıcı silme:
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetById(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        
    }
}
