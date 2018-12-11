﻿using System;
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
            NhanVienViewModel data = new NhanVienViewModel(db);
            var test = data.GetDsNhanVien();
            var jsonData = JsonConvert.SerializeObject(test);
            ViewBag.Test = jsonData;
            return View();
        }
    }
}