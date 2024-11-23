using DataAccess.Core.DefErrorDAs;
using Object.Core;
using System.Collections.Generic;
using System.Linq;

namespace Business.Core.Services.DefErrorServices
{
    public class DefErrorService : IDefErrorService
    {
        private readonly IDefErrorDA _defErrorDA;

        public DefErrorService(IDefErrorDA defErrorDA)
        {
            _defErrorDA = defErrorDA;
        }

        //
        public List<DefError> GetAll()
        {
            return _defErrorDA.Get()?.ToList(); ;
        }
    }
}
