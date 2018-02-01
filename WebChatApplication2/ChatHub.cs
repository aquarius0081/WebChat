using Microsoft.AspNetCore.SignalR;
using WebChatApplication2.ViewModels;

namespace WebChatApplication2
{
    /// <summary>
    /// Chat hub used for real time web chat through SignalR.
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// Sends <see cref="MessageDto"/> to all connected clients asynchronously.
        /// </summary>
        /// <param name="message"></param>
        public void SendToAll(MessageDto message)
        {
            Clients.All.InvokeAsync("sendToAll", message);
        }
    }
}
