namespace Object.Core.Configs
{
    public sealed class BOConnectApiConfig
    {
        public const string AppsettingsKey = "BOConnectApiConfig";
        public const string HttpClientName = "BOConnectApi";

        public bool ConnectEnabled { get; init; }
        public string BaseAddress { get; init; }
        public string SecretKey { get; init; }
    }
}
