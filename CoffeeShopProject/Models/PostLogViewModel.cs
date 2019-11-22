using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoffeeShopProject.Models
{
    public class PostLogViewModel : PostLog
    {
        private readonly CoffeeShopContext db;
        public PostLogViewModel() { }
        public PostLogViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IEnumerable<PostLogViewModel> GetAllData()
        {
            var list = (from pl in db.PostLog
                        orderby pl.RegDate descending
                        select new PostLogViewModel {
                            Id = pl.Id,
                            Api = pl.Api,
                            Params = pl.Params,
                            Response = pl.Response,
                            RegDate = pl.RegDate,
                            LocalId = pl.LocalId
                        });

            return list;
        }
        public IEnumerable<PostLogViewModel> GetDataByLocalId(string local_id)
        {
            var list = (from pl in db.PostLog
                        where pl.LocalId == local_id
                        orderby pl.RegDate descending
                        select new PostLogViewModel
                        {
                            Id = pl.Id,
                            Api = pl.Api,
                            Params = pl.Params,
                            Response = pl.Response,
                            RegDate = pl.RegDate,
                            LocalId = pl.LocalId
                        });

            return list;
        }
        public bool DeleteDataById(String id)
        {
            if (db.PostLog.Find(int.Parse(id)) != null)
            {
                db.PostLog.Remove(db.PostLog.Find(int.Parse(id)));
                db.SaveChanges();
                return true;
            }
            return false;
            //return new ThucDonViewModel(db).GetDsThucDon();
        }

        public bool InsertData(PostLog pl)
        {
            if (pl != null)
            {
                db.PostLog.Add(pl);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool EditData(PostLog pl)
        {
            //Edit bằng id nghe
            PostLog nv = db.PostLog.Find(pl.Id);
            if (nv != null)
            {
                db.Entry(nv).CurrentValues.SetValues(pl);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }

}
