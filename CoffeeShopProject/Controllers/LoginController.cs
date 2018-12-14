using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly CoffeeShopContext db;
        public LoginController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            TaiKhoan tk = db.TaiKhoan.SingleOrDefault(x => x.TenTaiKhoan.Equals(username) && x.MatKhau.Equals(password));
            if(tk == null)
            {
                ViewBag.NotMatch = "Tài khoản không tồn tại";
                return View("Index");
            }
            else
            {
                AccountDisplay ac = new AccountDisplay()
                {
                    MaTaiKhoan = tk.MaTaiKhoan,
                    PhanQuyen = tk.MaPhanQuyen,
                    TenTaiKhoan = tk.TenTaiKhoan
                };
                if (tk.MaPhanQuyen == "kh")
                {
                    KhachHang kh = db.KhachHang.SingleOrDefault(x => x.MaTaiKhoan.Equals(tk.MaTaiKhoan));
                    ac.HoTen = kh.TenKhachHang;
                    ac.Email = kh.Email;
                    HttpContext.Session.Set("MaTaiKhoan", ac.MaTaiKhoan);
                    HttpContext.Session.Set("HoTen", ac.HoTen);
                    HttpContext.Session.Set("Email", ac.Email);
                    HttpContext.Session.Set("MaPhanQuyen", ac.PhanQuyen);
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    NhanVien nv = db.NhanVien.SingleOrDefault(x => x.MaTaiKhoan.Equals(tk.MaTaiKhoan));
                    ac.HoTen = nv.HoTen;
                    ac.HinhAnh = nv.HinhAnh;
                    ac.Email = nv.Email;
                    HttpContext.Session.Set("MaTaiKhoan", ac.MaTaiKhoan);
                    HttpContext.Session.Set("Avatar", ac.HinhAnh);
                    HttpContext.Session.Set("HoTen", ac.HoTen);
                    HttpContext.Session.Set("Email", ac.Email);
                    HttpContext.Session.Set("MaPhanQuyen", ac.PhanQuyen);
                    return RedirectToAction("Index", "ProductAdmin");
                }
            }
            
        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "TrangChu");
        }
    }
}