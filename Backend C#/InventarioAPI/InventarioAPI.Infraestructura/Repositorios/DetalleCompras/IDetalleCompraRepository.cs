using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.DetalleCompras
{
    public interface IDetalleCompraRepository
    {
        List<DetalleCompraEntity> GetAll();
        List<DetalleCompraEntity> GetByPurchaseId(int purchaseId);
        DetalleCompraEntity GetById(int id);
        DetalleCompraEntity Insert(DetalleCompraEntity entity);
        DetalleCompraEntity Update(DetalleCompraEntity entity);
        void Delete(DetalleCompraEntity entity);

    }
}
