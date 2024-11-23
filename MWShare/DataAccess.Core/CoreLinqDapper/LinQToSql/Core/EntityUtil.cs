using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DapperLib.LinQToSql.Core
{
    public class EntityUtil
    {
        private static ConcurrentDictionary<string, Table> _database = new();
        private static Table Build(Type type)
        {
            string keyDic = type.Name;
            if (!_database.TryGetValue(keyDic, out Table? table))
            {
                var properties = type.GetProperties();
                var columns = new List<Column>();
                foreach (var item in properties)
                {
                    if(item?.GetSetMethod() == null && item?.GetGetMethod() == null) continue;
                    var columnName = item.Name;
                    var key = ColumnKey.None;
                    if (item.GetCustomAttributes(typeof(Object.Core.CustomAttributes.DbFieldAttribute), true).Length > 0)
                    {
                        var attribute = item.GetCustomAttributes(typeof(Object.Core.CustomAttributes.DbFieldAttribute), true)[0] as Object.Core.CustomAttributes.DbFieldAttribute;
                        if (attribute == null) continue;
                        if (attribute.Ignore || attribute.IgnoreInsert || attribute.IgnoreUpdate)
                        {
                            continue;
                        }
                        key = attribute.IsKey ? ColumnKey.Primary: ColumnKey.None ;
                        columnName = string.IsNullOrEmpty(attribute.Name) ? item.Name : attribute.Name;
                    }
                    var column = new Column()
                    {
                        ColumnKey = key,
                        ColumnName = columnName,
                        CSharpName = item.Name,
                    };
                    columns.Add(column);
                }
                if (columns.Count > 0 && !columns.Exists(e => e.ColumnKey == ColumnKey.Primary))
                {
                    columns[0].ColumnKey = ColumnKey.Primary;
                }
                var tableName = type.Name;
                if (type.GetCustomAttributes(typeof(DbTableAttribute), true).Length > 0)
                {
                    tableName = (type.GetCustomAttributes(typeof(Object.Core.CustomAttributes.DbTableAttribute), true)[0] as Object.Core.CustomAttributes.DbTableAttribute)?.Name ?? keyDic;
                }
                table = new Table()
                {
                    CSharpName = type.Name,
                    CSharpType = type,
                    TableName = tableName,
                    Columns = columns,
                };
                _database[keyDic] = table;
            }
            return table;
        }
        public static Table GetTable<T>() where T : class
        {
            return Build(typeof(T));
        }
        public static Table GetTable(Type type)
        {
            return Build(type);
        }
        public static Column? GetColumn(Type type, Func<Column, bool> func)
        {
            return Build(type).Columns.Find(f => func(f));
        }
    }
    public class Table
    {
        public Type? CSharpType { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string CSharpName { get; set; } = string.Empty;
        public List<Column> Columns { get; set; } = new();
    }
    public class Column
    {
        public string ColumnName { get; set; } = string.Empty;
        public string CSharpName { get; set; } = string.Empty;
        public ColumnKey ColumnKey { get; set; }
    }

    public enum ColumnKey
    {
        None,
        Primary,
        Quniue,
        Unique,
        Foreign
    }
}
