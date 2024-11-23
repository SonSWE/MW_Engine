namespace DapperLib.LinQToSql.Core
{
    public class ConfigDapper
    {
        public static string PREFIXPARM = ":";
        public static TypeDB TYPEDB = TypeDB.Postgreesql;
    }

    public enum TypeDB
    {
        Mysql,
        Postgreesql,
        Oracle
    }
}
