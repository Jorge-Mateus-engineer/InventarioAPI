using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Clientes;
using InventarioAPI.Dominio.Services.Comunes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClientesService _clientesService;
        private readonly IJWTService _jwtService;
        public ClienteController(IClientesService clientesService, IJWTService JWTService)
        {
            _clientesService = clientesService;
            _jwtService = JWTService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string token = _jwtService.GetJWT(new ClienteContract() { id_cliente = 1 });
            List<ClienteContract> clientes = _clientesService.GetAll();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("([Action]")]
        [Authorize]
        public IActionResult GetByID(int id)
        {
            ClienteContract cliente = _clientesService.GetById(id);
            return Ok(cliente);

        }
    }
}
