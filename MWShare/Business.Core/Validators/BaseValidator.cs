using CommonLib.Constants;
using CommonLib.Extensions;
using FluentValidation;
using FluentValidation.Results;
using MemoryData;
using Object.Core;
using Object.Core.CustomAttributes;
using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Core.Validators
{
    public enum ValidationAction
    {
        None,
        Create,
        Correct,
        Update,
        Delete,
        Import,
        // Using in SaUser
        ChangePass,
        Process
    }

    public class BaseValidator<T> : AbstractValidator<T>
    {
        public ValidationConfig Config = new();
        public LoggedUser LoggedUserInfo { get; set; }
        //
        public BaseValidator()
        {
            InitBaseRules();
            InitRules();
        }
        public BaseValidator(ValidationAction action)
        {
            Config.Action = action;
            InitBaseRules();
            InitRules();
        }
        public BaseValidator(ValidationAction action, string language)
        {
            Config.Action = action;
            Config.Language = language ?? string.Empty;
            InitBaseRules();
            InitRules();
        }
        public BaseValidator(ValidationConfig config)
        {
            Config = config;
            InitBaseRules();
            InitRules();
        }


        // Override lib method
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            if (context.InstanceToValidate is null)
            {
                return new ValidationResult(new[] {
                    new ValidationFailure {
                        ErrorCode = ErrorCodes.Err_DataNull.ToString(),
                        ErrorMessage = BuildCustomMessage("[" +ErrorCodes.Err_DataNull.ToString() + "] - Du lieu khong hop le - null"),
                    }
                });
            }
            return base.Validate(context);
        }
        public override Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is null)
            {
                return Task.FromResult(new ValidationResult(new[] {
                    new ValidationFailure {
                        ErrorCode = ErrorCodes.Err_DataNull.ToString(),
                        ErrorMessage = BuildCustomMessage("[" +ErrorCodes.Err_DataNull.ToString() + "] - Du lieu khong hop le - null"),
                    }
                }));
            }
            return base.ValidateAsync(context, cancellation);
        }

        // Virtual method
        private void InitBaseRules()
        {
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var attributes = prop.GetCustomAttributes(true);
                foreach (var attr in attributes)
                {
                    if (attr is null)
                    {
                        continue;
                    }

                    if (attr is FluentSystemCodeRuleAttribute)
                    {
                        var systemCodeRule = (FluentSystemCodeRuleAttribute)attr;

                        RuleFor(x => x.GetPropertyValue(prop.Name) as string)
                            .Must(p => string.IsNullOrEmpty(p)
                                || SystemCodeMem.IsValidValue(systemCodeRule.SystemCodeId, p))
                            .WithErrorCode(systemCodeRule.ErrorCode)
                            .WithMessage(DefErrorMem.GetErrorDesc(systemCodeRule.ErrorCode, Config.Language));
                    }
                    else if (attr is FluentStringRuleAttribute)
                    {
                        BuildStringBaseRules(prop, (FluentStringRuleAttribute)attr);
                    }
                    else if (attr is FluentNumberRuleAttribute)
                    {
                        BuildNumberBaseRules(prop, (FluentNumberRuleAttribute)attr);
                    }
                }
            }
        }

        private void BuildStringBaseRules(PropertyInfo prop, FluentStringRuleAttribute stringRule)
        {
            //
            if (stringRule.Required)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name) as string)
                    .NotEmpty()
                    .WithErrorCode(stringRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(stringRule.ErrorCode, Config.Language));
            }

            //
            if (stringRule.Len is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name) as string)
                    .Length((int)stringRule.Len, (int)stringRule.Len)
                    .WithErrorCode(stringRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(stringRule.ErrorCode, Config.Language));
            }

            //
            if (stringRule.MinLen is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name) as string)
                    .MinimumLength((int)stringRule.MinLen)
                    .WithErrorCode(stringRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(stringRule.ErrorCode, Config.Language));
            }

            //
            if (stringRule.MaxLen is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name) as string)
                    .MinimumLength((int)stringRule.MaxLen)
                    .WithErrorCode(stringRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(stringRule.ErrorCode, Config.Language));
            }

            //
            if (!string.IsNullOrWhiteSpace(stringRule.Regex))
            {
                RuleFor(x => x.GetPropertyValue(prop.Name) as string)
                    .Matches(stringRule.Regex)
                    .WithErrorCode(stringRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(stringRule.ErrorCode, Config.Language));
            }
        }

        private void BuildNumberBaseRules(PropertyInfo prop, FluentNumberRuleAttribute numberRule)
        {
            //
            if (numberRule.Required)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .NotEmpty()
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }

            //
            if (numberRule.Equal is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .Must(p =>
                    {
                        var comparer = GetComparable(p.GetType());
                        return comparer.CompareTo(numberRule.Equal) == 0;
                    })
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }

            //
            if (numberRule.NotEqual is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .Must(p =>
                    {
                        var comparer = GetComparable(p.GetType());
                        return comparer.CompareTo(numberRule.NotEqual) != 0;
                    })
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }

            //
            if (numberRule.LessThan is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .Must(p =>
                    {
                        var comparer = GetComparable(p.GetType());
                        return comparer.CompareTo(numberRule.LessThan) < 0;
                    })
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }

            //
            if (numberRule.GreaterThan is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .Must(p =>
                    {
                        var comparer = GetComparable(p.GetType());
                        return comparer.CompareTo(numberRule.GreaterThan) > 0;
                    })
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }

            //
            if (numberRule.LessThanOrEqual is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .Must(p =>
                    {
                        var comparer = GetComparable(p.GetType());
                        return comparer.CompareTo(numberRule.LessThanOrEqual) <= 0;
                    })
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }

            //
            if (numberRule.GreaterThanOrEqual is not null)
            {
                RuleFor(x => x.GetPropertyValue(prop.Name))
                    .Must(p =>
                    {
                        var comparer = GetComparable(p.GetType());
                        return comparer.CompareTo(numberRule.GreaterThanOrEqual) >= 0;
                    })
                    .WithErrorCode(numberRule.ErrorCode)
                    .WithMessage(DefErrorMem.GetErrorDesc(numberRule.ErrorCode, Config.Language));
            }
        }

        public virtual void InitRules()
        {
        }

        public bool CheckDOB(DateTime? dateOfBirth)
        {
            var dateOfBirthValue = dateOfBirth.GetValueOrDefault();

            return dateOfBirthValue.Date != DateTime.MinValue.Date && dateOfBirthValue.Date <= DateTime.Now;
        }
        public bool CheckIdDate(DateTime? dateOfBirth, DateTime? idDate)
        {
            var dateOfBirthValue = dateOfBirth.GetValueOrDefault();
            var idDateValue = idDate.GetValueOrDefault();

            return idDateValue.Date != DateTime.MinValue.Date && idDateValue.Date >= dateOfBirthValue.Date && idDateValue.Date <= DateTime.Now;
        }
        public bool CheckDate(DateTime? dateStart, DateTime? dateEnd)
        {
            var dateStartValue = dateStart.GetValueOrDefault();
            var dateEndValue = dateEnd.GetValueOrDefault();

            return dateEndValue.Date >= dateStartValue.Date;
        }
        public bool CheckMobile(string mobile) => !string.IsNullOrEmpty(mobile) && mobile.Length >= 10;
        public bool IsDateNumber(int dateInNumber) => dateInNumber == 0 || Regex.IsMatch($"{dateInNumber}", "^[0-9]{8}$");
        public bool IsDateNumber(string dateInNumber) => string.IsNullOrEmpty(dateInNumber) || Regex.IsMatch($"{dateInNumber}", "^[0-9]{8}$");

        public bool RuleLevelCascadeModeIsStop => RuleLevelCascadeMode == CascadeMode.Stop;
        public bool ClassLevelCascadeModeIsContinue => ClassLevelCascadeMode == CascadeMode.Continue;

        //
        public string BuildCustomMessage(string errorMessage)
        {
            StringBuilder builder = new();

            if (Config != null && !string.IsNullOrEmpty(Config.CollectionPrefix))
            {
                builder.Append(Config.CollectionPrefix + " - ");
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                builder.Append(errorMessage);
            }

            return builder.ToString();
        }

        #region Private functions

        private IComparable GetComparable(Type type)
        {
            return typeof(IComparable<>).MakeGenericType(type).GetProperty("Default", BindingFlags.Public | BindingFlags.Static).GetValue(null) as IComparable;
        }

        #endregion
    }
}
