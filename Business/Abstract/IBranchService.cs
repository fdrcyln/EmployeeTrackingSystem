using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<List<Branch>> GetAll();
        IDataResult<List<Branch>> GetAllByBranchId(int id);
        IResult Add(Branch branch);
        IDataResult<List<Branch>> GetAllByName(string name);
        IDataResult<List<Branch>> GetAllById(int id);
        IDataResult<Branch> GetById(int id);
       
        IResult Update(Branch branch);
        IResult Delete(int id);
    }
}
