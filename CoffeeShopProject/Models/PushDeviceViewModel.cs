using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class PushDeviceViewModel : PushDevice
    {
        private readonly CoffeeShopContext db;
        public PushDeviceViewModel() { }
        public PushDeviceViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }
        public bool Insert(string token)
        {
            PushDevice dv = db.PushDevice.Where(x => x.Token.Equals(token)).FirstOrDefault();
            if (dv == null)
            {
                PushDevice newDv = new PushDevice
                {
                    Token = token
                };
                db.PushDevice.Add(newDv);
                db.SaveChanges();
            }
            return true;
        }

        public string[] GetAllTokenExcept(string exceptToken)
        {
            string[] arrToken = db.PushDevice.Where(x => x.Token != exceptToken).Select(x => x.Token).ToArray();
            return arrToken;
        }
    }
}
