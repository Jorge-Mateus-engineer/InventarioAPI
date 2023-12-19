using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Clientes
{
    public interface IClienteRepository
    {
        List<ClienteEntity> GetAll();
        ClienteEntity GetById(int id);
        ClienteEntity GetByEmail(string email);
        ClienteEntity Insert(ClienteEntity entity);
        ClienteEntity Update(ClienteEntity entity);
        void Delete(ClienteEntity entity);
    }
}
