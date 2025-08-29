using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.CrossCuttingConcerns;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        private readonly IValidator<Department> _validator;
        public DepartmentManager(IDepartmentDal departmentDal, IValidator<Department> validator)
        {
            _departmentDal = departmentDal;
            _validator = validator;
        }

        public IResult Add(Department entity)
        {
            try
            {
                ValidationTool.Validate(_validator, entity);
            }
            catch (ValidationException ex)
            {
                return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            }
            _departmentDal.Add(entity);
            return new SuccessResult("Department added successfully.");
        }

        public IResult Delete(int id)
        {
            _departmentDal.Delete(new Department { Id = id });
            return new SuccessResult("Department deleted successfully.");
        }

        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(), "Departments listed successfully.");
        }

        public IDataResult<Department> GetById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(d => d.Id == id), "Department retrieved successfully.");
        }

        public IResult Update(Department entity)
        {
            try
            {
                ValidationTool.Validate(_validator, entity);
            }
            catch (ValidationException ex)
            {
                return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            }
            _departmentDal.Update(entity);
            return new SuccessResult("Department updated successfully.");
        }
    }
}
