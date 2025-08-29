using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;
        private readonly IValidator<Branch> _branchValidator;

        public BranchManager(IBranchDal branchDal, IValidator<Branch> branchValidator)
        {
            _branchDal = branchDal;
            _branchValidator = branchValidator;
        }
        public IDataResult<List<Branch>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Branch>>(Messages.InvalidDate);
            }

            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(), "Ürünler listelendi");
        }
        public IResult Add(Branch branch)
        {
            try
            {
                ValidationTool.Validate(_branchValidator, branch);
            }
            catch (ValidationException ex)
            {
                return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            }

            _branchDal.Add(branch);

            return new SuccessResult(Messages.BranchAdded);
        }

        public IDataResult<List<Branch>> GetAllById(int id)
        {
            return new DataResult<List<Branch>>(_branchDal.GetAll(), true, "Listelendi");
        }

        public IDataResult<List<Branch>> GetAllByBranchId(int id)
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => b.Id == id), "Branch listelendi");
        }

        public IDataResult<List<Branch>> GetAllByName(string name)
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => b.Name.Contains(name)), "Branch isme göre listelendi");
        }

        IDataResult<List<Branch>> IBranchService.GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(), "Branches listed successfully");
        }

        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(b => b.Id == id), "Sıkıntı Yok babajum");
        }

        // Added Update implementation
        public IResult Update(Branch branch)
        {
            try
            {
                ValidationTool.Validate(_branchValidator, branch);
            }
            catch (ValidationException ex)
            {
                return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            }
            _branchDal.Update(branch);
            return new SuccessResult(Messages.BranchUpdated);
        }

        // Added Delete implementation
        public IResult Delete(int id)
        {
            _branchDal.Delete(new Branch { Id = id });
            return new SuccessResult(Messages.BranchDeleted);
        }
    }
}
