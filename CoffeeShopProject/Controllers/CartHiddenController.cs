using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class CartHiddenController : Controller
    {
        public IActionResult Index()
        {
            return View("../Layout/User/Header");
        }
    }
}