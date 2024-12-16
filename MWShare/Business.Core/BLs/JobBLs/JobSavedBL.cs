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
using DataAccess.Core.SystemCodeDAs;
using Business.Core.BLs.BaseBLs;
using DataAccess.Core.Interfaces;
using DataAccess.Core.SystemDAs;
using System.Collections.Generic;
using Object;
using DataAccess.Core.JobDAs;
using DataAccess.Core.SkillDAs;

namespace Business.Core.BLs.JobBLs
{
    public class JobSavedBL : IJobSavedBL
    {
        private readonly IJobSavedDA _jobSaveDA;

        public JobSavedBL(IJobSavedDA jobSaveDA)
        {
            _jobSaveDA = jobSaveDA;
        }

        public long InsertData(IDbTransaction transaction, MWJobSaved data)
        {
            int insertCount = _jobSaveDA.Insert(data, transaction);
            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }

        public long DeleteData(IDbTransaction transaction, MWJobSaved data)
        {
            int insertCount = _jobSaveDA.DeleteData(transaction, data);
            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }


        public List<MWJob> GetSavedJobsByFreelancer(IDbTransaction transaction, string freelancerId)
        {
            return _jobSaveDA.GetSavedJobsByFreelancer(transaction, freelancerId);
        }

    }
}
