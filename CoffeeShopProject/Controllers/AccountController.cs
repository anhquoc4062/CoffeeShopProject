using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly CoffeeShopContext db;
        public AccountController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAccountById(string account_id)
        {
            TaiKhoanViewModel query = new TaiKhoanViewModel(db);
            var response = query.GetTaiKhoanById(account_id);
            return Json(response);
        }

        public IActionResult AddAccountForEmployee(string emp_id, string account_name, string account_password)
        {
            TaiKhoanViewModel query_account = new TaiKhoanViewModel(db);
            TaiKhoan newAcc = new TaiKhoan
            {
                TenTaiKhoan = account_name,
                MatKhau = account_password,
                MaPhanQuyen = "nv"
            };
            query_account.InsertTaiKhoan(newAcc);

            NhanVien tmp = new NhanVien();
            tmp.MaNhanVien = int.Parse(emp_id);
            NhanVien editNv = db.NhanVien.Find(tmp.MaNhanVien);
            editNv.MaTaiKhoan = newAcc.MaTaiKhoan;//get last inserted id

            NhanVienViewModel query_employee = new NhanVienViewModel(db);
            query_employee.EditNhanVien(editNv);
            var response = query_employee.GetNhanVienById(emp_id);
            return Json(response);
        }
    }
}