using InventarioAPI.Comunes.Clases.Contratos;
using System.IdentityModel.Tokens.Jwt;

namespace InventarioAPI.Dominio.Services.Comunes
{
    public interface IJWTService
    {
        string GetJWT(ClienteContract clienteContract);
        JwtSecurityToken VerifyJWT(string jwt);
    }
}
