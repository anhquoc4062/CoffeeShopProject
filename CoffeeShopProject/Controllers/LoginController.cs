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
            var tk = db.TaiKhoan.SingleOrDefault(x => x.TenTaiKhoan == username && x.MatKhau == password);
            if(tk == null)
            {
                ViewBag.NotExist = false;
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("USERNAME_SESSION", tk.TenTaiKhoan.ToString());
                HttpContext.Session.SetString("CREDENTITY_SESSION", tk.MaPhanQuyen);
                HttpContext.Session.SetString("ACCID_SESSION", tk.MaTaiKhoan.ToString());
                HttpContext.Session.SetString("AVATAR_SESSION", tk.AnhDaiDien.ToString());
                HttpContext.Session.SetString("EMAIL_SESSION", tk.Email.ToString());
                HttpContext.Session.SetString("ACCID_SESSION", tk.MaTaiKhoan.ToString());
                CommonConstant.ACCOUNT_SESSION = HttpContext.Session.GetString("USERNAME_SESSION");
                CommonConstant.CREDENTITY = HttpContext.Session.GetString("CREDENTITY_SESSION");
                CommonConstant.ACCID_SESSION = HttpContext.Session.GetString("ACCID_SESSION");
                if (CommonConstant.CREDENTITY == "kh")
                {
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    return RedirectToAction("Index", "DashBoard");
                }
            }
        }
        public IActionResult SignUp()
        {
            ViewBag.City = from tt in db.TinhThanh select tt;
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(string username, string password, 
                                    string email, IFormFile avatar)
        {
            TaiKhoan newTk = new TaiKhoan
            {
                TenTaiKhoan = username,
                MatKhau = password,
                Email = email,
                MaPhanQuyen = "kh"
            };
            if (avatar != null)
            {
                string path_to_image = "wwwroot/uploads/employee/" + avatar.FileName;
                using (var stream = new FileStream(path_to_image, FileMode.Create))
                {
                    avatar.CopyTo(stream);
                }
                newTk.AnhDaiDien = avatar.FileName;
            }
            else
            {
                newTk.AnhDaiDien = "none-avatar.jpg";
            }
            db.TaiKhoan.Add(newTk);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            CommonConstant.ACCOUNT_SESSION = HttpContext.Session.GetString("USERNAME_SESSION");
            CommonConstant.CREDENTITY = HttpContext.Session.GetString("CREDENTITY_SESSION");
            return RedirectToAction("Index", "TrangChu");
        }
    }
}