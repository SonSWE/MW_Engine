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

        public int UpdateHourlyRate(MWFreelancer data, IDbTransaction transaction)
        {
            string updateSqlText = $"UPDATE {Const.DbTable.MWFreelancer} SET " +
                $"{nameof(MWFreelancer.HourlyRate)} = :{nameof(MWFreelancer.HourlyRate)}, " +
                $"{nameof(MWFreelancer.LastChangeBy)} = :{nameof(MWFreelancer.LastChangeBy)}, " +
                $"{nameof(MWFreelancer.LastChangeDate)} = :{nameof(MWFreelancer.LastChangeDate)} " +
                $" WHERE {nameof(MWFreelancer.FreelancerId)} = :{nameof(MWFreelancer.FreelancerId)}";

            var param = new DynamicParameters();
            param.Add(nameof(MWFreelancer.FreelancerId), data.FreelancerId);
            param.Add(nameof(MWFreelancer.HourlyRate), data.HourlyRate);
            param.Add(nameof(MWFreelancer.LastChangeBy), data.LastChangeBy);
            param.Add(nameof(MWFreelancer.LastChangeDate), data.LastChangeDate);


            return transaction.Connection.Execute(updateSqlText, param, transaction, null, CommandType.Text);

        }

        public int UpdateHourWorkingPerWeek(MWFreelancer data, IDbTransaction transaction)
        {
            string updateSqlText = $"UPDATE {Const.DbTable.MWFreelancer} SET " +
                $"{nameof(MWFreelancer.HourWorkingPerWeek)} = :{nameof(MWFreelancer.HourWorkingPerWeek)}, " +
                $"{nameof(MWFreelancer.LastChangeBy)} = :{nameof(MWFreelancer.LastChangeBy)}, " +
                $"{nameof(MWFreelancer.LastChangeDate)} = :{nameof(MWFreelancer.LastChangeDate)} " +
                $" WHERE {nameof(MWFreelancer.FreelancerId)} = :{nameof(MWFreelancer.FreelancerId)}";

            var param = new DynamicParameters();
            param.Add(nameof(MWFreelancer.FreelancerId), data.FreelancerId);
            param.Add(nameof(MWFreelancer.HourWorkingPerWeek), data.HourWorkingPerWeek);
            param.Add(nameof(MWFreelancer.LastChangeBy), data.LastChangeBy);
            param.Add(nameof(MWFreelancer.LastChangeDate), data.LastChangeDate);


            return transaction.Connection.Execute(updateSqlText, param, transaction, null, CommandType.Text);

        }

        public int UpdateTitle(MWFreelancer data, IDbTransaction transaction)
        {
            string updateSqlText = $"UPDATE {Const.DbTable.MWFreelancer} SET " +
                $"{nameof(MWFreelancer.Title)} = :{nameof(MWFreelancer.Title)}, " +
                $"{nameof(MWFreelancer.LastChangeBy)} = :{nameof(MWFreelancer.LastChangeBy)}, " +
                $"{nameof(MWFreelancer.LastChangeDate)} = :{nameof(MWFreelancer.LastChangeDate)} " +
                $" WHERE {nameof(MWFreelancer.FreelancerId)} = :{nameof(MWFreelancer.FreelancerId)}";

            var param = new DynamicParameters();
            param.Add(nameof(MWFreelancer.FreelancerId), data.FreelancerId);
            param.Add(nameof(MWFreelancer.Title), data.Title);
            param.Add(nameof(MWFreelancer.LastChangeBy), data.LastChangeBy);
            param.Add(nameof(MWFreelancer.LastChangeDate), data.LastChangeDate);


            return transaction.Connection.Execute(updateSqlText, param, transaction, null, CommandType.Text);

        }

        public int UpdateBio(MWFreelancer data, IDbTransaction transaction)
        {
            string updateSqlText = $"UPDATE {Const.DbTable.MWFreelancer} SET " +
                $"{nameof(MWFreelancer.Bio)} = :{nameof(MWFreelancer.Bio)}, " +
                $"{nameof(MWFreelancer.LastChangeBy)} = :{nameof(MWFreelancer.LastChangeBy)}, " +
                $"{nameof(MWFreelancer.LastChangeDate)} = :{nameof(MWFreelancer.LastChangeDate)} " +
                $" WHERE {nameof(MWFreelancer.FreelancerId)} = :{nameof(MWFreelancer.FreelancerId)}";

            var param = new DynamicParameters();
            param.Add(nameof(MWFreelancer.FreelancerId), data.FreelancerId);
            param.Add(nameof(MWFreelancer.Bio), data.Bio);
            param.Add(nameof(MWFreelancer.LastChangeBy), data.LastChangeBy);
            param.Add(nameof(MWFreelancer.LastChangeDate), data.LastChangeDate);


            return transaction.Connection.Execute(updateSqlText, param, transaction, null, CommandType.Text);

        }


    }
}
