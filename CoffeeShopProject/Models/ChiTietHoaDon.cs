using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class ChiTietHoaDon
    {
        public int MaChiTiet { get; set; }
        public int? MaHoaDon { get; set; }
        public int? MaThucDon { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }

        public HoaDon MaHoaDonNavigation { get; set; }
        public ThucDon MaThucDonNavigation { get; set; }
    }
}
