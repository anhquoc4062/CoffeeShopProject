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
        [Route("thuc-don")]
        public IActionResult Index()
        {
            ThucDonViewModel query_thucdon = new ThucDonViewModel(db);
            ViewBag.ListProduct = query_thucdon.GetDataByPage(1,6);
            LoaiThucDonViewModel query_loaithucdon = new LoaiThucDonViewModel(db);
            ViewBag.ListCate = query_loaithucdon.GetLoaiThucDon();
            ViewBag.ListDiscount = query_thucdon.GetAllData().Where(x => x.KhuyenMai != 0).Take(4);
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
        public IActionResult GetProductCountWithKeyword(string keyword)
        {
            keyword = keyword.ToLower();
            ThucDonViewModel query_thucdon = new ThucDonViewModel(db);
            var response = query_thucdon.GetDataByName(keyword).Count();
            return Json(response);
        }
        public IActionResult GetProductByName(string keyword, int page = 1, int limit = 6)
        {
            keyword = keyword.ToLower();
            ThucDonViewModel query_thucdon = new ThucDonViewModel(db);
            var response = query_thucdon.GetDataByNameWithPage(keyword, page, limit);
            return Json(response);
        }

        public IActionResult GetNameProduct()
        {
            string term = HttpContext.Request.Query["term"].ToString();
            var names = db.ThucDon.Where(p => p.TenThucDon.Contains(term)).Select(p => p.TenThucDon).ToList();
            return Json(names);
        }
    }
}