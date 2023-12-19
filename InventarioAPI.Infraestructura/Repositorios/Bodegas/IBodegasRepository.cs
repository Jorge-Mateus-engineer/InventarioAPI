using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Bodegas
{
    public interface IBodegasRepository
    {
        List<BodegaEntity> GetAll();
        BodegaEntity GetByID(int id);
        BodegaEntity GetByName(string name);
        BodegaEntity Insert(BodegaEntity entity);
        BodegaEntity Update(BodegaEntity entity);
        void DeleteByID(int id);
    }
}
