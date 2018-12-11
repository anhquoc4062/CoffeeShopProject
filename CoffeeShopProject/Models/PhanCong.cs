using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class PhanCong
    {
        public int MaPhanCong { get; set; }
        public int? MaNhanVien { get; set; }
        public int? MaBan { get; set; }
        public int? Ca { get; set; }
        public DateTime? NgayPhanCong { get; set; }

        public BanAn MaBanNavigation { get; set; }
    }
}
