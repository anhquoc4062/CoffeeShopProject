using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class ThucDon
    {

        public int MaThucDon { get; set; }
        public string TenThucDon { get; set; }
        public string HinhAnh { get; set; }
        public int? MaLoai { get; set; }
        public double? Gia { get; set; }
        public int? KhuyenMai { get; set; }
        public string MoTa { get; set; }
        public double? GiaKhuyenMai => (Gia - Gia * KhuyenMai / 100);
    }
}
