using Business.Abstract;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;
        private readonly IValidator<Position> _validator;

        public PositionManager(IPositionDal positionDal, IValidator<Position> validator)
        {
            _positionDal = positionDal;
            _validator = validator;
        }

        public IResult Add(Position entity)
        {
            try { ValidationTool.Validate(_validator, entity); }
            catch (ValidationException ex) { return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage))); }
            _positionDal.Add(entity);
            return new SuccessResult("Position added successfully.");
        }

        public IResult Delete(int id)
        {
            var existing = _positionDal.Get(p => p.Id == id);
            if (existing == null) return new ErrorResult("Position not found.");
            _positionDal.Delete(existing);
            return new SuccessResult("Position deleted successfully.");
        }

        public IDataResult<List<Position>> GetAll()
        {
            var data = _positionDal.GetAll();
            return new SuccessDataResult<List<Position>>(data, "Positions listed successfully.");
        }

        public IDataResult<Position> GetById(int id)
        {
            var entity = _positionDal.Get(p => p.Id == id);
            if (entity == null) return new ErrorDataResult<Position>("Position not found.");
            return new SuccessDataResult<Position>(entity, "Position retrieved successfully.");
        }

        public IResult Update(Position entity)
        {
            try { ValidationTool.Validate(_validator, entity); }
            catch (ValidationException ex) { return new ErrorResult(string.Join("; ", ex.Errors.Select(e => e.ErrorMessage))); }
            var existing = _positionDal.Get(p => p.Id == entity.Id);
            if (existing == null) return new ErrorResult("Position not found.");
            _positionDal.Update(entity);
            return new SuccessResult("Position updated successfully.");
        }
    }
}
