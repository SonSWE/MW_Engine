namespace CommonLib
{
    public sealed class LdapConfig
    {
        public LdapConfig()
        {
        }

        public LdapConfig(string domain, int port, string user, string password, string searchRegion, string searchAttribute, string getAttributes, string useSSL)
        {
            this.Domain = domain?.Trim();
            this.Port = port;
            this.User = user?.Trim();
            this.Password = password?.Trim();
            this.SearchRegion = searchRegion?.Trim();
            this.SearchAttribute = searchAttribute?.Trim();
            this.GetAttributes = getAttributes?.Trim();
            this.UseSSL = string.Equals(useSSL, "Y", System.StringComparison.OrdinalIgnoreCase);
        }

        public string Domain { get; }
        public int Port { get; }
        public string User { get; }
        public string Password { get; }
        public string SearchRegion { get; }
        public string SearchAttribute { get; }
        public string GetAttributes { get; }
        public bool UseSSL { get; }
    }
}
