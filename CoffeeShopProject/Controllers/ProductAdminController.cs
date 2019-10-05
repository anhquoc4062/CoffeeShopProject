using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
            //var pageNumber = page ?? 1;
            //var allProduct = dsThucDon.GetAllData();
            //var onePageProduct = allProduct.ToPagedList(pageNumber, 5);
            ViewBag.List = dsThucDon.GetDataWithCateByPage("0", 1);
            LoaiThucDonViewModel dsLoai = new LoaiThucDonViewModel(db);
            var data = dsLoai.GetLoaiThucDon();
            ViewBag.ListCate = data;
            return View();
        }
        public IActionResult GetProductCount(string MaLoai = "0")
        {
            ThucDonViewModel query = new ThucDonViewModel(db);
            var response = query.GetAllDataByCate(MaLoai).Count();
            return Json(response);
        }
        public IActionResult GetProductByPage(string maloai, string page)
        {
            ThucDonViewModel query = new ThucDonViewModel(db);
            var response = query.GetDataWithCateByPage(maloai, int.Parse(page));
            return Json(response);
        }
        [HttpPost]
        public IActionResult AddCategory(string tenLoai, string danhMuc)
        {
            LoaiThucDon newCate = new LoaiThucDon
            {
                TenLoai = tenLoai,
                MaLoaiCha = int.Parse(danhMuc)
            };
            LoaiThucDonViewModel query = new LoaiThucDonViewModel(db);
            query.InsertLoaiThucDon(newCate);
            var response = query.GetLoaiThucDon();
            return Json(response);
        }
        [HttpPost]
        public IActionResult AddProduct(string product_name, IFormFile product_img, 
            string product_category, string product_price, string filter,
            string product_discount, string product_info, string page)
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
            newProduct.MoTa = product_info;

            ThucDonViewModel query = new ThucDonViewModel(db);
            query.InsertThucDon(newProduct);
            var response = query.GetDataWithCateByPage(filter,int.Parse(page));
            return Json(response);
        }

        public IActionResult BindDataToForm(string id)
        {
            ThucDonViewModel query = new ThucDonViewModel(db);
            var response = query.GetDataById(id);
            return Json(response);
        }
        [HttpPost]
        public IActionResult UpdateProduct(string product_id, string product_name, 
            IFormFile product_img, string product_category, 
            string product_price, string product_discount, string filter,
            string old_product_img, string product_info, string page)
        {
            ThucDon editProduct = new ThucDon
            {
                MaThucDon = int.Parse(product_id),
                TenThucDon = product_name,
                MaLoai = int.Parse(product_category),
                Gia = float.Parse(product_price),
                KhuyenMai = int.Parse(product_discount),
                MoTa = product_info
            };
            if (product_img == null)
            {
                editProduct.HinhAnh = old_product_img;
            }
            else
            {
                string path_to_image = "wwwroot/uploads/product/" + product_img.FileName;
                using (var stream = new FileStream(path_to_image, FileMode.Create))
                {
                    product_img.CopyTo(stream);
                }
                editProduct.HinhAnh = product_img.FileName;
            }
            ThucDonViewModel query = new ThucDonViewModel(db);
            query.EditThucDon(editProduct);
            var response = query.GetDataWithCateByPage(filter ,int.Parse(page));
            return Json(response);
        }
        public IActionResult DeleteProduct(string id, string filter, string page)
        {
            List<ChiTietGioHang> ctgh = db.ChiTietGioHang.Where(x => x.MaThucDon == int.Parse(id)).ToList();
            foreach(var item in ctgh)
            {
                db.ChiTietGioHang.Remove(item);
            }
            List<DanhGia> dg = db.DanhGia.Where(x => x.MaThucDon == int.Parse(id)).ToList();
            foreach (var item in dg)
            {
                db.DanhGia.Remove(item);
            }
            ThucDonViewModel query = new ThucDonViewModel(db);
            query.DeleteThucDonById(id);
            var response = query.GetDataWithCateByPage(filter, int.Parse(page));
            return Json(response);
        }
        public IActionResult FilterProduct(string maloai)
        {
            ThucDonViewModel query = new ThucDonViewModel(db);
            var response = query.GetDataWithCateByPage(maloai, 1);
            return Json(response);
        }
        public IActionResult GetProductSearchCount(string keyword)
        {
            ThucDonViewModel query = new ThucDonViewModel(db);
            var response = query.GetDataByName(keyword).Count();
            return Json(response);
        }
        public IActionResult SearchProduct(string keyword, string page="1")
        {
            var page_num = int.Parse(page);
            ThucDonViewModel query = new ThucDonViewModel(db);
            var response = query.GetDataByNameWithPage(keyword, page_num);
            return Json(response);
        }
        public IActionResult DeleteProductSearch(string id, string keyword, string page)
        {
            List<ChiTietGioHang> ctgh = db.ChiTietGioHang.Where(x => x.MaThucDon == int.Parse(id)).ToList();
            foreach (var item in ctgh)
            {
                db.ChiTietGioHang.Remove(item);
            }
            List<DanhGia> dg = db.DanhGia.Where(x => x.MaThucDon == int.Parse(id)).ToList();
            foreach (var item in dg)
            {
                db.DanhGia.Remove(item);
            }
            ThucDonViewModel query = new ThucDonViewModel(db);
            query.DeleteThucDonById(id);
            var response = query.GetDataByNameWithPage(keyword, int.Parse(page));
            return Json(response);
        }
    }
}