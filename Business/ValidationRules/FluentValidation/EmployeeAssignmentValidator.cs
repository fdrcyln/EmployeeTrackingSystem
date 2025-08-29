using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeAssignmentValidator : AbstractValidator<EmployeeAssignment>
    {
        public EmployeeAssignmentValidator()
        {
            RuleFor(a => a.EmployeeId)
                .GreaterThan(0).WithMessage("EmployeeId must be greater than 0");

            RuleFor(a => a.DepartmentId)
                .GreaterThan(0).WithMessage("DepartmentId must be greater than 0");

            RuleFor(a => a.PositionId)
                .GreaterThan(0).WithMessage("PositionId must be greater than 0");

            RuleFor(a => a.HireDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("HireDate cannot be in the future");

            RuleFor(a => a)
                .Must(a => a.TerminationDate == null || a.TerminationDate >= a.HireDate)
                .WithMessage("TerminationDate cannot be earlier than HireDate");
        }
    }
}
