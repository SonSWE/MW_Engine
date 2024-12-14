using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using Object.Core;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using DataAccess.Core.FreelancerDAs;
using DataAccess.Core.UserDAs;
using System.Collections.Generic;
using static CommonLib.Constants.ErrorCodes;
using Business.Core.BLs.UserBLs;
using Business.Core.Services.BaseServices;
using Azure.Core;
using DataAccess.Core.Abtractions;
using static CommonLib.Constants.Const;

namespace Business.Cus.BLs.FreelancerBLs
{
    public class FreelancerBL : IFreelancerBL
    {
        private readonly IBaseDA<MWFreelancer> _baseDA;
        private readonly IFreelancerWorkingHistoryDA _workingHistoryDA;
        private readonly IFreelancerSpecialtyDA _specialtyDA;
        private readonly IFreelancerSkillDA _skillDA;
        private readonly IFreelancerEducationDA _educationDA;
        private readonly IFreelancerCertificateDA _certificateDA;

        public virtual ILoggingManagement LoggingManagement { get; private set; }
        public string RequestId => LoggingManagement.RequestId;

        public FreelancerBL(IBaseDA<MWFreelancer> baseDA, IDbManagement dbManagement, ILoggingManagement loggingManagement, IFreelancerWorkingHistoryDA workingHistoryDA, IFreelancerSpecialtyDA specialtyDA,
            IFreelancerSkillDA skillDA, IFreelancerEducationDA freelancerEducationDA, IFreelancerCertificateDA certificateDA)
        {
            LoggingManagement = loggingManagement;

            _workingHistoryDA = workingHistoryDA;
            _specialtyDA = specialtyDA;
            _skillDA = skillDA;
            _educationDA = freelancerEducationDA;
            _certificateDA = certificateDA;

            _baseDA = baseDA;
        }

        public virtual long UpdateOpenJob(IDbTransaction transaction, string id, string value, ClientInfo clientInfo)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] Start. data=[id: {id}, isOpenForJob: {value}]");

            long result = ErrorCodes.Err_Unknown;

            if (string.IsNullOrEmpty(id) || !Const.YN.IsValidate(value))
            {
                result = ErrorCodes.Err_DataNull;
                goto endFunc;
            }

            //
            MWFreelancer oldData = GetDetailById(transaction, id) ?? new();
            if (oldData == null || string.IsNullOrEmpty(oldData.FreelancerId?.ToString()))
            {
                result = ErrorCodes.Err_NotFound;
                goto endFunc;
            }

            oldData.IsOpeningForJob = value;

            var param = new MWFreelancer();
            param.FreelancerId = id;

            result = _baseDA.Update(oldData, param, transaction);

        //
        endFunc:
            Logger.log.Info($"[{RequestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");
            return result;
        }

        public MWFreelancer GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWFreelancer data = _baseDA.GetViewFirstOrDefault(new Dictionary<string, object>
            {
                { nameof(MWFreelancer.FreelancerId), id},
            }, transaction);

            if (data != null && !string.IsNullOrEmpty(data.FreelancerId))
            {
                data.WorkingHistories = _workingHistoryDA.GetView(new
                {
                    data.FreelancerId,
                }, transaction).ToList() ?? new();

                data.Specialties = _specialtyDA.GetView(new
                {
                    data.FreelancerId,
                }, transaction).ToList() ?? new();

                data.Skills = _skillDA.GetView(new
                {
                    data.FreelancerId,
                }, transaction).ToList() ?? new();

                data.Educations = _educationDA.GetView(new
                {
                    data.FreelancerId,
                }, transaction).ToList() ?? new();

                data.Certificates = _certificateDA.GetView(new
                {
                    data.FreelancerId,
                }, transaction).ToList() ?? new();
            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }
    }
}
