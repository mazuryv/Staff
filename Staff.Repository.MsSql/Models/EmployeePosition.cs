using System;
using System.Collections.Generic;
using System.Text;

namespace Staff.Repository.MsSql.Models
{
    public class EmployeePosition
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Position Position { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
