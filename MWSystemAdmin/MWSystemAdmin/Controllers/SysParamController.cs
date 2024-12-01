using MWShare.Controllers;
using MWShare.FilterAttributes;
using Object.Core;
using CommonLib.Constants;
using MWShare.GrpcAuthen;
using MWShare.Helpers;
using Business.Core;
using DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;
using Business.Core.Services.BaseServices;
namespace BOSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.SysParam)]
    [MasterDataBaseControllerConfig("SYSPARAM", Const.ProfileKeyField.SysParam)]
    public class SysParamController : MasterDataBaseController<MWSysParam>
    {
        public SysParamController(IMasterDataBaseService<MWSysParam> masterDataBaseBL, ILoggingManagement loggingManagement) : base(masterDataBaseBL, loggingManagement)
        {
        }
    }

}
