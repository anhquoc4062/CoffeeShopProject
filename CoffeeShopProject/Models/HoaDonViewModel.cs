using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class HoaDonViewModel:HoaDon
    {
        private readonly CoffeeShopContext db;
        public string TenBan { get; set; }
        public string TenTang { get; set; }
        public List<ChiTietHoaDonViewModel> DsMon { get; set; }
        public HoaDonViewModel() { }
        public HoaDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<HoaDonViewModel> GetDsHoaDon()
        {
            var ds = (from hd in db.HoaDonX
                      join b in db.BanAn
                      on hd.MaBan equals b.MaBan
                      join t in db.Tang
                      on b.MaTang equals t.MaTang
                      where !hd.TrangThai.Equals(3) && !hd.TrangThai.Equals(4) && !hd.TrangThai.Equals(8)
                      select new HoaDonViewModel
                      {
                          MaHoaDon = hd.MaHoaDon,
                          ThoiGianLap = hd.ThoiGianLap,
                          MaNhanVienOrder = hd.MaNhanVienOrder,
                          MaBan = hd.MaBan,
                          TenBan = b.TenBan,
                          TenTang = t.TenTang,
                          TongTien = hd.TongTien,
                          MaHoaDonLocal = hd.MaHoaDonLocal,
                          TrangThai = hd.TrangThai,
                          MaThuNgan = hd.MaThuNgan,
                          GiamGia = hd.GiamGia,
                          ThanhTien = hd.ThanhTien,
                          // DsMon = new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon(hd.MaHoaDon)

                      }).ToList();
            foreach (var item in ds)
            {
                item.DsMon = new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon(item.MaHoaDon);
            }
            return ds;
        }

        public bool DeleteHoaDonById(String id)
        {
            if (db.HoaDonX.Find(int.Parse(id)) != null)
            {
                db.HoaDonX.Remove(db.HoaDonX.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new HoaDonViewModel(db).GetDsHoaDon();
        }
        public HoaDonX GetHoaDonById(String id)
        {
            return db.HoaDonX.Find(int.Parse(id));
        }

        public HoaDonViewModel GetHoaDonById_v2(String id)
        {
            var hoaDon = (from hd in db.HoaDonX
                            join b in db.BanAn
                            on hd.MaBan equals b.MaBan
                            join t in db.Tang
                            on b.MaTang equals t.MaTang
                            where hd.MaHoaDon == int.Parse(id)
                            select new HoaDonViewModel
                            {
                                MaHoaDon = hd.MaHoaDon,
                                ThoiGianLap = hd.ThoiGianLap,
                                MaNhanVienOrder = hd.MaNhanVienOrder,
                                MaBan = hd.MaBan,
                                TenBan = b.TenBan + '-' + t.TenTang,
                                TongTien = hd.TongTien,
                                MaHoaDonLocal = hd.MaHoaDonLocal,
                                TrangThai = hd.TrangThai,
                                MaThuNgan = hd.MaThuNgan,
                                GiamGia = hd.GiamGia,
                                ThanhTien = hd.ThanhTien,

                            }).FirstOrDefault();
            if (hoaDon != null) {
                hoaDon.DsMon = new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon(hoaDon.MaHoaDon);
            }                
            return hoaDon;
        }

        public bool InsertHoaDon(HoaDonX hd)
        {
            if (hd != null)
            {
                db.HoaDonX.Add(hd);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new HoaDonViewModel(db).GetDsHoaDon();
        }
        public bool EditHoaDon(HoaDonX HoaDon)
        {
            //Edit bằng id nghe
            HoaDonX nv = db.HoaDonX.Find(HoaDon.MaHoaDon);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(HoaDon);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new HoaDonViewModel(db).GetDsHoaDon();
        }

        public bool InserOrUpdateHoaDon(HoaDonX hd) {
            HoaDonX nv = db.HoaDonX.Where(x => x.MaHoaDonLocal.Equals(hd.MaHoaDonLocal)).FirstOrDefault();
            if (nv != null)
            {
                nv.MaHoaDonLocal = hd.MaHoaDonLocal;
                nv.MaNhanVienOrder = hd.MaNhanVienOrder;
                nv.TongTien = hd.TongTien;
                nv.GiamGia = hd.GiamGia;
                nv.ThoiGianLap = hd.ThoiGianLap;
                nv.MaBan = hd.MaBan;
                nv.TrangThai = hd.TrangThai;
                nv.ThanhTien = hd.ThanhTien;
                nv.MaThuNgan = hd.MaThuNgan;
                // db.Entry(nv).CurrentValues.SetValues(hd);
                db.HoaDonX.Update(nv);
            } else {
                db.HoaDonX.Add(hd);
            }
            hd = nv;
            db.SaveChanges();
            return true;
        }
    }
}
