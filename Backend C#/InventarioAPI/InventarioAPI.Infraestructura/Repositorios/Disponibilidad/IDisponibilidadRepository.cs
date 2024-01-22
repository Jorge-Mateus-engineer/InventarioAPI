using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Disponibilidad
{
    public interface IDisponibilidadRepository
    {
        List<DisponibilidadEntity> GetAll();
        List<DisponibilidadEntity> GetByProductID(int productID);
        List<DisponibilidadEntity> GetByWharehouseID(int wharehouseID);
        DisponibilidadEntity Insert(DisponibilidadEntity entity);
        DisponibilidadEntity Update(DisponibilidadEntity entity);
        void Delete(DisponibilidadEntity entity);
    }
}
