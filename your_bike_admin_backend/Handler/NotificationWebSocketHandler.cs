
using Microsoft.AspNetCore.SignalR;
using System.Net.WebSockets;
using System.Text;

namespace your_bike_admin_backend.Handler
{
    public class NotificationWebSocketHandler : Hub
    {
        private readonly List<WebSocket> _connectedSockets = new();

        public async Task HandleAsync(WebSocket socket)
        {
            _connectedSockets.Add(socket);

            var buffer = new byte[1024 * 4];
            try
            {
                while (socket.State == WebSocketState.Open)
                {
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        Console.WriteLine($"Received: {message}");

                        // Send acknowledgment or broadcast message
                        await BroadcastMessageAsync($"New Notification: {message}");
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("WebSocket connection closed.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling WebSocket: {ex.Message}");
            }
            finally
            {
                _connectedSockets.Remove(socket);
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by server", CancellationToken.None);
            }
        }

        public async Task BroadcastMessageAsync(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            foreach (var socket in _connectedSockets)
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
