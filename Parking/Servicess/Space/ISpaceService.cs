using Microsoft.AspNetCore.Mvc;

namespace Parking.Servicess.Space;

public interface ISpaceService
{
    Task<IEnumerable<Models.Space>> GetSpacesByFloor(int floor);
}