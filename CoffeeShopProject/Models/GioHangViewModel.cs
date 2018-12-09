using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class GioHangViewModel:GioHang
    {
        private readonly CoffeeShopContext db;
        public GioHangViewModel() { }
        public GioHangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<GioHangViewModel> GetDsGioHang()
        {
            var ds = (from td in db.GioHang
                      select new GioHangViewModel
                      {
                          MaGioHang=td.MaGioHang,
                          MaKhachHang=td.MaKhachHang,
                          TongCong=td.TongCong,
                          NgayDat=td.NgayDat,
                          TrangThai=td.TrangThai

                      }).ToList();
            return ds;
        }

        public bool DeleteGioHangById(String id)
        {
            if (db.GioHang.Find(int.Parse(id)) != null)
            {
                db.GioHang.Remove(db.GioHang.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new GioHangViewModel(db).GetDsGioHang();
        }
        public GioHang GetGioHangById(String id)
        {
            return db.GioHang.Find(int.Parse(id));
        }
        public bool InsertGioHang(GioHang nv)
        {
            if (nv != null)
            {
                db.GioHang.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new GioHangViewModel(db).GetDsGioHang();
        }
        public bool EditGioHang(GioHang GioHang)
        {
            //Edit bằng id nghe
            GioHang nv = db.GioHang.Find(GioHang.MaGioHang);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(GioHang);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new GioHangViewModel(db).GetDsGioHang();
        }
    }
}
