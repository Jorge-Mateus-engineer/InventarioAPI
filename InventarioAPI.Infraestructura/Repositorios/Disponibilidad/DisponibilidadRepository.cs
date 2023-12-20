using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Disponibilidad
{
    public class DisponibilidadRepository : IDisponibilidadRepository
    {
        private readonly InventarioContext _context;

        public DisponibilidadRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(DisponibilidadEntity entity)
        {
            _context.Disponibilidades.Remove(entity);
            _context.SaveChanges();
        }

        public List<DisponibilidadEntity> GetAll()
        {
            return _context.Disponibilidades.ToList();
        }

        public List<DisponibilidadEntity> GetByProductID(int productID)
        {
            return _context.Disponibilidades.Where(d => d.id_producto == productID).ToList();
        }

        public List<DisponibilidadEntity> GetByWharehouseID(int wharehouseID)
        {
            return _context.Disponibilidades.Where(d => d.id_bodega == wharehouseID).ToList();
        }

        public DisponibilidadEntity Insert(DisponibilidadEntity entity)
        {
            _context.Disponibilidades.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public DisponibilidadEntity Update(DisponibilidadEntity entity)
        {
            _context.Disponibilidades.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
