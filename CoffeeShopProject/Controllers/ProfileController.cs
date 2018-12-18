using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Common;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly CoffeeShopContext db;
        public ProfileController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetString("ACCID_SESSION");
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.ListOrder = db.GioHang.Where(x => x.MaTaiKhoan == int.Parse(id));
                return View();
            }
           
        }
        public IActionResult GetDetailOrder(string cart_id)
        {
            ChiTietGioHangViewModel query = new ChiTietGioHangViewModel(db);
            var response = query.GetDsChiTietGioHang(cart_id);
            return Json(response);
        }
    }
}