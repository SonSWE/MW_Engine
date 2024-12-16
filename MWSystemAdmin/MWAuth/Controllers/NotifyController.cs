using CommonLib;
using CommonLib.Constants;
using Microsoft.AspNetCore.Mvc;
using MWAuth.Extensions;
using MWAuth.NotifySocketServer;
using System.Reflection;

namespace MWAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly INotifyServer _notifyServer;

        public NotifyController(INotifyServer notifyServer)
        {
            _notifyServer = notifyServer;
        }

        //
        [HttpPost, Route("send")]
        public async Task<IActionResult> Send([FromBody] NotifyMessage message)
        {
            var requestId = Utils.GenGuidStringN();

            var requestTime = DateTime.Now;
            var browserInfo = Request.GetBrowserInfo();

            var responseCode = StatusCodes.Status200OK;
            object responseData = null;

            try
            {
                using var cts = new CancellationTokenSource(_notifyServer.SendTokenTimeOutInMiliseconds);
                await _notifyServer.SendMessageBroacastAsync(message, cts.Token);
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{requestId}] {ex.Message}");

                responseCode = StatusCodes.Status500InternalServerError;
                responseData = ex.Message;
            }

            Logger.logData.Info(JsonHelper.Serialize(new
            {
                requestId,
                requestTime,
                responseTime = DateTime.Now,
                processTime = Logger.GetProcessingMilliseconds(requestTime),
                userName = Request.GetUserName(),
                browserInfo,
                request = message,
            }));

            return StatusCode(responseCode, responseData);
        }
    }
}
