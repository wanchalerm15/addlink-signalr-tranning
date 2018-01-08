using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Backend.Hubs
{
    public class ChatHub : Hub
    {
        private static List<string> UsersLogin = new List<string>();

        public void onMessage(string client, string message)
        {
            switch (client)
            {
                case "all":
                    Clients.All.InvokeAsync("onMessage", Context.ConnectionId, message);
                    break;
                default:
                    Clients.Client(client).InvokeAsync("onMessage", Context.ConnectionId, message);
                    Clients.Client(Context.ConnectionId).InvokeAsync("onMessage", Context.ConnectionId, message);
                    break;
            }
        }

        public override Task OnConnectedAsync()
        {
            UsersLogin.Add(Context.ConnectionId);
            Clients.All.InvokeAsync("Login", UsersLogin);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UsersLogin.Remove(Context.ConnectionId);
            Clients.All.InvokeAsync("Login", UsersLogin);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
