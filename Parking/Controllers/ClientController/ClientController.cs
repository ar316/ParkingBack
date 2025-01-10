using Microsoft.AspNetCore.Mvc;
using Parking.Data.Repositories.ClientRepository;
using Parking.Models;
using Parking.Servicess.ClienteService;

namespace Parking.Controllers.ClientController
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController: ControllerBase
    {
        private readonly IClientService _ClienteService;

        public ClientController(IClientService clientService)
        {
            _ClienteService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Cliente client)
        {
            await _ClienteService.CreateClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _ClienteService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

    }
}
