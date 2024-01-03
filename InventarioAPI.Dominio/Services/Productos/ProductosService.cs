using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;
using InventarioAPI.Infraestructura.Repositorios.Productos;

namespace InventarioAPI.Dominio.Services.Productos
{
    public class ProductosService : IProductosService
    {
        private readonly IProductosRepository _productosRepository;
        private readonly IMapper _mapper;

        public ProductosService(IProductosRepository productosRepository, IMapper mapper)
        {
            _productosRepository = productosRepository;
            _mapper = mapper;
        }

        public void Delete(ProductoContract contract)
        {
            _productosRepository.Delete(_mapper.Map<ProductoEntity>(contract));
        }

        public List<ProductoContract> GetAll()
        {
            return _mapper.Map<List<ProductoContract>>(_productosRepository.GetAll());
        }

        public List<ProductoContract> GetByCategory(int categoryID)
        {
            return _mapper.Map<List<ProductoContract>>(_productosRepository.GetByCategory(categoryID));
        }

        public ProductoContract GetById(int id)
        {
            return _mapper.Map<ProductoContract>(_productosRepository.GetById(id));
        }

        public ProductoContract GetByName(string name)
        {
            return _mapper.Map<ProductoContract>(_productosRepository.GetByName(name));
        }

        public List<ProductoContract> GetByProviderID(int providerID)
        {
            return _mapper.Map<List<ProductoContract>>(_productosRepository.GetByProviderID(providerID));
        }

        public ProductoContract Insert(ProductoContract contract)
        {
            ProductoEntity producto = _mapper.Map<ProductoEntity>(contract);
            _productosRepository.Insert(producto);
            return _mapper.Map<ProductoContract>(producto);
        }

        public ProductoContract Update(ProductoContract contract)
        {
            ProductoEntity producto = _mapper.Map<ProductoEntity>(contract);
            _productosRepository.Update(producto);
            return _mapper.Map<ProductoContract>(producto);
        }
    }
}
