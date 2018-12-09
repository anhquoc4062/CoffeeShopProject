﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class BanAnViewModel:BanAn
    {
        private readonly CoffeeShopContext db;
        public BanAnViewModel() { }
        public BanAnViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }

        public List<BanAnViewModel> GetDsBanAn()
        {
            var ds = (from td in db.BanAn
                      select new BanAnViewModel
                      {
                          MaBan=td.MaBan,
                          SoGhe=td.SoGhe,

                      }).ToList();
            return ds;
        }

        public bool DeleteBanAnById(String id)
        {
            if (db.BanAn.Find(int.Parse(id)) != null)
            {
                db.BanAn.Remove(db.BanAn.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new BanAnViewModel(db).GetDsBanAn();
        }
        public BanAn GetBanAnById(String id)
        {
            return db.BanAn.Find(int.Parse(id));
        }
        public bool InsertBanAn(BanAn nv)
        {
            if (nv != null)
            {
                db.BanAn.Add(nv);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new BanAnViewModel(db).GetDsBanAn();
        }
        public bool EditBanAn(BanAn BanAn)
        {
            //Edit bằng id nghe
            BanAn nv = db.BanAn.Find(BanAn.MaBan);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(BanAn);
                db.SaveChanges();
                return true;
            }
            return false;
            //return new BanAnViewModel(db).GetDsBanAn();
        }
    }
}
