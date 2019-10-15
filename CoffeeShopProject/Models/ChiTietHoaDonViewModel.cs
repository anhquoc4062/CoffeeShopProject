using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class ChiTietHoaDonViewModel:ChiTietHoaDon
    {
        private readonly CoffeeShopContext db;
        public string TenThucDon { get; set; }
        public double? GiaMon { get; set; }
        public ChiTietHoaDonViewModel() { }
        public ChiTietHoaDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<ChiTietHoaDonViewModel> GetDsChiTietHoaDon(int maHoaDon)
        {
            var ds = (from cthd in db.ChiTietHoaDon
                      join td in db.ThucDon
                      on cthd.MaThucDon equals td.MaThucDon
                      where cthd.MaHoaDon.Equals(maHoaDon)
                      select new ChiTietHoaDonViewModel
                      {
                          MaChiTiet= cthd.MaChiTiet,
                          MaHoaDon = cthd.MaHoaDon,
                          MaHoaDonLocal = cthd.MaHoaDonLocal,
                          MaThucDon = cthd.MaThucDon,
                          SoLuong = cthd.SoLuong,
                          GiaMon = td.GiaKhuyenMai,
                          DonGia = cthd.SoLuong * td.GiaKhuyenMai,
                          TenThucDon = td.TenThucDon,
                          MaChiTietLocal = cthd.MaChiTietLocal,
                          TrangThai = cthd.TrangThai

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

        public bool InserOrUpdateChiTietHoaDon(ChiTietHoaDon cthd) {
            ChiTietHoaDon exist = db.ChiTietHoaDon.Where(x => x.MaChiTietLocal.Equals(cthd.MaChiTietLocal)).FirstOrDefault();
            if (exist != null)
            {
                exist.MaHoaDon = cthd.MaHoaDon;
                exist.MaHoaDonLocal = cthd.MaHoaDonLocal;
                // exist.MaChiTiet = cthd.MaChiTiet;
                exist.MaChiTietLocal = cthd.MaChiTietLocal;
                exist.SoLuong = cthd.SoLuong;
                exist.MaThucDon = cthd.MaThucDon;
                exist.TrangThai = cthd.TrangThai;
                exist.DonGia = cthd.DonGia;
                db.ChiTietHoaDon.Update(exist);
            } else {
                db.ChiTietHoaDon.Add(cthd);
            }
            db.SaveChanges();
            return true;
        }
    }
}
