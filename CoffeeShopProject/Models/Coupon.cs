using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class Coupon
    {
        public int MaCoupon { get; set; }
        public string MaNhap { get; set; }
        public int? GiaKhuyenMai { get; set; }
    }
}
