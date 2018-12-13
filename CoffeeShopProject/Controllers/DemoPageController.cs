using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class DemoPageController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Layout/User/Layout.cshtml");
        }

        public IActionResult chiTietDatHang()
        {
            return View();
        }
    }

}