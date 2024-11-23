using System;

namespace Object.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class FluentAllcodeRuleAttribute : System.Attribute
    {
        public FluentAllcodeRuleAttribute(string cdType, string cdCode, string errorCode = null)
        {
            CdType = cdType;
            CdType = cdCode;
            ErrorCode = errorCode;
        }

        public string CdType { get; init; }
        public string CdCode { get; init; }
        //
        public string ErrorCode { get; init; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class FluentSystemCodeRuleAttribute : System.Attribute
    {
        public FluentSystemCodeRuleAttribute(string systemCodeId, string errorCode = null)
        {
            SystemCodeId = systemCodeId;
            ErrorCode = errorCode;
        }

        public string SystemCodeId { get; init; }
        //
        public string ErrorCode { get; init; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class FluentStringRuleAttribute : System.Attribute
    {
        public bool Required { get; init; } = false;
        public int? Len { get; init; }
        public int? MinLen { get; init; }
        public int? MaxLen { get; init; }
        public string Regex { get; init; }
        //
        public string ErrorCode { get; init; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class FluentNumberRuleAttribute : System.Attribute
    {
        public bool Required { get; init; } = false;
        public object Equal { get; set; }
        public object NotEqual { get; set; }
        public object LessThan { get; set; }
        public object GreaterThan { get; set; }
        public object LessThanOrEqual { get; set; }
        public object GreaterThanOrEqual { get; set; }
        //
        public string ErrorCode { get; init; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class FluentDateRuleAttribute : System.Attribute
    {
        public bool Required { get; init; } = false;
        public object Equal { get; set; }
        public object NotEqual { get; set; }
        public object LessThan { get; set; }
        public object GreaterThan { get; set; }
        public object LessThanOrEqual { get; set; }
        public object GreaterThanOrEqual { get; set; }
        //
        public string ErrorCode { get; init; }
    }
}
