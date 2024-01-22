using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Compras
{
    public interface IComprasService
    {
        List<CompraContract> GetAll();
        List<CompraContract> GetByClientId(int id);
        CompraContract GetById(int id);
        CompraContract Insert(CompraContract contract);
        CompraContract Update(CompraContract contract);
        void Delete(CompraContract contract);
    }
}
