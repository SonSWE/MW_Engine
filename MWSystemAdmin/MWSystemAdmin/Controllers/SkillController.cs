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
using Object;
namespace BOSystemAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiAuthorizeFunctionConfig(Const.AuthenFunctionId.Skill)]
    [MasterDataBaseControllerConfig("SKILL", Const.ProfileKeyField.Skill)]
    public class SkillController : MasterDataBaseController<MWSkill>
    {
        public SkillController(IMasterDataBaseService<MWSkill> masterDataBaseBL, ILoggingManagement loggingManagement) : base(masterDataBaseBL, loggingManagement)
        {
        }
    }

}
