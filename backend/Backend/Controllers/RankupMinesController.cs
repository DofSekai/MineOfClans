using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankupMinesController : ControllerBase
    {
        private readonly IRankupMinesService _rankupMinesService;

        public RankupMinesController(IRankupMinesService rankupMinesService)
        {
            _rankupMinesService = rankupMinesService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<RankupMine>> GetById(int id)
        {
            var rankupMine = await _rankupMinesService.GetById(id);

            if (rankupMine is null)
            {
                return NoContent();
            }

            return Ok(rankupMine);
        }
    }
}
