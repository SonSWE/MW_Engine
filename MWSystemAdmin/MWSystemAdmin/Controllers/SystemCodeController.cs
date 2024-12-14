using MWShare.Controllers;
using MWShare.FilterAttributes;
using Object.Core;
using CommonLib.Constants;
using MWShare.Authen;
using MWShare.Helpers;
using Business.Core;
using DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;
using Business.Core.Services.BaseServices;
namespace BOSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.SystemCode)]
    [MasterDataBaseControllerConfig("SYSTEMCODE", Const.ProfileKeyField.SystemCode)]
    public class SystemCodeController : MasterDataBaseController<MWSystemCode>
    {
        public SystemCodeController(IMasterDataBaseService<MWSystemCode> masterDataBaseBL, ILoggingManagement loggingManagement) : base(masterDataBaseBL, loggingManagement)
        {
        }
    }

}
