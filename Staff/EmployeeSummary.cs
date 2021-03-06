using Staff.Domain;
using System;
using System.Linq;

namespace Staff
{
    public class EmployeeSummary
    {
        public string Id { get; set; }
        public string Position { get; set; }
        public string FullName { get; set; }
        public string Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalDate { get; set; }

        public static EmployeeSummary FromDomain(Employee employee)
        {
            var currentPosition = employee.EmployeePositions
                    .Where(position => employee.DismissalDate.HasValue ? position.DismissalDate == employee.DismissalDate : position.DismissalDate == null)
                    .OrderBy(position => position.HireDate)
                    .LastOrDefault()?.Position.Description;

            return new EmployeeSummary
            {
                Id = employee.Id.ToString(),
                FullName = $"{employee.LastName} {employee.FirstName}",
                Salary = employee.Salary,
                Position = currentPosition,
                DismissalDate = employee.DismissalDate,
                HireDate = employee.HireDate
            };
        }
    }
}
