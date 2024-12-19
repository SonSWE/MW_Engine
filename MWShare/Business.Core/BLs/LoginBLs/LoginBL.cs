using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using Object.Core;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using DataAccess.Core.SystemCodeDAs;
using DataAccess.Core.UserDAs;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Core.LoginDAs;
using Dapper;
using DataAccess.Core.ClientDAs;
using DataAccess.Core.FreelancerDAs;
using static CommonLib.Constants.Const;
using Business.Core.BLs.FreelancerBLs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Core.BLs.LoginBLs
{
    public class LoginBL : ILoginBL
    {
        private readonly ILoginDA _loginDA;
        private readonly IUserDA _userDA;
        private readonly IFreelancerDA _freelancerDA;
        private readonly IClientDA _clientDA;
        private readonly IFreelancerWorkingHistoryDA _workingHistoryDA;
        private readonly IFreelancerSpecialtyDA _specialtyDA;
        private readonly IFreelancerSkillDA _skillDA;
        private readonly IFreelancerEducationDA _educationDA;
        private readonly IFreelancerCertificateDA _certificateDA;


        public LoginBL(ILoginDA loginDA, IUserDA userDA, IFreelancerDA freelancerDA, IFreelancerWorkingHistoryDA workingHistoryDA, IFreelancerSpecialtyDA specialtyDA,
            IFreelancerSkillDA skillDA, IFreelancerEducationDA freelancerEducationDA, IFreelancerCertificateDA certificateDA, IClientDA clientDA)
        {
            _loginDA = loginDA;
            _userDA = userDA;

            _freelancerDA = freelancerDA;
            _workingHistoryDA = workingHistoryDA;
            _specialtyDA = specialtyDA;
            _skillDA = skillDA;
            _educationDA = freelancerEducationDA;
            _certificateDA = certificateDA;

            _clientDA = clientDA;
        }

        public MWUser GetUserByUserName(string userName, IDbTransaction transaction)
        {
            return _loginDA.GetUserByUserName(transaction, userName);
        }

        public List<MWUserFunction> GetFunctionByUserName(string userName, IDbTransaction transaction)
        {
            return _loginDA.GetFunctionByUserName(transaction, userName);
        }

        public async Task<MWUser> GetUserByUserNameAsync(IDbTransaction transaction, string userName)
        {
            return await _loginDA.GetUserByUserNameAsync(transaction, userName);
        }

        public async Task<List<MWUserFunction>> GetFunctionByUserNameAsync(IDbTransaction transaction, string userName)
        {
            return await _loginDA.GetFunctionByUserNameAsync(transaction, userName);
        }


        public async Task<MWUser> GetDetailUserAsync(IDbTransaction transaction, string userName)
        {
            var user = await _userDA.GetViewFirstOrDefaultAsync(new Dictionary<string, object>
            {
                { nameof(MWUser.UserName), userName},
            }, transaction);

            if (user != null && !string.IsNullOrEmpty(user.Email))
            {
                user.Clients = (await _clientDA.GetViewAsync(new
                {
                    user.Email,
                }, transaction))?.ToList() ?? new();

                if (!string.IsNullOrEmpty(user.LoggedClientId))
                {
                    user.Client = (await _clientDA.GetFirstOrDefaultAsync(new Dictionary<string, object> { { nameof(MWClient.ClientId), user.LoggedClientId }, }, transaction)) ?? new();
                }

                var data = (await _freelancerDA.GetFirstOrDefaultAsync(new
                {
                    user.Email,
                }, transaction)) ?? new();

                if (data != null && !string.IsNullOrEmpty(data.FreelancerId))
                {
                    data.WorkingHistories = (await _workingHistoryDA.GetViewAsync(new
                    {
                        data.FreelancerId,
                    }, transaction))?.ToList() ?? new();

                    data.Specialties = (await _specialtyDA.GetViewAsync(new
                    {
                        data.FreelancerId,
                    }, transaction))?.ToList() ?? new();

                    data.Skills = (await _skillDA.GetViewAsync(new
                    {
                        data.FreelancerId,
                    }, transaction))?.ToList() ?? new();

                    data.Educations = (await _educationDA.GetViewAsync(new
                    {
                        data.FreelancerId,
                    }, transaction))?.ToList() ?? new();

                    data.Certificates = (await _certificateDA.GetViewAsync(new
                    {
                        data.FreelancerId,
                    }, transaction))?.ToList() ?? new();

                    user.Freelancer = data;
                }


            }
            return user;
        }

    }
}
