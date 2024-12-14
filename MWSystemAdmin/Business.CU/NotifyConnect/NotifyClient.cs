using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Core
{
    public sealed class NotifyClient : INotifyClient
    {
        private readonly string _serverHost = "";

        public NotifyClient(string serverHost)
        {
            _serverHost = serverHost;
        }

        //
        public async Task<bool> Send(NotifyMessage message)
        {
            try
            {
                if (string.IsNullOrEmpty(_serverHost))
                    return false;

                var client = new HttpClient();
                var postContent = JsonContent.Create(message, MediaTypeHeaderValue.Parse("application/json"), new JsonSerializerOptions()
                {
                    WriteIndented = false,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

                var response = await client.PostAsync($"{_serverHost}/api/notify/send", postContent);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
