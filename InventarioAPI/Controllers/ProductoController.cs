using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Productos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProductosService _productosService;

        public ProductoController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<ProductoContract> products = _productosService.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByCategoryId(int id)
        {
            List<ProductoContract> products = _productosService.GetByCategory(id);
            return Ok(products);

        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByProviderID(int id)
        {
            List<ProductoContract> products = _productosService.GetByProviderID(id);
            return Ok(products);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetById(int id)
        {
            ProductoContract producto = _productosService.GetById(id);
            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByName(string name)
        {
            ProductoContract producto = _productosService.GetByName(name);
            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Create(ProductoContract producto)
        {
            _productosService.Insert(producto);
            return Ok(producto);
        }

        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Update(ProductoContract producto)
        {
            ProductoContract productoContract = _productosService.GetByName(producto.nombre);
            if (productoContract != null)
            {
                _productosService.Update(producto);
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Delete(ProductoContract producto)
        {
            ProductoContract productoContract = _productosService.GetByName(producto.nombre);
            if (productoContract != null)
            {
                _productosService.Delete(producto);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
