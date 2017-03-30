using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTime.Helpers;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            HubHelper.AddConn(Context.ConnectionId);
            UpdateUserCount();
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            HubHelper.RemoveConn(Context.ConnectionId);
            UpdateUserCount();
            return base.OnDisconnected(stopCalled);
        }
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
        public void GetUserCount(){
            Clients.Client(Context.ConnectionId).updateUserCount(HubHelper.GetCount());
        }
        public void UpdateUserCount(){
            Clients.All.updateUserCount(HubHelper.GetCount());
        }
    }
}