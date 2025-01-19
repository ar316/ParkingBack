using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data.Repositories.SpaceRepository;

    public class SpaceRepository: RepositoryImpl<Space>
    {
        private new readonly ApplicationDbContext _context;

        public SpaceRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Space>> GetSpacesByFloorAsync(int floorNumber)
        {
            return await _context.Spaces
                .Where(space => space.Piso == floorNumber)
                .ToListAsync();
        }
        
        
        
    }