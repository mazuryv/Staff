using System;

namespace Staff.Repository.MsSql.Models
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Domain.Position ToDomain()
        {
            return Domain.Position.FromPersistence(Id, Description);
        }
    }
}
