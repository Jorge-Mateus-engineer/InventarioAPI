using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.DetalleCompras
{
    public interface IDetalleComprasService
    {
        List<DetalleCompraContract> GetAll();
        List<DetalleCompraContract> GetByPurchaseId(int purchaseId);
        DetalleCompraContract GetById(int id);
        DetalleCompraContract Insert(DetalleCompraContract contract);
        DetalleCompraContract Update(DetalleCompraContract contract);
        void Delete(DetalleCompraContract contract);
    }
}
