using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;
using Object;
using System.Collections.Generic;
using Business.Core.BLs.JobBLs;
using DataAccess.Core.JobDAs;
using System;

namespace Business.Core.Services.JobServices
{
    public class JobSavedService : IJobSavedService
    {
        private readonly IJobSavedBL _jobSavedBL;
        private readonly IDbManagement DbManagement;
        public JobSavedService(IDbManagement dbManagement, IJobSavedBL jobSavedBL)
        {
            _jobSavedBL = jobSavedBL;
            DbManagement = dbManagement;
        }

        public List<MWJob> GetSavedJobsByFreelancer(string freelancerId, ClientInfo clientInfo)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            if (string.IsNullOrEmpty(freelancerId) && !string.IsNullOrEmpty(clientInfo?.LoggedUser?.Freelancer?.FreelancerId))
            {
                freelancerId = clientInfo.LoggedUser.Freelancer.FreelancerId;
            }

            return _jobSavedBL.GetSavedJobsByFreelancer(transaction, freelancerId);
        }

        public long InsertData(MWJobSaved data, ClientInfo clientInfo, out string createResMessage)
        {
            createResMessage = string.Empty;
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            data.CreateDate = DateTime.Now;
            data.CreateBy = clientInfo.UserName;

            long insertCount = _jobSavedBL.InsertData(transaction, data);

            if (insertCount > 0)
            {
                createResMessage = "Lưu công việc thành công";
                transaction.Commit();
            }
            else
            {
                createResMessage = "Lưu công việc thất bại";
                transaction.Rollback();
            }

            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }

        public long DeleteData(MWJobSaved data, ClientInfo clientInfo, out string createResMessage)
        {
            createResMessage = string.Empty;
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long insertCount = _jobSavedBL.DeleteData(transaction, data);

            if (insertCount > 0)
            {
                createResMessage = "Xóa thành công";
                transaction.Commit();
            }
            else
            {
                createResMessage = "Xóa thất bại";
                transaction.Rollback();
            }

            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }
    }
}
