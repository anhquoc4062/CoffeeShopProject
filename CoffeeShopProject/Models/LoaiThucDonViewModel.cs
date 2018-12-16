using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class LoaiThucDonViewModel:LoaiThucDon
    {
        private readonly CoffeeShopContext db;
        public LoaiThucDonViewModel() { }
        public LoaiThucDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<LoaiThucDonViewModel> GetLoaiThucDon()
        {

            var loaithucdon = (from td in db.LoaiThucDon
                               select new LoaiThucDonViewModel
                               {
                                   MaLoai= td.MaLoai,
                                   TenLoai = td.TenLoai,
                                   MaLoaiCha = td.MaLoaiCha
                               }).ToList();
            return loaithucdon;
        }

        //public bool DeleteLoaiThucDon(string i)
        //{
        //    var loai = db.LoaiThucDon.Where(x => x.MaLoai == int.Parse(i)).SingleOrDefault();
        //    var dsSanPhamCungId = new ThucDonViewModel(db).GetDataByCate(i);
        //    if (loai != null&&dsSanPhamCungId!=null)
        //    {
        //        foreach (var item in dsSanPhamCungId)
        //        {
        //            db.ThucDon.Remove(item);
        //        }
        //        db.SaveChanges();
        //        db.LoaiThucDon.Remove(loai);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        public bool InsertLoaiThucDon(LoaiThucDon loai)
        {
            if (loai != null)
            {
                db.LoaiThucDon.Add(loai);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool EditLoaiThucDon(String i,String TenMoi)
        {
            LoaiThucDon loaiMoi = db.LoaiThucDon.Find(int.Parse(i));
            LoaiThucDon loaiCu = db.LoaiThucDon.Find(int.Parse(i));


            loaiMoi.TenLoai = TenMoi;
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
