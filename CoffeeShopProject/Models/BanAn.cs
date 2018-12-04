using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class BanAn
    {
        public BanAn()
        {
            HoaDon = new HashSet<HoaDon>();
            PhanCong = new HashSet<PhanCong>();
        }

        public int MaBan { get; set; }
        public int? SoGhe { get; set; }

        public ICollection<HoaDon> HoaDon { get; set; }
        public ICollection<PhanCong> PhanCong { get; set; }
    }
}
