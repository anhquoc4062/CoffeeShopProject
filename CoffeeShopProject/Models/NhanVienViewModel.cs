using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class NhanVienViewModel:NhanVien
    {
        public string TenChucVu { get; set; }
        private readonly CoffeeShopContext db;
        public NhanVienViewModel() { }
        public NhanVienViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<NhanVienViewModel> GetDsNhanVien()
        {
            var ds= (from nv in db.NhanVien
                     join cv in db.ChucVu
                     on nv.MaChucVu equals cv.MaChucVu
                     orderby nv.MaChucVu descending
                     select new NhanVienViewModel
                     {
                         MaNhanVien=nv.MaNhanVien,
                         HoTen= nv.HoTen,
                         HinhAnh = nv.HinhAnh,
                         Cmnd  = nv.Cmnd,
                         Email = nv.Email,
                         MoTa   = nv.MoTa,
                         Luong  = nv.Luong,
                         MaChucVu = nv.MaChucVu,
                         MaTaiKhoan = nv.MaTaiKhoan,
                         TenChucVu= cv.TenChucVu
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
