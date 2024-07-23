using Furniture.BusinessLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using Furniture.UILayer.Dtos;
using Furniture.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TCreate(new ContactUs()
                {
                    MessageBody = model.MessageBody,
                    Mail = model.Mail,
                    MessageStatus = true,
                    Subject = model.Subject,
                    Name = model.Name,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}
