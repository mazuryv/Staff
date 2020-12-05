using Microsoft.EntityFrameworkCore;
using Staff.Domain;
using Staff.Repository.MsSql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Staff.Repository.MsSql
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StaffContext staffContext;
        public EmployeeRepository(StaffContext staffContext) => this.staffContext = staffContext;
        public async Task<IEnumerable<Employee>> GetAsync()
        {
            var records = await staffContext.Employees
                .Include(e=>e.EmployeePositions)
                .ThenInclude(e=>e.Position)
                .AsNoTracking()
                .ToArrayAsync();
            return records.Select(record => record.ToDomain());
        }

        public Task<Employee> GetAsync(Guid id) => throw new NotImplementedException();
        
        public async Task InsertAsync(Employee entity)
        {
            var employeePositions = await Task.WhenAll(entity.EmployeePositions
                    .Select(async position => new Models.EmployeePosition()
                    {
                        Id = Guid.NewGuid(),
                        EmployeeId = entity.Id,
                        Position = await staffContext.Positions.FirstAsync(p => p.Id == position.Position.Id),
                        HireDate = position.HireDate,
                        FireDate = position.FireDate
                    }).ToArray());

            var record = new Models.Employee()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                HireDate = entity.HireDate,
                FireDate = entity.FireDate,
                Salary = entity.Salary,
                EmployeePositions = employeePositions
            };
            await staffContext.Employees.AddAsync(record);
            await staffContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Employee entity) => throw new NotImplementedException();
        public Task DeleteAsync(Guid id) => throw new NotImplementedException();

    }
}
