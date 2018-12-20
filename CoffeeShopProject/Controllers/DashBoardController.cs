using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly CoffeeShopContext db;
        public DashBoardController(CoffeeShopContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.EmployeeCount = (from nv in db.NhanVien select nv).Count();
            var listEarning = new List<EarningMonth>();
            GioHangViewModel query_gh = new GioHangViewModel(db);
            NhanVienViewModel query_nv = new NhanVienViewModel(db);
            double? totalEarning = 0.0;
            int? totalItems = 0;
            int totalOrders = 0;
            for(int i = 1; i <= 12; i++)
            {
                listEarning.Add(new EarningMonth
                {
                    Month = "Tháng " + i.ToString(),
                    Earning = query_gh.GetEarningByMonth(i),
                    EmployeeCount = query_nv.GetCountEmployeeByMonth(i),
                    ItemCount = query_gh.GetItemCountByMonth(i),
                    OrderCount = query_gh.GetOrderCountByMonth(i),
                });
                totalEarning += query_gh.GetEarningByMonth(i);
                totalItems += query_gh.GetItemCountByMonth(i);
                totalOrders += query_gh.GetOrderCountByMonth(i);
            }
            ViewBag.TotalEarning = totalEarning;
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalOrders = totalOrders;
            return View(listEarning);
        }
    }
}