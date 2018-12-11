using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeShopProject.Controllers
{
    public class EmployeeAdminController : Controller
    {
        private readonly CoffeeShopContext db;
        public EmployeeAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            NhanVienViewModel query = new NhanVienViewModel(db);
            ViewBag.List = query.GetDsNhanVien();
            return View();
        }
    }
}