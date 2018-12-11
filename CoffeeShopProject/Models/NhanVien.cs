using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public int MaNhanVien { get; set; }
        public string Cmnd { get; set; }
        public string HinhAnh { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public double? Luong { get; set; }
        public string MoTa { get; set; }
        public int? MaChucVu { get; set; }
        public int? MaTaiKhoan { get; set; }

        public ChucVu MaChucVuNavigation { get; set; }
        public TaiKhoan MaTaiKhoanNavigation { get; set; }
        public ICollection<HoaDon> HoaDon { get; set; }
    }
}
