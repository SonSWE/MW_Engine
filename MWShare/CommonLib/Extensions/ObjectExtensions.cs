using DeepCopy;
using System;
using System.Linq;
using System.Reflection;

namespace CommonLib.Extensions
{
    public static class ObjectExtensions
    {
        public static void TrimStringProperty(this object obj)
        {
            if (obj == null) return;

            var props = obj.GetType().GetProperties();
            if (props != null)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    var prop = props[i];
                    if (prop.PropertyType == typeof(string) && prop.CanWrite)
                    {
                        string value = (string)prop.GetValue(obj, null);
                        if (!string.IsNullOrEmpty(value))
                        {
                            prop.SetValue(obj, value.Trim(), null);
                        }
                    }
                }
            }

            ////
            //var fields = obj.GetType().GetFields();
            //if (fields != null)
            //{
            //    for (int i = 0; i < fields.Length; i++)
            //    {
            //        var field = fields[i];
            //        if (field.FieldType == typeof(string))
            //        {
            //            string value = (string)field.GetValue(obj);
            //            if (!string.IsNullOrEmpty(value))
            //            {
            //                field.SetValue(obj, value.Trim());
            //            }
            //        }
            //    }
            //}
        }

        public static PropertyInfo? GetProperty(this object obj, string propertyName, bool ignoreCase = false)
        {
            if (obj == null) return null;
            if (ignoreCase)
            {
                return obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }
            return obj.GetType().GetProperty(propertyName);
        }

        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return null;
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (propertyInfo == null || !propertyInfo.CanRead) return null;
            return propertyInfo.GetValue(obj);
        }

        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return;
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (propertyInfo == null || !propertyInfo.CanWrite) return;
            propertyInfo.SetValue(obj, value);
        }

        //public static T Clone<T>(this T source)
        //{
        //    if (Object.ReferenceEquals(source, null))
        //    {
        //        return default(T);
        //    }

        //    return JsonHelper.Deserialize<T>(JsonHelper.Serialize(source));
        //}

        public static T Clone<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            return DeepCopier.Copy(source);
        }

        public static bool Compare<T>(T self, T to, params string[] ignoreProperties)
        {
            var properties = self.GetType().GetProperties();

            string selfValue, toValue;

            foreach (var property in properties)
            {
                if (ignoreProperties != null && ignoreProperties.Contains(property.Name))
                {
                    continue;
                }

                selfValue = property.GetValue(self, null).ToStringNullSafe();
                toValue = property.GetValue(to, null).ToStringNullSafe();

                if (string.Equals(selfValue, toValue) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static string ToStringNullSafe(this object obj)
        {
            return obj != null ? obj.ToString() : string.Empty;
        }

        public static T Transform<T>(this object source)
        {
            Type sourceType = source.GetType();
            Type targetType = typeof(T);
            var target = Activator.CreateInstance(targetType, false);

            var sourceMembers = sourceType.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();
            var targetMembers = targetType.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();

            var sourceMemberNames = sourceMembers.Select(y => y.Name).ToList();

            var members = targetMembers.Where(x => sourceMemberNames.Contains(x.Name));

            PropertyInfo propertyInfo;
            PropertyInfo sourcePropertyInfo;

            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                if (!propertyInfo.CanWrite)
                {
                    continue;
                }

                sourcePropertyInfo = source.GetType().GetProperty(memberInfo.Name);
                if (sourcePropertyInfo == null || !sourcePropertyInfo.CanRead)
                {
                    continue;
                }

                if (propertyInfo.PropertyType.Name != sourcePropertyInfo.PropertyType.Name)
                {
                    continue;
                }

                value = sourcePropertyInfo.GetValue(source, null);
                propertyInfo.SetValue(target, value, null);
            }
            return (T)target;
        }

        public static bool CheckPropertiesNullOrEmpty(this object obj, string[] propertiesToCheck, out string propertyName)
        {
            propertyName = string.Empty;
            if (obj == null || propertiesToCheck == null)
            {
                return false;
            };

            foreach (var item in propertiesToCheck)
            {
                PropertyInfo property = obj.GetType().GetProperty(item);

                if (property == null)
                {
                    propertyName = item;
                    return true;
                }

                var value = property.GetValue(obj) as string;
                if (string.IsNullOrEmpty(value))
                {
                    propertyName = item;
                    return true;
                }
            }

            return false;
        }

    }
}
