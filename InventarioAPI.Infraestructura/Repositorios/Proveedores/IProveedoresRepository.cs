using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Proveedores
{
    public interface IProveedoresRepository
    {
        List<ProveedorEntity> GetAll();
        List<ProveedorEntity> GetByCompany(string companyName);
        List<ProveedorEntity> GetByEmail(string email);
        ProveedorEntity Insert(ProveedorEntity entity);
        ProveedorEntity Update(ProveedorEntity entity);
        void Delete(ProveedorEntity entity);
    }
}
