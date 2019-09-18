﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class HoaDonViewModel:HoaDon
    {
        private readonly CoffeeShopContext db;
        public string TenBan { get; set; }
        public List<ChiTietHoaDonViewModel> DsMon { get; set; }
        public HoaDonViewModel() { }
        public HoaDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<HoaDonViewModel> GetDsHoaDon()
        {
            var ds = (from hd in db.HoaDon
                      join b in db.BanAn
                      on hd.MaBan equals b.MaBan
                      select new HoaDonViewModel
                      {
                          MaHoaDon = hd.MaHoaDon,
                          ThoiGianLap = hd.ThoiGianLap,
                          MaNhanVienOrder = hd.MaNhanVienOrder,
                          MaBan = hd.MaBan,
                          TenBan = b.TenBan,
                          TongTien = hd.TongTien,
                          MaHoaDonLocal = hd.MaHoaDonLocal,
                          TrangThai = hd.TrangThai,
                          MaThuNgan = hd.MaThuNgan,
                          GiamGia = hd.GiamGia,
                          ThanhTien = hd.ThanhTien,
                          DsMon = new ChiTietHoaDonViewModel(db).GetDsChiTietHoaDon(1)

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
