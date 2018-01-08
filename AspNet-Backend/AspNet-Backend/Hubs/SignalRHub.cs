using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AspNet_Backend.Hubs
{
    public class SignalRHub : Hub
    {
        public void sayMessage(string message)
        {
            Clients.All.sayMessage(message);
        }

        public override Task OnConnected()
        {
            Clients.All.Logon($"{Context.ConnectionId} log in");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.Logon($"{Context.ConnectionId} log out");
            return base.OnDisconnected(stopCalled);
        }
    }
}