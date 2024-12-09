using MWShare.Controllers;
using MWShare.FilterAttributes;
using CommonLib.Constants;
using DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;
using Business.Core.Services.BaseServices;
using Object.Core;

namespace BOSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Job)]
    [MasterDataBaseControllerConfig("USER", Const.ProfileKeyField.User)]
    public class UserController : MasterDataBaseController<MWUser>
    {
        public UserController(IMasterDataBaseService<MWUser> masterDataBaseBL, ILoggingManagement loggingManagement) : base(masterDataBaseBL, loggingManagement)
        {
        }
    }

}
