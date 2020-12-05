using System;
using System.Collections.Generic;
using System.Linq;

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

        public Staff.Domain.Employee ToDomain()
        {
            var employeePositions = EmployeePositions
                .Select(position => Domain.EmployeePosition.FromPersistence(
                    Domain.Position.FromPersistence(position.Position.Id, position.Position.Description), 
                    position.HireDate, 
                    position.FireDate));
            return Domain.Employee.FromPersistence(Id, FirstName, LastName, Salary, HireDate, FireDate, employeePositions);
        }
    }
}
