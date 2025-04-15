using Microsoft.AspNetCore.SignalR;

namespace NotificationServices.NotiConfHub
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string type, string message, object data = null)
        {
            await Clients.All.SendAsync("ReceiveNotification", new
            {
                type,
                message,
                timestamp = DateTime.UtcNow,
                data
            });
        }
    }

}
