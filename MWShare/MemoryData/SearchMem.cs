using CommonLib.Constants;
using CommonLib.Extensions;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryData
{
    public static class SearchMem
    {
        private static readonly object _lock = new();
        private static List<Search> _searches = new();

        //
        public static void InitData(List<Search> searches)
        {
            lock (_lock)
            {
                _searches = searches ?? new List<Search>();
            }
        }

        public static List<Search> GetAll()
        {
            lock (_lock)
            {
                return _searches?.Select(x => x.Clone()).ToList();
            }
        }

        public static Search GetByCode(string code)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(code))
                {
                    return _searches?.FirstOrDefault(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
                }

                return null;
            }
        }

        //public static List<SearchFld> SearchFldGetBySearchCode(string searchCode)
        //{
        //    lock (_lock)
        //    {
        //        if (!string.IsNullOrEmpty(searchCode))
        //        {
        //            return _searchFlds?.Where(x => x.SearchCode.Equals(searchCode, StringComparison.OrdinalIgnoreCase))?.ToList();
        //        }

        //        return null;
        //    }
        //}

        public static List<SearchFilterOption> GetSearchFilterOptions(string source)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(source)) source = source.Trim();

                if (!string.IsNullOrEmpty(source))
                {
                    switch (source)
                    {

                        case "FUNCTIONMEM":
                            return FunctionMem.GetAll()?.OrderBy(x => x.FunctionId).Select(x => new SearchFilterOption
                            {
                                CdVal = x.FunctionId,
                                Content = x.FunctionId + " - " + x.Description,
                                ContentEn = x.FunctionId + " - " + x.DescriptionEn,
                            }).ToList();
                        //
                        default:
                            string[] strings = source?.Split(new string[] { "__" }, StringSplitOptions.None);
                            if (strings?.Length == 2 && strings[0]?.Equals("SYSTEMCODE", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return SystemCodeMem.GetBySystemCodeId(strings[1])?.SystemCodeValues?.OrderBy(x => x.Ord).Select(x => new SearchFilterOption
                                {
                                    CdVal = x.Value,
                                    Content = x.Description,
                        
                                }).ToList();
                            }
                            break;
                    }
                }

                return null;
            }
        }
    }
}
