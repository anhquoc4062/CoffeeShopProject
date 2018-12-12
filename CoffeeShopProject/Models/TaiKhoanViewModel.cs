using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class TaiKhoanViewModel:TaiKhoan
    {
        private readonly CoffeeShopContext db;
        public TaiKhoanViewModel() { }
        public TaiKhoanViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public IEnumerable<TaiKhoanViewModel> GetAllTaiKhoan()
        {

            var dstk = (from td in db.TaiKhoan
                               select new TaiKhoanViewModel
                               {
                                   MaTaiKhoan= td.MaTaiKhoan,
                                   TenTaiKhoan = td.TenTaiKhoan,
                                   MatKhau = td.MatKhau
                             
                               });
            return dstk;
        }

        public TaiKhoanViewModel GetTaiKhoanById(string id)
        {
            var tk = GetAllTaiKhoan().Where(self => self.MaTaiKhoan.ToString().Equals(id)).FirstOrDefault();
            return tk;
        }

        //public bool DeleteTaiKhoan(string i)
        //{
        //    var loai = db.TaiKhoan.Where(x => x.MaTaiKhoan == int.Parse(i)).SingleOrDefault();
        //    var dsSanPhamCungId = new ThucDonViewModel(db).GetDataByCate(i);
        //    if (loai != null&&dsSanPhamCungId!=null)
        //    {
        //        foreach (var item in dsSanPhamCungId)
        //        {
        //            db.ThucDon.Remove(item);
        //        }
        //        db.SaveChanges();
        //        db.TaiKhoan.Remove(loai);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        public bool InsertTaiKhoan(TaiKhoan neww)
        {
            if (neww != null)
            {
                db.TaiKhoan.Add(neww);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool EditTaiKhoan(TaiKhoan edittk)
        {
            TaiKhoan tk = db.TaiKhoan.Find(edittk.MaTaiKhoan);
            if (tk != null)
            {
                db.Entry(tk).CurrentValues.SetValues(edittk);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
