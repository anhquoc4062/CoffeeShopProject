using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeShopProject.Controllers
{
    public class EmployeeAdminController : BaseController
    {
        private readonly CoffeeShopContext db;
        public EmployeeAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            NhanVienViewModel query = new NhanVienViewModel(db);
            ViewBag.List = query.GetDsNhanVien();
            
            ChucVuViewModel query_cv = new ChucVuViewModel(db);
            ViewBag.ListPos = query_cv.GetChucVu();
            return View();
        }

        public IActionResult BindDataToForm(string id)
        {
            NhanVienViewModel query = new NhanVienViewModel(db);
            var response = query.GetNhanVienById(id);
            return Json(response);
        }
        
        public IActionResult AddEmployee(IFormFile emp_img, string emp_name,
                                          string emp_identity, string emp_email,
                                          string emp_position, string emp_salary,
                                          string emp_info)
        {
            NhanVien newEmp = new NhanVien();

            if (emp_img != null)
            {
                string path_to_image = "wwwroot/uploads/employee/" + emp_img.FileName;
                using (var stream = new FileStream(path_to_image, FileMode.Create))
                {
                    emp_img.CopyTo(stream);
                }
                newEmp.HinhAnh = emp_img.FileName;
            }
            else
            {
                newEmp.HinhAnh = "none-avatar.jpg";
            }
            newEmp.HoTen = emp_name;
            newEmp.MaChucVu = int.Parse(emp_position);
            newEmp.Luong = float.Parse(emp_salary);
            newEmp.Cmnd = emp_identity;
            newEmp.Email = emp_email;
            newEmp.MoTa = emp_info;
            newEmp.NgayBatDau = DateTime.Now;

            NhanVienViewModel query = new NhanVienViewModel(db);
            query.InsertNhanVien(newEmp);
            var response = query.GetDsNhanVien();
            return Json(response);
        }

        public IActionResult UpdateEmployee(IFormFile emp_img, string emp_name,
                                          string emp_identity, string emp_email,
                                          string emp_position, string emp_salary,
                                          string emp_info, string old_emp_img,
                                          string emp_id, string acc_id)
        {
            NhanVien editEmployee = new NhanVien
            {
                MaNhanVien = int.Parse(emp_id),
                HoTen = emp_name,
                MaChucVu = int.Parse(emp_position),
                Luong = float.Parse(emp_salary),
                Email = emp_email,
                MoTa = emp_info,
                Cmnd = emp_identity
            };
            if (acc_id == "0")
            {
                editEmployee.MaTaiKhoan = null;
            }
            else
            {
                editEmployee.MaTaiKhoan = int.Parse(acc_id);
            }
            if (emp_img == null)
            {
                editEmployee.HinhAnh = old_emp_img;
            }
            else
            {
                string path_to_image = "wwwroot/uploads/employee/" + emp_img.FileName;
                using (var stream = new FileStream(path_to_image, FileMode.Create))
                {
                    emp_img.CopyTo(stream);
                }
                editEmployee.HinhAnh = emp_img.FileName;
            }
            NhanVien tmp = db.NhanVien.SingleOrDefault(x => x.MaNhanVien == int.Parse(emp_id));
            editEmployee.NgayBatDau = tmp.NgayBatDau;
            NhanVienViewModel query = new NhanVienViewModel(db);
            query.EditNhanVien(editEmployee);
            if(editEmployee.MaTaiKhoan != null)
            {
                TaiKhoan thisTaiKhoan = db.TaiKhoan.Where(x => x.MaTaiKhoan == editEmployee.MaTaiKhoan).SingleOrDefault();
                thisTaiKhoan.AnhDaiDien = editEmployee.HinhAnh;
                thisTaiKhoan.Email = editEmployee.Email;
                TaiKhoanViewModel query_tk = new TaiKhoanViewModel(db);
                query_tk.EditTaiKhoan(thisTaiKhoan);
            }
            var response = query.GetDsNhanVien();
            return Json(response);
        }

        public IActionResult DeleteEmployee(string emp_id)
        {
            NhanVienViewModel query = new NhanVienViewModel(db);
            query.DeleteNhanVienById(emp_id);
            var response = query.GetDsNhanVien();
            return Json(response);
        }

        
    }
}