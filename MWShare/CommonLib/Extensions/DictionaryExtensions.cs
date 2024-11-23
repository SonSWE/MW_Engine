using System.Collections.Generic;

namespace CommonLib.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs, TKey key)
        {
            if (keyValuePairs != null && keyValuePairs.ContainsKey(key))
                return keyValuePairs[key];

            return default;
        }
    }
}
