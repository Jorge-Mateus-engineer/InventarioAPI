using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        //private readonly IClienteService
        public IActionResult Index()
        {
            return View();
        }
    }
}
