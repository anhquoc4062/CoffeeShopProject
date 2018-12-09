using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class ThucDonViewModel : ThucDon
    {
        public string TenLoai { get; set; }

        private readonly CoffeeShopContext db;
        public ThucDonViewModel() { }
        public ThucDonViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<ThucDonViewModel> GetAllData()
        {
            var dsThucDon = (from td in db.ThucDon
                             join ltd in db.LoaiThucDon
                             on td.MaLoai equals ltd.MaLoai
                             orderby td.MaThucDon descending
                             select new ThucDonViewModel
                             {
                                 MaThucDon = td.MaThucDon,
                                 TenThucDon = td.TenThucDon,
                                 HinhAnh = td.HinhAnh,
                                 TenLoai = ltd.TenLoai,
                                 MaLoai = td.MaLoai,
                                 Gia = td.Gia,
                                 KhuyenMai = td.KhuyenMai
                             }).ToList();

            return dsThucDon;
        }

        public ThucDonViewModel GetDataById(string id)
        {
            var thucdon = (from td in db.ThucDon
                           where td.MaThucDon == int.Parse(id)
                           join ltd in db.LoaiThucDon
                           on td.MaLoai equals ltd.MaLoai
                           select new ThucDonViewModel
                           {
                               MaThucDon = td.MaThucDon,
                               TenThucDon = td.TenThucDon,
                               HinhAnh = td.HinhAnh,
                               TenLoai = ltd.TenLoai,
                               MaLoai = td.MaLoai,
                               Gia = td.Gia,
                               KhuyenMai = td.KhuyenMai
                           }).FirstOrDefault();
            return thucdon;
        }
        public List<ThucDonViewModel> GetDataByCate(string MaLoai)
        {
            var dsThucDon = (from td in db.ThucDon
                             where td.MaLoai == int.Parse(MaLoai)
                             join ltd in db.LoaiThucDon
                             on td.MaLoai equals ltd.MaLoai
                             select new ThucDonViewModel
                             {
                                 MaThucDon = td.MaThucDon,
                                 TenThucDon = td.TenThucDon,
                                 HinhAnh = td.HinhAnh,
                                 TenLoai = ltd.TenLoai,
                                 MaLoai = td.MaLoai,
                                 Gia = td.Gia,
                                 KhuyenMai = td.KhuyenMai
                             }).ToList();

            return dsThucDon;
        }
        //------------------------------------------
        public bool DeleteThucDonById(String id)
        {
            if (db.ThucDon.Find(int.Parse(id)) != null)
            {
                db.ThucDon.Remove(db.ThucDon.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ThucDonViewModel(db).GetDsThucDon();
        }

        public bool InsertThucDon(ThucDon nv)
        {
            if (nv != null)
            {
                db.ThucDon.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ThucDonViewModel(db).GetDsThucDon();
        }
        public bool EditThucDon(ThucDon ThucDon)
        {
            //Edit bằng id nghe
            ThucDon nv = db.ThucDon.Find(ThucDon.MaThucDon);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(ThucDon);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ThucDonViewModel(db).GetDsThucDon();
        }
    }
}
