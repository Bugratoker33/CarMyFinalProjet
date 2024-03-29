﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidation: AbstractValidator<Brand>
    {
        public BrandValidation()
        {
            RuleFor(x => x.BrandName).MinimumLength(2).WithMessage("Marka adı en az 2 karakter uzunluğunda olmalıdır.");
        }
    }
}
