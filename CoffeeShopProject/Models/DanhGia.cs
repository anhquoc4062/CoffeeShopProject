using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class DanhGia
    {
        public int MaDanhGia { get; set; }
        public int? MaTaiKhoan { get; set; }
        public int? MaThucDon { get; set; }
        public string LoiNhanXet { get; set; }
        public DateTime? NgayDanhGia { get; set; }
    }
}
