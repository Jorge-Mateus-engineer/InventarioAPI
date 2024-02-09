using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Compras;
using InventarioAPI.Dominio.Services.DetalleCompras;
using InventarioAPI.Dominio.Services.Productos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleCompraController : Controller
    {
        private readonly IDetalleComprasService _detalleComprasSerivce;
        private readonly IComprasService _comprasSerivce;
        private readonly IProductosService _productosService;

        public DetalleCompraController(IDetalleComprasService detalleComprasService, IComprasService comprasService, IProductosService productosService)
        {
            _detalleComprasSerivce = detalleComprasService;
            _comprasSerivce = comprasService;
            _productosService = productosService;
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
        public IActionResult Create(DetalleCompraContract detalle)
        {
            CompraContract compraAsociada = _comprasSerivce.GetById(detalle.id_compra);
            ProductoContract productoAsociado = _productosService.GetById(detalle.id_producto);
            if (compraAsociada != null)
            {
                if (productoAsociado != null)
                {
                    Decimal totalDetalle = (Decimal) (detalle.cantidad * productoAsociado.precio_unitario);
                    compraAsociada.valor_total += totalDetalle;
                    _comprasSerivce.Update(compraAsociada);
                    detalle.total_detalle = (float) totalDetalle;
                    _detalleComprasSerivce.Insert(detalle);
                    return Ok(detalle);
                }
                else
                {
                    return BadRequest($"El producto con ID: {detalle.id_producto} no existe");
                }
            }
            else
            {
                return NotFound($"La compra con ID: {detalle.id_compra} no existe");
            }
        }

        [HttpPatch]
        [Route("[Action]")]
        public IActionResult Update(DetalleCompraContract detalle)
        {
            CompraContract compraAsociada = _comprasSerivce.GetById(detalle.id_compra);
            ProductoContract productoAsociado = _productosService.GetById(detalle.id_producto);
            DetalleCompraContract detalleAnterior = _detalleComprasSerivce.GetById(detalle.id_detalle_compra);
            if (compraAsociada != null)
            {
                if (productoAsociado != null)
                {
                    //Get old total from associated detail
                    Decimal totalDetalleAnterior = (Decimal) detalleAnterior.total_detalle;

                    //Recalculate the total for the detail to update
                    Decimal totalDetalleActual = (Decimal)(detalle.cantidad * productoAsociado.precio_unitario);

                    //Update the total of the associated purchase
                    //1. Remove old detail value from purchase total
                    compraAsociada.valor_total -= totalDetalleAnterior;
                    //2. Add new total of the detail
                    compraAsociada.valor_total += totalDetalleActual;
                    //3. Update totals using the service
                    _comprasSerivce.Update(compraAsociada);
                    detalle.total_detalle = (float)totalDetalleActual;
                    _detalleComprasSerivce.Update(detalle);
                    return Ok(detalle);
                }
                else
                {
                    return BadRequest($"El producto con ID: {detalle.id_producto} no existe");
                }
            }
            else
            {
                return NotFound($"La compra con ID: {detalle.id_compra} no existe");
            }

        }

        [HttpDelete]
        [Route("[Action]")]
        public IActionResult Delete(int id)
        {
            DetalleCompraContract detalle = _detalleComprasSerivce.GetById(id);
            if (detalle != null)
            {
                _detalleComprasSerivce.Delete(detalle);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
