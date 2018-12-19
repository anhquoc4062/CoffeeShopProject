using System;
using System.Collections.Generic;
using System.IO;
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
                var info = db.TaiKhoan.Where(x => x.MaTaiKhoan == int.Parse(id)).SingleOrDefault();
                return View(info);
            }
           
        }
        public IActionResult GetDetailOrder(string cart_id)
        {
            ChiTietGioHangViewModel query = new ChiTietGioHangViewModel(db);
            var response = query.GetDsChiTietGioHang(cart_id);
            return Json(response);
        }
        [HttpPost]
        public IActionResult EditProfile(IFormFile img, string email, string id, string old_img)
        {
            TaiKhoan tmp = db.TaiKhoan.SingleOrDefault(x => x.MaTaiKhoan == int.Parse(id));
            TaiKhoan editTk = new TaiKhoan
            {
                MaPhanQuyen = "kh",
                MaTaiKhoan = int.Parse(id),
                Email = email,
                TenTaiKhoan = tmp.TenTaiKhoan,
                MatKhau = tmp.MatKhau
            };
            if (img != null)
            {
                string path_to_image = "wwwroot/uploads/employee/" + img.FileName;
                using (var stream = new FileStream(path_to_image, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                editTk.AnhDaiDien = img.FileName;
            }
            else
            {
                editTk.AnhDaiDien = old_img;
            }
            TaiKhoanViewModel query = new TaiKhoanViewModel(db);
            query.EditTaiKhoan(editTk);
            return RedirectToAction("Index");
        }

        public IActionResult CancelOrder(string id)
        {
            GioHang gh = db.GioHang.Single(x => x.MaGioHang == int.Parse(id));
            gh.TrangThai = -1;
            GioHangViewModel query = new GioHangViewModel(db);
            query.EditGioHang(gh);
            return RedirectToAction("Index");
        }
    }
}