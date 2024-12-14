using CommonLib;
using CommonLib.Constants;
using Object.Core;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MWShare.Authen
{
    public sealed class MWAuthClient : IMWAuthClient, IDisposable
    {
        private readonly HttpClient? _httpClient;

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly ConcurrentDictionary<string, ProcessTimeInfo> _dicProcessTime = new();
        private readonly PeriodicTimer _writeLogProcessTimeTimer = new(TimeSpan.FromSeconds(30));

        public MWAuthClient(string serverHost)
        {
            Logger.log.Info($"[MWAuthClient] Khoi tao serverHost=[{serverHost}]");

            if (!string.IsNullOrWhiteSpace(serverHost))
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(serverHost),
                    DefaultRequestVersion = HttpVersion.Version20,
                    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
                };
            }

            //
            WriteLogProcessTimeThread(_cancellationTokenSource.Token);
        }

        #region Dispose

        private bool _disposed;

        ~MWAuthClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _httpClient?.Dispose();
                        _cancellationTokenSource.Cancel();
                        _writeLogProcessTimeTimer.Dispose();
                    }
                    finally
                    {

                    }
                }
            }
            _disposed = true;
        }

        #endregion

        #region Timer write log Process time, TPS


        private async Task WriteLogProcessTimeThread(CancellationToken cancellationToken)
        {
            while (await _writeLogProcessTimeTimer.WaitForNextTickAsync(cancellationToken))
            {
                var processTimeInfos = _dicProcessTime.Values;
                _dicProcessTime.Clear();

                //
                if (processTimeInfos != null && processTimeInfos.Count > 0)
                {
                    string guid = Utils.GenGuidStringN();
                    foreach (var item in processTimeInfos)
                    {
                        Logger.log.Info($"[{guid}] [Log TPS MWAuthClient] methodName=[{item.MethodName}] numberRequest=[{item.NumberRequest}] maxProcessTime=[{item.MaxProcessTime}(ms)] minProcessTime=[{item.MinProcessTime}(ms)] avgProcessTime=[{Math.Round(item.TotalProcessTime / item.NumberRequest, 2)}(ms)]");
                    }
                }
            }
        }

        private void RecordProcessTime(string methodName, double processTime)
        {
            if (!_dicProcessTime.ContainsKey(methodName))
            {
                _dicProcessTime.TryAdd(methodName, new ProcessTimeInfo
                {
                    MethodName = methodName,
                    MaxProcessTime = processTime,
                    MinProcessTime = processTime,
                    NumberRequest = 1,
                    TotalProcessTime = processTime,
                });
            }
            else
            {
                _dicProcessTime.TryGetValue(methodName, out var processTimeInfo);
                if (processTimeInfo != null)
                {
                    if (processTime > processTimeInfo.MaxProcessTime)
                    {
                        processTimeInfo.MaxProcessTime = processTime;
                    }

                    if (processTime < processTimeInfo.MinProcessTime)
                    {
                        processTimeInfo.MinProcessTime = processTime;
                    }

                    processTimeInfo.NumberRequest++;
                    processTimeInfo.TotalProcessTime += processTime;
                }
            }
        }
        private class ProcessTimeInfo
        {
            public string MethodName { get; set; } = string.Empty;
            public double MaxProcessTime { get; set; }
            public double MinProcessTime { get; set; }
            public double NumberRequest { get; set; }
            public double TotalProcessTime { get; set; }
        }

        #endregion

        //
        public async Task<bool> ValidateFunction(string userId, string functionId, string action, string checkMode = "")
        {
            var requestId = Utils.GenGuidStringN();
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateFunction] dia chi [{_httpClient?.BaseAddress}] tham so userId=[{userId}] userPid=[{functionId}] action=[{action}]");

            var verifyResult = false;

            if (_httpClient == null)
            {
                verifyResult = false;
                goto endFunc;
            }

            var postContent = JsonContent.Create(new
            {
                userId,
                functionId,
                action,
                checkMode,
            },
            MediaTypeHeaderValue.Parse("application/json"),
            new JsonSerializerOptions()
            {
                WriteIndented = false,
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = null,
            });

            var response = await _httpClient.PostAsync("/api/token/verify-function", postContent);

            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateFunction] responseCode=[{(int)response.StatusCode}-{response.StatusCode}]");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                verifyResult = true;
                goto endFunc;
            }

        //
        endFunc:

            var processTime = ConstLog.GetProcessingMilliseconds(requestTime);
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateFunction] thoi gian xu ly {processTime}(ms)");
            RecordProcessTime("MWAuthClient.ValidateFunction", processTime);

            return verifyResult;
        }

        public async Task<Tuple<HttpStatusCode, LoggedUser>> ValidateTokenAndFunction(string token, string functionId, string action, bool checkFunction, string checkMode = "")
        {
            var requestId = Utils.GenGuidStringN();
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndFunction] dia chi [{_httpClient?.BaseAddress}] tham so userPid=[{functionId}] action=[{action} checkFunction=[{checkFunction}]");

            if (_httpClient == null)
            {
                return default;
            }

            var postContent = JsonContent.Create(new
            {
                token,
                functionId,
                action,
                checkFunction,
                checkMode,
            },
            MediaTypeHeaderValue.Parse("application/json"),
            new JsonSerializerOptions()
            {
                WriteIndented = false,
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = null,
            });

            var response = await _httpClient.PostAsync("/api/token/verify-token-and-function", postContent);
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndFunction] responseCode=[{(int)response.StatusCode}-{response.StatusCode}]");

            //
            LoggedUser user = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentString = await response.Content.ReadAsStringAsync();

                user = JsonHelper.Deserialize<LoggedUser>(contentString);

                Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndFunction] Authenticated userId={user?.UserName}; name={user?.Name};");
            }


            var processTime = ConstLog.GetProcessingMilliseconds(requestTime);
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndFunction] thoi gian xu ly {processTime}(ms)");
            RecordProcessTime("MWAuthClient.ValidateTokenAndFunction", processTime);

            //
            return new Tuple<HttpStatusCode, LoggedUser>(response.StatusCode, user);
        }

        public async Task<Tuple<HttpStatusCode, LoggedUser>> ValidateTokenAndUrl(string token, string requestUrl, bool isCheckUrl = true)
        {
            var requestId = Utils.GenGuidStringN();
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndUrl] dia chi [{_httpClient?.BaseAddress}] tham so requestUrl=[{requestUrl}] isCheckUrl=[{isCheckUrl}]");

            if (_httpClient == null)
            {
                return default;
            }

            var postContent = JsonContent.Create(new
            {
                token,
                requestUrl = isCheckUrl ? requestUrl : string.Empty,
                isCheckUrl,
            },
            MediaTypeHeaderValue.Parse("application/json"),
            new JsonSerializerOptions()
            {
                WriteIndented = false,
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = null,
            });

            var response = await _httpClient.PostAsync("/api/token/verify", postContent);

            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndUrl] responseCode=[{(int)response.StatusCode}-{response.StatusCode}]");

            //
            LoggedUser user = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentString = await response.Content.ReadAsStringAsync();

                user = JsonHelper.Deserialize<LoggedUser>(contentString);

                Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndUrl] Authenticated userId={user?.UserName}; name={user?.Name};");
            }

            var processTime = ConstLog.GetProcessingMilliseconds(requestTime);
            Logger.log.Info($"[{requestId}] [MWAuthClient.ValidateTokenAndUrl] thoi gian xu ly {processTime}(ms)");
            RecordProcessTime("MWAuthClient.ValidateTokenAndUrl", processTime);


            //
            return new Tuple<HttpStatusCode, LoggedUser>(response.StatusCode, user);
        }
    }
}
