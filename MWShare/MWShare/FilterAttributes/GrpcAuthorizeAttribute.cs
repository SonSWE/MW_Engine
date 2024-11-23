namespace MWShare.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class GrpcAuthorizeAttribute : Attribute
    {
        public bool IsCheckUrl { get; set; } = true;
        public string HttpUrl { get; set; } = string.Empty;
        public string GrpcUrl { get; set; } = string.Empty;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class GrpcFunctionAuthorizeAttribute : Attribute
    {
        public bool CheckFunction { get; set; } = true;
        public string FunctionId { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
    }
}
