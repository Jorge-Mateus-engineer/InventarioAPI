using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Categorias;
using InventarioAPI.Dominio.Services.Productos;
using InventarioAPI.Dominio.Services.Proveedores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly IProductosService _productosService;
        private readonly ICategoriaService _categoriaService;
        private readonly IProveedorService _proveedorService;

        public ProductoController(IProductosService productosService, ICategoriaService categoriaService, IProveedorService proveedorService)
        {
            _productosService = productosService;
            _categoriaService = categoriaService;
            _proveedorService = proveedorService;
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
        public IActionResult Create(ProductoContract producto)
        {
            CategoriaContract categoria = _categoriaService.GetById(producto.id_categoria);
            ProveedorContract proveedorContract = _proveedorService.GetById(producto.id_proveedor);
            if (categoria != null)
            {
                if (proveedorContract != null)
                {
                    _productosService.Insert(producto);
                    return Ok(producto);
                }
                else
                {
                    return BadRequest($"El proveedor con ID: {producto.id_proveedor} no existe");
                }
            }
            else
            {
                return BadRequest($"La categoria de ID: {producto.id_categoria} no existe");
            }
        }


        [HttpPatch]
        [Route("[Action]")]
        public IActionResult Update(ProductoContract producto)
        {
            CategoriaContract categoria = _categoriaService.GetById(producto.id_categoria);
            ProveedorContract proveedorContract = _proveedorService.GetById(producto.id_proveedor);
            if (categoria != null)
            {
                if (proveedorContract != null)
                {
                    _productosService.Update(producto);
                    return Ok(producto);
                }
                else
                {
                    return BadRequest($"El proveedor con ID: {producto.id_proveedor} no existe");
                }
            }
            else
            {
                return BadRequest($"La categoria de ID: {producto.id_categoria} no existe");
            }
        }

        [HttpDelete]
        [Route("[Action]")]
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
