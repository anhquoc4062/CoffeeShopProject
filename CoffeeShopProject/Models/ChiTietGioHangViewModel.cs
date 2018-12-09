using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class ChiTietGioHangViewModel:ChiTietGioHang
    {
        private readonly CoffeeShopContext db;
        public ChiTietGioHangViewModel() { }
        public ChiTietGioHangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<ChiTietGioHangViewModel> GetDsChiTietGioHang()
        {
            var ds = (from td in db.ChiTietGioHang
                      select new ChiTietGioHangViewModel
                      {
                          MaCtgioHang = td.MaCtgioHang,
                          MaGioHang = td.MaGioHang,
                          MaThucDon=td.MaThucDon,
                          SoLuong=td.SoLuong,

                      }).ToList();
            return ds;
        }

        public bool DeleteChiTietGioHangById(String id)
        {
            if (db.ChiTietGioHang.Find(int.Parse(id)) != null)
            {
                db.ChiTietGioHang.Remove(db.ChiTietGioHang.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietGioHangViewModel(db).GetDsChiTietGioHang();
        }
        public ChiTietGioHang GetChiTietGioHangById(String id)
        {
            return db.ChiTietGioHang.Find(int.Parse(id));
        }
        public bool InsertChiTietGioHang(ChiTietGioHang nv)
        {
            if (nv != null)
            {
                db.ChiTietGioHang.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietGioHangViewModel(db).GetDsChiTietGioHang();
        }
        public bool EditChiTietGioHang(ChiTietGioHang ChiTietGioHang)
        {
            //Edit bằng id nghe
            ChiTietGioHang nv = db.ChiTietGioHang.Find(ChiTietGioHang.MaCtgioHang);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(ChiTietGioHang);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietGioHangViewModel(db).GetDsChiTietGioHang();
        }
    }
}
