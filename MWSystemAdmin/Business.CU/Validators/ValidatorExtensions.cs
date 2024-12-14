using Business.Core.Validators;
using FluentValidation;
using System.Text;

namespace Business.Core.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithCodeAndMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, BaseValidator<T> validator, int errorCode, string errorMessage)
        {

            if (rule != null)
            {
                StringBuilder builder = new();

                if (validator.Config != null && !string.IsNullOrEmpty(validator.Config.CollectionPrefix))
                {
                    builder.Append(validator.Config.CollectionPrefix + " - ");
                }

                builder.Append($"[{errorCode}] - ");

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    builder.Append(errorMessage);
                }

                rule.WithErrorCode(errorCode.ToString()).WithMessage(builder.ToString());
            }

            return rule;
        }
        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, long errorCode)
        {
            rule.WithErrorCode(errorCode.ToString());
            return rule;
        }
    }
}
