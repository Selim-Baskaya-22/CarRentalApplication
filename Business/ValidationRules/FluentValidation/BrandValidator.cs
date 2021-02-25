using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brands>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandId).NotNull().When(b => b.BrandId == 4);
            RuleFor(b => b.BrandName).NotEmpty();
        }
    }
}
