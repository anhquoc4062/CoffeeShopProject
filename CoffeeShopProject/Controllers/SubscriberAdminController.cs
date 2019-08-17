using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Common;
using CoffeeShopProject.Models;
using MailChimp.Net;
using MailChimp.Net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class SubscriberAdminController : BaseController
    {
        
        private string listId = "f2574fb0f2";
        private static string apiKey = "b9788ffb309507ffb251f59fc5606d5a-us3";
        private static readonly MailChimpManager Manager = new MailChimpManager(apiKey);

        public async Task<ActionResult> GetListMember()
        {
            var options = new CampaignRequest
            {
                ListId = "f2574fb0f2",
                Status = CampaignStatus.Sent,
                SortOrder = CampaignSortOrder.DESC,
                Limit = 10
            };
 
            try
            {
                var model = await Manager.Members.GetAllAsync("f2574fb0f2");
                return Json(model);
            }
            catch (MailChimpException mce)
            {
                return Json(mce.Message);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}