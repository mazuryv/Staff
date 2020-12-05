using Staff.Domain;
using System;

namespace Staff
{
    public class PositionSummary
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public static PositionSummary FromDomain(Position domain)
        {
            return new PositionSummary
            {
                Id = domain.Id.ToString(),
                Description = domain.Description
            };
        }
    }
}