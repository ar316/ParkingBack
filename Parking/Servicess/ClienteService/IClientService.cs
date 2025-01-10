using Parking.Models;

namespace Parking.Servicess.ClienteService
{
    public interface IClientService
    {
        Task<Cliente> CreateClientAsync(Cliente client);
        Task<Cliente> GetClientByIdAsync(int id);
    }
}
