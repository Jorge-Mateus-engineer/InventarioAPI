using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Categorias;

namespace InventarioAPI.Dominio.Services.Categorias
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriasRepository _categoriasRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriasRepository categoriasRepository, IMapper mapper)
        {
            _categoriasRepository = categoriasRepository;
            _mapper = mapper;
        }

        public void Delete(CategoriaContract entity)
        {
            CategoriaEntity categoria = _categoriasRepository.GetByName(entity.nombre.ToLower());
            if (categoria != null)
            {
                _categoriasRepository.Delete(categoria);
            }
        }

        public List<CategoriaContract> GetAll()
        {
            return _mapper.Map<List<CategoriaContract>>(_categoriasRepository.GetAll());
        }

        public CategoriaContract GetByName(string name)
        {
            return _mapper.Map<CategoriaContract>(_categoriasRepository.GetByName(name));
        }

        public CategoriaContract GetById(int id)
        {
            return _mapper.Map<CategoriaContract>(_categoriasRepository.GetById(id));
        }

        public CategoriaContract Insert(CategoriaContract entity)
        {
            throw new NotImplementedException();
        }

        public CategoriaContract Update(CategoriaContract entity)
        {
            throw new NotImplementedException();
        }
    }
}
