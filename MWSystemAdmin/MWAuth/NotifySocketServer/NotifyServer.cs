using CommonLib;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace MWAuth.NotifySocketServer
{
    public sealed class NotifyServer : INotifyServer
    {
        private readonly UTF8Encoding _encoding = new();
        private readonly ConcurrentDictionary<string, WebSocket> _clients = new();
        //private readonly ConcurrentQueue<NotifyMessage> _queueMessageRecvs = new();
        private readonly ConcurrentDictionary<string, string> _userIdByIdentify = new();
        private byte[] buffer = new byte[1024 * 4]; // 4kb

        //
        public int SendTokenTimeOutInMiliseconds => 2000; //ConfigData.NotifyTimeoutMs;

        //
        public async Task<string> AddClientAsync(WebSocket webSocket)
        {
            string identify = Guid.NewGuid().ToString();
            bool isSuccess = _clients.TryAdd(identify, webSocket);
            Logger.log.Info($"AddingClientAsync {identify}");
            if (isSuccess)
                return await Task.FromResult(identify);

            return string.Empty;
        }
        public async Task RemoveClientAsync(string identify)
        {
            _ = _clients.TryRemove(identify, out var removedWebSocket);
            _ = _userIdByIdentify.TryRemove(identify, out var removedUserId);
            if (removedWebSocket != null && removedWebSocket.State == WebSocketState.Open)
            {
                await removedWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", CancellationToken.None);
            }
        }
        public async Task ReceiveMessageAsync(WebSocket webSocket, string identify)
        {
            try
            {
                while (webSocket.State.HasFlag(WebSocketState.Open))
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (!result.CloseStatus.HasValue)
                    {
                        OnReceiveMessage(identify, _encoding.GetString(buffer, 0, result.Count));
                    }
                    else
                    {
                        break;
                    }
                }

                //
                if (webSocket.State != WebSocketState.Closed && webSocket.State != WebSocketState.Aborted)
                {
                    try
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Socket closed", CancellationToken.None);
                    }
                    catch
                    {
                        // this may throw on shutdown and can be ignored
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, ex.Message);
            }
            finally
            {
                _clients.TryRemove(identify, out _);
            }
        }

        //
        public async Task SendMessageBroacastAsync(NotifyMessage message, CancellationToken cancellationToken)
        {
            await SendMessageBroacastAsync(SerializeMessage(message), cancellationToken);
        }
        public async Task SendMessageBroacastAsync(string message, CancellationToken cancellationToken)
        {
            DateTime startTime = DateTime.Now;
            if (_clients.IsEmpty == false)
            {
                Logger.log.Info($"Number of logged-in clients: {_clients.Count}");

                // Create and start all send tasks at once
                var sendTasks = _clients.Keys.Select(id => SendMessageByIdentifyAsync(id, message, cancellationToken)).ToList();

                try
                {
                    await Task.WhenAll(sendTasks);
                }
                catch (Exception ex)
                {
                    Logger.log.Error("Error occurred while broadcasting message", ex);
                }

                Logger.log.Info($"[SendMessageBroacastAsync] Ket thuc. Tong thoi gian {Logger.GetProcessingMilliseconds(startTime)}(ms)");
            }
        }

        public async Task SendMessageByIdentifyAsync(string identify, NotifyMessage message, CancellationToken cancellationToken)
        {
            await SendMessageByIdentifyAsync(identify, SerializeMessage(message), cancellationToken);
        }
        public async Task SendMessageByIdentifyAsync(string identify, string message, CancellationToken cancellationToken)
        {
            _ = _clients.TryGetValue(identify, out var socket);
            if (socket != null && socket.State == WebSocketState.Open)
            {
                await SendMessageAsync(socket, message, cancellationToken);
            }
            else
            {
                await RemoveClientAsync(identify);
            }
        }

        // Private funcs
        private static string SerializeMessage(NotifyMessage message)
        {
            return JsonHelper.Serialize(message);
        }
        private void OnReceiveMessage(string identify, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message)) return;

                var reqMessage = JsonHelper.Deserialize<NotifyMessage>(message);
                if (reqMessage != null)
                {
                    //reqMessage.Identify = identify;
                    //_queueMessageRecvs.Enqueue(reqMessage);

                    if (string.Equals(reqMessage.Type, "USER_REGISTER"))
                    {
                        _userIdByIdentify.AddOrUpdate(identify, reqMessage.Content, (key, oldValue) => reqMessage.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, ex.Message);
            }
        }
        private async Task SendMessageAsync(WebSocket webSocket, string message, CancellationToken cancellationToken)
        {
            try
            {
                await webSocket.SendAsync(
                    new ArraySegment<byte>(_encoding.GetBytes(message)),
                    WebSocketMessageType.Text,
                    true,
                    cancellationToken
                );
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, ex.Message);
            }
        }
    }
}
