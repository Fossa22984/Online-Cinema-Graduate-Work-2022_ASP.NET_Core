﻿using System.Threading.Tasks;

namespace Online_Cinema_BLL.Interfaces.SignalR
{
    public interface IChatHub
    {
        Task SendMessage(string user, string message, string room, bool join);
        Task JoinRoom(string roomName);
        Task LeaveRoom(string roomName);
        Task SendSession(int sessionId, string room);
    }
}
