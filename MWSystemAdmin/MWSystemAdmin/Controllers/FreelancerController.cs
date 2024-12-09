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
    [MasterDataBaseControllerConfig("FREELANCER", Const.ProfileKeyField.Freelancer)]
    public class FreelancerController : MasterDataBaseController<MWFreelancer>
    {
        public FreelancerController(IMasterDataBaseService<MWFreelancer> masterDataBaseBL, ILoggingManagement loggingManagement) : base(masterDataBaseBL, loggingManagement)
        {
        }
    }

}
