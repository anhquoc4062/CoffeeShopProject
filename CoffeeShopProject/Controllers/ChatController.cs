using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Models;
using CoffeeShopProject.Models.ChatBox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProject.Controllers
{
    public class ChatController : BaseController
    {
        private readonly CoffeeShopContext db;
        public ChatController(CoffeeShopContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            PhongChatViewModel query = new PhongChatViewModel(db);
            ViewBag.ListConversations = query.GetAllConversationsOf(int.Parse(HttpContext.Session.GetString("ACCID_SESSION"))).OrderByDescending(x => x.Time);
            return View();
        }
        public IActionResult GetAllRoomsList()
        {
            PhongChatViewModel query = new PhongChatViewModel(db);
            var response = query.GetAllConversationsOf(int.Parse(HttpContext.Session.GetString("ACCID_SESSION"))).OrderByDescending(x => x.Time);
            return Json(response);
        }
        public IActionResult GetParticipantByRoomId(int room_id)
        {
            PhongChatViewModel query = new PhongChatViewModel(db);
            var response = query.GetParticipantByRoomId(int.Parse(HttpContext.Session.GetString("ACCID_SESSION")), room_id);
            return Json(response);
        }
        public IActionResult GetAllMessageByRoomId(int room_id)
        {
            PhongChatViewModel query = new PhongChatViewModel(db);
            var response = query.GetMessageByRoomId(room_id);
            return Json(response);
        }
        public IActionResult AddMessageToDatabase(int room_id, string message)
        {
            TinNhan newMess = new TinNhan
            {
                MaPhongChat = room_id,
                MaTaiKhoan = int.Parse(HttpContext.Session.GetString("ACCID_SESSION")),
                TinNhan1 = message,
                NgayTao = DateTime.Now,
                TrangThai = 0
            };
            db.TinNhan.Add(newMess);
            db.SaveChanges();
            var respone = newMess;
            return Json(respone);
        }

        public IActionResult SetUserActive(int userId, int yes)
        {
            var queryAcc = new TaiKhoanViewModel(db);
            var thisAcc = db.TaiKhoan.SingleOrDefault(x => x.MaTaiKhoan == userId);
            thisAcc.DangHoatDong = (yes == 1) ? 1 : 0;

            queryAcc.EditTaiKhoan(thisAcc);
            var response = thisAcc;
            return Json(response);
        }

        /*public IActionResult AddConversation(List<int>userId)
        {
            return Json(response);
        }*/

    }
}