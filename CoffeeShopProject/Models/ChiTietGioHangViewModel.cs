using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class ChiTietGioHangViewModel:ChiTietGioHang
    {
        public string TenThucDon { get; set; }
        public double? Gia { get; set; }
        private readonly CoffeeShopContext db;
        public ChiTietGioHangViewModel() { }
        public ChiTietGioHangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public IEnumerable<ChiTietGioHangViewModel> GetDsChiTietGioHang(string cart_id)
        {
            var ds = from ctgh in db.ChiTietGioHang
                      where ctgh.MaGioHang == int.Parse(cart_id)
                      join td in db.ThucDon
                        on ctgh.MaThucDon equals td.MaThucDon
                      select new ChiTietGioHangViewModel
                      {
                          MaCtgioHang = ctgh.MaCtgioHang,
                          MaGioHang = ctgh.MaGioHang,
                          MaThucDon= ctgh.MaThucDon,
                          TenThucDon = td.TenThucDon,
                          Gia = td.GiaKhuyenMai,
                          SoLuong= ctgh.SoLuong,

                      };
            return ds;
        }

        public bool DeleteChiTietGioHangByCartId(string cart_id)
        {
            var records = db.ChiTietGioHang.Where(c => c.MaGioHang == int.Parse(cart_id));
            if (records != null)
            {
                db.ChiTietGioHang.RemoveRange(records);
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
