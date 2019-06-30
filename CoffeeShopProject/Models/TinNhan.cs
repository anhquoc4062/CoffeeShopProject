using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class TinNhan
    {
        public int MaTinNhan { get; set; }
        public int? MaPhongChat { get; set; }
        public int? MaTaiKhoan { get; set; }
        public string TinNhan1 { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? TrangThai { get; set; }
    }
}
