using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoffeeShopProject.Controllers
{
    [Route("chi-tiet")]
    public class SingleProductController : Controller
    {
        private readonly CoffeeShopContext db;
        public SingleProductController(CoffeeShopContext _db)
        {
            db = _db;
        }
        [HttpGet("{name}-{id}")]
        public IActionResult Index(string name, string id)
        {
            //var friendlyName = FriendlyUrlHelper.GetFriendlyTitle(name);
            ThucDonViewModel query = new ThucDonViewModel(db);
            var td = query.GetDataById(id);
            ViewBag.CungLoai = query.GetAllDataByCate(td.MaLoai.ToString()).Take(4);
            DanhGiaViewModel query_dg = new DanhGiaViewModel(db);
            ViewBag.ListDanhGia = query_dg.GetDanhGiaByProduct(id).OrderByDescending(x => x.MaDanhGia);
            return View(td);
            
        }
        [HttpPost]
        public IActionResult AddRating(string product_id, string rating)
        {
            DanhGia newDg = new DanhGia()
            {
                MaTaiKhoan = int.Parse(HttpContext.Session.GetString("ACCID_SESSION")),
                LoiNhanXet = rating,
                MaThucDon = int.Parse(product_id),
                NgayDanhGia = DateTime.Now
            };
            db.DanhGia.Add(newDg);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(
                                        new { controller = "SingleProduct", action = "Index", id = product_id }));
        }
    }
}