using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class TrangChuController : Controller
    {
        private readonly CoffeeShopContext db;
        public TrangChuController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ThucDonViewModel dsThucDon = new ThucDonViewModel(db);
            ViewBag.ListProduct = dsThucDon.GetAllData().Take(6);
            return View();
        }
    }
}