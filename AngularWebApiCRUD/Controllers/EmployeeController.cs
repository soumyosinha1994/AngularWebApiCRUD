using AngularWebApiCRUD.DTO;
using AngularWebApiCRUD.IService;
using AngularWebApiCRUD.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApiCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model)
        {
            await _employeeService.AddEmployee(_mapper.Map<EmployeeDTO>(model));
            _employeeService.save();
            return Ok();
        }
        //[HttpGet("{id}")]
        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployee([FromQuery] int id)
        {
          var Employee=  await _employeeService.GetEmployee(x=>x.Id==id);
            return Ok(Employee);
        }
        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            var Employee = await _employeeService.GetAllEmployee();
            return Ok(Employee);
        }
        //[HttpPut("UpdateEmployee/{id}")]
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee([FromQuery] int id, [FromBody] Employee model)
        {
            var Employee = await _employeeService.GetEmployee(x => x.Id == id,true);
            if (Employee != null) {
                model.Id = Employee.Id;
                await _employeeService.UpdateEmployee(_mapper.Map<EmployeeDTO>(model));
                _employeeService.save();
            }
            
            return Ok();
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee([FromQuery] int id,[FromBody] Employee model)
        {
            var Employee = await _employeeService.GetEmployee(x => x.Id == id, true);
            if (Employee != null)
            {
                model.Id = Employee.Id;
                await _employeeService.DeleteEmployee(_mapper.Map<EmployeeDTO>(model));
                _employeeService.save();
            }

            return Ok();
        }
        [HttpPost("AddUpdateEmployee")]
        public async Task<ActionResult> AddUpdateEmployee([FromQuery] int id, [FromBody] Employee model)
        {
            var Employee = await _employeeService.GetEmployee(x => x.Id == id, true);

            if (Employee != null)
            {
                model.Id = Employee.Id;
                await _employeeService.UpdateEmployee(_mapper.Map<EmployeeDTO>(model));
            }
            else
            {
                await _employeeService.AddEmployee(_mapper.Map<EmployeeDTO>(model));
            }
            _employeeService.save();
            return Ok();
        }
    }
}
