namespace Object.Core.Configs
{
    public sealed class BOConnectBankApiConfig
    {
        public const string AppsettingsKey = "BOConnectBankApiConfig";
        public const string HttpClientName = "BOConnectBankApi";

        public bool ConnectEnabled { get; init; }
        public string BaseAddress { get; init; }
        public string SecretKey { get; init; }
    }
}
