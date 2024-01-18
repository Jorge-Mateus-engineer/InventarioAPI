using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Clientes
{
    public interface IClientesService
    {
        List<ClienteContract> GetAll();
        ClienteContract GetById(int id);
        (ClienteContract?, string, byte[]) FindByEmail(string email);
        ClienteContract Insert(ClienteContract contract);
        ClienteContract Update(ClienteContract contract);
        void Delete(ClienteContract contract);
    }
}
