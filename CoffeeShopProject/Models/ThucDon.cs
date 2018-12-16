using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class ThucDon
    {
        public ThucDon()
        {
            ChiTietGioHang = new HashSet<ChiTietGioHang>();
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public int MaThucDon { get; set; }
        public string TenThucDon { get; set; }
        public string HinhAnh { get; set; }
        public int? MaLoai { get; set; }
        public double? Gia { get; set; }
        public int? KhuyenMai { get; set; }
        public string MoTa { get; set; }
        public double? GiaKhuyenMai => Gia * (100 - KhuyenMai) / 100;
        public LoaiThucDon MaLoaiNavigation { get; set; }
        public ICollection<ChiTietGioHang> ChiTietGioHang { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
