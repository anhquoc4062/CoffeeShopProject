using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class PhanQuyen
    {
        public PhanQuyen()
        {
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        public string MaPhanQuyen { get; set; }
        public string QuyenHan { get; set; }

        public ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
