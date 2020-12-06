using Staff.Domain;
using System;
using System.Linq;

namespace Staff
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string PositionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? FireDate { get; set; }
    }
}
