using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.DetalleCompras;

namespace InventarioAPI.Dominio.Services.DetalleCompras
{
    public class DetalleComprasService : IDetalleComprasService
    {
        private readonly IDetalleCompraRepository _detalleCompraRepository;
        private readonly IMapper _mapper;

        public DetalleComprasService(IDetalleCompraRepository detalleCompraRepository, IMapper mapper)
        {
            _detalleCompraRepository = detalleCompraRepository;
            _mapper = mapper;
        }

        public void Delete(DetalleCompraContract contract)
        {
            _detalleCompraRepository.Delete(_mapper.Map<DetalleCompraEntity>(contract));
        }

        public List<DetalleCompraContract> GetAll()
        {
            return _mapper.Map<List<DetalleCompraContract>>(_detalleCompraRepository.GetAll());
        }

        public List<DetalleCompraContract> GetByPurchaseId(int purchaseId)
        {
            return _mapper.Map<List<DetalleCompraContract>>(_detalleCompraRepository.GetByPurchaseId(purchaseId));
        }

        public DetalleCompraContract Insert(DetalleCompraContract contract)
        {
            DetalleCompraEntity detalle = _mapper.Map<DetalleCompraEntity>(contract);
            _detalleCompraRepository.Insert(detalle);
            return _mapper.Map<DetalleCompraContract>(detalle);
        }

        public DetalleCompraContract Update(DetalleCompraContract contract)
        {
            DetalleCompraEntity detalle = _mapper.Map<DetalleCompraEntity>(contract);
            _detalleCompraRepository.Update(detalle);
            return _mapper.Map<DetalleCompraContract>(detalle);
        }
    }
}
