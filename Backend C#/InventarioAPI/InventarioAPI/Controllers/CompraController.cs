using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Compras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompraController : Controller
    {

        private readonly IComprasService _comprasService;

        public CompraController(IComprasService comprasService)
        {
            _comprasService = comprasService;
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
        [Authorize]
        public IActionResult Create(CompraContract compra)
        {
            _comprasService.Insert(compra);
            return Ok(compra);
        }

        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
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
        [Authorize]
        public IActionResult Delete(CompraContract compra)
        {
            CompraContract compraContract = _comprasService.GetById(compra.id_compra);
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
