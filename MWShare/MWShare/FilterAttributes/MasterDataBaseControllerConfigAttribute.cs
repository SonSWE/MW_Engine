namespace MWShare.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class MasterDataBaseControllerConfigAttribute : Attribute
    {
        public MasterDataBaseControllerConfigAttribute(string notifyKey, string profileKeyField)
        {
            NotifyKey = notifyKey;
            ProfileKeyField = profileKeyField;
        }

        public string NotifyKey { get; init; } = string.Empty;
        public string ProfileKeyField { get; init; } = string.Empty;
    }
}
