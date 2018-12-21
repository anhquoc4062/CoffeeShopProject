using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class OrderAdminController : BaseController
    {
        private readonly CoffeeShopContext db;
        public OrderAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            GioHangViewModel query = new GioHangViewModel(db);
            ViewBag.ListOrder = query.GetDsGioHang().OrderByDescending(x => x.NgayDat);
            return View();
        }
        public IActionResult GetDetailOrder(string cart_id)
        {
            ChiTietGioHangViewModel query = new ChiTietGioHangViewModel(db);
            var response = query.GetDsChiTietGioHang(cart_id);
            return Json(response);
        }
        public IActionResult RemoveOrder(string id)
        {
            ChiTietGioHangViewModel query_ctdh = new ChiTietGioHangViewModel(db);
            query_ctdh.DeleteChiTietGioHangByCartId(id);
            GioHangViewModel query_dh = new GioHangViewModel(db);
            query_dh.DeleteGioHangById(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeProgress(int id, int status)
        {
            GioHang gh = db.GioHang.SingleOrDefault(x => x.MaGioHang == id);
            gh.TrangThai = status;
            GioHangViewModel query = new GioHangViewModel(db);
            query.EditGioHang(gh);
            return Json(true);
        }
    }
}