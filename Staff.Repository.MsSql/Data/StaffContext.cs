using Microsoft.EntityFrameworkCore;
using Staff.Repository.MsSql.Models;

namespace Staff.Repository.MsSql.Data
{
    public class StaffContext : DbContext
    {
        public StaffContext(DbContextOptions<StaffContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
