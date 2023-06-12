using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VillagesController :  ControllerBase {
        private readonly IVillagesService _villagesService;

        public VillagesController(IVillagesService villagesService) {
            _villagesService = villagesService;
        }
        
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Village>>> GetAllVillages(CancellationToken cancellationToken = default) {
            return Ok(await _villagesService.GetAllVillages(cancellationToken));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Village>> GetById(int id) {
            var game = await _villagesService.GetById(id);

            if (game is null) {
                return NoContent();
            }

            return Ok(game);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(Village village) {
            try {
                await _villagesService.Create(village);
                return Created($"/api/Games/{village.Id}", village);
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
