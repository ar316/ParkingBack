using Microsoft.AspNetCore.Components;
using Parking.Models;
using Parking.Servicess.Space;

namespace Parking.Controllers.SpaceController;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SpaceController: ControllerBase
{

    private readonly ISpaceService _spaceService;

    public SpaceController(ISpaceService spaceService)
    {
        _spaceService = spaceService;
    }

    [HttpGet("{floorNumber}")]
    public async Task<IActionResult> Get(int floorNumber)
    {
        var spaces = await _spaceService.GetSpacesByFloor(floorNumber);
        if (spaces == null )
        {
            return NotFound($"No spaces found on floor {floorNumber}.");
        }
        
        return Ok(spaces);
    }
    
}