using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace DataAccess.Core.JobDAs
{
    public sealed class JobDA : BaseDA<MWJob>, IJobDA
    {
        public JobDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public long GetNextSequenceValue(IDbTransaction transaction)
        {
            string sqlText = $"SELECT seq_{Const.DbTable.MWJob}.NEXTVAL FROM dual";
            long result = transaction.Connection.QueryFirstOrDefault<long>(sqlText);
            return result;
        }

        public List<MWJob> GetSuggestByFreelancer(IDbTransaction transaction, string freelancerId)
        {
            string sqlQuery = @$"
                        SELECT j.*, (a.skillMatchCount + a.specialtyMatchCount + a.levelMatch) as matchPoint
                                , (CASE WHEN js.freelancerId is not null THEN 'Y' ELSE 'N' END) AS saved
                        FROM (
                            SELECT j.jobId, 
                                   j.specialtyId, 
                                   j.levelfreelancerid, 
                                   j.createDate,
                                   COUNT(DISTINCT js.skillId) AS skillMatchCount,
                                   COUNT(DISTINCT fspec.specialtyId) AS specialtyMatchCount,
                                   CASE WHEN j.levelfreelancerid = f.levelId THEN 1 ELSE 0 END AS levelMatch
                            FROM {Const.DbTable.MWJob} j
                            LEFT JOIN {Const.DbTable.MWJobSkill} js ON j.jobId = js.jobId
                            LEFT JOIN {Const.DbTable.MWFreelancerSkill} fs ON js.skillId = fs.skillId
                            LEFT JOIN {Const.DbTable.MWFreelancerSpecialty} fspec ON j.specialtyId = fspec.specialtyId
                            LEFT JOIN {Const.DbTable.MWFreelancer} f ON f.freelancerId = fs.freelancerId
                            WHERE f.freelancerId = :{nameof(MWFreelancer.FreelancerId)}
                            GROUP BY j.jobId, j.specialtyId, j.levelfreelancerid, j.createDate, f.levelId
                        ) a
                        JOIN vw_{Const.DbTable.MWJob} j ON a.jobId = j.jobid
                        LEFT JOIN {Const.DbTable.MWJobSaved} js ON j.jobId = js.jobId AND js.freelancerId = :{nameof(MWFreelancer.FreelancerId)}
                        ORDER BY matchPoint DESC, j.createDate DESC
                        FETCH FIRST 30 ROWS ONLY";

            List<MWJob> result = transaction.Connection.Query<MWJob>(sqlQuery, new Dictionary<string, object> { { nameof(MWFreelancer.FreelancerId), freelancerId } }).ToList();

            return result;
        }

    }
}
