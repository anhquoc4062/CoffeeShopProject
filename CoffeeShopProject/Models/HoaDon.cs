using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime? ThoiGianLap { get; set; }
        public int? MaNhanVien { get; set; }
        public int? MaBan { get; set; }
        public double? TongTien { get; set; }
        public string MaHoaDonLocal { get; set; }
        public string TrangThai { get; set; }
    }
}
