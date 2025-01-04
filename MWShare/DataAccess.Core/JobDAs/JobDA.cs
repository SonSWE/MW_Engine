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

        private readonly string sqlJobByMatchPoint = @$"
                        SELECT j.*, (a.skillMatchCount + a.specialtyMatchCount + a.levelMatch) as matchPoint
                                , (CASE WHEN js.freelancerId is not null THEN 'Y' ELSE 'N' END) AS saved
, CASE WHEN (SELECT count(*) FROM {Const.DbTable.MWProposal} WHERE jobid = j.jobId AND freelancerId = :{nameof(MWFreelancer.FreelancerId)}  GROUP BY jobid) > 0 THEN '{Const.YN.Yes}' ELSE '{Const.YN.No}' END AS Applied
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
                        FETCH FIRST 1000 ROWS ONLY";

        public List<MWJob> GetSuggestByFreelancer(IDbTransaction transaction, string freelancerId)
        {
            List<MWJob> result = transaction.Connection.Query<MWJob>(sqlJobByMatchPoint, new Dictionary<string, object> { { nameof(MWFreelancer.FreelancerId), freelancerId } }).ToList();

            return result;
        }

        public List<MWJob> Search(IDbTransaction transaction, SearchJobRequest data)
        {
            string conds = buildConditions(data);
            string sql = $"SELECT * FROM ({sqlJobByMatchPoint}) WHERE 1=1 {conds} ";

            List<MWJob> result = transaction.Connection.Query<MWJob>(sql, new Dictionary<string, object> { { nameof(MWFreelancer.FreelancerId), data.FreelancerId } }).ToList();

            return result;
        }

        private string buildConditions(SearchJobRequest dataSearch)
        {
            var sqlQuery = $"";
            if (!string.IsNullOrEmpty(dataSearch.Title))
            {
                sqlQuery += $" AND (  UPPER({nameof(MWJob.Title)}) like '%{dataSearch.Title.ToUpper()}%' OR UPPER({nameof(MWJob.Description)}) like '%{dataSearch.Title.ToUpper()}%' ) ";
            }

            if (dataSearch.LevelIds != null && dataSearch.LevelIds.Count > 0)
            {
                sqlQuery += $" AND {nameof(MWJob.LevelFreelancerId)} in ('{string.Join("', '", dataSearch.LevelIds)}') ";
            }

            return sqlQuery;
        }

    }
}
