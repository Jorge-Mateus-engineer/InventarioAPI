using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Clientes
{
    public interface IClientesService
    {
        List<ClienteContract> GetAll();
        ClienteContract GetById(int id);
        ClienteContract GetByEmail(string email);
        ClienteContract Insert(ClienteContract contract);
        ClienteContract Update(ClienteContract contract);
        void Delete(ClienteContract contract);
    }
}
