using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NotificationServices.Dto;
using NotificationServices.NotiConfHub;

namespace NotificationServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotifyController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NotificationModel model)
        {
            model.Timestamp = DateTime.UtcNow;
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", model);
            return Ok("Send Succesfuly...");
        }
    }
}
