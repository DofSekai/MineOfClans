using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankupHdvsController : ControllerBase
    {
        private readonly IRankupHdvsService _rankupHdvsService;

        public RankupHdvsController(IRankupHdvsService rankupHdvsService)
        {
            _rankupHdvsService = rankupHdvsService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<RankupHdv>> GetById(int id)
        {
            var rankupHdv = await _rankupHdvsService.GetById(id);

            if (rankupHdv is null)
            {
                return NoContent();
            }

            return Ok(rankupHdv);
        }
    }
}
