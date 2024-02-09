using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Disponibilidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DisponibilidadController : Controller
    {
        private readonly IDisponibilidadService _disponibilidadService;

        public DisponibilidadController(IDisponibilidadService disponibilidadService)
        {
            _disponibilidadService = disponibilidadService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<DisponibilidadContract> disponibilidades = _disponibilidadService.GetAll();
            return Ok(disponibilidades);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByProductId(int id)
        {
            List<DisponibilidadContract> disponibilidades = _disponibilidadService.GetByProductID(id);
            return Ok(disponibilidades);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByWhareHouseId(int id)
        {
            List<DisponibilidadContract> disponibilidades = _disponibilidadService.GetByWharehouseID(id);
            return Ok(disponibilidades);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult Create(DisponibilidadContract disponibilidad)
        {
            _disponibilidadService.Insert(disponibilidad);
            return Ok(disponibilidad);
        }

        [HttpPatch]
        [Route("[Action]")]
        public IActionResult Update(DisponibilidadContract disponibilidad)
        {
            DisponibilidadContract disponibilidadContract = _disponibilidadService.GetByProductID(disponibilidad.id_producto).Where(d => d.id_bodega == disponibilidad.id_bodega).FirstOrDefault();
            if (disponibilidadContract != null)
            {
                _disponibilidadService.Update(disponibilidad);
                return Ok(disponibilidad);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("[Action]")]
        public IActionResult Delete(int idProducto, int idBodega )
        {
            DisponibilidadContract disponibilidadContract = _disponibilidadService.GetAll().Where(d => d.id_producto == idProducto && d.id_bodega == idBodega).FirstOrDefault();
            if (disponibilidadContract != null)
            {
                _disponibilidadService.Delete(disponibilidadContract);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
