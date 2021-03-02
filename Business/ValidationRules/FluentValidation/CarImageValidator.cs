using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator: AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ı => ı.ImagePath).GreaterThan("").WithMessage("Resim alanı boş bırakılamaz");
            RuleFor(c => c.CarId).NotNull();
            RuleFor(c => c.ImageId).NotNull();
        }
    }
}
