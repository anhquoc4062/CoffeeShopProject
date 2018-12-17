using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class CustomerAdminController : Controller
    {
        private readonly CoffeeShopContext db;
        public CustomerAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            KhachHangViewModel query = new KhachHangViewModel(db);
            ViewBag.ListCustomer = query.GetDsKhachHang();
            return View();
        }

        public IActionResult GetCustomerInfo(string customer_id)
        {
            KhachHangViewModel query = new KhachHangViewModel(db);
            var response = query.GetKhachHangById(customer_id);
            return Json(response);
        }
    }
}