using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Clientes;
using InventarioAPI.Dominio.Services.Compras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompraController : Controller
    {

        private readonly IComprasService _comprasService;
        private readonly IClientesService _clientesService;

        public CompraController(IComprasService comprasService, IClientesService clientesService)
        {
            _comprasService = comprasService;
            _clientesService = clientesService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<CompraContract> compras = _comprasService.GetAll();
            return Ok(compras);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByClientId(int id)
        {
            List<CompraContract> compras = _comprasService.GetByClientId(id);
            return Ok(compras);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int id)
        {
            CompraContract compra = _comprasService.GetById(id);
            if (compra != null)
            {
                return Ok(compra);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult Create(CompraContract compra)
        {
            ClienteContract associatedClient = _clientesService.GetById(compra.id_cliente);
            if (associatedClient != null)
            {
                _comprasService.Insert(compra);
                return Ok(compra);
            }
            else
            {
                return NotFound($"El cliente de ID: {compra.id_cliente} no existe");
            }
        }

        [HttpPatch]
        [Route("[Action]")]
        public IActionResult Update(CompraContract compra)
        {
            CompraContract compraContract = _comprasService.GetById(compra.id_compra);
            if (compraContract != null)
            {
                _comprasService.Update(compra);
                return Ok(compra);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("[Action]")]
        public IActionResult Delete(int id)
        {
            CompraContract compraContract = _comprasService.GetById(id);
            if (compraContract != null)
            {
                _comprasService.Delete(compraContract);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
