using Microsoft.EntityFrameworkCore;
using Staff.Domain;
using Staff.Repository.MsSql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Staff.Repository.MsSql
{
    public class PositionRepository : IPositionRepository
    {
        private readonly StaffContext staffContext;
        public PositionRepository(StaffContext staffContext) => this.staffContext = staffContext;

        public Task DeleteAsync(Guid id) => throw new NotImplementedException();
        public async Task<IEnumerable<Position>> GetAsync()
        {
            var records = await staffContext.Positions
                .AsNoTracking()
                .ToArrayAsync();
            return records.Select(record => record.ToDomain());
        }

        public async Task<Position> GetAsync(Guid id)
        {
            var record = await staffContext.Positions.FirstOrDefaultAsync(position => position.Id == id);
            return record?.ToDomain();
        }

        public async Task InsertAsync(Position entity)
        {
            var isDublicate = await staffContext.Positions.AnyAsync(position => position.Description == entity.Description);
            if (isDublicate)
            {
                throw new InvalidOperationException($"Position with description \"{entity.Description}\" have already been added");
            }
            var record = new Models.Position()
            {
                Id = entity.Id,
                Description = entity.Description
            };
            await staffContext.Positions.AddAsync(record);
            await staffContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Position entity) => throw new NotImplementedException();
    }
}