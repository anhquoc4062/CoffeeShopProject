using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return Respond(data);
        }
        public async Task<bool> SendPushNotification(OrderPostData order, string exceptToken)
        {
            var applicationID = "AAAAngCsjps:APA91bGIORNVRh56qyK6aQuVs9r41EoWnzRIGikVITD9N-KXHlNIUQCcrS3ADLn84urJSmdgXj81jU8781M5tB2nOKtJg1soSYFUS0lwVCs3kyM06oxn23Z69FYc1It_h86473lPk_3c";
            // var senderId = "xxx";
            // var deviceId = "xxxx";


            using (var client = new HttpClient())
            {
                //do something with http client
                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={applicationID}");
                // client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={senderId}");

                var pushDeviceQuery = new PushDeviceViewModel(db);

                pushDeviceQuery.Insert(exceptToken);

                var statusMessage = order.TenBan + ' ';

                switch(order.TrangThai)
                {
                    case 1:
                        statusMessage += "có order mới";
                        break;
                    case 2:
                        statusMessage += "có cập nhật";
                        break;
                    case 3:
                        statusMessage += "đã hủy order";
                        break;
                    case 8:
                        statusMessage += "đã thanh toán order";
                        break;
                    case 7:
                        statusMessage += "đã chế biến xong";
                        break;
                }

                var param = new
                {
                    registration_ids = new PushDeviceViewModel(db).GetAllTokenExcept(exceptToken),
                    data = new
                    {
                        order_local_id = order.MaHoaDonLocal,
                        order_id = order.MaHoaDon,
                        status = order.TrangThai,
                        created_date = order.ThoiGianLap,
                        message = statusMessage,
                    }

                };

                var json = JsonConvert.SerializeObject(param);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("/fcm/send", httpContent);
            }
            return true;
        }
        [HttpPost]
        public IActionResult SyncOrder(OrderPostData order) {

            PostLog postLog = new PostLog();
            postLog.LocalId = order.MaHoaDonLocal;
            postLog.Api = "syncOrder";
            postLog.RegDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            postLog.Params = JsonConvert.SerializeObject(order);
            PostLogViewModel postLogViewModel = new PostLogViewModel(db);
            postLogViewModel.InsertData(postLog);

            HoaDonX newhd = new HoaDonX();
            newhd.MaHoaDonLocal = order.MaHoaDonLocal;
            // newhd.MaHoaDon = order.MaHoaDon;
            newhd.MaBan = order.MaBan;
            newhd.TrangThai = order.TrangThai;
            newhd.TongTien = order.TongTien;
            newhd.ThanhTien = order.ThanhTien;
            newhd.GiamGia = order.GiamGia;
            newhd.MaThuNgan = order.MaThuNgan;
            newhd.MaNhanVienOrder = order.MaNhanVienOrder;
            newhd.ThoiGianLap = order.ThoiGianLap;

            var hdQuery = new HoaDonViewModel(db).InserOrUpdateHoaDon(newhd);
            if (hdQuery != null) {
                order.MaHoaDon = hdQuery.MaHoaDon;
                if (order.DsMon == null && order.DsMonJson != null) {
                    order.DsMon = JsonConvert.DeserializeObject<ChiTietHoaDon[]>(order.DsMonJson);
                }
                foreach (var item in order.DsMon)
                {
                    ChiTietHoaDon ctHd = new ChiTietHoaDon
                    {
                        MaHoaDon = order.MaHoaDon,
                        MaHoaDonLocal = newhd.MaHoaDonLocal,
                        MaChiTiet = item.MaChiTiet,
                        MaChiTietLocal = item.MaChiTietLocal,
                        SoLuong = item.SoLuong,
                        MaThucDon = item.MaThucDon,
                        TrangThai = item.TrangThai,
                        DonGia = item.DonGia
                    };
                    var cthdQuery = new ChiTietHoaDonViewModel(db).InserOrUpdateChiTietHoaDon(ctHd);
                    if (!cthdQuery)
                    {
                        return Respond("", false);
                    } 
                }
                this.SendPushNotification(order, order.TokenThietBi);
                return Respond(hdQuery, true);
            }
            else {
                return Respond("", false);
            }
        }
        [HttpPost]
        public IActionResult testPost(OrderPostData order)
        {
            if (order.DsMon == null && order.DsMonJson != null)
            {
                order.DsMon = JsonConvert.DeserializeObject<ChiTietHoaDon[]>(order.DsMonJson);
            }
            return Respond(order, true);
        }
        [HttpPost]
        public IActionResult getOrderFromServer(string id)
        {
            var query = new HoaDonViewModel(db).GetHoaDonById_v2(id);
            return Respond(query, true);
        }
        [HttpPost]
        public IActionResult login(string username, string password)
        {
            var tk = db.TaiKhoan.SingleOrDefault(x => x.TenTaiKhoan == username && x.MatKhau == password);
            if (tk == null) {
                return Respond("", false);
            } else {
                return Respond(tk);
            }
        }

        [HttpPost]
        public IActionResult pushToken(string token)
        {
            var pushDeviceQuery = new PushDeviceViewModel(db);

            if(pushDeviceQuery.Insert(token)) {
                return Respond("");
            }
            return Respond("", false);
        }

        [HttpPost]
        public IActionResult popToken(string token)
        {
            var pushDeviceQuery = new PushDeviceViewModel(db);

            if (pushDeviceQuery.Delete(token))
            {
                return Respond("");
            }
            return Respond("", false);
        }

    }
}