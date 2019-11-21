using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class GioHangViewModel:GioHang
    {
        public string TenKhachHang { get; set; }
        public string Email { get; set; }
        private readonly CoffeeShopContext db;

        private readonly int CurrentYear = DateTime.Now.Year;
        public GioHangViewModel() { }
        public GioHangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<GioHangViewModel> GetDsGioHang()
        {
            var ds = (from gh in db.GioHang
                      join kh in db.KhachHang
                        on gh.MaKhachHang equals kh.MaKhachHang
                      select new GioHangViewModel
                      {
                          MaGioHang=gh.MaGioHang,
                          MaKhachHang=gh.MaKhachHang,
                          TenKhachHang = kh.TenKhachHang,
                          Email = kh.Email,
                          NgayDat=gh.NgayDat,
                          TrangThai=gh.TrangThai
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

        public double? GetEarningByMonth(int month)
        {
            var listGh = db.GioHang.Where(x => x.NgayDat.Value.Month == month && x.NgayDat.Value.Year == CurrentYear).ToList();
            double? total = 0.0;
            foreach (var gh in listGh)
            {
                var listDetail = db.ChiTietGioHang.Where(x => x.MaGioHang == gh.MaGioHang).ToList();
                foreach (var ctgh in listDetail)
                {
                    var giaTd = (from td in db.ThucDon
                                 select td).Where(x => x.MaThucDon == ctgh.MaThucDon).Select(x => x.GiaKhuyenMai).SingleOrDefault();
                    total += giaTd*ctgh.SoLuong;
                }
            }

            var listHd = db.HoaDonX.Where(x => x.ThoiGianLap.Value.Month == month && x.ThoiGianLap.Value.Year == CurrentYear).ToList();
            foreach (var hd in listHd)
            {
                var listDetail = db.ChiTietHoaDon.Where(x => x.MaHoaDon == hd.MaHoaDon).ToList();
                foreach (var cthd in listDetail)
                {
                    var giaTd = (from td in db.ThucDon
                                 select td).Where(x => x.MaThucDon == cthd.MaThucDon).Select(x => x.GiaKhuyenMai).SingleOrDefault();
                    total += giaTd * cthd.SoLuong;
                }
            }

            return total;
        }

        public int? GetItemCountByMonth(int month)
        {
            var listGh = db.GioHang.Where(x => x.NgayDat.Value.Month == month && x.NgayDat.Value.Year == CurrentYear).ToList();
            int? total = 0;
            foreach (var gh in listGh)
            {
                var listDetail = db.ChiTietGioHang.Where(x => x.MaGioHang == gh.MaGioHang).ToList();
                foreach (var ctgh in listDetail)
                {
                    var giaTd = (from td in db.ThucDon
                                 select td).Where(x => x.MaThucDon == ctgh.MaThucDon).Select(x => x.GiaKhuyenMai).SingleOrDefault();
                    total += ctgh.SoLuong;
                }
            }

            var listHd = db.HoaDonX.Where(x => x.ThoiGianLap.Value.Month == month && x.ThoiGianLap.Value.Year == CurrentYear).ToList();
            foreach (var hd in listHd)
            {
                var listDetail = db.ChiTietHoaDon.Where(x => x.MaHoaDon == hd.MaHoaDon && (x.TrangThai == 1 || x.TrangThai == 2)).ToList();
                foreach (var cthd in listDetail)
                {
                    var giaTd = (from td in db.ThucDon
                                 select td).Where(x => x.MaThucDon == cthd.MaThucDon).Select(x => x.GiaKhuyenMai).SingleOrDefault();
                    total += cthd.SoLuong;
                }
            }
            return total;
        }

        public int GetOrderCountByMonth(int month)
        {
            int count = db.GioHang.Where(x => x.NgayDat.Value.Month == month && x.NgayDat.Value.Year == CurrentYear).Count();
            count += db.HoaDonX.Where(x => x.ThoiGianLap.Value.Month == month && x.ThoiGianLap.Value.Year == CurrentYear).Count();
            return count;
        }
    }
}
