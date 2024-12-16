using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Object;
using Object.Core;
using System.Data;


namespace DataAccess.Core.FreelancerDAs
{
    public sealed class FreelancerDA : BaseDA<MWFreelancer>, IFreelancerDA
    {
        public FreelancerDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public int UpdateIsOpenForJob( MWFreelancer data, IDbTransaction transaction)
        {
            string updateSqlText = $"UPDATE {Const.DbTable.MWFreelancer} SET {nameof(MWFreelancer.IsOpeningForJob)} = :{nameof(MWFreelancer.IsOpeningForJob)}" +
                $" WHERE {nameof(MWFreelancer.FreelancerId)} = :{nameof(MWFreelancer.FreelancerId)}";

            var param = new DynamicParameters();
            param.Add(nameof(MWFreelancer.FreelancerId), data.FreelancerId);

            return transaction.Connection.Execute(updateSqlText, param, transaction, null, CommandType.Text);

        }

        
    }
}
