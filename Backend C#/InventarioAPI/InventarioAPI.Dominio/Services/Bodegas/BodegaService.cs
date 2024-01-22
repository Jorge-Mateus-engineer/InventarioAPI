using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Bodegas;

namespace InventarioAPI.Dominio.Services.Bodegas
{
    public class BodegaService : IBodegaService
    {
        private readonly IBodegasRepository _bodegaRepository;
        private readonly IMapper _mapper;

        public BodegaService(IBodegasRepository bodegasRepository, IMapper mapper)
        {
            _bodegaRepository = bodegasRepository;
            _mapper = mapper;
        }

        public void DeleteByID(int id)
        {
            BodegaEntity bodega = _bodegaRepository.GetByID(id);
            if (bodega != null)
            {
                _bodegaRepository.DeleteByID(id);
            }
        }

        public List<BodegaContract> GetAll()
        {
            return _mapper.Map<List<BodegaContract>>(_bodegaRepository.GetAll());
        }

        public BodegaContract GetByID(int id)
        {
            return _mapper.Map<BodegaContract>(_bodegaRepository.GetByID(id));
        }

        public BodegaContract GetByName(string name)
        {
            return _mapper.Map<BodegaContract>(_bodegaRepository.GetByName(name));
        }

        public BodegaContract Insert(BodegaContract contract)
        {
            BodegaEntity bodegaInsertada = _mapper.Map<BodegaEntity>(contract);
            _bodegaRepository.Insert(bodegaInsertada);
            return _mapper.Map<BodegaContract>(bodegaInsertada);
        }

        public BodegaContract Update(BodegaContract contract)
        {
            BodegaEntity bodegaActualizada = _mapper.Map<BodegaEntity>(contract);
            _bodegaRepository.Update(bodegaActualizada);
            return _mapper.Map<BodegaContract>(bodegaActualizada);
        }
    }
}
