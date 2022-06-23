using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Sween.Infrastructure.Hubs
{
    public class ChatHubs : Hub ,IDisposable
    {

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessage(string name, string message,string groupName)
        {
            await Clients.Group(groupName).SendAsync("Receive", name, message);
        }

       
    }


}
