using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClientesService _clientesService;
        public ClienteController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ClienteContract> clientes = _clientesService.GetAll();
            return Ok(clientes);
        }
    }
}
