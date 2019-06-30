using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Models.ChatBox
{
    public class PhongChatViewModel : NgThamGia
    {
        public string Avatar { get; set; }
        public string RealName { get; set; }
        public string LastMessage { get; set; }
        public string Time { get; set; }
        public int Status { get; set; }
        public int OwnLastMessage { get; set; }
        public int QuantityNewMessages { get; set; }
        public int IsActive { get; set; }
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
            var listRoomChat = (from pc in db.NgThamGia select pc).Where(x => x.MaTaiKhoan == user_id).Select(x => x.MaPhongChat);
            var listConversations = new List<PhongChatViewModel>();
            foreach (var roomChat in listRoomChat)
            {
                var participant = db.NgThamGia.Where(x => x.MaTaiKhoan != user_id)
                    .SingleOrDefault(x => x.MaPhongChat == roomChat);//get all participants of this room chat except me
                var conversation = new PhongChatViewModel();
                var informarion = GetInfoOf(participant.MaTaiKhoan);//get information of these participants
                var lastMessage = db.TinNhan.Where(x => x.MaPhongChat == participant.MaPhongChat)
                    .OrderByDescending(x => x.MaTinNhan)
                    .FirstOrDefault();

                conversation.MaPhongChat = roomChat;
                conversation.RealName = informarion.RealName;
                conversation.Avatar = informarion.Avatar;
                if (lastMessage != null)
                {
                    conversation.LastMessage = lastMessage.TinNhan1;
                    conversation.Time = lastMessage.NgayTao.Value.ToString("o");
                    conversation.Status = lastMessage.TrangThai.Value;
                    conversation.OwnLastMessage = lastMessage.MaTaiKhoan.Value;
                    conversation.QuantityNewMessages = GetQuantityNewMessages(roomChat, user_id);
                }
                else
                {
                    conversation.LastMessage = "Group chat has been created";
                    conversation.Time = DateTime.Now.ToString("o");
                    conversation.Status = 0;
                    conversation.OwnLastMessage = -1;
                    conversation.QuantityNewMessages = 1;
                }

                conversation.IsActive = (informarion.IsActive == 0) ? 0 : 1;

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
                RealName = (employeeInfo != null) ? employeeInfo.HoTen : accountInfo.TenTaiKhoan,
                Avatar = accountInfo.AnhDaiDien,
                IsActive = accountInfo.DangHoatDong
            };
            return res;
        }

        public List<TinNhan> GetMessageByRoomId(int room_id)
        {
            var messages = db.TinNhan.Where(x => x.MaPhongChat == room_id).ToList();
            return messages;
        }

        public int GetQuantityNewMessages(int room_id, int user_id)
        {
            var listMessageOfRoom = db.TinNhan.Where(x => x.MaPhongChat == room_id).OrderByDescending(x => x.NgayTao);
            var count = 0;
            foreach (var mess in listMessageOfRoom)
            {
                if (mess.MaTaiKhoan != user_id)
                {
                    if (mess.TrangThai == 1)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    break;
                }

            }
            return count;
        }
    }
}
