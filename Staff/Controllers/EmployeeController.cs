using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Staff.Domain;
using Staff.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Staff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IPositionRepository positionRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository, IPositionRepository positionRepository)
        {
            this.logger = logger;
            this.employeeRepository = employeeRepository;
            this.positionRepository = positionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeSummary>> Get()
        {
            var employees = await employeeRepository.GetAsync();
            return employees.Select(domain => EmployeeSummary.FromDomain(domain));
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmployeeDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.FirstName) 
                || string.IsNullOrEmpty(employeeDto.LastName)
                || string.IsNullOrEmpty(employeeDto.Salary)
                || string.IsNullOrEmpty(employeeDto.PositionId)
                || !Guid.TryParse(employeeDto.PositionId, out var positionId)
                || employeeDto.HireDate == null)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }
            var position = await positionRepository.GetAsync(positionId);
            if (position == null)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity,$"Position with id {employeeDto.PositionId} was not found");
            }

            var employee = new Employee(employeeDto.FirstName, employeeDto.LastName, employeeDto.Salary, employeeDto.HireDate.Value);
            employee.ChangePosition(position, employeeDto.HireDate.Value);
            if (employeeDto.FireDate.HasValue)
            {
                employee.FireEmployee(employeeDto.FireDate.Value);
            }
            await employeeRepository.InsertAsync(employee);
            
            return CreatedAtAction(
                nameof(Get),
                new { id = employee.Id.ToString() },
                EmployeeSummary.FromDomain(employee));
        }
    }
}
