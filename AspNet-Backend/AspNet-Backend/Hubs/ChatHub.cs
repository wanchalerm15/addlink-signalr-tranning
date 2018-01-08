using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AspNet_Backend.Hubs
{
    public class ChatHub : Hub
    {
        private static List<string> UsersLogin = new List<string>();

        public void onMessage(string client, string message)
        {
            switch (client)
            {
                case "all":
                    Clients.All.onMessage(Context.ConnectionId, message);
                    break;
                default:
                    Clients.Client(client).onMessage(Context.ConnectionId, message);
                    Clients.Caller.onMessage(Context.ConnectionId, message);
                    break;
            }
        }

        public override Task OnConnected()
        {
            UsersLogin.Add(Context.ConnectionId);
            Clients.All.Login(UsersLogin);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UsersLogin.Remove(Context.ConnectionId);
            Clients.All.Login(UsersLogin);
            return base.OnDisconnected(stopCalled);
        }
    }
}