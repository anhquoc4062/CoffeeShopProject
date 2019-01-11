﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models.ChatBox
{
    public class PhongChatViewModel:NgThamGia
    {
        public string Avatar { get; set; }
        public string RealName { get; set; }
        public string LastMessage { get; set; }
        public string Time { get; set; }
        public int Status { get; set; }
        private readonly CoffeeShopContext db;
        public PhongChatViewModel() { }
        public PhongChatViewModel(CoffeeShopContext _db)
        {
            db = _db;
        }
        //public List<TinNhan> GetAllMessagesOfRoom(int room_id) {
        //    var list = (from msg in db.TinNhan select msg).Where(x => x.MaPhongChat == room_id).ToList();
        //    return list;
        //}
        public List<PhongChatViewModel> GetAllConversationsOf(int user_id)
        {
            var listRoomChat = (from pc in db.NgThamGia select pc).Where(x => x.MaTaiKhoan == user_id).Select(x=>x.MaPhongChat);
            var listConversations = new List<PhongChatViewModel>();
            foreach(var roomChat in listRoomChat)
            {
                var participant = db.NgThamGia.Where(x=> x.MaTaiKhoan != user_id).SingleOrDefault(x => x.MaPhongChat == roomChat);
                var conversation = new PhongChatViewModel();
                var informarion = GetInfoOf(participant.MaTaiKhoan);
                var lastMessage = db.TinNhan.Where(x => x.MaPhongChat == participant.MaPhongChat).OrderByDescending(x => x.MaTinNhan).FirstOrDefault();

                conversation.MaPhongChat = roomChat;
                conversation.RealName = informarion.RealName;
                conversation.Avatar = informarion.Avatar;
                conversation.LastMessage = lastMessage.TinNhan1;
                conversation.Time = lastMessage.NgayTao.Value.ToString("o");
                conversation.Status = lastMessage.TrangThai.Value;
                listConversations.Add(conversation);
            }
            return listConversations;
        } 
        public PhongChatViewModel GetParticipantByRoomId(int user_id, int room_id)
        {
            var participant = GetAllConversationsOf(user_id).SingleOrDefault(x => x.MaPhongChat == room_id);
            return participant;
        }
        public PhongChatViewModel GetInfoOf(int user_id)
        {
            var accountInfo = db.TaiKhoan.SingleOrDefault(x => x.MaTaiKhoan == user_id);
            var employeeInfo = db.NhanVien.SingleOrDefault(x => x.MaTaiKhoan == user_id);
            var res = new PhongChatViewModel
            {
                RealName = (employeeInfo!=null)?employeeInfo.HoTen: accountInfo.TenTaiKhoan,
                Avatar = accountInfo.AnhDaiDien
            };
            return res;
        }

        public List<TinNhan> GetMessageByRoomId(int room_id)
        {
            var messages = db.TinNhan.Where(x => x.MaPhongChat == room_id).ToList();
            return messages;
        }
    }
}
