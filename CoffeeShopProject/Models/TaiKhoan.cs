using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            KhachHang = new HashSet<KhachHang>();
            NhanVien = new HashSet<NhanVien>();
        }

        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaPhanQuyen { get; set; }

        public PhanQuyen MaPhanQuyenNavigation { get; set; }
        public ICollection<KhachHang> KhachHang { get; set; }
        public ICollection<NhanVien> NhanVien { get; set; }
    }
}
