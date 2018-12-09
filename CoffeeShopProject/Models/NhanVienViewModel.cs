using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class NhanVienViewModel:NhanVien
    {
        private readonly CoffeeShopContext db;
        public NhanVienViewModel() { }
        public NhanVienViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<NhanVienViewModel> GetDsNhanVien()
        {
            var ds= (from td in db.NhanVien
                     select new NhanVienViewModel
                     {
                         MaNhanVien=td.MaNhanVien,
                         HoTen=td.HoTen,
                         NgaySinh=td.NgaySinh,
                         TenDangNhap=td.TenDangNhap,
                         MatKhau=td.MatKhau,
                         ChucVu=td.ChucVu

                     }).ToList();
            return ds;
        }

        public bool DeleteNhanVienById(String id)
        {
            if (db.NhanVien.Find(int.Parse(id)) != null)
            {
                db.NhanVien.Remove(db.NhanVien.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
        }
        
        public bool InsertNhanVien(NhanVien nv)
        {
            if (nv != null)
            {
                db.NhanVien.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool EditNhanVien(NhanVien nhanVien)
        {
            //Edit bằng id nghe
            NhanVien nv = db.NhanVien.Find(nhanVien.MaNhanVien);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(nhanVien);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new NhanVienViewModel(db).GetDsNhanVien();
        }
    }
}
