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
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string ChucVu { get; set; }

        public ICollection<HoaDon> HoaDon { get; set; }
    }
}
