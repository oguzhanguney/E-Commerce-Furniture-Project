﻿using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
