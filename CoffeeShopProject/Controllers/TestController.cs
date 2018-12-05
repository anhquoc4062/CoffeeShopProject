using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

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
            var dsThucDon = (from td in db.ThucDon
                             join ltd in db.LoaiThucDon
                             on td.MaLoai equals ltd.MaLoai
                             select new ThucDonViewModel
                             {
                                 MaThucDon = td.MaThucDon,
                                 TenThucDon = td.TenThucDon,
                                 HinhAnh = td.HinhAnh,
                                 TenLoai = ltd.TenLoai,
                                 MaLoai = td.MaLoai,
                                 Gia = td.Gia,
                                 KhuyenMai = td.KhuyenMai
                             }).ToList();
            ViewBag.Test = dsThucDon;
            return View();
        }
    }
}