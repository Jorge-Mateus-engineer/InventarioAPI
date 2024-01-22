using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Bodegas
{
    public interface IBodegaService
    {
        List<BodegaContract> GetAll();
        BodegaContract GetByID(int id);
        BodegaContract GetByName(string name);
        BodegaContract Insert(BodegaContract contract);
        BodegaContract Update(BodegaContract contract);
        void DeleteByID(int id);
    }
}
