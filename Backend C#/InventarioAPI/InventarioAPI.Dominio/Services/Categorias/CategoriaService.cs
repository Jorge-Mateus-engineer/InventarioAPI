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
            CategoriaEntity categoriaToDelete = _categoriasRepository.GetById(entity.id_categoria);
            if (categoriaToDelete != null)
            {
                _categoriasRepository.Delete(categoriaToDelete);
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

        public CategoriaContract Insert(CategoriaContract contract)
        {
            CategoriaEntity categoriaEntity = _mapper.Map<CategoriaEntity>(contract);
            _categoriasRepository.Insert(categoriaEntity);
            return contract;
        }

        public CategoriaContract Update(CategoriaContract contract)
        {
            CategoriaEntity categoriaEntity = _mapper.Map<CategoriaEntity>(contract);
            _categoriasRepository.Update(categoriaEntity);
            return contract;
        }
    }
}
