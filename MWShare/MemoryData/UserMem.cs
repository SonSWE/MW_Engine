using Object.Core;
using System.Collections.Generic;
using System.Linq;

namespace MemoryData
{
    public static class UserMem
    {
        private static readonly object _lock = new();
        private static readonly Dictionary<string, MWUser> _dicDatas = new();

        //
        public static void InitData(List<MWUser> datas)
        {
            lock (_lock)
            {
                _dicDatas.Clear();
                if (datas != null)
                {
                    foreach (var item in datas)
                    {
                        if (item == null)
                        {
                            continue;
                        }

                        _dicDatas.TryAdd(item.UserName, item);
                    }
                }
            }
        }

        //
        public static List<MWUser> GetAll()
        {
            lock (_lock)
            {

                return _dicDatas.Values.ToList();
            }
        }

        //
        public static MWUser GetById(string id)
        {
            lock (_lock)
            {
                _dicDatas.TryGetValue(id, out var value);
                return value;
            }
        }

        //
        public static bool IsValidId(string id)
        {
            return _dicDatas.ContainsKey(id);
        }
    }
}
