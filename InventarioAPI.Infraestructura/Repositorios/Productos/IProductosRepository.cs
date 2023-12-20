using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Productos
{
    public interface IProductosRepository
    {
        List<ProductoEntity> GetAll();
        List<ProductoEntity> GetByCategory(int categoryID);
        List<ProductoEntity> GetByProviderID(int providerID);
        ProductoEntity GetById(int id);
        ProductoEntity GetByName(string name);
        ProductoEntity Insert(ProductoEntity entity);
        ProductoEntity Update(ProductoEntity entity);
        void Delete(ProductoEntity entity);
    }
}
