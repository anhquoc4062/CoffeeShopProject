using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class ChiTietGioHang
    {
        public int MaCtgioHang { get; set; }
        public int? MaGioHang { get; set; }
        public int? MaThucDon { get; set; }
        public int? SoLuong { get; set; }

        public GioHang MaGioHangNavigation { get; set; }
        public ThucDon MaThucDonNavigation { get; set; }
    }
}
