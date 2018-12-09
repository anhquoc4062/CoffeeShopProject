using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeShopProject.Controllers
{
    public class TestController : Controller
    {
        private readonly CoffeeShopContext db;
        public TestController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
          ThucDonViewModel data = new ThucDonViewModel(db);

        ThucDon pc = new ThucDon();
            pc.KhuyenMai = 1000;
            pc.MaLoai = 2;
            //var test = data.DeleteThucDonById("5");
            var test = data.GetAllData();
            var jsonData = JsonConvert.SerializeObject(test);
            ViewBag.Test = jsonData;
            return View();
        }
    }
}