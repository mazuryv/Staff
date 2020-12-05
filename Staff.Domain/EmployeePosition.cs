using System;

namespace Staff.Domain
{
    public class EmployeePosition
    {
        public Position Position { get;}
        public DateTime HireDate { get; }
        public DateTime? FireDate { get; set; }

        public EmployeePosition(Position position, DateTime hireDate)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            HireDate = hireDate;
        }

        public static EmployeePosition FromPersistence(Position position, DateTime hireDate, DateTime? fireDate)
        {
            var employeePosition = new EmployeePosition(position, hireDate);
            employeePosition.FireDate = fireDate;
            return employeePosition;
        }
    }
}