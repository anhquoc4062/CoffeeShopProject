using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class SingleProductController : Controller
    {
        private readonly CoffeeShopContext db;
        public SingleProductController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index(string id)
        {
            ThucDonViewModel query = new ThucDonViewModel(db);
            var td = query.GetDataById(id);
            ViewBag.CungLoai = query.GetAllDataByCate(td.MaLoai.ToString()).Take(4);
            return View(td);
        }
    }
}