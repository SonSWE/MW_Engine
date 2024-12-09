using DataAccess.Core.Abtractions;
using Object;
using Object.Core;
using System.Data;

namespace DataAccess.Core.SpencialDAs
{
    public interface ISpecialtyDA : IBaseDA<MWSpecialty>
    {
        long GetNextSequenceValue(IDbTransaction transaction);
    }
}
