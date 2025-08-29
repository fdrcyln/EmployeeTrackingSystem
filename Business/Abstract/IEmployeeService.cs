using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int id);
        IResult Add(Employee entity);
        IResult Update(Employee entity);
        IResult Delete(int id);
        // New: total employee count
        IDataResult<int> GetCount();
    }
}
