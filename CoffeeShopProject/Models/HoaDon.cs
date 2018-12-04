using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public int MaHoaDon { get; set; }
        public DateTime? ThoiGianLap { get; set; }
        public int? SoKhach { get; set; }
        public int? MaNhanVien { get; set; }
        public int? MaBan { get; set; }
        public double? TongTien { get; set; }

        public BanAn MaBanNavigation { get; set; }
        public NhanVien MaNhanVienNavigation { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
