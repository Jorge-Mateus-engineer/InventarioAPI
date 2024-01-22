using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Compras;

namespace InventarioAPI.Dominio.Services.Compras
{
    public class ComprasService : IComprasService
    {
        private readonly IComprasRepository _comprasRepository;
        private readonly IMapper _mapper;

        public ComprasService(IComprasRepository comprasRepository, IMapper mapper)
        {
            _comprasRepository = comprasRepository;
            _mapper = mapper;
        }

        public void Delete(CompraContract contract)
        {
            CompraEntity compra = _mapper.Map<CompraEntity>(_comprasRepository.GetByClientId(contract.id_cliente));
            if (compra != null)
            {
                _comprasRepository.Delete(compra);
            }
        }

        public List<CompraContract> GetAll()
        {
            return _mapper.Map<List<CompraContract>>(_comprasRepository.GetAll());
        }

        public List<CompraContract> GetByClientId(int id)
        {
            return _mapper.Map<List<CompraContract>>(_comprasRepository.GetByClientId(id));
        }

        public CompraContract GetById(int id)
        {
            return _mapper.Map<CompraContract>(_comprasRepository.GetById(id));
        }

        public CompraContract Insert(CompraContract contract)
        {
            CompraEntity compra = _mapper.Map<CompraEntity>(contract);
            _comprasRepository.Insert(compra);
            return _mapper.Map<CompraContract>(compra);
        }

        public CompraContract Update(CompraContract contract)
        {
            CompraEntity compra = _mapper.Map<CompraEntity>(contract);
            _comprasRepository.Update(compra);
            return _mapper.Map<CompraContract>(compra);
        }
    }
}
