using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CommonLib.Extensions
{
    public static class ListExtensions
    {
        public static Dictionary<string, object[]> ToDictionaryPropertyAndValues<T>(this List<T> values)
        {
            if (values == null || values.Count == 0) return null;

            var type = typeof(T);
            var properties = type.GetProperties().ToArray();

            if (properties == null || properties.Length == 0) return null;

            //
            var dicPropertyAndValues = new Dictionary<string, object[]>();

            for (int itemIdx = 0; itemIdx < values.Count; itemIdx++)
            {
                var item = values[itemIdx];

                for (int propNameIdx = 0; propNameIdx < properties.Length; propNameIdx++)
                {
                    var prop = properties[propNameIdx];
                    var propName = prop.Name;

                    if (itemIdx == 0)
                    {
                        dicPropertyAndValues[propName] = new object[values.Count];
                    }

                    //
                    if (prop.CanRead == false) continue;

                    //
                    dicPropertyAndValues[propName][itemIdx] = prop.GetValue(item);
                }
            }

            return dicPropertyAndValues;
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ToDataTable<T>(this IList<T> data, params string[] paramValues)
        {
            var listParams = paramValues.ToList();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new();
            foreach (PropertyDescriptor prop in properties)
            {
                if (listParams.Contains(prop.Name))
                {

                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }    
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (string param in listParams)
                    row[param] = properties.Find(param, false).GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            // Get all the properties of the class
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var columns = dataTable.Columns.Cast<DataColumn>();

            // Create a list of the given type
            var list = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                // Create a new instance of the type
                var item = new T();
                foreach (var prop in properties)
                {
                    if (columns.Any(c => c.ColumnName.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        var value = row[prop.Name];
                        if (value != DBNull.Value)
                        {
                            if (prop.PropertyType == typeof(DateTime?))
                            {
                                prop.SetValue(item, (DateTime?)value, null);
                            }
                            else
                            {
                                prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType), null);
                            }
                        }
                    }
                }
                list.Add(item);
            }

            return list;
        }
    }
}
