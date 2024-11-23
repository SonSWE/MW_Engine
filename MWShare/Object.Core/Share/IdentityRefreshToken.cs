using System;


namespace Object.Core.Share
{
    public class IdentityRefreshToken
    {
        public string Identity { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime IssueTimeUtc { get; set; }
        public DateTime ExpiryTimeUtc { get; set; }
        public bool IsExpired { get { return DateTime.UtcNow >= ExpiryTimeUtc; } }
    }
}
