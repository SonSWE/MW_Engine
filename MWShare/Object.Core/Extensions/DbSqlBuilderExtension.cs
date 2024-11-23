namespace Object.Core.Extensions
{
    public static class DbSqlBuilderExtension
    {
        //public static string BuildCreateSqlText(this Type type)
        //{
        //    var tableName = type.GetDbTableName();
        //    var fieldNames = type.GetInsertDbFieldNames();

        //    return $@"INSERT INTO {tableName}({string.Join(", ", fieldNames)}) VALUES ({string.Join(", ", fieldNames.Select(field => ":" + field))})";
        //}

        //public static string BuildUpdateSqlText(this Type type)
        //{
        //    var tableName = type.GetDbTableName();
        //    var fieldNames = type.GetUpdateDbFieldNames(out var condFieldNames);

        //    return $@"UPDATE {tableName} SET {string.Join(", ", fieldNames.Select(field => field + " = :" + field))} WHERE {string.Join(" AND ", condFieldNames.Select(field => field + " = :" + field))}";
        //}

        //public static string BuildDeleteSqlText(this Type type)
        //{
        //    var tableName = type.GetDbTableName();
        //    var condFieldNames = type.GetDeleteCondFieldNames();

        //    return $@"DELETE FROM {tableName} WHERE {string.Join(" AND ", condFieldNames.Select(field => field + " = :" + field))}";
        //}

        ////
        //private static string GetDbTableName(this Type type)
        //{
        //    var dbTableAttribute = (DbTableAttribute)type.GetCustomAttributes(typeof(DbTableAttribute))?.FirstOrDefault();
        //    if (dbTableAttribute != null && !string.IsNullOrEmpty(dbTableAttribute.Name))
        //    {
        //        return dbTableAttribute.Name;
        //    }

        //    return type.Name;
        //}

        //private static IList<string> GetInsertDbFieldNames(this Type type)
        //{
        //    var insertFieldNames = new List<string>();

        //    var props = type.GetProperties();
        //    foreach (var prop in props)
        //    {
        //        var attribute = (DbFieldAttribute)prop.GetCustomAttributes(typeof(DbFieldAttribute))?.FirstOrDefault();
        //        if (attribute == null)
        //        {
        //            continue;
        //        }

        //        var fieldName = !string.IsNullOrEmpty(attribute.Name) ? attribute.Name : prop.Name;

        //        if (!attribute.IgnoreInsert)
        //        {
        //            insertFieldNames.Add(fieldName);
        //        }
        //    }

        //    return insertFieldNames;
        //}

        //private static IList<string> GetUpdateDbFieldNames(this Type type, out IList<string> condFieldNames)
        //{
        //    var updateFieldNames = new List<string>();
        //    condFieldNames = new List<string>();

        //    var props = type.GetProperties();
        //    foreach (var prop in props)
        //    {
        //        var attribute = (DbFieldAttribute)prop.GetCustomAttributes(typeof(DbFieldAttribute))?.FirstOrDefault();
        //        if (attribute == null)
        //        {
        //            continue;
        //        }

        //        var fieldName = !string.IsNullOrEmpty(attribute.Name) ? attribute.Name : prop.Name;

        //        if (attribute.BuildUpdate)
        //        {
        //            updateFieldNames.Add(fieldName);
        //        }

        //        if (attribute.IsKeyUpdate)
        //        {
        //            condFieldNames.Add(fieldName);
        //        }
        //    }

        //    return updateFieldNames;
        //}

        //private static IList<string> GetDeleteCondFieldNames(this Type type)
        //{
        //    var condFieldNames = new List<string>();

        //    var props = type.GetProperties();
        //    foreach (var prop in props)
        //    {
        //        var attribute = (DbFieldAttribute)prop.GetCustomAttributes(typeof(DbFieldAttribute))?.FirstOrDefault();
        //        if (attribute == null)
        //        {
        //            continue;
        //        }

        //        var fieldName = !string.IsNullOrEmpty(attribute.Name) ? attribute.Name : prop.Name;

        //        if (attribute.IsKeyDelete)
        //        {
        //            condFieldNames.Add(fieldName);
        //        }
        //    }

        //    return condFieldNames;
        //}
    }
}
