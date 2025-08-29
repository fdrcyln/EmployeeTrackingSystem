using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Department name cannot be empty")
                .MinimumLength(2).WithMessage("Department name must be at least 2 characters")
                .MaximumLength(100).WithMessage("Department name must not exceed 100 characters");
        }
    }
}
