using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeShopProject.Controllers
{
    public class DashBoardController : BaseController
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
            string[] monthNames = {"January", "February", "March", "April", "May", "June",
                                "July", "August", "September", "October", "November", "December" };
            for (int i = 1; i <= 12; i++)
            {
                listEarning.Add(new EarningMonth
                {
                    Month = monthNames[i-1],
                    Earning = Math.Round(query_gh.GetEarningByMonth(i).GetValueOrDefault(), 0),
                    EmployeeCount = query_nv.GetCountEmployeeByMonth(i),
                    ItemCount = query_gh.GetItemCountByMonth(i),
                    OrderCount = query_gh.GetOrderCountByMonth(i)
                });
                totalEarning += query_gh.GetEarningByMonth(i);
                totalItems += query_gh.GetItemCountByMonth(i);
                totalOrders += query_gh.GetOrderCountByMonth(i);
            }
            var query_cv = new ChucVuViewModel(db);
            var listCv = query_cv.GetChucVu();
            var listPercent = new List<PositionPercent>();
            foreach(var cv in listCv)
            {
                listPercent.Add(new PositionPercent {
                    PositionName = cv.TenChucVu,
                    Percent = Convert.ToInt32(query_nv.GetPercentEmployeePosition(cv.MaChucVu))
                });
            }
            ViewBag.TotalEarning = totalEarning;
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalOrders = totalOrders;
            ViewBag.PositionName = JsonConvert.SerializeObject(listPercent.Select(x=>x.PositionName));
            ViewBag.Percent = JsonConvert.SerializeObject(listPercent.Select(x=>x.Percent));
            return View(listEarning);
        }
    }
}