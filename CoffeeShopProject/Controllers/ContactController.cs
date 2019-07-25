using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    [Route("lien-he")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}