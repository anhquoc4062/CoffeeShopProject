using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class DanhGiaViewModel : DanhGia
    {
        public string AnhDaiDien { get; set; }
        public string TenTaiKhoan { get; set; }
        public string HinhAnh { get; set; }
        public string TenThucDon { get; set; }
        private readonly CoffeeShopContext db;
        public DanhGiaViewModel() { }
        public DanhGiaViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }
        public List<DanhGiaViewModel> GetDsDanhGia()
        {
            var ds = (from dg in db.DanhGia
                      join tk in db.TaiKhoan
                         on dg.MaTaiKhoan equals tk.MaTaiKhoan
                      select new DanhGiaViewModel
                      {
                          MaDanhGia = dg.MaDanhGia,
                          MaThucDon = dg.MaThucDon,
                          MaTaiKhoan = dg.MaTaiKhoan,
                          LoiNhanXet = dg.LoiNhanXet,
                          AnhDaiDien = tk.AnhDaiDien,
                          TenTaiKhoan = tk.TenTaiKhoan,
                          NgayDanhGia = dg.NgayDanhGia
                      }).ToList();
            foreach(var item in ds)
            {
                var td = db.ThucDon.Where(x => x.MaThucDon == item.MaThucDon).SingleOrDefault();
                item.HinhAnh = td.HinhAnh;
                item.TenThucDon = td.TenThucDon;
            }
            return ds;
        }
        public List<DanhGiaViewModel> GetDanhGiaByProduct(string product_id)
        {
            var ds = GetDsDanhGia().Where(x => x.MaThucDon == int.Parse(product_id)).ToList();
            return ds;
        }
        public DanhGiaViewModel GetDanhGiaById(string id)
        {
            var ds = GetDsDanhGia().Where(x => x.MaDanhGia == int.Parse(id)).SingleOrDefault();
            return ds;
        }
        public IEnumerable<DanhGiaViewModel> GetDanhGiaByAccount(string acc_id)
        {
            var ds = GetDsDanhGia().Where(x => x.MaTaiKhoan == int.Parse(acc_id));
            return ds;
        }
    }
}
