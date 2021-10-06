﻿using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Online_Cinema_BLL.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Cinema_UI.Middlewares
{
    public class Chat : Hub
    {
        private readonly AdminService _adminService;
        public Chat(AdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task SendMessage(string user, string message, string room, bool join)
        {
            if (join)
            {
                await JoinRoom(room).ConfigureAwait(false);
                //await Clients.Group(room).SendAsync("Send", user, " joined to " + room).ConfigureAwait(true);

            }
            else
            {
                await Clients.Group(room).SendAsync("Send", user, message).ConfigureAwait(true);
            }
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task VideoTest(string message, string room)
        {
            await Clients.Group(room).SendAsync("SendVideo", message).ConfigureAwait(true);

        }

        public async Task GetSession(string room)
        {
            var res = await _adminService.GetSessionAsync(Convert.ToInt32(room));
            if (res != null) await Clients.Group(room).SendAsync("GetSession", res.Id).ConfigureAwait(true);
        }
    }
}
