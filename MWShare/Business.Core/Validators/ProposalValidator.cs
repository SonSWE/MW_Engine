using Business.Core.Validators;
using CommonLib.Constants;
using CommonLib.Extensions;
using FluentValidation;
using FluentValidation.Results;
using MemoryData;
using Microsoft.Identity.Client;
using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Validators
{
    public class ProposalValidator : BaseValidator<MWProposal>
    {
        public ProposalValidator() : base()
        {
        }

        public ProposalValidator(ValidationAction action) : base(action)
        {
        }

        public ProposalValidator(ValidationConfig config) : base(config)
        {
        }

        public ProposalValidator(ValidationAction action, string language) : base(action, language)
        {
        }

        public override void InitRules()
        {
            //RuleFor(x => x.SystemCodeId).NotEmpty()
            //   .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeId_Invalid)
            //   .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeId_Invalid, Config.Language));

            //RuleFor(x => x.Name).NotEmpty()
            //   .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeDescription_Invalid)
            //   .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeDescription_Invalid, Config.Language))
            //   .MaximumLength(250)
            //   .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeDescription_Invalid)
            //   .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeDescription_Invalid, Config.Language));

            //RuleFor(x => x.SystemCodeValues).Must((obj, SystemCodeValues, context) =>
            //{
            //    SystemCodeValueValidator valueValidator = new SystemCodeValueValidator(this.Config)
            //    {
            //        ClassLevelCascadeMode = this.ClassLevelCascadeMode,
            //        RuleLevelCascadeMode = this.RuleLevelCascadeMode,
            //    };
            //    if (SystemCodeValues != null)
            //    {
            //        for (int i = 0; i < SystemCodeValues.Count; i++)
            //        {
            //            var validateResult = valueValidator.Validate(SystemCodeValues[i]);
            //            if (!validateResult.IsValid)
            //            {
            //                var firstError = validateResult.Errors[0];

            //                context.AddFailure(new ValidationFailure
            //                {
            //                    PropertyName = $"positionlimitGroupDetail[{i}].{firstError.PropertyName?.ToCamelCase()}",
            //                    ErrorCode = firstError.ErrorCode,
            //                    ErrorMessage = $"{firstError.ErrorMessage}",
            //                });

            //                //
            //                if (this.ClassLevelCascadeMode != CascadeMode.Continue)
            //                    break;
            //            }
            //        }

            //    }
            //    return true;
            //});
        }
    }
}
