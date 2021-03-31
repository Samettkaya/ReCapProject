using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {

        public CarValidator()
        {
           
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage("Araç adı en az 2 karekter den büyük olmalıdır.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük fiyatı 0'dan büyük olmalı.");
            RuleFor(c => c.ModelYear).GreaterThan(0).WithMessage("Model yılı boş bırakılamaz.");
            RuleFor(c => c.Description).MinimumLength(10).WithMessage("Araç açıklaması en az 10 karekter uzunluğun da olmalı. ");
            
        }

      
    }
}
