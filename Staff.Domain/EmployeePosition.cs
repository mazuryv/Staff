using System;

namespace Staff.Domain
{
    public class EmployeePosition
    {
        public Position Position { get;}
        public DateTime HireDate { get; }
        public DateTime? DismissalDate { get; set; }

        public EmployeePosition(Position position, DateTime hireDate)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            HireDate = hireDate;
        }

        public static EmployeePosition FromPersistence(Position position, DateTime hireDate, DateTime? dismissalDate)
        {
            var employeePosition = new EmployeePosition(position, hireDate)
            {
                DismissalDate = dismissalDate
            };
            return employeePosition;
        }
    }
}