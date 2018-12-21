using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CoffeeShopContext db;
        public CheckoutController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ViewBag.City = (from tt in db.TinhThanh select tt);
            var gioHang = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.Cart = gioHang;
            if(gioHang != null)
            {
                ViewBag.Total = gioHang.Sum(x => x.SoLuong * x.GiaBan);
            }
            else
            {
                ViewBag.Total = 0;
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddOrder(string account_id, string fullname, string address, string email, string tel, string city)
        {
            var gioHang = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
            if (gioHang == null || gioHang.Count() == 0)
            {
                ViewBag.Success = false;
            }
            else
            {
                KhachHang newKh = new KhachHang
                {
                    TenKhachHang = fullname,
                    DiaChi = address,
                    Email = email,
                    SoDt = tel,
                    MaTinhThanh = int.Parse(city)
                };
                db.KhachHang.Add(newKh);
                db.SaveChanges();
                GioHang newOrder = new GioHang
                {
                    MaKhachHang = newKh.MaKhachHang,
                    NgayDat = DateTime.Now,
                    TrangThai = 0
                };
                if (account_id != null)
                {
                    newOrder.MaTaiKhoan = int.Parse(account_id);
                }
                db.GioHang.Add(newOrder);
                db.SaveChanges();
                var cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
                foreach (var item in cart)
                {
                    ChiTietGioHang newDetail = new ChiTietGioHang
                    {
                        MaGioHang = newOrder.MaGioHang,
                        MaThucDon = item.MaThucDon,
                        SoLuong = item.SoLuong
                    };
                    db.ChiTietGioHang.Add(newDetail);
                    db.SaveChanges();
                }
                HttpContext.Session.Remove("cart");
                ViewBag.Success = true;
            }
            ViewBag.City = (from tt in db.TinhThanh select tt);
            gioHang = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.Cart = gioHang;
            if (gioHang != null)
            {
                ViewBag.Total = gioHang.Sum(x => x.SoLuong * x.GiaBan);
            }
            else
            {
                ViewBag.Total = 0;
            }
            return View("Index");
        }
    }
}