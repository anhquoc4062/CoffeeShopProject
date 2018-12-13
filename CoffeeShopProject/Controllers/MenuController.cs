using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class MenuController : Controller
    {
        private readonly CoffeeShopContext db;
        public MenuController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ThucDonViewModel query_thucdon = new ThucDonViewModel(db);
            ViewBag.ListProduct = query_thucdon.GetDataByPage(1,6);
            LoaiThucDonViewModel query_loaithucdon = new LoaiThucDonViewModel(db);
            ViewBag.ListCate = query_loaithucdon.GetLoaiThucDon();
            return View();
        }
        public IActionResult GetProductCountWithFilter(string maloai, string sapxep)
        {
            ThucDonViewModel query_thucdon = new ThucDonViewModel(db);
            var response = query_thucdon.GetAllDataWithFilter(maloai, sapxep).Count();
            return Json(response);
        }

        public IActionResult GetProductByPageWithFilter(string maloai, string sapxep, int page = 1, int limit=6)
        {
            ThucDonViewModel query_thucdon = new ThucDonViewModel(db);
            var response = query_thucdon.GetAllDataWithFilterByPage(page, limit, maloai, sapxep);
            return Json(response);
        }
    }
}