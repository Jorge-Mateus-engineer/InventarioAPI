using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Productos
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly InventarioContext _context;

        public ProductosRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(ProductoEntity entity)
        {
            _context.Productos.Remove(entity);
            _context.SaveChanges();
        }

        public List<ProductoEntity> GetAll()
        {
            return _context.Productos.ToList();
        }

        public List<ProductoEntity> GetByCategory(int categoryID)
        {
            return _context.Productos.Where(p => p.id_categoria == categoryID).ToList();
        }

        public ProductoEntity GetById(int id)
        {
            return _context.Productos.Find(id);
        }

        public ProductoEntity GetByName(string name)
        {
            return _context.Productos.Where(p => p.nombre.ToLower() == name.ToLower()).Single();
        }

        public List<ProductoEntity> GetByProviderID(int providerID)
        {
            return _context.Productos.Where(p => p.id_proveedor == providerID).ToList();
        }

        public ProductoEntity Insert(ProductoEntity entity)
        {
            _context.Productos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public ProductoEntity Update(ProductoEntity entity)
        {
            _context.Productos.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
