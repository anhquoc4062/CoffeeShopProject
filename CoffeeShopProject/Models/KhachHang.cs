using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            GioHang = new HashSet<GioHang>();
        }

        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SoDt { get; set; }
        public int? MaTaiKhoan { get; set; }
        public int? MaTinhThanh { get; set; }

        public TaiKhoan MaTaiKhoanNavigation { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
    }
}
