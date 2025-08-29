using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionService
    {
        IDataResult<List<Position>> GetAll();
        IDataResult<Position> GetById(int id);
        IResult Add(Position entity);
        IResult Update(Position entity);
        IResult Delete(int id);
    }
}
