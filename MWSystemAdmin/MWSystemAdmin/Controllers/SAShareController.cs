using Business.Core.Services.Share;
using Business.Core.Services.ShareServices;
using CommonLib;
using DataAccess.Helpers;
using MemoryData;
using Microsoft.AspNetCore.Mvc;
using MWShare.FilterAttributes;
using Object.Core;

namespace MWSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorize(CheckFunction = false)]
    public class SAShareController : ControllerBase
    {
        private readonly ISAShareService _sAShareService;
        private readonly ILoggingManagement _loggingManagement;

        public SAShareController(ISAShareService sAShareService, ILoggingManagement loggingManagement)
        {
            _sAShareService = sAShareService;
            _loggingManagement = loggingManagement;
        }

        public string RequestId => _loggingManagement.RequestId;

        [HttpGet("getsystemcodes")]
        public async Task<IEnumerable<MWSystemCode>> GetSystemCodes()
        {
            try
            {
                var systemCodes = SystemCodeMem.GetAll();

                if (systemCodes == null || !systemCodes.Any())
                {
                    Response.StatusCode = StatusCodes.Status204NoContent;
                    return null;
                }

                return systemCodes;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"[{RequestId}] {ex.Message}");
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
        }

    }
}
