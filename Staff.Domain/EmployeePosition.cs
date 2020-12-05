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
    }
}