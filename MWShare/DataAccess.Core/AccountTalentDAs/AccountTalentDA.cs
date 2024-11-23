using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;
using Object.Core;


namespace DataAccess.Core.AccountTalentDAs
{
    public sealed class AccountTalentDA : BaseDA<MWAccountTalent>, IAccountTalentDA
    {
        public AccountTalentDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
