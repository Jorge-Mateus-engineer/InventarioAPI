using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Bodegas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BodegaController : Controller
    {
        private readonly IBodegaService _bodegaService;

        public BodegaController(IBodegaService bodegaService)
        {
            _bodegaService = bodegaService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<BodegaContract> bodegas = _bodegaService.GetAll();
            return Ok(bodegas);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int id)
        {
            BodegaContract bodega = _bodegaService.GetByID(id);
            if (bodega == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bodega);
            }
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult Create(BodegaContract bodega)
        {
            _bodegaService.Insert(bodega);
            return Ok(bodega);
        }

        [HttpPatch]
        [Route("[Action]")]
        public IActionResult Update(BodegaContract bodega)
        {
            _bodegaService.Update(bodega);
            return Ok(bodega);
        }

        [HttpDelete]
        [Route("[Action]")]
        public IActionResult DeleteById(int id)
        {
            BodegaContract bodega = _bodegaService.GetByID(id);
            if (bodega != null)
            {
                _bodegaService.DeleteByID(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
