using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Productos
{
    public interface IProductosService
    {
        List<ProductoContract> GetAll();
        List<ProductoContract> GetByCategory(int categoryID);
        List<ProductoContract> GetByProviderID(int providerID);
        ProductoContract GetById(int id);
        ProductoContract GetByName(string name);
        ProductoContract Insert(ProductoContract contract);
        ProductoContract Update(ProductoContract contract);
        void Delete(ProductoContract contract);
    }
}
