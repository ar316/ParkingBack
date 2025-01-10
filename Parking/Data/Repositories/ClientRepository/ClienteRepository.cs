using Parking.Models;

namespace Parking.Data.Repositories.ClientRepository
{
    public class ClienteRepository: RepositoryImpl<Cliente>
    {
        private new readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

    


    }
}
