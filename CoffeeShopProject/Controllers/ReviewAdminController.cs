using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class ReviewAdminController : BaseController
    {
        private readonly CoffeeShopContext db;
        public ReviewAdminController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            DanhGiaViewModel query = new DanhGiaViewModel(db);
            ViewBag.ListReview = query.GetDsDanhGia();
            return View();
        }
        public IActionResult RemoveReview(int id)
        {
            var thisRv = db.DanhGia.SingleOrDefault(x => x.MaDanhGia == id);
            db.DanhGia.Remove(thisRv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}