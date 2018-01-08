using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Backend.Hubs
{
    public class SignalRHub : Hub
    {
        public Task sayMessage(string message)
        {
            return Clients.All.InvokeAsync("sayMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            Clients.All.InvokeAsync("Login", $"{Context.ConnectionId} is log in.");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.InvokeAsync("Login", $"{Context.ConnectionId} is log out.");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
