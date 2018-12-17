using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class KhachHangViewModel : KhachHang
    {
        public string TenTinhThanh { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        private readonly CoffeeShopContext db;
        public KhachHangViewModel() { }
        public KhachHangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }
        public List<KhachHangViewModel> GetDsKhachHang()
        {

            var khachhang = (from kh in db.KhachHang
                             join tp in db.TinhThanh
                                on kh.MaTinhThanh equals tp.MaTinhThanh 
                             join tk in db.TaiKhoan
                             on kh.MaTaiKhoan equals tk.MaTaiKhoan
                             select new KhachHangViewModel
                             {
                                 MaKhachHang = kh.MaKhachHang,
                                 TenKhachHang = kh.TenKhachHang,
                                 Email = kh.Email,
                                 DiaChi = kh.DiaChi,
                                 MaTinhThanh = tp.MaTinhThanh,
                                 TenTinhThanh = tp.TenTinhThanh,
                                 MaTaiKhoan = kh.MaTaiKhoan,
                                 TenTaiKhoan = tk.TenTaiKhoan,
                                 MatKhau = tk.MatKhau,
                                 SoDt = kh.SoDt

                             }).ToList();
            return khachhang;
        }
        public KhachHang GetKhachHangById(string id)
        {
            var khachhang = GetDsKhachHang().Where(x => x.MaKhachHang == int.Parse(id)).FirstOrDefault();
            return khachhang;
        }
        public bool DeleteKhachHang(string id)
        {
            if (db.KhachHang.Find(int.Parse(id)) != null)
            {
                db.KhachHang.Remove(db.KhachHang.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new KhachHangViewModel(db).GetDsKhachHang();
        }

        public bool InsertKhachHang(KhachHang kh)
        {
            if (kh != null)
            {
                db.KhachHang.Add(kh);
                db.SaveChanges();
                return true;

            }
            return false;
            // return new KhachHangViewModel(db).GetKhachHang();
        }

        public bool EditKhachHang(KhachHang kh){
            KhachHang khachhang = db.KhachHang.Find(kh.MaKhachHang);
            if (khachhang != null)
            {
                db.Entry(khachhang).CurrentValues.SetValues(kh);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteKhachHangById(String id)
        {
            if (db.KhachHang.Find(int.Parse(id)) != null)
            {
                db.KhachHang.Remove(db.KhachHang.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ChiTietGioHangViewModel(db).GetDsChiTietGioHang();
        }
    }
}
