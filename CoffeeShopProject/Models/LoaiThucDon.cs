using System;
using System.Collections.Generic;

namespace CoffeeShopProject.Models
{
    public partial class LoaiThucDon
    {
        public LoaiThucDon()
        {
            ThucDon = new HashSet<ThucDon>();
        }

        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public int? MaLoaiCha { get; set; }

        public ICollection<ThucDon> ThucDon { get; set; }
    }
}
