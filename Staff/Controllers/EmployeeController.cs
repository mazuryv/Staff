using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeSummary> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new EmployeeSummary
            {
                Position = "Test1",
                FullName = "Employee",
                Salary = "100$",
                HireDate = DateTime.Now.Date.AddDays(-index)
            })
            .ToArray();
        }
    }
}
