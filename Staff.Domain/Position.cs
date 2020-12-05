using System;

namespace Staff.Domain
{
    public class Position
    {
        public Guid Id { get; }
        public string Description { get; }

        public Position(string description)
        {
            Id = new Guid();
            Description = description;
        }
    }
}