using Business.Core.Validators;
using CommonLib.Constants;
using FluentValidation;
using MemoryData;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Validators
{
    public class SystemCodeValueValidator : BaseValidator<MWSystemCodeValue>
    {
        public SystemCodeValueValidator() :base() { }

        public SystemCodeValueValidator(ValidationAction action) : base(action)
        {
        }

        public SystemCodeValueValidator(ValidationConfig config) : base(config)
        {
        }

        public SystemCodeValueValidator(ValidationAction action, string language) : base(action, language)
        {
        }

        public override void InitRules()
        {
            RuleFor(x => x.Value).NotEmpty()
               .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ValuesInvalid)
               .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ValuesInvalid, Config.Language))
               .MaximumLength(250)
               .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ValuesInvalid)
               .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ValuesInvalid, Config.Language));
            RuleFor(x => x.Description).NotEmpty()
               .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ContentInvalid)
               .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ContentInvalid, Config.Language))
               .MaximumLength(250)
               .WithErrorCode(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ContentInvalid)
               .WithMessage(DefErrorMem.GetErrorDesc(ErrorCodes.SA_SystemCode.Err_SystemCodeValues_ContentInvalid, Config.Language));
           
        }
    }
}
