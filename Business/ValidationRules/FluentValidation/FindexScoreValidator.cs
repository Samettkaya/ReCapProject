using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FindexScoreValidator : AbstractValidator<FindexScore>
    {
        public FindexScoreValidator()
        {
            RuleFor(b => b.CustomerId).NotEmpty();
            RuleFor(b => b.Score).ExclusiveBetween(0, 1901);
        }
    }
}
