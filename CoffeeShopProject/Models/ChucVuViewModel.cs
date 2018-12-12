using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class ChucVuViewModel:ChucVu
    {
        private readonly CoffeeShopContext db;
        public ChucVuViewModel() { }
        public ChucVuViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<ChucVuViewModel> GetChucVu()
        {

            var ChucVu = (from td in db.ChucVu
                               select new ChucVuViewModel
                               {
                                   MaChucVu= td.MaChucVu,
                                   TenChucVu = td.TenChucVu,
                             
                               }).ToList();
            return ChucVu;
        }

        //public bool DeleteChucVu(string i)
        //{
        //    var loai = db.ChucVu.Where(x => x.MaChucVu == int.Parse(i)).SingleOrDefault();
        //    var dsSanPhamCungId = new ThucDonViewModel(db).GetDataByCate(i);
        //    if (loai != null&&dsSanPhamCungId!=null)
        //    {
        //        foreach (var item in dsSanPhamCungId)
        //        {
        //            db.ThucDon.Remove(item);
        //        }
        //        db.SaveChanges();
        //        db.ChucVu.Remove(loai);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        public bool InsertChucVu(String TenChucVu)
        {
            ChucVu neww = new ChucVu();
            neww.TenChucVu = TenChucVu;
            if (neww != null)
            {
                db.ChucVu.Add(neww);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool EditChucVu(String i,String TenMoi)
        {
            ChucVu loaiMoi = db.ChucVu.Find(int.Parse(i));
            ChucVu loaiCu = db.ChucVu.Find(int.Parse(i));


            loaiMoi.TenChucVu = TenMoi;
            if (loaiCu != null && loaiMoi != null)
            {
                db.Entry(loaiCu).CurrentValues.SetValues(loaiMoi);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
