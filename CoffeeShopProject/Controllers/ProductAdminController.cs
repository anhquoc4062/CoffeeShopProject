using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly CoffeeShopContext db;
        public ProductAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ThucDonViewModel dsThucDon = new ThucDonViewModel(db);
            ViewBag.List = dsThucDon.GetAllData();
            return View();
        }
    }
}