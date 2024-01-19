using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Proveedores
{
    public interface IProveedorService
    {
        List<ProveedorContract> GetAll();
        List<ProveedorContract> GetByCompany(string companyName);
        ProveedorContract GetByEmail(string email);
        ProveedorContract Insert(ProveedorContract contract);
        ProveedorContract Update(ProveedorContract contract);
        void Delete(ProveedorContract contract);
    }
}
