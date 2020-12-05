using System;

namespace Staff.Domain
{
    public class Position
    {
        public Guid Id { get; }
        public string Description { get; }

        private Position(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Position(string description) : this(Guid.NewGuid(), description) { }

        public static Position FromPersistence(Guid id, string description)
        {
            return new Position(id, description);
        }
    }
}