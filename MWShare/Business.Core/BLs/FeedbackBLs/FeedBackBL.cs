using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using System.Data;
using Business.Core.BLs.BaseBLs;
using Object;
using Object.Core;
using System.Collections.Generic;
using DataAccess.Core.FreelancerDAs;

namespace Business.Core.BLs.FeedbackBLs
{
    public class FeedBackBL : MasterDataBaseBL<MWFeedBack>, IFeedBackBL
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Feedback;
        public override string DbTable => Const.DbTable.MWFeedBack;

        public FeedBackBL(IDbManagement dbManagement, ILoggingManagement loggingManagement) : base(dbManagement, loggingManagement)
        {

        }

        public override void BeforeCreate(IDbTransaction transaction, MWFeedBack data)
        {
            //tự sinh id
            data.FeedBackId = "FB" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }

        
    }
}
