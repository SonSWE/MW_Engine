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
using Business.Core.BLs.BaseBLs;
using DataAccess.Core.FreelancerDAs;
using DataAccess.Core.UserDAs;
using System.Collections.Generic;
using static CommonLib.Constants.ErrorCodes;
using Business.Core.BLs.UserBLs;
using Business.Core.Services.BaseServices;

namespace Business.Core.BLs.FreelancerBLs
{
    public class FreelancerBL : MasterDataBaseBL<MWFreelancer>, IFreelancerBL
    {
        private readonly IFreelancerDA _freelancerDA;
        private readonly IFreelancerWorkingHistoryDA _workingHistoryDA;
        private readonly IFreelancerSpecialtyDA _specialtyDA;
        private readonly IFreelancerSkillDA _skillDA;
        private readonly IFreelancerEducationDA _educationDA;
        private readonly IFreelancerCertificateDA _certificateDA;

        public override string ProfileKeyField => Const.ProfileKeyField.Freelancer;
        public override string DbTable => Const.DbTable.MWFreelancer;

        public FreelancerBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IFreelancerWorkingHistoryDA workingHistoryDA, IFreelancerSpecialtyDA specialtyDA,
            IFreelancerSkillDA skillDA, IFreelancerEducationDA freelancerEducationDA, IFreelancerCertificateDA certificateDA, IFreelancerDA freelancerDA) : base(dbManagement, loggingManagement)
        {
            _freelancerDA = freelancerDA;
            _workingHistoryDA = workingHistoryDA;
            _specialtyDA = specialtyDA;
            _skillDA = skillDA;
            _educationDA = freelancerEducationDA;
            _certificateDA = certificateDA;
        }

        public override MWFreelancer GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWFreelancer data = base.GetDetailById(transaction, id);
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
        public MWFreelancer GetDetailByEmail(IDbTransaction transaction, string email)
        {
            MWFreelancer data = _baseDA.GetFirstOrDefault(new Dictionary<string, object>
            {
                { nameof(MWFreelancer.Email), email },
            }, transaction);

            if (data == null)
            {
                return default;
            }

            return GetDetailById(transaction, data.FreelancerId);
        }

        public override void BeforeCreate(IDbTransaction transaction, MWFreelancer data)
        {
            //tự sinh id
            data.FreelancerId = "FR" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }

        public override long InsertChildData(IDbTransaction transaction, MWFreelancer data, MWFreelancer oldData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (resultValues > 0 && data.WorkingHistories?.Count > 0)
            {
                long[] resProposal = new long[] { };
                data.WorkingHistories.ForEach(x =>
                {
                    x.FreelancerId = data.FreelancerId;
                    x.WorkingHistoryId = "WH" + _workingHistoryDA.GetNextSequenceValue(transaction).ToString();
                });

                var insertedCount = _workingHistoryDA.Insert(data.WorkingHistories, transaction);
                resultValues = insertedCount == data.WorkingHistories.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && data?.Specialties?.Count > 0)
            {
                data.Specialties.ForEach(x =>
                {
                    x.FreelancerId = data.FreelancerId;
                });

                var insertedCount = _specialtyDA.Insert(data.Specialties, transaction);
                resultValues = insertedCount == data.Specialties.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && data?.Skills?.Count > 0)
            {
                data.Skills.ForEach(x =>
                {
                    x.FreelancerId = data.FreelancerId;
                });

                var insertedCount = _skillDA.Insert(data.Skills, transaction);
                resultValues = insertedCount == data.Skills.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && data?.Educations?.Count > 0)
            {
                data.Educations.ForEach(x =>
                {
                    x.FreelancerId = data.FreelancerId;
                    x.EducationId = "ED" + _educationDA.GetNextSequenceValue(transaction).ToString();
                });

                var insertedCount = _educationDA.Insert(data.Educations, transaction);
                resultValues = insertedCount == data.Educations.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && data?.Certificates?.Count > 0)
            {
                data.Certificates.ForEach(x =>
                {
                    x.FreelancerId = data.FreelancerId;
                    x.CertificateId = "CER" + _certificateDA.GetNextSequenceValue(transaction).ToString();
                });

                var insertedCount = _certificateDA.Insert(data.Certificates, transaction);
                resultValues = insertedCount == data.Certificates.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }

        public override long DeleteChildData(IDbTransaction transaction, string id, MWFreelancer deleteData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (deleteData != null && deleteData.WorkingHistories?.Count > 0)
            {
                long[] resProposal = new long[] { };
                deleteData.WorkingHistories.ForEach(x =>
                {
                    x.FreelancerId = deleteData.FreelancerId;
                });

                var insertedCount = _workingHistoryDA.Delete(deleteData.WorkingHistories, transaction);
                resultValues = insertedCount == deleteData.WorkingHistories.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && deleteData?.Specialties?.Count > 0)
            {
                deleteData.Specialties.ForEach(x =>
                {
                    x.FreelancerId = deleteData.FreelancerId;
                });

                var insertedCount = _specialtyDA.Delete(deleteData.Specialties, transaction);
                resultValues = insertedCount == deleteData.Specialties.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && deleteData?.Skills?.Count > 0)
            {
                deleteData.Skills.ForEach(x =>
                {
                    x.FreelancerId = deleteData.FreelancerId;
                });

                var insertedCount = _skillDA.Delete(deleteData.Skills, transaction);
                resultValues = insertedCount == deleteData.Skills.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && deleteData?.Educations?.Count > 0)
            {
                deleteData.Educations.ForEach(x =>
                {
                    x.FreelancerId = deleteData.FreelancerId;
                });

                var insertedCount = _educationDA.Delete(deleteData.Educations, transaction);
                resultValues = insertedCount == deleteData.Educations.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            if (resultValues > 0 && deleteData?.Certificates?.Count > 0)
            {
                deleteData.Certificates.ForEach(x =>
                {
                    x.FreelancerId = deleteData.FreelancerId;
                });

                var insertedCount = _certificateDA.Delete(deleteData.Certificates, transaction);
                resultValues = insertedCount == deleteData.Certificates.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }

        public bool IsExistedEmail(IDbTransaction transaction, string email, string freelancerId)
        {
            if (string.IsNullOrEmpty(freelancerId))
            {
                var count = _freelancerDA.Count(new Dictionary<string, object> { { nameof(MWFreelancer.Email), email } }, transaction);
                return count > 1;
            }
            else
            {
                var count = _freelancerDA.Get(new Dictionary<string, object> { { nameof(MWFreelancer.Email), email } }, transaction).Where(x => x.FreelancerId != freelancerId).Count();
                return count > 1;
            }

        }
    }
}
