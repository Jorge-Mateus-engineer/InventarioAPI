using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.DetalleCompras
{
    public class DetalleCompraRepository : IDetalleCompraRepository
    {
        private readonly InventarioContext _context;

        public DetalleCompraRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(DetalleCompraEntity entity)
        {
            _context.DetalleCompras.Remove(entity);
            _context.SaveChanges();
        }

        public List<DetalleCompraEntity> GetAll()
        {
            return _context.DetalleCompras.ToList();
        }

        public List<DetalleCompraEntity> GetByPurchaseId(int purchaseId)
        {
            return _context.DetalleCompras.Where(d => d.id_compra == purchaseId).ToList();
        }

        public DetalleCompraEntity GetById(int id)
        {
            return _context.DetalleCompras.Where(d => d.id_detalle_compra == id).FirstOrDefault();
        }

        public DetalleCompraEntity Insert(DetalleCompraEntity entity)
        {
            _context.DetalleCompras.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public DetalleCompraEntity Update(DetalleCompraEntity entity)
        {
            _context.DetalleCompras.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
