using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeAssignmentService
    {
        IDataResult<List<EmployeeAssignment>> GetAll();
        IDataResult<EmployeeAssignment> GetById(int id);
        IResult Add(EmployeeAssignment entity);
        IResult Update(EmployeeAssignment entity);
        IResult Delete(int id);
        IDataResult<List<EmployeeAssignmentDetailDTO>> GetDetails();
        IResult AddOrReplaceActive(EmployeeAssignment entity); // closes previous active if exists
    }
}
