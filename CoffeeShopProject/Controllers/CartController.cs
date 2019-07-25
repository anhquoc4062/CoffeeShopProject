using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class CartController : Controller
    {
        private readonly CoffeeShopContext db;
        public CartController(CoffeeShopContext _db)
        {
            db = _db;
        }
        [Route("gio-hang")]
        public IActionResult Index()
        {
            ViewBag.Cart = GetGioHang;
            ViewBag.Total = GetGioHang.Sum(x => x.SoLuong*x.GiaBan);
            return View();
        }

        public List<CartItem> GetGioHang
        {
            get
            {
                List<CartItem> myCart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
                if (myCart == default(List<CartItem>))
                {
                    myCart = new List<CartItem>();
                }
                return myCart;
            }
        }
        public IActionResult AddToCart(int id)
        {
            int product_id = id;
            //lấy giỏ hàng đang có
            var gioHang = GetGioHang;
            //kiểm tra xem hàng đã có trong giỏ chưa
            CartItem item = gioHang.SingleOrDefault(p => p.MaThucDon == product_id);
            //nếu có
            if (item != null)
            {
                item.SoLuong++;//tăng số lượng
            }
            else
            {
                ThucDon hh = db.ThucDon.SingleOrDefault(p => p.MaThucDon == product_id);
                item = new CartItem
                {
                    MaThucDon = product_id,
                    SoLuong = 1,
                    TenThucDon = hh.TenThucDon,
                    HinhAnh = hh.HinhAnh,
                    GiaBan = hh.GiaKhuyenMai
                };
                gioHang.Add(item);
            }
            //lưu session
            SessionHelper.Set(HttpContext.Session, "cart", gioHang);
            var response = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
            //chuyển tới trang giỏ hàng để xem
            return Json(response);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var gioHang = GetGioHang;
            CartItem item = gioHang.SingleOrDefault(p => p.MaThucDon == id);
            item.SoLuong = quantity;
            SessionHelper.Set(HttpContext.Session, "cart", gioHang);
            var response = item.SoLuong * item.GiaBan;
            return Json(response);
        }

        public IActionResult RemoveItem(int id)
        {
            var gioHang = GetGioHang;
            CartItem item = gioHang.SingleOrDefault(p => p.MaThucDon == id);
            gioHang.Remove(item);
            SessionHelper.Set(HttpContext.Session, "cart", gioHang);
            var response = true;
            return Json(response);
        }
        public IActionResult GetTotal()
        {
            var gioHang = GetGioHang.Sum(x => x.SoLuong * x.GiaBan);
            return Json(gioHang);
        }

        public IActionResult LoadCartHidden()
        {
            var response = GetGioHang;
            return Json(response);
        }
    }
}