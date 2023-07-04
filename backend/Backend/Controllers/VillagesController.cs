using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VillagesController : ControllerBase
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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update(int id)
    {
        var village = await _villagesService.GetById(id);

        if (village is null)
        {
            return NotFound();
        }

        try
        {
            await _villagesService.Update(village.Id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/mine")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateMine(int id)
    {
        var village = await _villagesService.GetById(id);

        if (village is null)
        {
            return NotFound();
        }

        try
        {
            await _villagesService.UpdateMine(village.Id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/hdv")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateHdv(int id)
    {
        var village = await _villagesService.GetById(id);

        if (village is null)
        {
            return NotFound();
        }

        try
        {
            await _villagesService.UpdateHdv(village.Id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/golem")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateGolem(int id)
    {
        var village = await _villagesService.GetById(id);

        if (village is null)
        {
            return NotFound();
        }

        try
        {
            await _villagesService.UpdateGolem(village.Id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/wall")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateWall(int id)
    {
        var village = await _villagesService.GetById(id);

        if (village is null)
        {
            return NotFound();
        }

        try
        {
            await _villagesService.UpdateWall(village.Id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/tower")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTower(int id)
    {
        var village = await _villagesService.GetById(id);

        if (village is null)
        {
            return NotFound();
        }

        try
        {
            await _villagesService.UpdateTower(village.Id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
