using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Position name cannot be empty")
                .MinimumLength(2).WithMessage("Position name must be at least 2 characters")
                .MaximumLength(100).WithMessage("Position name must not exceed 100 characters");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MinimumLength(5).WithMessage("Description must be at least 5 characters")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

            RuleFor(p => p.DepartmantId)
                .GreaterThan(0).WithMessage("DepartmantId must be a positive id");
        }
    }
}
