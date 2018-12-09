using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class KhachHangViewModel : KhachHang
    {
        private readonly CoffeeShopContext db;
        public KhachHangViewModel() { }
        public KhachHangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }
        public List<KhachHangViewModel> GetDsKhachHang()
        {

            var khachhang = (from td in db.KhachHang
                             select new KhachHangViewModel
                             {
                                 MaKhachHang = td.MaKhachHang,
                                 TenKhachHang = td.TenKhachHang,
                                 Email = td.Email,
                                 DiaChi = td.DiaChi,
                                 TinhThanh = td.TinhThanh,
                                 SoDt = td.SoDt

                             }).ToList();
            return khachhang;
        }
        public KhachHang GetKhachHangById(String id)
        {
            //Không có thì nó return null nhé :)
            KhachHang khachhang = db.KhachHang.Find(int.Parse(id));
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
