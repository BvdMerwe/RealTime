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
        public void Send(string name, string room, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.Group(room).addChatMessage(name, message);
        }
        public void GetUserCount(){
            Clients.Client(Context.ConnectionId).updateUserCount(HubHelper.GetCount());
        }
        public void UpdateUserCount(){
            Clients.All.updateUserCount(HubHelper.GetCount());
        }

        public async Task JoinRoom(string playerName ,string roomName)
        {
            Clients.Group(roomName).addChatMessage(playerName, " joined.");
            await Groups.Add(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string playerName, string roomName)
        {
            Clients.Group(roomName).addChatMessage(playerName, " left.");
            return Groups.Remove(Context.ConnectionId, roomName);
        }

        public void GetUserDetails(string roomName) {
            //check DB and get users from there
                        
        }
    }
}