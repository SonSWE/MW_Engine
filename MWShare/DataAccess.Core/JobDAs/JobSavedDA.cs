using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.FreelancerDAs;
using DataAccess.Core.Helpers;
using DataAccess.Core.JobDAs;
using Object;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccess.Core.JobDAs
{
    public sealed class JobSavedDA : BaseDA<MWJobSaved>, IJobSavedDA
    {
        public JobSavedDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public int DeleteData(IDbTransaction transaction, MWJobSaved data)
        {
            string sql = $"DELETE {Const.DbTable.MWJobSaved} WHERE {nameof(MWJobSaved.JobId)} = :{nameof(MWJobSaved.JobId)} AND {nameof(MWJobSaved.FreelancerId)} = :{nameof(MWJobSaved.FreelancerId)}";
            int insertCount = transaction.Connection.Execute(sql, new Dictionary<string, object> { { nameof(MWJobSaved.JobId), data.JobId }, { nameof(MWJobSaved.FreelancerId), data.FreelancerId } });
            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }

        public List<MWJob> GetSavedJobsByFreelancer(IDbTransaction transaction, string freelancerId)
        {
            string sqlQuery = @$" select j.* from {Const.DbTable.MWJobSaved} js
                                    JOIN vw_{Const.DbTable.MWJob} j ON j.jobid = js.jobid
                                    where js.freelancerid = :freelancerId
                                    order by js.createdate DESC ";

            List<MWJob> result = transaction.Connection.Query<MWJob>(sqlQuery, new { freelancerId }).ToList();

            return result;
        }
    }
}
