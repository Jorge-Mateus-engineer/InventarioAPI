using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Comunes.Clases.Helpers.Encription;
using InventarioAPI.Dominio.Services.Clientes;
using InventarioAPI.Dominio.Services.Comunes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClientesService _clientesService;
        private readonly IJWTService _jwtService;
        public ClienteController(IClientesService clientesService, IJWTService JWTService)
        {
            _clientesService = clientesService;
            _jwtService = JWTService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            List<ClienteContract> clientes = _clientesService.GetAll();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("[Action]")]
        [Authorize]
        public IActionResult GetByID(int id)
        {
            ClienteContract cliente = _clientesService.GetById(id);
            return Ok(cliente);

        }

        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
        public IActionResult UpdateClient(ClienteContract cliente)
        {
            _clientesService.Update(cliente);
            return Ok(cliente);
        }

        [HttpDelete]
        [Route("[Action]")]
        [Authorize]
        public IActionResult DeleteClient(int id)
        {
            ClienteContract cliente = _clientesService.GetById(id);
            _clientesService.Delete(cliente);
            return NoContent();
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult SignUp(ClienteContract cliente)
        {
            _clientesService.Insert(cliente);
            var datos = new
            {
                Nombre_de_usuario = $"{cliente.primer_nombre}",
                Correo_de_usuario = $"{cliente.correo}",
                jwt = _jwtService.GetJWT(cliente),
            };

            //Regresa un statusCode 201 (created)
            return CreatedAtAction("SignUp", datos);

        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult SignIn([FromBody] AuthenticationContract authenticationContract)
        {
            (ClienteContract cliente, string contrasena_enc, byte[] salt) = _clientesService.FindByEmail(authenticationContract.correo);
            if (cliente != null)
            {
                if (Encriptador.ComparePasswords(authenticationContract.contrasena, contrasena_enc, salt))
                {
                    var datos = new
                    {
                        JWT = _jwtService.GetJWT(cliente),
                    };

                    return Ok(datos);
                }
                else
                {
                    //Regresa un statusCode 404 (not found)
                    return NotFound();
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult ValidateToken(string token)
        {
            if (_jwtService.VerifyJWT(token) != null)
            {
                var datos = new
                {
                    tokenValidity = "Valid Token",
                };

                return Ok(datos);
            }
            else
            {
                var datos = new
                {
                    tokenValidity = "The token is no longer valid",
                };
                return BadRequest(datos);
            }
        }
    }
}
