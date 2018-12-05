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
                           //where td.MaLoai == int.Parse(id)
                           join ltd in db.LoaiThucDon
                           on td.MaLoai equals ltd.MaLoai
                           select new LoaiThucDonViewModel
                           {
                               MaLoai=td.MaLoai,
                               TenLoai = td.TenLoai,
                             
                           }).ToList();
            return loaithucdon;
        }

    }
}
