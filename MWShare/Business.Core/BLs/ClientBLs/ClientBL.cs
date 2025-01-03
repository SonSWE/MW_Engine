using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using Object.Core;
using System.Data;
using Business.Core.BLs.BaseBLs;
using System.Collections.Generic;
using DataAccess.Core.UserDAs;
using DataAccess.Core.ClientDAs;
using System.Linq;

namespace Business.Core.BLs.ClientBLs
{
    public class ClientBL : MasterDataBaseBL<MWClient>, IClientBL
    {
        private readonly IClientDA _clientDA;

        public override string ProfileKeyField => Const.ProfileKeyField.Client;
        public override string DbTable => Const.DbTable.MWClient;

        public ClientBL(IDbManagement dbManagement, ILoggingManagement loggingManagement,
            IClientDA clientDA) : base(dbManagement, loggingManagement)
        {
            _clientDA = clientDA;
        }

        public override void BeforeCreate(IDbTransaction transaction, MWClient data)
        {
            //tự sinh id
            data.ClientId = "CL" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }

        public bool IsExistedEmail(IDbTransaction transaction, string email, string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                var count = _clientDA.Count(new Dictionary<string, object> { { nameof(MWClient.Email), email } }, transaction);
                return count > 1;
            }
            else
            {
                var count = _clientDA.Get(new Dictionary<string, object> { { nameof(MWClient.Email), email } }, transaction).Where(x => x.ClientId != clientId).Count();
                return count > 1;
            }

        }
    }
}
