﻿using Microsoft.AspNetCore.Mvc;

namespace Furniture.UILayer.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
