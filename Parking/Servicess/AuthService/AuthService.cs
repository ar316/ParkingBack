using Parking.Data.Repositories.ClientRepository;
using Parking.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Xml.Linq;

namespace Parking.Servicess.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly ClienteRepository _clientRepository;

        private readonly IConfiguration _configuration;

        public AuthService(ClienteRepository clientRepository, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _configuration = configuration;
        }

        public async Task<(string token, Cliente client)> AuthenticateAsync(string identification, string password)
        {

            Cliente client = _clientRepository.findByIdentificationNumber(identification);

            if (client != null)
            {
                if (client.password == password)
                {
                    string token = this.GenerateToken(client);

                    Cliente user = new Cliente
                    {
                        Id = client.Id,
                        identification = identification,
                        email = client.email,
                        name = client.name
                    };

                    return await Task.FromResult((token, user));
                }

            }
            return (null, null);
        }

        private string GenerateToken(Cliente user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.identification),
                new Claim(ClaimTypes.Email, user.phone)
              
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
