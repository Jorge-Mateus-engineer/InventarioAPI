using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Clientes;

namespace InventarioAPI.Dominio.Services.Clientes
{
    public class ClientesService : IClientesService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public void Delete(ClienteContract contract)
        {
            _clienteRepository.Delete(_mapper.Map<ClienteEntity>(contract));
        }

        public List<ClienteContract> GetAll()
        {
            return _mapper.Map<List<ClienteContract>>(_clienteRepository.GetAll());
        }

        public ClienteContract GetByEmail(string email)
        {
            return _mapper.Map<ClienteContract>(_clienteRepository.GetByEmail(email));
        }

        public ClienteContract GetById(int id)
        {
            return _mapper.Map<ClienteContract>(_clienteRepository.GetById(id));
        }

        public ClienteContract Insert(ClienteContract contract)
        {
            ClienteEntity cliente = _mapper.Map<ClienteEntity>(contract);
            _clienteRepository.Insert(cliente);
            return _mapper.Map<ClienteContract>(cliente);
        }

        public ClienteContract Update(ClienteContract contract)
        {
            ClienteEntity cliente = _mapper.Map<ClienteEntity>(contract);
            _clienteRepository.Update(cliente);
            return _mapper.Map<ClienteContract>(cliente);
        }
    }
}
