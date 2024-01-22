using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Comunes.Clases.Helpers.Encription;
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


        public (ClienteContract?, string, byte[]) FindByEmail(string email)
        {
            ClienteEntity cliente = _clienteRepository.GetByEmail(email);
            ClienteContract clienteResult = _mapper.Map<ClienteContract>(cliente);
            return (clienteResult, cliente.contrasena_encriptada, cliente.salt);

        }


        public ClienteContract GetById(int id)
        {
            return _mapper.Map<ClienteContract>(_clienteRepository.GetById(id));
        }

        public ClienteContract Insert(ClienteContract cliente)
        {
            ClienteEntity clienteEntity = _mapper.Map<ClienteEntity>(cliente);
            (string contraseñaEncriptada, byte[] salt) = Encriptador.EncryptPassword(cliente.contrasena);
            clienteEntity.contrasena_encriptada = contraseñaEncriptada;
            clienteEntity.salt = salt;
            clienteEntity = _clienteRepository.Insert(clienteEntity);

            return _mapper.Map<ClienteContract>(clienteEntity);
        }

        public ClienteContract Update(ClienteContract cliente)
        {
            ClienteEntity clienteEntity = _clienteRepository.GetById(cliente.id_cliente);
            if (clienteEntity != null)
            {
                clienteEntity = _clienteRepository.Update(_mapper.Map<ClienteEntity>(cliente));
            }
            return _mapper.Map<ClienteContract>(clienteEntity);
        }
    }
}
