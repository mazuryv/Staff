using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Staff.Domain;
using Staff.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Staff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly ILogger<PositionController> logger;
        private readonly IPositionRepository positionRepository;
        public PositionController(ILogger<PositionController> logger, IPositionRepository positionRepository)
        {
            this.logger = logger;
            this.positionRepository = positionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PositionSummary>> Get()
        {
            var positions = await positionRepository.GetAsync();
            return positions.Select(domain => PositionSummary.FromDomain(domain));
        }

        [HttpPost]
        public async Task<ActionResult> Create(PositionDto positionDto)
        {
            if (!string.IsNullOrEmpty(positionDto.Description))
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }
            var position = new Position(positionDto.Description);
            await positionRepository.InsertAsync(position);
            return CreatedAtAction(
                nameof(Get),
                new { id = position.Id.ToString()},
                PositionSummary.FromDomain(position));
        }
    }
}
