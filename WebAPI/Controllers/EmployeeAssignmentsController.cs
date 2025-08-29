using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAssignmentsController : ControllerBase
    {
        private readonly IEmployeeAssignmentService _employeeAssignmentService;

        public EmployeeAssignmentsController(IEmployeeAssignmentService employeeAssignmentService)
        {
            _employeeAssignmentService = employeeAssignmentService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeAssignmentService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetDetails")]
        public IActionResult GetDetails()
        {
            var result = _employeeAssignmentService.GetDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _employeeAssignmentService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(EmployeeAssignment employeeAssignment)
        {
            var result = _employeeAssignmentService.Add(employeeAssignment);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("AddOrReplaceActive")]
        public IActionResult AddOrReplaceActive(EmployeeAssignment employeeAssignment)
        {
            var result = _employeeAssignmentService.AddOrReplaceActive(employeeAssignment);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(EmployeeAssignment employeeAssignment)
        {
            var result = _employeeAssignmentService.Update(employeeAssignment);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _employeeAssignmentService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
