﻿using System;
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
        public DateTime? DismissalDate { get; private set; }
        public IEnumerable<EmployeePosition> EmployeePositions { get => employeePositions; }

        private Employee(
            Guid id,
            string firstName,
            string lastName,
            string salary,
            DateTime hireDate,
            DateTime? dismissalDate = null,
            IEnumerable<EmployeePosition> employeePositions = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            HireDate = hireDate;
            DismissalDate = dismissalDate;
            if (employeePositions != null)
            {
                this.employeePositions = new List<EmployeePosition>(employeePositions);
            }
        }

        public Employee(string firstName, string lastName, string salary, DateTime hireDate)
            : this(Guid.NewGuid(), firstName, lastName, salary, hireDate) { }

        public static Employee FromPersistence(
            Guid id,
            string firstName,
            string lastName,
            string salary,
            DateTime hireDate,
            DateTime? dismissalDate,
            IEnumerable<EmployeePosition> employeePositions)
        {
            return new Employee(id, firstName, lastName, salary, hireDate, dismissalDate, employeePositions);
        }
        public void ChangePosition(Position position, DateTime hireDate)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            var lastPosition = GetLastPosition();
            if (lastPosition!=null)
            {
                if (position == lastPosition.Position)
                {
                    throw new InvalidOperationException("Adding same possition is not allowed");
                }
                lastPosition.DismissalDate = hireDate;
            }
            employeePositions.Add(new EmployeePosition(position, hireDate));
        }

        public void DismissalEmployee(DateTime dismissalDate)
        {
            if (dismissalDate<HireDate)
            {
                throw new InvalidOperationException($"Dismissal date should be later than hire date");
            }
            DismissalDate = dismissalDate;
            var lastPosition = GetLastPosition();
            lastPosition.DismissalDate = dismissalDate;
        }

        private EmployeePosition GetLastPosition() => employeePositions.FirstOrDefault(item => item.DismissalDate == null);

    }
}
