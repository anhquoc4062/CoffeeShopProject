using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class ChiTietHoaDonViewModel:ChiTietHoaDon
    {
        private readonly CoffeeShopContext db;
        public ChiTietHoaDonViewModel() { }
        public ChiTietHoaDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<ChiTietHoaDonViewModel> GetDsChiTietHoaDon()
        {
            var ds = (from td in db.ChiTietHoaDon
                      select new ChiTietHoaDonViewModel
                      {
                          MaChiTiet=td.MaChiTiet,
                          MaHoaDon = td.MaHoaDon,
                          MaThucDon = td.MaThucDon,
                          SoLuong = td.SoLuong,
                          DonGia=td.DonGia

                      }).ToList();
            return ds;
        }

        public bool DeleteChiTietHoaDonById(String id)
        {
            if (db.ChiTietHoaDon.Find(int.Parse(id)) != null)
            {
                db.ChiTietHoaDon.Remove(db.ChiTietHoaDon.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon();
        }

        public ChiTietHoaDon GetChiTietHoaDonById(String id)
        {
            ChiTietHoaDon chitiet = db.ChiTietHoaDon.Find(int.Parse(id));
            return chitiet;
        }

        public bool InsertChiTietHoaDon(ChiTietHoaDon nv)
        {
            if (nv != null)
            {
                db.ChiTietHoaDon.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon();
        }
        public bool EditChiTietHoaDon(ChiTietHoaDon ChiTietHoaDon)
        {
            //Edit bằng id nghe
            ChiTietHoaDon nv = db.ChiTietHoaDon.Find(ChiTietHoaDon.MaChiTiet);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(ChiTietHoaDon);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon();
        }
    }
}
