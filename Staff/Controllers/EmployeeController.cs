using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Staff.Repository;
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
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            this.logger = logger;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeSummary>> Get()
        {
            var employees = await employeeRepository.GetAsync();
            return employees.Select(domain => EmployeeSummary.FromDomain(domain));
        }
    }
}
