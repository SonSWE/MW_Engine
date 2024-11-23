namespace MWAuth.Models
{
    public sealed class VerifyTokenModel
    {
        public string Token { get; set; } = string.Empty;
        public string RequestUrl { get; set; } = string.Empty;
    }

    public sealed class VerifyTokenAndFunctionModel
    {
        public string Token { get; set; } = string.Empty;
        public string FunctionId { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public bool CheckFunction { get; set; } = true;
        public string CheckMode { get; set; } = string.Empty;
    }

    public sealed class VerifyFunctionModel
    {
        public string UserName { get; set; } = string.Empty;
        public string FunctionId { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string CheckMode { get; set; } = string.Empty;
    }
}
