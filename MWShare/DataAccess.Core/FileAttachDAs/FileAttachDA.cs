using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object;

namespace DataAccess.Core.FileAttachDAs
{
    public sealed class FileAttachDA : BaseDA<MWFileAttach>, IFileAttachDA
    {
        public FileAttachDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
