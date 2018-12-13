using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class CartItem
    {
        public int MaThucDon { get; set; }
        public string TenThucDon { get; set; }
        public string HinhAnh { get; set; }
        public double? GiaBan { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
    }
}
