using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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

        public IEnumerable<ThucDonViewModel> GetAllData()
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
                                 KhuyenMai = td.KhuyenMai,
                                 MoTa = td.MoTa
                             });

            return dsThucDon;
        }
        public IEnumerable<ThucDonViewModel> GetAllDataByCate(string MaLoai)
        {
            var dsThucdon = Enumerable.Empty<ThucDonViewModel>();
            if (MaLoai == "0")
            {
                dsThucdon = GetAllData();
            }
            else
            {
                dsThucdon = GetAllData().Where(self => self.MaLoai.ToString().Equals(MaLoai));
            }
            
            return dsThucdon;
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
                               KhuyenMai = td.KhuyenMai,
                               MoTa = td.MoTa

                           }).FirstOrDefault();
            return thucdon;
        }
        public IEnumerable<ThucDonViewModel> GetDataByPage(int page) {
            var limit = 5;
            var offset = (page - 1) * limit;
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
                                 KhuyenMai = td.KhuyenMai,
                                 MoTa = td.MoTa
                             })
                             .Skip(offset)
                             .Take(limit);

            return dsThucDon;
        }
        public IEnumerable<ThucDonViewModel> GetDataWithCateByPage(string MaLoai, int page)
        {
            var limit = 5;
            var offset = (page - 1) * limit;
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
                                 KhuyenMai = td.KhuyenMai,
                                 MoTa = td.MoTa
                             });
                             
            if(MaLoai != "0")
            {
                dsThucDon = dsThucDon.Where(self => self.MaLoai.ToString().Equals(MaLoai)).Skip(offset).Take(limit);
            }
            else
            {
                dsThucDon = dsThucDon.Skip(offset).Take(limit);
            }
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
