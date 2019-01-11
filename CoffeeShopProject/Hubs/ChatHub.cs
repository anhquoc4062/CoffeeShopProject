using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopProject.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(int user_id, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user_id, message);
        }
        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage");
        }
        public override async Task OnConnectedAsync()
        {
            //var user_id = Common.CommonConstant.ACCID_SESSION;
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("UserDisConnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
        public Task JoinGroup(string group_id)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group_id);
        }
        public Task SendMessageInGroup(string group_id, int user_id, string message)
        {
            return Clients.Group(group_id).SendAsync("ReceiveMessage", user_id, message);
        }
        public async Task IsTyping(string user)
        {
            await Clients.All.SendAsync("IsTyping", user);
        }
    }
}
