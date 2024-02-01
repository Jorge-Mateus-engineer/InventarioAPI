using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Proveedores
{
    public class ProveedoresRepository : IProveedoresRepository
    {
        private readonly InventarioContext _context;

        public ProveedoresRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(ProveedorEntity entity)
        {
            _context.Proveedores.Remove(entity);
            _context.SaveChanges();
        }

        public List<ProveedorEntity> GetAll()
        {
            return _context.Proveedores.ToList();
        }

        public List<ProveedorEntity> GetByCompany(string companyName)
        {
            return _context.Proveedores.Where(p => p.nombre_empresa.ToLower() == companyName.ToLower()).ToList();
        }

        public ProveedorEntity GetByEmail(string email)
        {
            return _context.Proveedores.Where(p => p.email.ToLower() == email.ToLower()).Single();
        }

        ProveedorEntity GetById(int id)
        {
            return _context.Proveedores.Where(p => p.id_proveedor == id).SingleOrDefault();
        }

        public ProveedorEntity Insert(ProveedorEntity entity)
        {
            _context.Proveedores.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public ProveedorEntity Update(ProveedorEntity entity)
        {
            _context.Proveedores.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
