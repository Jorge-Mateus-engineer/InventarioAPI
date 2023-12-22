using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Disponibilidad;

namespace InventarioAPI.Dominio.Services.Disponibilidad
{
    public class DisponibilidadService : IDisponibilidadService
    {
        private readonly IDisponibilidadRepository _disponibilidadRepository;
        private readonly IMapper _mapper;

        public DisponibilidadService(IDisponibilidadRepository disponibilidadRepository, IMapper mapper)

        {
            _mapper = mapper;
            _disponibilidadRepository = disponibilidadRepository;
        }

        public void Delete(DisponibilidadContract contract)
        {
            _disponibilidadRepository.Delete(_mapper.Map<DisponibilidadEntity>(contract));
        }

        public List<DisponibilidadContract> GetAll()
        {
            return _mapper.Map<List<DisponibilidadContract>>(_disponibilidadRepository.GetAll());
        }

        public List<DisponibilidadContract> GetByProductID(int productID)
        {
            return _mapper.Map<List<DisponibilidadContract>>(_disponibilidadRepository.GetByProductID(productID));
        }

        public List<DisponibilidadContract> GetByWharehouseID(int wharehouseID)
        {
            return _mapper.Map<List<DisponibilidadContract>>(_disponibilidadRepository.GetByWharehouseID(wharehouseID));
        }

        public DisponibilidadContract Insert(DisponibilidadContract contract)
        {
            DisponibilidadEntity disponibilidadEntity = _mapper.Map<DisponibilidadEntity>(contract);
            _disponibilidadRepository.Insert(disponibilidadEntity);
            return _mapper.Map<DisponibilidadContract>(disponibilidadEntity);
        }

        public DisponibilidadContract Update(DisponibilidadContract contract)
        {
            DisponibilidadEntity disponibilidadEntity = _mapper.Map<DisponibilidadEntity>(contract);
            _disponibilidadRepository.Update(disponibilidadEntity);
            return _mapper.Map<DisponibilidadContract>(disponibilidadEntity);
        }
    }
}
