using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public ICollection<NhanVien> NhanVien { get; set; }
    }
}
