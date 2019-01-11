using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class GioHang
    {
        public GioHang()
        {
            ChiTietGioHang = new HashSet<ChiTietGioHang>();
        }

        public int MaGioHang { get; set; }
        public int? MaKhachHang { get; set; }
        public double? TongCong { get; set; }
        public DateTime? NgayDat { get; set; }
        public int? TrangThai { get; set; }
        public int? MaTaiKhoan { get; set; }
        public int? MaCoupon { get; set; }

        public KhachHang MaKhachHangNavigation { get; set; }
        public ICollection<ChiTietGioHang> ChiTietGioHang { get; set; }
    }
}
