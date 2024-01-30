using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.DetalleCompras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCompraController : Controller
    {
        private readonly IDetalleComprasService _detalleComprasSerivce;

        public DetalleCompraController(IDetalleComprasService detalleComprasService)
        {
            _detalleComprasSerivce = detalleComprasService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<DetalleCompraContract> detalles = _detalleComprasSerivce.GetAll();
            return Ok(detalles);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByPurchaseId(int purchaseId)
        {
            List<DetalleCompraContract> detalles = _detalleComprasSerivce.GetByPurchaseId(purchaseId);
            return Ok(detalles);
        }

        [HttpPost]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Create(DetalleCompraContract detalle)
        {
            _detalleComprasSerivce.Insert(detalle);
            return Ok(detalle);
        }

        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Update(DetalleCompraContract detalle)
        {
            DetalleCompraContract detalleContract = _detalleComprasSerivce.GetById(detalle.id_detalle_compra);
            if (detalleContract != null)
            {
                _detalleComprasSerivce.Update(detalle);
                return Ok(detalle);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            DetalleCompraContract detalle = _detalleComprasSerivce.GetById(id);
            if (detalle != null)
            {
                _detalleComprasSerivce.Update(detalle);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
