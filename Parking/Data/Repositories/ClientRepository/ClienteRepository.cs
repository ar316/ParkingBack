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

   

        public Cliente findByIdentificationNumber(string identification)
        {
            try
            {
                return _context.Clientes.FirstOrDefault(c => c.identification == identification);
            }
            catch (Exception e)
            {
                throw new Exception("Error al buscar el cliente por identificacion", e);
            }
        }
    }
}
