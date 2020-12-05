using System;
using System.Collections.Generic;


namespace Staff.Repository.MsSql.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? FireDate { get; set; }
        public ICollection<EmployeePosition> EmployeePositions { get; set; }
    }
}
