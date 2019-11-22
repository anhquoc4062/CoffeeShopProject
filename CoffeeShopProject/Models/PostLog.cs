using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models
{
    public class PostLog
    {
        public int Id { get; set; }
        public string Api { get; set; }
        public string Params { get; set; }
        public string Response { get; set; }
        public string RegDate { get; set; }
        public string LocalId { get; set; }
    }
}
