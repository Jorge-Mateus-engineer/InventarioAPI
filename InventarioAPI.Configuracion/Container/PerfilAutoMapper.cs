using AutoMapper;
using InventarioAPI.Comunes.Clases.Contratos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Configuracion.Container
{
    public class PerfilAutoMapper : Profile
    {
        public PerfilAutoMapper()
        {
            CreateMap<CategoriaEntity, CategoriaContract>().ReverseMap();
            CreateMap<BodegaEntity, BodegaContract>().ReverseMap();
            CreateMap<ProveedorEntity, ProveedorContract>().ReverseMap();
            CreateMap<ProductoEntity, ProductoContract>().ReverseMap();
            CreateMap<DisponibilidadEntity, DisponibilidadContract>().ReverseMap();
            CreateMap<DetalleCompraEntity, DetalleCompraContract>().ReverseMap();
            CreateMap<CompraEntity, CompraContract>().ReverseMap();
            CreateMap<ClienteEntity, ClienteContract>().ReverseMap();
        }
    }
}