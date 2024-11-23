using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FeedBackDAs
{
    public sealed class FeedBackImageDA : BaseDA<MWFeedBackImage>, IFeedBackImageDA
    {
        public FeedBackImageDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
