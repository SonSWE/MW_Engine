using Business.Core.Validators;
using CommonLib.Constants;
using CommonLib.Extensions;
using FluentValidation;
using FluentValidation.Results;
using MemoryData;
using Microsoft.Identity.Client;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Validators
{
    public class SysParamValidator : BaseValidator<MWSysParam>
    {
        public SysParamValidator() : base()
        {
        }

        public SysParamValidator(ValidationAction action) : base(action)
        {
        }

        public SysParamValidator(ValidationConfig config) : base(config)
        {
        }

        public SysParamValidator(ValidationAction action, string language) : base(action, language)
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
        }
    }
}
