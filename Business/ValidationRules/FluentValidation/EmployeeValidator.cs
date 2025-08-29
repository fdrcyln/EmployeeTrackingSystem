using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeValidator(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;

            RuleFor(e => e.NationalId)
                .NotEmpty().WithMessage("National ID cannot be empty")
                .Length(11).WithMessage("National ID must be exactly 11 characters long")
                .Matches("^[0-9]{11}$").WithMessage("National ID must contain only digits")
                .Must((employee, nationalId) => IsNationalIdUnique(employee, nationalId))
                .WithMessage("National ID already exists");
        }

        private bool IsNationalIdUnique(Employee employee, string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId)) return true; // other rules handle emptiness/format
            var existing = _employeeDal.Get(e => e.NationalId == nationalId);
            // Allow if not found or it's the same record during update
            return existing == null || existing.Id == employee.Id;
        }
    }
}
