using Business.Abstract;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeAssignmentManager : IEmployeeAssignmentService
    {
        private readonly IEmployeeAssignmentDal _employeeAssignmentDal;
        private readonly IValidator<EmployeeAssignment> _validator;

        public EmployeeAssignmentManager(IEmployeeAssignmentDal employeeAssignmentDal, IValidator<EmployeeAssignment> validator)
        {
            _employeeAssignmentDal = employeeAssignmentDal;
            _validator = validator;
        }

        public IResult Add(EmployeeAssignment entity)
        {
            try { ValidationTool.Validate(_validator, entity); }
            catch (ValidationException ex) { return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage))); }
            _employeeAssignmentDal.Add(entity);
            return new SuccessResult("Employee assignment added successfully.");
        }

        public IResult AddOrReplaceActive(EmployeeAssignment entity)
        {
            try { ValidationTool.Validate(_validator, entity); }
            catch (ValidationException ex) { return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage))); }

            // Close existing active
            var active = _employeeAssignmentDal.Get(a => a.EmployeeId == entity.EmployeeId && a.TerminationDate == null);
            if (active != null)
            {
                active.TerminationDate = entity.HireDate.AddDays(-1) < entity.HireDate ? entity.HireDate.AddDays(-1) : entity.HireDate;
                _employeeAssignmentDal.Update(active);
            }
            _employeeAssignmentDal.Add(entity);
            return new SuccessResult("Employee new assignment created (previous closed if existed).");
        }

        public IResult Delete(int id)
        {
            var existing = _employeeAssignmentDal.Get(e => e.Id == id);
            if (existing == null)
                return new ErrorResult("Employee assignment not found.");
            _employeeAssignmentDal.Delete(existing);
            return new SuccessResult("Employee assignment deleted successfully.");
        }

        public IDataResult<List<EmployeeAssignment>> GetAll()
        {
            var data = _employeeAssignmentDal.GetAll();
            return new SuccessDataResult<List<EmployeeAssignment>>(data, "Employee assignments retrieved successfully.");
        }

        public IDataResult<EmployeeAssignment> GetById(int id)
        {
            var entity = _employeeAssignmentDal.Get(e => e.Id == id);
            if (entity == null)
                return new ErrorDataResult<EmployeeAssignment>("Employee assignment not found.");
            return new SuccessDataResult<EmployeeAssignment>(entity, "Employee assignment retrieved successfully.");
        }

        public IDataResult<List<EmployeeAssignmentDetailDTO>> GetDetails()
        {
            var list = _employeeAssignmentDal.GetAssignmentDetails();
            return new SuccessDataResult<List<EmployeeAssignmentDetailDTO>>(list, "Assignment details listed.");
        }

        public IResult Update(EmployeeAssignment entity)
        {
            try { ValidationTool.Validate(_validator, entity); }
            catch (ValidationException ex) { return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage))); }
            var existing = _employeeAssignmentDal.Get(e => e.Id == entity.Id);
            if (existing == null)
                return new ErrorResult("Employee assignment not found.");
            _employeeAssignmentDal.Update(entity);
            return new SuccessResult("Employee assignment updated successfully.");
        }
    }
}
