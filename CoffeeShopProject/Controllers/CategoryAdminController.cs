using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class CategoryAdminController : Controller
    {
        private readonly CoffeeShopContext db;
        public CategoryAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}