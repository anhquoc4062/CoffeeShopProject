using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    [EnableCors("CorsPolicy")]
    public class ApiController : Controller
    {
        private readonly CoffeeShopContext db;
        public ApiController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Respond(object data, bool success = true)
        {
            if (success == true)
            {
                return Json(new
                {
                    exit_code = 1,
                    data = data,
                    message = "Success"
                });
            }
            else
            {
                return Json(new
                {
                    exit_code = 0,
                    data = data,
                    message = "Fail"
                });
            }
        }

        public IActionResult GetData()
        {
            var data = new
            {
                loaiThucDon = new LoaiThucDonViewModel(db).GetLoaiThucDon(),
                thucDon = new ThucDonViewModel(db).GetAllData(),
                banAn = new BanAnViewModel(db).GetDsBanAn(),
                tang = new TangViewModel(db).GetDsTang(),
                hoaDon = new HoaDonViewModel(db).GetDsHoaDon()
            };
            Console.WriteLine(new HoaDonViewModel(db).GetDsHoaDon());
            return Respond(data);
        }
    }
}