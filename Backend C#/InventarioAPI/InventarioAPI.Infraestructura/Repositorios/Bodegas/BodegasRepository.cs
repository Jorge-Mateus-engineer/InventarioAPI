using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Bodegas
{
    public class BodegasRepository : IBodegasRepository
    {
        private readonly InventarioContext _context;

        public BodegasRepository(InventarioContext context)
        {
            _context = context;
        }

        public void DeleteByID(int id)
        {
            BodegaEntity bodega = _context.Bodegas.Find(id);
            if (bodega != null)
            {
                _context.Bodegas.Remove(bodega);
                _context.SaveChanges();
            }
        }

        public List<BodegaEntity> GetAll()
        {
            return _context.Bodegas.ToList();
        }

        public BodegaEntity GetByID(int id)
        {
            return _context.Bodegas.Find(id);
        }

        public BodegaEntity GetByName(string name)
        {
            return _context.Bodegas.Where(b => b.nombre == name).Single();
        }

        public BodegaEntity Insert(BodegaEntity entity)
        {
            _context.Bodegas.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public BodegaEntity Update(BodegaEntity entity)
        {
            _context.Bodegas.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
