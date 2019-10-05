namespace CoffeeShopProject.Models
{
    public class OrderPostData : HoaDon
    {
        public ChiTietHoaDon[] DsMon { get; set; }
        public string TokenThietBi { get; set; }
        public string TenBan { get; set; }
    }
}