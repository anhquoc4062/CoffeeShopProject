using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class PhanCongViewModel:PhanCong
    {
        private readonly CoffeeShopContext db;
        public PhanCongViewModel() { }
        public PhanCongViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<PhanCongViewModel> GetDsPhanCong()
        {
            var ds = (from td in db.PhanCong
                      select new PhanCongViewModel
                      {
                          MaPhanCong = td.MaPhanCong,
                          
                          Ca=td.Ca,
                          MaNhanVien = td.MaNhanVien,
                          MaBan = td.MaBan,
                          NgayPhanCong=td.NgayPhanCong,

                      }).ToList();
            return ds;
        }

        public bool DeletePhanCongById(String id)
        {
            if (db.PhanCong.Find(int.Parse(id)) != null)
            {
                db.PhanCong.Remove(db.PhanCong.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new PhanCongViewModel(db).GetDsPhanCong();
        }
        public PhanCong GetPhanCongById(String id)
        {
            return db.PhanCong.Find(int.Parse(id));
        }
        public bool InsertPhanCong(PhanCong nv)
        {
            if (nv != null)
            {
                db.PhanCong.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new PhanCongViewModel(db).GetDsPhanCong();
        }
        public bool EditPhanCong(PhanCong PhanCong)
        {
            //Edit bằng id nghe
            PhanCong nv = db.PhanCong.Find(PhanCong.MaPhanCong);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(PhanCong);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new PhanCongViewModel(db).GetDsPhanCong();
        }
    }
}
