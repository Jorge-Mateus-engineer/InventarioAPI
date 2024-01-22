using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Compras
{
    public class ComprasRepository : IComprasRepository
    {
        private readonly InventarioContext _context;

        public ComprasRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(CompraEntity entity)
        {
            _context.Compras.Remove(entity);
            _context.SaveChanges();
        }

        public List<CompraEntity> GetAll()
        {
            return _context.Compras.ToList();
        }

        public List<CompraEntity> GetByClientId(int id)
        {
            return _context.Compras.Where(c => c.id_cliente == id).ToList();
        }

        public CompraEntity GetById(int id)
        {
            return _context.Compras.Find(id);
        }

        public CompraEntity Insert(CompraEntity entity)
        {
            _context.Compras.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public CompraEntity Update(CompraEntity entity)
        {
            _context.Compras.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
