using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController :  ControllerBase {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService) {
            _usersService = usersService;
        }
        
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(CancellationToken cancellationToken = default) {
            return Ok(await _usersService.GetAllUsers(cancellationToken));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<User>> GetById(int id) {
            var user = await _usersService.GetById(id);

            if (user is null) {
                return NoContent();
            }

            return Ok(user);
        }

        [HttpGet("search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> SearchByName(string name) {
            return Ok(await _usersService.SearchByName(name));
        }
        
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(User user) {
            try {
                await _usersService.Create(user);
                return Created($"/api/{user.Id}", user);
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
