using System;
using System.Collections.Generic;
using System.Linq;

namespace Staff.Domain
{
    public class Employee
    {
        private readonly List<EmployeePosition> employeePositions = new List<EmployeePosition>();
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
        public DateTime HireDate { get; }
        public DateTime? FireDate { get; private set; }
        public IEnumerable<EmployeePosition> EmployeePositions { get => employeePositions; }

        public Employee(string firstName, string lastName, string salary, DateTime hireDate)
        {
            Id = new Guid();
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            HireDate = hireDate;
        }

        public void ChangePosition(Position position, DateTime hireDate)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            var lastPosition = GetLastPosition();
            if (position == lastPosition.Position)
            {
                throw new InvalidOperationException("Adding same possition is not allowed");
            }
            lastPosition.FireDate = hireDate;
            employeePositions.Add(new EmployeePosition(position, hireDate));
        }

        public void FireEmployee(DateTime fireDate)
        {
            FireDate = fireDate;
            var lastPosition = GetLastPosition();
            lastPosition.FireDate = fireDate;
        }

        private EmployeePosition GetLastPosition() => employeePositions.FirstOrDefault(item => item.FireDate == null);

    }
}
