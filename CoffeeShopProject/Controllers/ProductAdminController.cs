using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly CoffeeShopContext db;
        public ProductAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ThucDonViewModel dsThucDon = new ThucDonViewModel(db);
            ViewBag.List = dsThucDon.GetAllData();
            LoaiThucDonViewModel dsLoai = new LoaiThucDonViewModel(db);
            var data = dsLoai.GetLoaiThucDon();
            ViewBag.ListCate = data;
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(string tenLoai)
        {
            LoaiThucDon newCate = new LoaiThucDon
            {
                TenLoai = tenLoai
            };
            LoaiThucDonViewModel query = new LoaiThucDonViewModel(db);
            query.InsertLoaiThucDon(tenLoai);
            var response = query.GetLoaiThucDon();
            return Json(response);
        }
        [HttpPost]
        public IActionResult AddProduct(string product_name, IFormFile product_img, string product_category, string product_price, string product_discount)
        {
            ThucDon newProduct = new ThucDon();

            if (product_img != null)
            {
                string path_to_image = "wwwroot/uploads/product/" + product_img.FileName;
                using (var stream = new FileStream(path_to_image, FileMode.Create))
                {
                    product_img.CopyTo(stream);
                }
                newProduct.HinhAnh = product_img.FileName;
            }
            newProduct.TenThucDon = product_name;
            newProduct.MaLoai = int.Parse(product_category);
            newProduct.Gia = float.Parse(product_price);
            newProduct.KhuyenMai = int.Parse(product_discount);

            ThucDonViewModel query = new ThucDonViewModel(db);
            query.InsertThucDon(newProduct);
            var response = query.GetAllData();
            return Json(response);
        }
    }
}