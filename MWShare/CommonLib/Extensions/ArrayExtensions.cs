using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonLib.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Add<T>(this T[] src, T obj)
        {
            if (src == null) return src;
            int oldLen = src.Length;
            Array.Resize(ref src, oldLen + 1);
            src[oldLen] = obj;
            return src;
        }

        public static T[] Concat<T>(this T[] x, T[] y)
        {
            if (x == null) return x;
            if (y == null) return x;
            int oldLen = x.Length;
            Array.Resize(ref x, x.Length + y.Length);
            Buffer.BlockCopy(y, 0, x, oldLen, y.Length);
            return x;
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            if (source == null || source.Length == 0) return source;
            if (index < 0 || index > (source.Length - 1)) return source;

            T[] dest = new T[source.Length - 1];
            if (dest.Length == 0)
            {
                return dest;
            }

            if (index > 0)
            {
                Buffer.BlockCopy(source, 0, dest, 0, index);
            }

            if (index < source.Length - 1)
            {
                Buffer.BlockCopy(source, index + 1, dest, index, source.Length - index - 1);
            }

            return dest;
        }

        public static T[] Remove<T>(this T[] source, int index, int length)
        {
            if (source == null || source.Length == 0) return source;
            if (index < 0 || index > (source.Length - 1)) return source;

            T[] dest = new T[source.Length];
            Buffer.BlockCopy(source, 0, dest, 0, source.Length);

            for (int i = 0; i < length; i++)
            {
                dest = dest.RemoveAt(index);
            }

            return dest;
        }

        public static T[] GetCopy<T>(this T[] source, int index, int length)
        {
            if (source == null || index < 0 || index > (source.Length - 1))
            {
                return null;
            }

            T[] dest = new T[length];
            Buffer.BlockCopy(source, index, dest, 0, Math.Min(length, source.Length - index - 1));
            return dest;
        }

        public static Dictionary<string, object[]> ToDictionaryPropertyAndValues<T>(this T[] values) where T : class
        {
            if (values == null || values.Length == 0) return null;

            var type = typeof(T);
            var properties = type.GetProperties().ToArray();

            if (properties == null || properties.Length == 0) return null;

            //
            var dicPropertyAndValues = new Dictionary<string, object[]>();

            for (int itemIdx = 0; itemIdx < values.Length; itemIdx++)
            {
                var item = values[itemIdx];

                for (int propNameIdx = 0; propNameIdx < properties.Length; propNameIdx++)
                {
                    var prop = properties[propNameIdx];
                    var propName = prop.Name;

                    if (itemIdx == 0)
                    {
                        dicPropertyAndValues[propName] = new object[values.Length];
                    }

                    //
                    if (prop.CanRead == false) continue;

                    //
                    dicPropertyAndValues[propName][itemIdx] = prop.GetValue(item);
                }
            }

            return dicPropertyAndValues;
        }
    }
}
