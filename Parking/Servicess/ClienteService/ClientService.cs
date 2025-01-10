using Parking.Data.Repositories.ClientRepository;
using Parking.Models;

namespace Parking.Servicess.ClienteService
{
    public class ClientService : IClientService
    {
        private readonly ClienteRepository _ClienteRepository;
        public ClientService(ClienteRepository clientRepository)
        {
            _ClienteRepository = clientRepository;
        }
        public async Task<Cliente> CreateClientAsync(Cliente client)
        {
           await _ClienteRepository.AddAsync(client);
           return client;
        }

        public async Task<Cliente> GetClientByIdAsync(int id)
        {
            var cliente = await _ClienteRepository.GetByIdAsync(id);
            return cliente;
        }
    }
}
