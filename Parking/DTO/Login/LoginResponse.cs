using Parking.Models;

namespace Parking.DTO.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public Cliente User { get; set; }

        public string Message { get; set; }
    }
}
