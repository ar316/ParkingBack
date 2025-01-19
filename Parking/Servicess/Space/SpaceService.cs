using Microsoft.AspNetCore.Mvc;
using Parking.Data.Repositories.SpaceRepository;

namespace Parking.Servicess.Space;

public class SpaceService: ISpaceService
{
    
    private readonly ILogger<SpaceService> _logger;
    private readonly SpaceRepository _repository;

    public SpaceService(ILogger<SpaceService> logger, SpaceRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    public async Task<IEnumerable<Models.Space>> GetSpacesByFloor(int floorNumber)
    {
       return await _repository.GetSpacesByFloorAsync(floorNumber);
    }
    
}