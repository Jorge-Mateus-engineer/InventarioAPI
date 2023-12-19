using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Compras
{
    public interface IComprasRepository
    {
        List<CompraEntity> GetAll();
        List<CompraEntity> GetByClientId(int id);
        CompraEntity Insert(CompraEntity entity);
        CompraEntity Update(CompraEntity entity);
        void Delete(CompraEntity entity);
    }
}
