using Object.Core;
using System.Collections.Generic;
using System.Linq;

namespace MemoryData
{
    public static class FunctionMem
    {
        private static readonly object _lock = new();
        private static readonly List<MWFunction> _functions = new();

        //
        public static void InitData(List<MWFunction> functions)
        {
            lock (_lock)
            {
                _functions.Clear();
                _functions.AddRange(functions);
            }
        }

        public static List<MWFunction> GetAll()
        {
            lock (_lock)
            {
                if (_functions?.Count > 0)
                {
                    return _functions;
                }
            }
            return null;
        }

        public static MWFunction GetByFunctionId(string functionId)
        {
            lock (_lock)
            {
                if (_functions?.Count > 0)
                {
                    return _functions?.FirstOrDefault(x => string.Equals(x.FunctionId, functionId));
                }
            }
            return null;
        }

        //
        public static bool IsValidFunction(string functionId)
        {
            lock (_lock)
            {
                if (_functions?.Count > 0)
                {
                    return _functions.Any(x => string.Equals(x.FunctionId, functionId));
                }
            }
            return false;
        }
    }
}
