using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }

        public ICollection<NhanVien> NhanVien { get; set; }
    }
}
