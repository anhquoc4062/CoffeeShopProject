using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class TangViewModel : Tang
    {
        private readonly CoffeeShopContext db;
        public TangViewModel() { }
        public TangViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<TangViewModel> GetDsTang()
        {
            var ds = (from t in db.Tang
                      select new TangViewModel
                      {
                          MaTang = t.MaTang,
                          TenTang = t.TenTang

                      }).ToList();
            return ds;
        }
    }
}
