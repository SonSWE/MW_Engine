using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FeedBackDAs
{
    public sealed class FeedBackDA : BaseDA<MWFeedBack>, IFeedBackDA
    {
        public FeedBackDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
