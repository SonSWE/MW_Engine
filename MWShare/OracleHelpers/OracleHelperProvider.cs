namespace OracleHelpers
{
    public static class OracleHelperProvider
    {
        public static IOracleHelper OracleHelper => new OracleHelper2();
    }
}
