using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using your_bike_admin_backend.Handler;

namespace your_bike_admin_backend.Controllers
{
    [ApiController]
    [Route("ws")]
    public class WebSocketController : ControllerBase
    {
        private readonly IHubContext<NotificationWebSocketHandler> _hubContext;
        public WebSocketController(IHubContext<NotificationWebSocketHandler> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok(new { Status = "Notification Sent" });
        }
    }
}
