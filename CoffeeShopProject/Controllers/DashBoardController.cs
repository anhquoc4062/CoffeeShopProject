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
            GioHangViewModel query = new GioHangViewModel(db);
            double? totalEarning = 0.0;
            for(int i = 1; i <= 12; i++)
            {
                listEarning.Add(new EarningMonth
                {
                    Month = "Tháng " + i.ToString(),
                    Earning = query.GetEarningByMonth(i)
                });
                totalEarning += query.GetEarningByMonth(i);
            }
            ViewBag.TotalEarning = totalEarning;
            return View(listEarning);
        }
    }
}