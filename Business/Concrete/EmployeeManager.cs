using Business.Abstract;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly IValidator<Employee> _employeeValidator;

        public EmployeeManager(IEmployeeDal employeeDal,IValidator<Employee> employeeValidator)
        {
            _employeeDal = employeeDal; 
            _employeeValidator = employeeValidator;
        }
        public IResult Add(Employee entity)
        {
            try
            {
                ValidationTool.Validate(_employeeValidator, entity);
                _employeeDal.Add(entity);
                return new SuccessResult("Employee added successfully.");
            }
            catch (ValidationException ex)
            {
                return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            }
            
        }

        public IResult Delete(int id)
        {
            _employeeDal.Delete(new Employee { Id = id });
            return new SuccessResult("Employee deleted successfully.");
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), "Employees listed successfully.");
        }

        public IDataResult<Employee> GetById(int id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.Id == id), "Employee retrieved successfully.");
        }

        public IResult Update(Employee entity)
        {
            try
            {
                ValidationTool.Validate(_employeeValidator, entity);
            }
            catch (ValidationException ex)
            {
                return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage)));
            }
            _employeeDal.Update(entity);
            return new SuccessResult("Employee updated successfully.");
        }

        public IDataResult<int> GetCount()
        {
            var count = _employeeDal.GetAll().Count; 
            return new SuccessDataResult<int>(count, "Employee count retrieved successfully.");
        }
    }
}
