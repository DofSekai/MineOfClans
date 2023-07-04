using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
    
[Route("api/[controller]")]
[ApiController]
public class VillagesController :  ControllerBase 
{
    private readonly IVillagesService _villagesService;

    public VillagesController(IVillagesService villagesService) 
    {
        _villagesService = villagesService;
    }
        
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Village>>> GetAllVillages(CancellationToken cancellationToken = default) 
    {
        return Ok(await _villagesService.GetAllVillages(cancellationToken));
    }
    
    [HttpGet("Users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Village>> GetAllVillagesByUserId(int id) 
    {
        var village = await _villagesService.GetAllVillagesByUserId(id);

        return Ok(village);
    }
        
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Village>> GetById(int id) 
    {
        var village = await _villagesService.GetById(id);

        if (village is null) 
        {
            return NoContent();
        }

        return Ok(village);
    }

    [HttpGet("search/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Village>>> SearchByName(string name) 
    {
        return Ok(await _villagesService.SearchByName(name));
    }
        
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(VillageCreationRequest villageRequest) 
    {
        try 
        {
            var village = await _villagesService.Create(villageRequest);
            return Created($"/api/{village.Id}", village);
        } 
        catch (ArgumentException ex) 
        {
            return BadRequest(ex.Message);
        }
    }
}
