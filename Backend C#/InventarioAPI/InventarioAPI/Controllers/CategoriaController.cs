using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Dominio.Services.Categorias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAll()
        {
            List<CategoriaContract> categorias = _categoriaService.GetAll();
            return Ok(categorias);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetByName(string name)
        {
            CategoriaContract categoria = _categoriaService.GetByName(name);
            if (categoria != null)
            {
                return Ok(categoria);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Create(CategoriaContract categoria)
        {
            _categoriaService.Insert(categoria);
            return Ok(categoria);
        }

        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
        public IActionResult Update(CategoriaContract categoria)
        {
            CategoriaContract categoriaContract = _categoriaService.GetByName(categoria.nombre);
            if (categoriaContract != null)
            {
                _categoriaService.Update(categoria);
                return Ok(categoria);
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
            CategoriaContract categoryToDelete = _categoriaService.GetById(id);
            if (categoryToDelete != null)
            {
                _categoriaService.Delete(categoryToDelete);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
