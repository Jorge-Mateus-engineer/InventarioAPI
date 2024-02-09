using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Proveedores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<ProveedorContract> proveedores = _proveedorService.GetAll();
            return Ok(proveedores);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByCompany(string name)
        {
            List<ProveedorContract> proveedores = _proveedorService.GetByCompany(name);
            return Ok(proveedores);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByEmail(string email)
        {
            ProveedorContract proveedor = _proveedorService.GetByEmail(email);
            return Ok(proveedor);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult Create(ProveedorContract proveedorContract)
        {
            _proveedorService.Insert(proveedorContract);
            return Ok(proveedorContract);
        }

        [HttpPatch]
        [Route("[Action]")]
        public IActionResult Update(ProveedorContract proveedor)
        {
            _proveedorService.Update(proveedor);
            return Ok(proveedor);
        }

        [HttpDelete]
        [Route("[Action]")]
        public IActionResult Delete(ProveedorContract proveedor)
        {
            _proveedorService.Delete(proveedor);
            return NoContent();
        }
    }
}
