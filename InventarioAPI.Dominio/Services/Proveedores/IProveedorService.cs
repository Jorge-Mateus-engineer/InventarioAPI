using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Proveedores
{
    public interface IProveedorService
    {
        List<ProveedorContract> GetAll();
        List<ProveedorContract> GetByCompany(string companyName);
        List<ProveedorContract> GetByEmail(string email);
        ProveedorContract Insert(ProveedorContract contract);
        ProveedorContract Update(ProveedorContract contract);
        void Delete(ProveedorContract contract);
    }
}
