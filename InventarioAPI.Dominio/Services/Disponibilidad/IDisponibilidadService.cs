using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Disponibilidad
{
    public interface IDisponibilidadService
    {
        List<DisponibilidadContract> GetAll();
        List<DisponibilidadContract> GetByProductID(int productID);
        List<DisponibilidadContract> GetByWharehouseID(int wharehouseID);
        DisponibilidadContract Insert(DisponibilidadContract contract);
        DisponibilidadContract Update(DisponibilidadContract contract);
        void Delete(DisponibilidadContract contract);
    }
}
