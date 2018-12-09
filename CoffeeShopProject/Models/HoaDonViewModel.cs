using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class HoaDonViewModel:HoaDon
    {
        private readonly CoffeeShopContext db;
        public HoaDonViewModel() { }
        public HoaDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<HoaDonViewModel> GetDsHoaDon()
        {
            var ds = (from td in db.HoaDon
                      select new HoaDonViewModel
                      {
                          MaHoaDon = td.MaHoaDon,
                          ThoiGianLap=td.ThoiGianLap,
                          SoKhach=td.SoKhach,
                          MaNhanVien=td.MaNhanVien,
                          MaBan=td.MaBan,
                          TongTien=td.TongTien

                      }).ToList();
            return ds;
        }

        public bool DeleteHoaDonById(String id)
        {
            if (db.HoaDon.Find(int.Parse(id)) != null)
            {
                db.HoaDon.Remove(db.HoaDon.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new HoaDonViewModel(db).GetDsHoaDon();
        }
        public HoaDon GetHoaDonById(String id)
        {
            return db.HoaDon.Find(int.Parse(id));
        }
        public bool InsertHoaDon(HoaDon nv)
        {
            if (nv != null)
            {
                db.HoaDon.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new HoaDonViewModel(db).GetDsHoaDon();
        }
        public bool EditHoaDon(HoaDon HoaDon)
        {
            //Edit bằng id nghe
            HoaDon nv = db.HoaDon.Find(HoaDon.MaHoaDon);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(HoaDon);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new HoaDonViewModel(db).GetDsHoaDon();
        }
    }
}
