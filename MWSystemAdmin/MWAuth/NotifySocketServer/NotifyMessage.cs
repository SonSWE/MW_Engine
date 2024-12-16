namespace MWAuth.NotifySocketServer
{
    public sealed class NotifyMessage
    {
        public string Identify { get; set; } = "";
        public string FunctionId { get; set; } = string.Empty;
        public string FunctionName { get; set; } = string.Empty;
        public string FunctionOther { get; set; } = string.Empty;
        public string Type { get; set; } = "";
        public string Content { get; set; } = "";
    }

    public sealed class NotifyMessageContent
    {
        public string Action { get; set; }
        public List<string> Ids { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
    }
}
