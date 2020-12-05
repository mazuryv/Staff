using System;
using System.Collections.Generic;
using System.Text;

namespace Staff.Repository.MsSql.Models
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
