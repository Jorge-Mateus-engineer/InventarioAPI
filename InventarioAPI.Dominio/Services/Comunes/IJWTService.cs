using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Comunes
{
    public interface IJWTService
    {
        string GetJWT(ClienteContract clienteContract);
    }
}
