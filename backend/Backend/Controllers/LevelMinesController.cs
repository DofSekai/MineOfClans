using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LevelMinesController :  ControllerBase 
{
    private readonly ILevelMinesService _levelMinesService;

    public LevelMinesController(ILevelMinesService levelMinesService) 
    {
        _levelMinesService = levelMinesService;
    }
        
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LevelMine>>> GetAllLevelMines(CancellationToken cancellationToken = default) 
    {
        return Ok(await _levelMinesService.GetAllLevelMines(cancellationToken));
    }
        
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<LevelMine>> GetById(int id) 
    {
        var user = await _levelMinesService.GetById(id);

        if (user is null) 
        {
            return NoContent();
        }

        return Ok(user);
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(LevelMine levelMine)
    {
        try 
        {
            await _levelMinesService.Create(levelMine);
            return Created($"/api/{levelMine.Id}", levelMine);
        } 
        catch (ArgumentException ex) 
        {
            return BadRequest(ex.Message);
        }
    }
}
