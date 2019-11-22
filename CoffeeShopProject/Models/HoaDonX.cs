using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class HoaDonX
    {
        public int MaHoaDon { get; set; }
        public string ThoiGianLap { get; set; }
        public int? MaNhanVienOrder { get; set; }
        public int? MaBan { get; set; }
        public double? TongTien { get; set; }
        public string MaHoaDonLocal { get; set; }
        public int? TrangThai { get; set; }
        public int? GiamGia { get; set; }
        public double? ThanhTien { get; set; }
        public int? MaThuNgan { get; set; }
    }
}
