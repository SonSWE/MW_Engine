using System.Data;

namespace Business.Core.Validators
{
    public class ValidationConfig
    {
        public bool IsCollection { get; set; } = false;
        public string CollectionName { get; set; } = string.Empty;
        public string CollectionPrefix { get; set; } = string.Empty;
        public ValidationAction Action { get; set; } = ValidationAction.None;
        public string Language { get; set; } = string.Empty;
        public string RequestId { get; set; } = string.Empty;
        public IDbTransaction DbTransaction { get; set; }
    }
}
