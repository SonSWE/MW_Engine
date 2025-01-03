using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;


namespace DataAccess.Core.UserDAs
{
    public sealed class UserDA : BaseDA<MWUser>, IUserDA
    {
        public UserDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }

        public int UpdateAvatar(MWUser data, IDbTransaction transaction)
        {
            string updateSqlText = $"UPDATE {Const.DbTable.MWUser} SET " +
                $"{nameof(MWUser.Avatar)} = :{nameof(MWUser.Avatar)}, " +
                $"{nameof(MWUser.LastChangeBy)} = :{nameof(MWUser.LastChangeBy)}, " +
                $"{nameof(MWUser.LastChangeDate)} = :{nameof(MWUser.LastChangeDate)} " +
                $" WHERE {nameof(MWUser.UserName)} = :{nameof(MWUser.UserName)}";

            var param = new DynamicParameters();
            param.Add(nameof(MWUser.UserName), data.UserName);
            param.Add(nameof(MWUser.Avatar), data.Avatar);
            param.Add(nameof(MWUser.LastChangeBy), data.LastChangeBy);
            param.Add(nameof(MWUser.LastChangeDate), data.LastChangeDate);


            return transaction.Connection.Execute(updateSqlText, param, transaction, null, CommandType.Text);

        }
    }
}
