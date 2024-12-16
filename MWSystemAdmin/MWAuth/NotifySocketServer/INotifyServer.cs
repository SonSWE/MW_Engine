using System.Net.WebSockets;

namespace MWAuth.NotifySocketServer
{
    public interface INotifyServer
    {
        int SendTokenTimeOutInMiliseconds { get; }

        Task<string> AddClientAsync(WebSocket webSocket);
        Task RemoveClientAsync(string identify);
        Task ReceiveMessageAsync(WebSocket webSocket, string identify);

        //
        Task SendMessageBroacastAsync(NotifyMessage message, CancellationToken cancellationToken);
        Task SendMessageBroacastAsync(string message, CancellationToken cancellationToken);

        Task SendMessageByIdentifyAsync(string identify, NotifyMessage message, CancellationToken cancellationToken);
        Task SendMessageByIdentifyAsync(string identify, string message, CancellationToken cancellationToken);
    }
}
