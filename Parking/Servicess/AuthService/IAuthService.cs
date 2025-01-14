using Parking.Models;

namespace Parking.Servicess.AuthService
{
    public interface IAuthService
    {

        Task<(string token, Cliente client)> AuthenticateAsync(string identification, string password);
    }
}
