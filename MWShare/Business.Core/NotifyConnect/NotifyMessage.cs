namespace Business.Core
{
    public sealed class NotifyMessage
    {
        public string Identify { get; set; } = "";
        public string FunctionId { get; set; } = string.Empty;
        public string Type { get; set; } = "";
        public string Content { get; set; } = "";
    }
}
