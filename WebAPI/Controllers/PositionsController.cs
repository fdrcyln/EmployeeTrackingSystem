using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;
        public PositionsController(IPositionService positionService) => _positionService = positionService;

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _positionService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _positionService.GetById(id);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Position position)
        {
            var result = _positionService.Add(position);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Position position)
        {
            var result = _positionService.Update(position);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _positionService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
