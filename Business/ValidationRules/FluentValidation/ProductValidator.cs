using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator(IBranchDal branchDal)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Branch name cannot be empty")
                .MinimumLength(2).WithMessage("Branch name must be at least 2 characters long")
                .MaximumLength(50).WithMessage("Branch name must not exceed 50 characters")
                .Must((branch, name) => IsNameUnique(branchDal, branch, name))
                .WithMessage("Branch name already exists");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Branch address cannot be empty")
                .MinimumLength(5).WithMessage("Branch address must be at least 5 characters long")
                .MaximumLength(200).WithMessage("Branch address must not exceed 200 characters");
        }

        private bool IsNameUnique(IBranchDal branchDal, Branch current, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return true; // handled by NotEmpty
            var existing = branchDal.Get(b => b.Name == name);
            return existing == null || existing.Id == current.Id; // allow same record when updating
        }
    }
}
