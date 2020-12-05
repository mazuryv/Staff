using Staff.Domain;
using System;
using System.Collections.Generic;

namespace Staff.Repository.MsSql
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> Get() => throw new NotImplementedException();
        public Employee Get(Guid id) => throw new NotImplementedException();
        public void Insert(Employee entity) => throw new NotImplementedException();
        public void Update(Employee entity) => throw new NotImplementedException();
        public void Delete(Guid id) => throw new NotImplementedException();

    }
}
