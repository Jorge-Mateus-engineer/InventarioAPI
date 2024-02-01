using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Proveedores;

namespace InventarioAPI.Dominio.Services.Proveedores
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedoresRepository _proveedoresRepository;
        private readonly IMapper _mapper;

        public ProveedorService(IProveedoresRepository proveedoresRepository, IMapper mapper)
        {
            _proveedoresRepository = proveedoresRepository;
            _mapper = mapper;
        }

        public void Delete(ProveedorContract contract)
        {
            _proveedoresRepository.Delete(_mapper.Map<ProveedorEntity>(contract));
        }

        public List<ProveedorContract> GetAll()
        {
            return _mapper.Map<List<ProveedorContract>>(_proveedoresRepository.GetAll());
        }

        public List<ProveedorContract> GetByCompany(string companyName)
        {
            return _mapper.Map<List<ProveedorContract>>(_proveedoresRepository.GetByCompany(companyName));
        }

        public ProveedorContract GetByEmail(string email)
        {
            return _mapper.Map<ProveedorContract>(_proveedoresRepository.GetByEmail(email));
        }

        public ProveedorContract GetById(int id)
        {
            return _mapper.Map<ProveedorContract>(_proveedoresRepository.GetById(id));
        }

        public ProveedorContract Insert(ProveedorContract contract)
        {
            ProveedorEntity proveedorEntity = _mapper.Map<ProveedorEntity>(contract);
            _proveedoresRepository.Insert(proveedorEntity);
            return _mapper.Map<ProveedorContract>(proveedorEntity);
        }

        public ProveedorContract Update(ProveedorContract contract)
        {
            ProveedorEntity proveedorEntity = _mapper.Map<ProveedorEntity>(contract);
            _proveedoresRepository.Update(proveedorEntity);
            return _mapper.Map<ProveedorContract>(proveedorEntity);
        }
    }
}
