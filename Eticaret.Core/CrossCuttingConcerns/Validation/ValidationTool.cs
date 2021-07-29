using System;
using System.Collections.Generic;
using System.Text;
using Eticaret.Core.Entities;
using FluentValidation;

namespace Eticaret.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }

}
